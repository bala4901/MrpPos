Imports WeifenLuo.WinFormsUI
Imports System.Linq
Imports Npgsql
Imports System.IO
Imports OpenErp.Net
Imports CookComputing.XmlRpc
Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports Numeria.IO
Imports CrystalDecisions.Shared


Public Class PieceOperation
    Inherits DockContent



    Dim WithEvents Port As SerialPort = New SerialPort(My.Settings.Comport _
                                                   , My.Settings.baudrate _
                                                   , My.Settings.parity _
                                                   , My.Settings.databits _
                                                   , My.Settings.stopbits)

    Private Delegate Sub SetTextCallback(ByVal text As String)

#Region "New"
    Private _currentState As Integer = 0
    Private _nextState As Integer = 0
    Private _previousState As Integer = 0

    Private _lotNo As String = ""
    Private _printPrice As Boolean = False
    Private _printCase As Boolean = False
    Private _printSlogan As Boolean = False
    Private _printCasePrice As Boolean = False

    Private _printSize As Boolean = True  'TRUE = 6cm x 6cm, False = 10cm x 6cm

    Private _case_product_id As Integer = 0
    Private _pcs_per_case As Integer = 0

    Private _lotId As Integer = 0
    Private _orderId As Integer = 0

    Private _selectImage As Bitmap
    Private dtFormat As String = "dd MMM yyyy HH:mm:ss"


    Private piecePriceLabel As String = "^XA" _
    & "^MMT" _
    & "^PW398" _
    & "^LL0319" _
    & "^LS0" _
    & "^FT10,74^A0N,28,28^FH\^FD{0}^FS" _
    & "^FT11,38^A0N,28,28^FH\^FD{1}^FS" _
    & "^FT212,150^A0N,14,14^FH\^FDExp:^FS" _
    & "^FT12,178^A0N,14,14^FH\^FDSerial :^FS" _
    & "^FT257,99^A0N,14,14^FH\^FD{2}^FS" _
    & "^FT204,100^A0N,14,14^FH\^FDU. Price:^FS" _
    & "^FT203,124^A0N,14,14^FH\^FDLot #:^FS" _
    & "^FT18,136^A0N,14,14^FH\^FD@Rp. ^FS" _
    & "^FT17,106^A0N,14,14^FH\^FDWeight:^FS" _
    & "^FT238,152^A0N,20,19^FH\^FD{3}^FS" _
    & "^FT58,179^A0N,20,19^FH\^FD{4}^FS" _
    & "^FT239,125^A0N,20,19^FH\^FD{5}^FS" _
    & "^FT56,149^A0N,28,28^FH\^FD{6}^FS" _
    & "^FT71,109^A0N,28,28^FH\^FD{7}^FS" _
    & "^FT157,184^A0N,28,28^FH\^FD{8}^FS" _
    & "^BY2,3,82^FT11,277^BCN,,Y,N" _
    & "^FD>;{9}^FS" _
    & "^PQ1,0,1,Y^XZ" 'Line1, Line2, unit_price, exp, serial, lot,price, weigh,ean_code, barcode

    Private pieceLabel As String = "^XA" _
                    & "^MMT" _
                    & "^PW398" _
                    & "^LL0319" _
                    & "^LS0" _
                    & "^FT10,74^A0N,28,28^FH\^FD{0}^FS" _
                    & "^FT10,38^A0N,28,28^FH\^FD{1}^FS" _
                    & "^FT209,108^A0N,14,14^FH\^FDExp:^FS" _
                    & "^FT19,145^A0N,14,14^FH\^FDSerial :^FS" _
                    & "^FT203,133^A0N,14,14^FH\^FDLot #:^FS" _
                    & "^FT17,115^A0N,14,14^FH\^FDWeight:^FS" _
                    & "^FT238,109^A0N,20,19^FH\^FD{2}^FS" _
                    & "^FT72,149^A0N,20,19^FH\^FD{3}^FS" _
                    & "^FT238,136^A0N,20,19^FH\^FD{4}^FS" _
                    & "^FT71,118^A0N,28,28^FH\^FD{5}^FS" _
                    & "^FT157,172^A0N,28,28^FH\^FD{6}^FS" _
                    & "^BY2,3,80^FT14,278^BCN,,Y,N" _
                    & "^FD>;{7}^FS" _
                    & "^PQ1,0,1,Y^XZ" 'line1, line2, exp, serial, lot, weight,ean_code, barcode

    Private csLabel As String = "^XA" _
                            & "^MMT" _
                            & "^PW398" _
                            & "^LL0319" _
                            & "^LS0" _
                            & "^FT5,70^A0N,28,28^FH\^FD{0}^FS" _
                            & "^FT4,34^A0N,28,28^FH\^FD{1}^FS" _
                            & "^FT221,127^A0N,14,14^FH\^FDSerial :^FS" _
                            & "^FT230,155^A0N,14,14^FH\^FDExp:^FS" _
                            & "^FT230,102^A0N,14,14^FH\^FDLot #:^FS" _
                            & "^FT71,156^A0N,28,28^FH\^FD{2}^FS" _
                            & "^FT265,131^A0N,20,19^FH\^FD{3}^FS" _
                            & "^FT18,110^A0N,14,14^FH\^FDWeight:^FS" _
                            & "^FT258,156^A0N,20,19^FH\^FD{4}^FS" _
                            & "^FT18,148^A0N,14,14^FH\^FDQty:^FS" _
                            & "^FT266,104^A0N,20,19^FH\^FD{5}^FS" _
                            & "^FT72,113^A0N,28,28^FH\^FD{6}^FS" _
                            & "^FT130,198^A0N,28,28^FH\^FD{7}^FS" _
                            & "^BY2,3,77^FT12,286^BCN,,Y,N" _
                            & "^FD>;{8}^FS" _
                            & "^PQ1,0,1,Y^XZ" 'Line1, Line2, qty, serial, exp, lot, weight, ean, barcode

    Private csPriceLabel As String = "^XA" _
                                    & "^MMT" _
                                    & "^PW398" _
                                    & "^LL0319" _
                                    & "^LS0" _
                                    & "^FT8,70^A0N,28,28^FH\^FD{0}^FS" _
                                    & "^FT7,35^A0N,28,28^FH\^FD{1}^FS" _
                                    & "^FT189,170^A0N,14,14^FH\^FDU. Price :^FS" _
                                    & "^FT203,136^A0N,14,14^FH\^FDExp:^FS" _
                                    & "^FT196,112^A0N,14,14^FH\^FDLot #:^FS" _
                                    & "^FT20,182^A0N,28,28^FH\^FDRp.{2}^FS" _
                                    & "^FT249,171^A0N,20,19^FH\^FDRp.{3}/kg^FS" _
                                    & "^FT8,216^A0N,14,14^FH\^FDQty:^FS" _
                                    & "^FT8,95^A0N,14,14^FH\^FDWeigh:^FS" _
                                    & "^FT231,138^A0N,20,19^FH\^FD{4}^FS" _
                                    & "^FT7,149^A0N,14,14^FH\^FDPrice^FS" _
                                    & "^FT33,216^A0N,23,24^FH\^FD{5}^FS" _
                                    & "^FT232,113^A0N,20,19^FH\^FD{6}^FS" _
                                    & "^FT25,128^A0N,28,28^FH\^FD{7}^FS" _
                                    & "^FT189,214^A0N,28,28^FH\^FD{8}^FS" _
                                    & "^BY2,3,55^FT11,284^BCN,,Y,N" _
                                    & "^FD>;{9}^FS" _
                                    & "^PQ1,0,1,Y^XZ" 'Line1, Line2, price, unit_price, exp, qty, lot, weight, ean, barcode

    Private csSummaryHeader As String = "^XA" _
                            & "^MMT" _
                            & "^PW398" _
                            & "^LL0319" _
                            & "^LS0" _
                            & "^FT25,290^A0N,23,24^FH\^FDPrint On:^FS" _
                            & "^FT25,245^A0N,34,33^FH\^FDPages: ^FS" _
                            & "^FT117,247^A0N,34,33^FH\^FD{0}^FS" _
                            & "^FT113,105^A0N,34,33^FH\^FD{1}^FS" _
                            & "^FT25,105^A0N,34,33^FH\^FDSerial: ^FS" _
                            & "^FT248,198^A0N,34,33^FH\^FD{2}^FS" _
                            & "^FT199,149^A0N,34,33^FH\^FD{3}^FS" _
                            & "^FT25,198^A0N,34,33^FH\^FDWeight:^FS" _
                            & "^FT25,150^A0N,34,33^FH\^FDPcs:^FS" _
                            & "^FT80,49^A0N,34,33^FH\^FDCASE SUMMARY^FS" _
                            & "^FT117,291^A0N,23,24^FH\^FD{4}^FS" _
                            & "^PQ1,0,1,Y^XZ" 'pages, serial, weight, pcs,print dt

    Private csSummaryDetails As String = "^XA" _
            & "^MMT" _
            & "^PW398" _
            & "^LL0319" _
            & "^LS0" _
            & "^FT324,303^A0N,17,16^FH\^FD{0} of {1}^FS" _
            & "^FT85,36^A0N,28,28^FH\^FD{2}^FS" _
            & "^FT7,36^A0N,28,28^FH\^FDCase: ^FS" _
            & "{3}" _
            & "^FT316,68^A0N,14,14^FH\^FDWeight^FS" _
            & "^FT113,68^A0N,14,14^FH\^FDWeight^FS" _
            & "^FT204,68^A0N,14,14^FH\^FDSerial^FS" _
            & "^FT17,68^A0N,14,14^FH\^FDSerial^FS" _
            & "^FO19,276^GB360,0,1^FS" _
            & "^FO14,48^GB359,0,1^FS" _
            & "^FO13,71^GB359,0,1^FS" _
            & "^FO194,47^GB0,230,1^FS" _
            & "{4}" _
            & "^PQ1,0,1,Y^XZ" 'pageno, totalpage, case_serial, details,end

    Private pcsSummary As String = "^XA" _
        & "^MMT" _
        & "^PW398" _
        & "^LL0319" _
        & "^LS0" _
        & "^FT324,303^A0N,17,16^FH\^FD{0} of {1}^FS" _
        & "^FT85,36^A0N,28,28^FH\^FD{2}^FS" _
        & "^FT7,36^A0N,28,28^FH\^FDOrder: ^FS" _
        & "{3}" _
        & "^FT316,68^A0N,14,14^FH\^FDWeight^FS" _
        & "^FT113,68^A0N,14,14^FH\^FDWeight^FS" _
        & "^FT204,68^A0N,14,14^FH\^FDSerial^FS" _
        & "^FT17,68^A0N,14,14^FH\^FDSerial^FS" _
        & "^FO19,276^GB360,0,1^FS" _
        & "^FO14,48^GB359,0,1^FS" _
        & "^FO13,71^GB359,0,1^FS" _
        & "^FO194,47^GB0,230,1^FS" _
        & "{4}" _
        & "^PQ1,0,1,Y^XZ" 'pageno, totalpage, case_serial, details,end

    Private csSummary As String = "^XA" _
                                    & "^MMT" _
                                    & "^PW398" _
                                    & "^LL0319" _
                                    & "^LS0" _
                                    & "^FT324,300^A0N,17,16^FH\^FD{0} of {1}^FS" _
                                    & "^FT7,36^A0N,28,28^FH\^FDCase Summary^FS" _
                                    & "^FT305,67^A0N,14,14^FH\^FDWeight^FS" _
                                    & "^FT212,67^A0N,14,14^FH\^FDPcs^FS" _
                                    & "^FT75,67^A0N,14,14^FH\^FDCase^FS" _
                                    & "{2}" _
                                    & "^FO19,276^GB360,0,1^FS" _
                                    & "^FO14,48^GB359,0,1^FS" _
                                    & "^FO271,47^GB0,230,1^FS" _
                                    & "^FO13,71^GB359,0,1^FS" _
                                    & "^FO176,47^GB0,230,1^FS" _
                                    & "{3}" _
                                    & "^PQ1,0,1,Y^XZ" 'page, no page, details, end

    Private pieceSummary As String = "^XA" _
        & "^MMT" _
        & "^PW398" _
        & "^LL0319" _
        & "^LS0" _
        & "^FT324,303^A0N,17,16^FH\^FD{0} of {1}^FS" _
        & "^FT7,36^A0N,28,28^FH\^FDPiece Summary: ^FS" _
        & "{3}" _
        & "^FT316,68^A0N,14,14^FH\^FDWeight^FS" _
        & "^FT113,68^A0N,14,14^FH\^FDWeight^FS" _
        & "^FT204,68^A0N,14,14^FH\^FDSerial^FS" _
        & "^FT17,68^A0N,14,14^FH\^FDSerial^FS" _
        & "^FO19,276^GB360,0,1^FS" _
        & "^FO14,48^GB359,0,1^FS" _
        & "^FO13,71^GB359,0,1^FS" _
        & "^FO194,47^GB0,230,1^FS" _
        & "{4}" _
        & "^PQ1,0,1,Y^XZ" 'pageno, totalpage,  details,end

    Private operationSummaryLabel As String = "^XA" _
                                                & "^MMT" _
                                                & "^PW398" _
                                                & "^LL0319" _
                                                & "^LS0" _
                                                & "^FT91,35^A0N,28,28^FH\^FDOperation Summary^FS" _
                                                & "^FT10,116^A0N,28,28^FH\^FD{0}^FS" _
                                                & "^FT10,82^A0N,28,28^FH\^FD{1}^FS" _
                                                & "^FT21,158^A0N,14,14^FH\^FDCode:^FS" _
                                                & "^FT59,158^A0N,20,19^FH\^FD{2}^FS" _
                                                & "^FT21,186^A0N,14,14^FH\^FDLot #:^FS" _
                                                & "^FT58,186^A0N,20,19^FH\^FD{3}^FS" _
                                                & "^FT21,216^A0N,14,14^FH\^FDExp:^FS" _
                                                & "^FT56,216^A0N,20,19^FH\^FD{4}^FS" _
                                                & "^FT21,242^A0N,14,14^FH\^FDEan:^FS" _
                                                & "^FT55,242^A0N,20,19^FH\^FD{5}^FS" _
                                                & "^FT214,175^A0N,14,14^FH\^FDWeight:^FS" _
                                                & "^FT261,172^A0N,28,28^FH\^FD{6}^FS" _
                                                & "^FT214,207^A0N,14,14^FH\^FDPcs:^FS" _
                                                & "^FT261,215^A0N,28,28^FH\^FD{7}^FS" _
                                                & "^FT214,243^A0N,14,14^FH\^FDCase:^FS" _
                                                & "^FT261,251^A0N,28,28^FH\^FD{8}^FS" _
                                                & "^FT226,305^A0N,11,12^FH\^FDPrint On:^FS" _
                                                & "^FT272,305^A0N,11,12^FH\^FD{9}^FS" _
                                                & "^FO4,47^GB393,0,3^FS" _
                                                & "^PQ1,0,1,Y^XZ" 'Line1, line2, code, lot,exp,ean, weight, pcs, case, print_on

#End Region



    Dim ll As New Dictionary(Of String, String)



#Region "Common"
    Private Sub clearLot()
        _lotNo = ""
        _case_product_id = 0
        _printCase = False
        _printPrice = False

    End Sub

    Private Sub cleanUp()
        _lotNo = ""
        _case_product_id = 0
        _printCase = False
        _printPrice = False
        _orderId = 0
        _lotId = 0
        dgvScanning.DataSource = DBNull.Value
        dgBoxLine.DataSource = DBNull.Value
        dgCaseData.DataSource = DBNull.Value
        RichTextBox1.Clear()
        txtLotNo.Text = vbEmpty
        pctWeightImage.Image = My.Resources.placeholder
        'dgvScanning.Rows.Clear()
        'dgBoxLine.Rows.Clear()
        'dgCaseData.Rows.Clear()



    End Sub

    Private Sub refreshOrderLineGrid()
        Using db As New MrpPosEntities

            If _orderId > 0 Then
                Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                                                              On ol.product_id Equals pp.id
                                                               Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                               Where ol.box_id = 0 And ol.order_id = _orderId
                                                               Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                                .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no}) _
                                                                    .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, _
                                                                       .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
                                                                                                                                .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
                                                                                                                                .eanCodeFont = setEAN13Code(x.eanCodeFont), .no = 0, .check = False, .serial_no = x.serial_no})

                If lines.ToList.Count > 0 Then

                    Dim rowNo As Integer = 1
                    Dim lst As New List(Of mrp_order_line)
                    For Each ol As mrp_order_line In lines.ToList
                        ol.no = rowNo
                        rowNo += 1
                        lst.Add(ol)
                    Next
                    dgvScanning.DataSource = lst
                    dgvScanning.Refresh()
                Else
                    dgvScanning.DataSource = DBNull.Value
                    dgvScanning.Refresh()
                End If
            End If

        End Using

    End Sub



    Private Sub refreshBoxListGrid()
        Using db As New MrpPosEntities
            If _orderId > 0 Then
                Dim lines As IEnumerable(Of mrp_order_case) = From p In db.mrp_order_case Where p.order_id = _orderId

                Dim lst As New List(Of mrp_order_case)
                Dim rowCnt As Integer = 1
                For Each cas As mrp_order_case In lines.ToList
                    cas.no = rowCnt
                    rowCnt += 1
                    lst.Add(cas)
                Next

                dgCaseData.DataSource = lst
                dgCaseData.Refresh()
            End If
        End Using
    End Sub

    Private Sub setSummary()

        RichTextBox1.Clear()

        Dim ol As mrp_order_line = getSummaryOrder()
        If Not ol Is Nothing Then
            Dim font As New Font("Tahoma", 16, FontStyle.Bold)
            RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            RichTextBox1.SelectionFont = font
            RichTextBox1.SelectedText = ol.line1 & vbNewLine & ol.line2 & vbNewLine



            Dim font2 As New Font("Tahoma", 14, FontStyle.Bold)
            RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
            RichTextBox1.SelectionFont = font2
            RichTextBox1.SelectedText = vbNewLine & "Code : " & ol.code & vbNewLine & "Lot No : " & ol.lot_no & vbNewLine


            RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
            RichTextBox1.SelectionFont = font2
            RichTextBox1.SelectedText = "No of Cases : " & ol.no_of_box & vbNewLine & "No of Pcs : " & ol.no_of_pcs & vbNewLine & "Total Weight : " & ol.total_weight & IIf(ol.qty > 0, " Kg", " g") & vbNewLine
        End If

    End Sub

    Private Function getSummaryOrder() As mrp_order_line
        Using db As New MrpPosEntities


            Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                                                                 On ol.product_id Equals pp.id
                                                                  Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                                  Where ol.order_id = _orderId
                                                                  Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                   .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                                   .exp_date = lot.expired_date, .eanCodeFont = pp.ean13}) _
                                                                       .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, _
                                                                          .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
                                                                                                                                   .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
                                                                                                                         .eanCodeFont = setEAN13Code(x.eanCodeFont), .no = 0, .check = False})
            Dim no_of_box As Integer = (From b In db.mrp_order_case Where b.order_id = _orderId Select b).Count

            If lines.ToList.Count > 0 Then

                Dim cnt As Integer = 0
                Dim totalPrice As Integer = 0
                Dim no_of_pcs As Integer = 0
                For Each ol As mrp_order_line In lines.ToList
                    cnt += ol.qty
                    totalPrice += ol.price
                    no_of_pcs += 1
                Next
                Dim lst As mrp_order_line = lines.ToList()(0)
                If cnt > 999 Then
                    cnt = cnt / 1000
                    lst.qty = 1
                Else
                    lst.qty = 0
                End If
                lst.total_weight = cnt
                lst.no_of_pcs = no_of_pcs
                lst.total_price = totalPrice
                lst.no_of_box = no_of_box
                Return lst
            Else
                Return Nothing

            End If
        End Using
    End Function
#End Region


#Region "Innitalize"

    Private Sub PieceOperation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure want to Exit from weighting?", MsgBoxStyle.OkCancel, "Information") = MsgBoxResult.Ok Then
            If Port.IsOpen Then Port.Close()


        End If
    End Sub
    Private Sub PieceOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Port.IsOpen Then Port.Close()
        tbWeight.Text = "000"
        initialize()
    End Sub

    Private Sub initialize()
        pctWeightImage.Image = My.Resources.placeholder
        Call setTouchImage()
        Call loadImages()
        Call displayImage()
    End Sub

    Private Sub setTouchImage()
        _currentState = 1
        pnlImageScan.Visible = False
        btnWeight.Enabled = False
        btnValidateWeight.Enabled = False
    End Sub

    Private Sub setLotNoView()

        Using db As New MrpPosEntities
            Dim orders As IEnumerable(Of mrp_order) = From pp In db.mrp_order Where pp.state = "Working" And pp.product_id = _product.id Select pp
            If orders.ToList.Count > 0 Then
                _orderId = orders(0).id
                _lotId = orders(0).lot_id
                If orders(0).printPrice = 1 Then
                    _printPrice = True
                End If
                If orders(0).printCase = 1 Then
                    _printCase = True
                End If
                If orders(0).printSlogan = 1 Then
                    _printSlogan = True
                End If
                If orders(0).caseprice = 1 Then
                    _printCasePrice = True
                End If
                _case_product_id = orders(0).case_product_id
                _pcs_per_case = orders(0).pcs_per_case
            End If

            If _orderId > 0 Then
                Call setWeighting()
                Return
            End If

        End Using

        btnReprint.Visible = False
        btnCasePrint.Visible = False
        btnDelete.Visible = False
        btnBack.Visible = True
        btnNext.Visible = True
        btnDelete.Visible = False
        btnConfirm.Visible = False

        _currentState = 2
        _nextState = 3
        _previousState = 1

        pnlImageScan.Visible = True
        pnlLotNo.Visible = True
        pnlOrder.Visible = False

        txtLotNo.Text = IIf(_lotNo.Length <= 0, "", _lotNo)
        cbCasePack.Text = IIf(_printCase, "By Case", "By Pcs")
        cbPrice.Text = IIf(_printPrice, "Yes", "No")
        cbCasePrice.Text = IIf(_printCasePrice, "Yes", "No")
        cbSize.Text = IIf(_printSize, "6cm x 6cm", "10cm x 6cm")
        cbSlogan.Text = "Yes"

    End Sub

    Private Sub setWeighting()
        Using db As New MrpPosEntities
            If txtLotNo.Text.Length > 0 Then
                'Dim lots As Integer = (From l In db.mrp_prod_lot Where l.name = txtLotNo.Text).Count

                'If lots > 0 Then
                '    MsgBox("This lot has been used before. Please enter a new one!", MsgBoxStyle.Exclamation, "Lot No")
                '    Call setLotNoView()
                '    Return
                'End If
            Else
                If _orderId <= 0 Then
                    MsgBox("Must Enter Lot No!", MsgBoxStyle.Exclamation, "Lot No")
                    Call setLotNoView()
                    Return
                End If
            End If
        End Using
        btnReprint.Visible = True
        btnCasePrint.Visible = True
        btnDelete.Visible = False
        btnBack.Visible = False
        btnNext.Visible = False
        btnDelete.Visible = True
        btnConfirm.Visible = True



        _currentState = 3

        _previousState = 2

        pnlImageScan.Visible = True
        pnlLotNo.Visible = True
        pnlOrder.Visible = True

        btnWeight.Enabled = True
        btnValidateWeight.Enabled = True



        If _orderId <= 0 Then
            _lotNo = txtLotNo.Text
            _printCase = IIf(cbCasePack.Text = "By Case", True, False)
            _printPrice = IIf(cbPrice.Text = "Yes", True, False)
            _printSlogan = IIf(cbSlogan.Text = "Yes", True, False)
            _printCasePrice = IIf(cbCasePrice.Text = "Yes", True, False)
            _printSize = IIf(cbSize.Text = "6cm x 6cm", True, False)

      


            If cbProductCode.Visible Then
                _case_product_id = cbProductCode.SelectedValue
                Try
                    _pcs_per_case = tbQtyPerCase.Text

                Catch ex As Exception
                    _pcs_per_case = 0
                    _case_product_id = 0
                    _printCase = False
                End Try
            End If
        End If

        pctWeightImage.Image = _selectImage
        Call refreshOrderLineGrid()
        Call refreshBoxListGrid()
        Call setSummary()

    End Sub
#End Region

#Region "Private"
    Private Sub loadImages()
        Using db As New MrpPosEntities
            Dim query As IEnumerable(Of product_product) = From p In db.product_product Where p.is_case_product = False Order By p.name Select p
            Dim imgList As New ImageList

            If query.ToList.Count <= 0 Then
                MsgBox("No Products Found")
                Return
            End If

            For Each prd As product_product In query.ToList
                If Not prd.image Is Nothing Then
                    If prd.image.Length > 0 Then
                        Dim mStream As New MemoryStream
                        Dim info = FileDB.Read(getFileDbPath, Guid.Parse(prd.image), mStream)
                        imgList.Images.Add(prd.id, System.Drawing.Image.FromStream(mStream))
                    End If
                Else
                    imgList.Images.Add(prd.id, My.Resources.placeholder)
                End If

            Next
            sharedProducts = query.ToList
            imgList.ImageSize = New Size(117, 109)
            shareImageList = imgList

            lvProductImage.LargeImageList = shareImageList

        End Using

    End Sub

    Private Sub displayImage()

        lvProductImage.Items.Clear()
        Dim itm As New ListViewItem

        For Each prod As product_product In sharedProducts
            itm = lvProductImage.Items.Add("[" & prod.code & "]" & vbNewLine & prod.name & vbNewLine & prod.name2)
            itm.ImageKey = prod.id
            itm.Name = prod.id
        Next
    End Sub

    Private Sub loadProductCaseIntoCbBox(ByVal stockList As List(Of product_product))
        Try

            cbProductCode.DataSource = stockList
            cbProductCode.ValueMember = "id"
            cbProductCode.DisplayMember = "code"


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region


#Region "Port Method"

    Private Sub port_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Port.DataReceived
        Dim reading As String = ""
        Try
            reading = Port.ReadTo("ST0")

        Catch ex As Exception


        End Try

        Dim val As String = ""

        Try

            If reading.Contains("-") Then
                val = reading
                If val <> tbWeight.Text Then
                    tbWeight.BackColor = Color.Red
                    SetText(reading)
                End If
            Else

                val = Trim(reading).Replace(".", "")

                If tbWeight.Text <> val Then
                    tbWeight.BackColor = Color.FromKnownColor(KnownColor.Window)
                    Dim intVal As Integer = val
                    SetText(intVal)
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub SetText(ByVal text As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.tbWeight.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {text})
        Else
            Me.tbWeight.Text = text
        End If
    End Sub
#End Region

#Region "Weight View Method"

    Private Function createLot() As Integer

        Using db As New MrpPosEntities
            Dim rwCnt As Integer = (From p In db.mrp_prod_lot Select p).Count

            Dim lots As New mrp_prod_lot
            lots.create_date = Now
            lots.create_uid = loginUser.id
            lots.write_date = Now
            lots.write_uid = loginUser.id
            lots.name = _lotNo
            lots.day_to_expiry = _product.day_to_expire
            lots.expired_date = Now.AddDays(_product.day_to_expire)
            lots.manufacturing_date = Now

            If rwCnt > 0 Then
                lots.id = getNextId(db.mrp_prod_lot.Select(Function(x) x.id).Max)
            Else
                lots.id = 1
            End If

            db.mrp_prod_lot.AddObject(lots)
            db.SaveChanges()

            _lotId = lots.id

            Return lots.id
        End Using
    End Function

    Private Function createOrder() As Integer
        Using db As New MrpPosEntities
            Dim rwCnt As Integer = (From p In db.mrp_order Select p).Count

            Dim mrpOrder As New mrp_order
            If rwCnt > 0 Then
                mrpOrder.id = getNextId(db.mrp_order.Select(Function(x) x.id).Max)
            Else
                mrpOrder.id = 1
            End If
            mrpOrder.create_date = Now
            mrpOrder.create_uid = loginUser.id
            mrpOrder.write_date = Now
            mrpOrder.write_uid = loginUser.id
            mrpOrder.state = "Working"
            mrpOrder.lot_id = _lotId
            mrpOrder.name = Now.ToString("yyyyMMddHHmmss")
            mrpOrder.product_id = _product.id
            mrpOrder.date_order = Now
            mrpOrder.nb_print = 0
            mrpOrder.case_product_id = _case_product_id
            mrpOrder.pcs_per_case = _pcs_per_case
            mrpOrder.name = generateOrderSerialNo(mrpOrder.id)

            If _printCase Then
                mrpOrder.printCase = 1
            Else
                mrpOrder.printCase = 0
            End If

            If _printPrice Then
                mrpOrder.printPrice = 1
            Else
                mrpOrder.printPrice = 0
            End If

            If _printSlogan Then
                mrpOrder.printSlogan = 1
            Else
                mrpOrder.printSlogan = 0
            End If


            If _printCase Then
                mrpOrder.caseprice = 1
            Else
                mrpOrder.caseprice = 0
            End If



            db.mrp_order.AddObject(mrpOrder)
            db.SaveChanges()

            _orderId = mrpOrder.id
            Return mrpOrder.id
        End Using
    End Function

    Private Function createWeightOrderLine() As Integer
        Using db As New MrpPosEntities

            Dim rwCnt As Integer = (From p In db.mrp_order_line Select p).Count

            Dim line As New mrp_order_line
            line.create_date = Now
            line.create_uid = loginUser.id
            line.write_date = Now
            line.write_uid = loginUser.id
            line.order_id = _orderId
            line.prodlot_id = _lotId
            line.product_id = _product.id
            line.qty = tbWeight.Text
            line.box_id = 0
            If rwCnt > 0 Then
                line.id = getNextId(db.mrp_order_line.Select(Function(x) x.id).Max)
            Else
                line.id = 1
            End If
            line.serial_no = generateSerialNo(line.id)


            If _printPrice Then
                line.price = (tbWeight.Text / 1000) * _product.price_per_kg
            Else
                line.price = 0
            End If

            db.mrp_order_line.AddObject(line)
            db.SaveChanges()



            Return line.id
        End Using
    End Function

    Private Function createCaseOrder(ByVal no_pcs As Integer, ByVal ttlWeight As Integer, ByRef serial_no As String) As Integer
        Using db As New MrpPosEntities
            Dim rwCnt As Integer = (From p In db.mrp_order_case Select p).Count

            Dim cas As New mrp_order_case
            cas.create_date = Now
            cas.create_id = loginUser.id
            cas.write_date = Now
            cas.write_id = loginUser.id
            cas.order_id = _orderId
            cas.no_of_pcs = no_pcs
            cas.qty = ttlWeight

            If _case_product_id <= 0 Then
                cas.product_id = _product.id
            Else
                cas.product_id = _case_product_id
            End If

            If rwCnt > 0 Then
                cas.id = getNextId(db.mrp_order_case.Select(Function(x) x.id).Max)
            Else
                cas.id = 1
            End If
            cas.serial_no = generateCaseSerialNo(cas.id)

            db.mrp_order_case.AddObject(cas)
            db.SaveChanges()

            serial_no = cas.serial_no
            Return cas.id

        End Using
    End Function




#End Region

#Region "Printing"
    Private Sub printLabel(ByVal line As DataTable)
        Dim ct As Integer = line.Rows.Count
        Dim label As String = ""

        For i As Integer = 0 To ct - 1
            Dim line1 As String = line.Rows(i)("line1")
            Dim line2 As String = line.Rows(i)("line2")
            Dim unit_price As String = line.Rows(i)("unit_price")
            Dim exp_date As String = line.Rows(i)("exp_date")
            Dim ean_code As String = line.Rows(i)("eancode")
            Dim serial_no As String = line.Rows(i)("serial_no")
            Dim lot_no As String = line.Rows(i)("lot_no")
            Dim barcode As String = line.Rows(i)("barcode")
            Dim price As String = line.Rows(i)("price")
            Dim qty As Double = line.Rows(i)("qty")
            Dim qty_str As String

            If qty > 999 Then
                qty_str = String.Format("{0} Kg", (qty / 1000))
            Else
                qty_str = String.Format("{0} g", qty)
            End If
            If _printPrice Then
                'Line1, Line2, unit_price, exp, serial, lot,price, weigh,ean_code, barcode
                label = String.Format(piecePriceLabel, line1, line2, unit_price, exp_date,
                                      serial_no, lot_no, price, qty_str, ean_code, barcode)
            Else
                'line1, line2, exp, serial, lot, weight,ean_code, barcode
                label = String.Format(pieceLabel, line1, line2, exp_date, serial_no, lot_no, qty_str, ean_code, barcode)

            End If
        Next

        If label.Length > 0 Then
            Dim printer As New LinePrinter(My.Settings.printer)
            printer.WriteChars(label, True)
            printer.EndJob(True)
        End If

        'For Each r In line
        '    If _printPrice Then

        '        '0: Line1 1:Line2 2:price 3:unit price 4:exp date 5:weight 6:ean 7:barcode
        '    End If
        'Next

        'If _printSize Then
        '    If _printPrice Then
        '        Using cr As New PiecePriceLabelSmall_c
        '            Try
        '                cr.SetDataSource(line)
        '                cr.PrintToPrinter(1, False, 0, 0)
        '            Catch ex As Exception
        '                MsgBox(ex.ToString)
        '            End Try
        '        End Using

        '    Else
        '        Using cr As New PieceNoPriceLabelSmall_c
        '            Try
        '                cr.SetDataSource(line)
        '                cr.PrintToPrinter(1, False, 0, 0)
        '                cr.Close()
        '            Catch ex As Exception
        '                MsgBox(ex.ToString)
        '            End Try
        '        End Using
        '    End If
        'Else
        '    If Not _printPrice Then
        '        Using cr As New PieceLabel
        '            Try
        '                cr.SetDataSource(line)
        '                cr.PrintToPrinter(1, False, 0, 0)
        '                cr.Close()
        '            Catch ex As Exception
        '                MsgBox(ex.ToString)
        '            End Try
        '        End Using
        '    Else
        '        Using cr As New PiecePriceLabel
        '            Try
        '                cr.SetDataSource(line)
        '                cr.PrintToPrinter(1, False, 0, 0)
        '                cr.Close()

        '            Catch ex As Exception
        '                MsgBox(ex.ToString)
        '            End Try
        '        End Using
        '    End If
        'End If



    End Sub

    Private Sub printCaseLabel(Optional ByVal manual As Boolean = False)
        Dim print As Boolean = False
        Dim box_id As Integer = 0

        Using db As New MrpPosEntities
            Dim cntLine As Integer = (From ol In db.mrp_order_line Where ol.order_id = _orderId And ol.box_id = 0 Select ol).Count
            If _printCase Then
                If cntLine = _pcs_per_case Then
                    print = True
                Else
                    If manual Then
                        print = True
                    End If
                End If
            Else
                If manual Then
                    print = True
                End If
            End If

            If print And cntLine > 0 Then
                Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                                                              On ol.product_id Equals pp.id
                                                               Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                               Where ol.order_id = _orderId And ol.box_id = 0
                                                               Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                                .exp_date = lot.expired_date, .eanCodeFont = pp.ean13}) _
                                                                    .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, _
                                                                       .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy")})


                If lines.ToList.Count > 0 Then

                    Dim totalWeight As Integer = 0
                    Dim totalPrice As Integer = 0
                    Dim no_of_pcs As Integer = 0
                    For Each ol As mrp_order_line In lines.ToList
                        totalWeight += ol.qty
                        totalPrice += ol.price
                        no_of_pcs += 1
                    Next

                    Dim case_prod As product_product

                    If _case_product_id <= 0 Then
                        case_prod = (From pp In db.product_product Where pp.id = _product.id Select pp).SingleOrDefault
                    Else
                        case_prod = (From pp In db.product_product Where pp.id = _case_product_id Select pp).SingleOrDefault
                    End If


                    Dim case_serial_no As String = ""

                    box_id = createCaseOrder(no_of_pcs, totalWeight, case_serial_no)

                    Dim orderLine As IEnumerable(Of mrp_order_line) = From ol In db.mrp_order_line Where ol.order_id = _orderId And ol.box_id = 0 Select ol

                    For Each line As mrp_order_line In orderLine.ToList

                        Dim rwCnt As Integer = (From p In db.mrp_case_piece Select p).Count

                        Dim case_piece As New mrp_case_piece
                        case_piece.case_id = box_id
                        case_piece.line_id = line.id
                        case_piece.order_id = _orderId
                        case_piece.write_by = loginUser.id
                        case_piece.create_by = loginUser.id
                        case_piece.write_date = Now
                        case_piece.create_date = Now
                        case_piece.status = 1

                        If rwCnt > 0 Then
                            case_piece.id = getNextId(db.mrp_case_piece.Select(Function(x) x.id).Max)
                        Else
                            case_piece.id = 1
                        End If

                        db.mrp_case_piece.AddObject(case_piece)
                        db.SaveChanges()

                    Next

                    For Each line As mrp_order_line In orderLine.ToList
                        line.box_id = box_id
                        db.mrp_order_line.ApplyCurrentValues(line)
                    Next

                    Try
                        Dim ord As mrp_order_line = lines.ToList()(0)
                        Dim listOrderLine As New List(Of mrp_order_line)
                        Dim dt As DataTable = orderLine.ToADOTable()
                        Dim dt2 As New DataTable
                        dt2 = dt.Clone

                        Dim label As String = ""
                        Dim price_label As String = ""

                        For Each row As DataRow In dt.Rows

                            Dim barcode As String = case_serial_no & "." & ord.lot_no & "." & ord.exp_date & "." & totalWeight
                            Dim eancode As String = setEAN13CodeFont1(case_prod.ean13)
                            Dim ttl_weight_str As String = ""

                            If totalWeight > 999 Then
                                ttl_weight_str = String.Format("{0} Kg", (totalWeight / 1000))
                            Else
                                ttl_weight_str = String.Format("{0} g", totalWeight)
                            End If


                            'Line1, Line2, qty, serial, exp, lot, weight, ean, barcode
                            label = String.Format(csLabel, case_prod.name, case_prod.name2, no_of_pcs,
                                                  case_serial_no, ord.exp_date, ord.lot_no, ttl_weight_str,
                                                  eancode, barcode)

                            Dim price As Integer = (totalWeight / 1000) * _product.price_per_kg
                            'Line1, Line2, price, unit_price, exp, qty, lot, weight, ean, barcode
                            price_label = String.Format(csPriceLabel, case_prod.name, case_prod.name2, price,
                            _product.price_per_kg, ord.exp_date, no_of_pcs, ord.lot_no, ttl_weight_str, eancode, barcode)
                            'setEAN13CodeFont1(case_prod.ean13)
                            'row("code") = "Rp. " & _product.price_per_kg & "/Kg"
                            'row("line1") = case_prod.name
                            'row("line2") = case_prod.name2
                            'row("qty") = totalWeight
                            'row("unit_price") = no_of_pcs
                            'row("eancode") = setEAN13CodeFont1(case_prod.ean13)
                            'row("exp_date") = ord.exp_date
                            'row("lot_no") = ord.lot_no
                            'row("isPrintComp") = _printSlogan
                            'row("serial_no") = case_serial_no
                            'row("price") = (totalWeight / 1000) * _product.price_per_kg
                            'row("barcode") = "*" & case_serial_no & "." & ord.lot_no & "." & ord.exp_date & "." & totalWeight & "*"
                            'dt2.Rows.Add(row.ItemArray)
                            Exit For
                        Next
                        Dim printer As New LinePrinter(My.Settings.printer)
                        For i As Integer = 1 To case_prod.no_of_barcode
                            If _printCasePrice Then
                                printer.WriteChars(price_label, True)
                            Else
                                printer.WriteChars(label, True)
                            End If
                        Next
                        printer.EndJob(True)
                        db.SaveChanges()
                        'If _printCasePrice Then
                        '    Using crPrice As New CasePriceLabel
                        '        crPrice.SetDataSource(dt2)
                        '        For i As Integer = 1 To case_prod.no_of_barcode
                        '            crPrice.PrintToPrinter(1, False, 0, 0)
                        '        Next
                        '    End Using
                        'Else
                        '    Using cr As New CaseLabel
                        '        cr.SetDataSource(dt2)
                        '        For i As Integer = 1 To case_prod.no_of_barcode
                        '            cr.PrintToPrinter(1, False, 0, 0)
                        '        Next
                        '    End Using
                        'End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                End If

            End If

        End Using

        If box_id > 0 Then
            If MsgBox("Do you want print Case Summary?", MsgBoxStyle.YesNo, "Case Summary") = MsgBoxResult.Yes Then
                Using db As New MrpPosEntities
                    'Dim cr As New cSummary
                    Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join oc In db.mrp_order_case
                                                                         On ol.box_id Equals oc.id
                                                                          Where oc.id = box_id
                                                                          Select New With {.case_serial_no = oc.serial_no, .serial_no = ol.serial_no, .qty = ol.qty, .total_qty = oc.qty, .unit_price = oc.no_of_pcs}) _
                                                                               .AsEnumerable().Select(Function(x) New mrp_order_line With {.case_serial_no = x.case_serial_no, .serial_no = x.serial_no, .qty = x.qty, _
                                                                                                                                          .total_weight = x.total_qty, .unit_price = x.unit_price, .serial_no1 = "", .qty1 = ""})

                    Dim dt As DataTable = lines.ToADOTable

                    Dim rowsCnt As Integer = dt.Rows.Count
                    Dim noRecordsShow As Integer = 20
                    Dim pg As Integer = Math.Ceiling(rowsCnt / noRecordsShow)
                    Dim printdt As String = DateTime.Now.ToString(dtFormat)

                    'pages, serial, weight, pcs,print dt
                    Dim csHeaderLabel As String = ""
                    Dim printer1 As New LinePrinter(My.Settings.printer)

                    Dim no_recs As Integer = 1
                    Dim page As Integer = 1
                    Dim h As Integer = 93
                    Dim detail As String = ""
                    Dim r1 As String = "^FT14,{0}^A0N,14,14^FH\^FD{1}^FS^FT107,{0}^A0N,14,14^FH\^FD{2}^FS"
                    Dim r2 As String = "^FT202,{0}^A0N,14,14^FH\^FD{1}^FS^FT294,{0}^A0N,14,14^FH\^FD{2}^FS"
                    Dim rEnd As String = "^FT170,303^A0N,23,24^FH\^FDEND^FS"

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim case_serial As String = dt.Rows(i)("case_serial_no")
                        If i = 0 Then

                            Dim total_weight As Double = dt.Rows(i)("total_weight")
                            Dim total_pcs As Double = dt.Rows(i)("unit_price")
                            Dim total_weight_str As String = ""
                            If total_weight > 999 Then
                                total_weight_str = String.Format("{0} Kg", (total_weight / 1000))
                            Else
                                total_weight_str = String.Format("{0} g", total_weight)
                            End If
                            csHeaderLabel = String.Format(csSummaryHeader, pg, case_serial, total_weight_str, total_pcs, printdt)
                            printer1.WriteChars(csHeaderLabel, True)
                        End If

                        If no_recs > 18 Then

                            'pageno, totalpage, case_serial, details,end
                            Dim detailLabels As String = ""

                            If page = pg Then
                                detailLabels = String.Format(csSummaryDetails, page, pg, case_serial, detail, rEnd)
                            Else
                                detailLabels = String.Format(csSummaryDetails, page, pg, case_serial, detail, "")
                            End If
                            printer1.WriteChars(detailLabels, True)
                            page += 1
                            h = 93
                            no_recs = 1
                            detail = ""
                        End If

                        Dim serial As String = dt.Rows(i)("serial_no")
                        Dim qty As Double = dt.Rows(i)("qty")
                        Dim qty_str As String = ""
                        If qty > 999 Then
                            qty_str = String.Format("{0} Kg", (qty / 1000))
                        Else
                            qty_str = String.Format("{0} g", qty)
                        End If

                        If i Mod 2 = 0 Then
                            detail = detail & String.Format(r1, h, serial, qty_str)
                        Else
                            detail = detail & String.Format(r2, h, serial, qty_str)
                            h += 22
                        End If


                        If i = rowsCnt - 1 Then
                            Dim detailLabels As String = ""
                            If page = pg Then
                                detailLabels = String.Format(csSummaryDetails, page, pg, case_serial, detail, rEnd)
                            Else
                                detailLabels = String.Format(csSummaryDetails, page, pg, case_serial, detail, "")
                            End If
                            printer1.WriteChars(detailLabels, True)
                        End If
                        no_recs += 1
                    Next
                    printer1.EndJob(True)

                    'Dim tDt1 As New DataTable
                    'Dim tDt2 As New DataTable
                    'tDt1 = dt.Clone
                    'tDt2 = dt.Clone

                    'For i As Integer = 0 To dt.Rows.Count - 1
                    '    If i Mod 2 = 0 Then
                    '        tDt1.Rows.Add(dt.Rows(i).ItemArray)
                    '    End If
                    'Next

                    'For i As Integer = 0 To dt.Rows.Count - 1
                    '    If i Mod 2 <> 0 Then
                    '        tDt2.Rows.Add(dt.Rows(i).ItemArray)
                    '    End If
                    'Next

                    'Dim ct As Integer = tDt1.Rows.Count
                    'Dim ct1 As Integer = tDt2.Rows.Count

                    'For i As Integer = 0 To ct - 1
                    '    If ct1 > i Then
                    '        tDt1.Rows(i)("serial_no1") = tDt2.Rows(i)("serial_no")
                    '        tDt1.Rows(i)("qty1") = tDt2.Rows(i)("qty")
                    '    End If
                    'Next

                    'Try
                    '    cr.SetDataSource(tDt1)
                    '    cr.PrintToPrinter(1, False, 0, 0)
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try
                End Using
            End If
        End If


    End Sub

    Private Sub printCaseSummary(ByVal orderId As Integer)
        Using db As New MrpPosEntities
            'Dim cr As New cSummary

            Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join oc In db.mrp_order_case
                                                                On ol.box_id Equals oc.id
                                                                Join od In db.mrp_order On od.id Equals ol.order_id
                                                                 Where ol.order_id = orderId
                                                                 Select New With {.case_serial_no = oc.serial_no, .serial_no = ol.serial_no, .qty = ol.qty, .total_qty = oc.qty, .unit_price = oc.no_of_pcs, .ordername = od.name}) _
                                                                      .AsEnumerable().Select(Function(x) New mrp_order_line With {.case_serial_no = x.case_serial_no & "-" & x.ordername, .serial_no = x.serial_no, .qty = x.qty, _
                                                                                                                                  .total_weight = x.total_qty, .unit_price = x.unit_price, .serial_no1 = "", .qty1 = "", .line1 = x.ordername})

            If lines.ToList.Count <= 0 Then Return



            Dim case_serial_nos As New List(Of String)
            Dim case_lines As New List(Of mrp_order_case)

            Dim order_name As String = ""
            For Each k As mrp_order_line In lines.ToList
                If order_name.Length <= 0 Then
                    order_name = k.line1
                End If

                If Not case_serial_nos.Contains(k.case_serial_no) Then
                    Dim cs_order As New mrp_order_case
                    cs_order.qty = k.total_weight
                    cs_order.no_of_pcs = k.unit_price
                    cs_order.serial_no = k.case_serial_no
                    case_lines.Add(cs_order)
                    case_serial_nos.Add(cs_order.serial_no)
                Else
                    Continue For
                End If
            Next

            Dim r1 As String = "^FT14,{3}^A0N,14,14^FH\^FD{0}^FS" _
                            & "^FT218,{3}^A0N,14,14^FH\^FD{1}^FS" _
                            & "^FT308,{3}^A0N,14,14^FH\^FD{2}^FS" ' case_no, pcs, weight, h

            Dim rEnd As String = "^FT193,304^A0N,23,24^FH\^FDEND^FS"
            Dim printdt As String = DateTime.Now.ToString(dtFormat)
            Dim printer1 As New LinePrinter(My.Settings.printer)

            Dim rowsCnt As Integer = case_lines.Count
            Dim noRecordsShow As Integer = 9
            Dim pg As Integer = Math.Ceiling(rowsCnt / noRecordsShow)

            Dim rec_cnt As Integer = 1
            Dim page As Integer = 1
            Dim h As Integer = 93
            Dim detail As String = ""
            Dim i As Integer = 0

            For Each cs As mrp_order_case In case_lines
                If rec_cnt > noRecordsShow Then
                    'page, no page, details, end
                    Dim detailLabels As String = ""

                    If page = pg Then
                        detailLabels = String.Format(csSummary, page, pg, detail, rEnd)
                    Else
                        detailLabels = String.Format(csSummary, page, pg, detail, "")
                    End If

                    printer1.WriteChars(detailLabels, True)

                    page += 1
                    h = 93
                    rec_cnt = 1
                    detail = ""
                End If

                Dim qty As Double = cs.qty
                Dim qty_str As String = ""

                If qty > 999 Then
                    qty_str = String.Format("{0} Kg", (qty / 1000))
                Else
                    qty_str = String.Format("{0} g", qty)
                End If

                detail += String.Format(r1, cs.serial_no, cs.no_of_pcs, qty_str, h)
                h += 22

                If i = rowsCnt - 1 Then
                    Dim detailLabels As String = ""
                    If page = pg Then
                        'page, no page, details, end
                        detailLabels = String.Format(csSummary, page, pg, detail, rEnd)
                    Else
                        detailLabels = String.Format(csSummary, page, pg, detail, "")
                    End If
                    printer1.WriteChars(detailLabels, True)
                End If

                i += 1
                rec_cnt += 1
            Next

            printer1.EndJob(True)

        End Using
    End Sub

    Private Sub printPieceSummary(ByVal orderId As Integer)
        Using db As New MrpPosEntities
            'Dim cr As New cSummary
            Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line
                                                           Join od In db.mrp_order On od.id Equals ol.order_id
                                                           Where (ol.order_id = orderId And ol.box_id = 0)
                                                                  Select New With {.case_serial_no = od.name, .serial_no = ol.serial_no, .qty = ol.qty, .total_qty = 0, .unit_price = 0}) _
                                                                       .AsEnumerable().Select(Function(x) New mrp_order_line With {.case_serial_no = x.case_serial_no, .serial_no = x.serial_no, .qty = x.qty, _
                                                                                                                                   .total_weight = x.total_qty, .unit_price = x.unit_price, .serial_no1 = "", .qty1 = ""})

            Dim rowCnt As Integer = lines.ToList.Count
            If rowCnt <= 0 Then Return

            Dim sumQty As Integer
            For Each ol As mrp_order_line In lines.ToList
                sumQty += ol.qty
            Next

            If sumQty > 999 Then
                sumQty = sumQty / 1000
            End If



            Dim dt As DataTable = lines.ToADOTable

            For Each row As DataRow In dt.Rows
                row("total_weight") = sumQty
                row("unit_price") = rowCnt
            Next


            Dim case_serial_nos As New List(Of String)

            Dim initCase As String = ""

            For Each k As mrp_order_line In lines.ToList
                If case_serial_nos.Count <= 0 Then
                    case_serial_nos.Add(k.case_serial_no)
                Else
                    If Not case_serial_nos.Contains(k.case_serial_no) Then
                        case_serial_nos.Add(k.case_serial_no)
                    End If
                End If


            Next

            Dim tDt1 As New DataTable
            tDt1 = dt.Clone

            Dim printer1 As New LinePrinter(My.Settings.printer)
            Dim noRecordsShow As Integer = 20
            Dim printdt As String = DateTime.Now.ToString(dtFormat)
            Dim r1 As String = "^FT14,{0}^A0N,14,14^FH\^FD{1}^FS^FT107,{0}^A0N,14,14^FH\^FD{2}^FS"
            Dim r2 As String = "^FT202,{0}^A0N,14,14^FH\^FD{1}^FS^FT294,{0}^A0N,14,14^FH\^FD{2}^FS"
            Dim rEnd As String = "^FT170,303^A0N,23,24^FH\^FDEND^FS"


            For Each cs As String In case_serial_nos
                tDt1.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("case_serial_no") = cs Then
                        tDt1.Rows.Add(dt.Rows(i).ItemArray)
                    End If
                Next

                Dim rowsCnt As Integer = tDt1.Rows.Count
                Dim pg As Integer = Math.Ceiling(rowsCnt / noRecordsShow)
                Dim no_recs As Integer = 1
                Dim page As Integer = 1
                Dim detail As String = ""
                Dim h As Integer = 93

                For i As Integer = 0 To tDt1.Rows.Count - 1

                    If no_recs > 18 Then

                        'pageno, totalpage, case_serial, details,end
                        Dim detailLabels As String = ""

                        If page = pg Then
                            detailLabels = String.Format(pcsSummary, page, pg, cs, detail, rEnd)
                        Else
                            detailLabels = String.Format(pcsSummary, page, pg, cs, detail, "")
                        End If
                        printer1.WriteChars(detailLabels, True)
                        page += 1
                        h = 93
                        no_recs = 1
                        detail = ""
                    End If

                    Dim serial As String = dt.Rows(i)("serial_no")
                    Dim qty As Double = dt.Rows(i)("qty")
                    Dim qty_str As String = ""
                    If qty > 999 Then
                        qty_str = String.Format("{0} Kg", (qty / 1000))
                    Else
                        qty_str = String.Format("{0} g", qty)
                    End If

                    If i Mod 2 = 0 Then
                        detail = detail & String.Format(r1, h, serial, qty_str)
                    Else
                        detail = detail & String.Format(r2, h, serial, qty_str)
                        h += 22
                    End If


                    If i = rowsCnt - 1 Then
                        Dim detailLabels As String = ""
                        If page = pg Then
                            detailLabels = String.Format(pcsSummary, page, pg, cs, detail, rEnd)
                        Else
                            detailLabels = String.Format(pcsSummary, page, pg, cs, detail, "")
                        End If
                        printer1.WriteChars(detailLabels, True)
                    End If
                    no_recs += 1
                Next
            Next
            printer1.EndJob(True)

        End Using
    End Sub

    Private Sub printSummaryLabel()
        'Dim cr As New PieceSummaryLabel
        Using db As New MrpPosEntities

            Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product On ol.product_id Equals pp.id
                                                                 Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                                 Join od In db.mrp_order On od.id Equals ol.order_id
                                                                  Where ol.order_id = _orderId
                                                                  Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                   .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                                   .exp_date = lot.expired_date, .eanCodeFont = od.name}) _
                                                                       .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eanCodeFont, _
                                                                          .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
                                                                                                                                   .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
                                                                                                                         .eanCodeFont = x.eanCodeFont, .no = 0, .check = False})
            Dim no_of_box As Integer = (From b In db.mrp_order_case Where b.order_id = _orderId Select b).Count

            If lines.ToList.Count > 0 Then
                Dim cnt As Integer = 0
                Dim totalPrice As Integer = 0
                Dim no_of_pcs As Integer = 0
                For Each ol As mrp_order_line In lines.ToList
                    cnt += ol.qty
                    totalPrice += ol.price
                    no_of_pcs += 1
                Next

                Dim dt As DataTable = lines.ToADOTable
                Dim dt2 As New DataTable
                dt2 = dt.Clone

                For Each row As DataRow In dt.Rows
                    row("qty") = cnt
                    row("unit_price") = no_of_pcs & " Pcs" & vbNewLine & no_of_box & " Case(s)"
                    dt2.Rows.Add(row.ItemArray)
                    Exit For
                Next

                Dim rwCount As Integer = dt2.Rows.Count
                Dim printon As String = DateTime.Now.ToString(dtFormat)
                Dim printer1 As New LinePrinter(My.Settings.printer)
                For i As Integer = 0 To rwCount - 1
                    Dim line1 As String = dt2.Rows(i)("line1")
                    Dim line2 As String = dt2.Rows(i)("line2")
                    Dim code As String = dt2.Rows(i)("code")
                    Dim lot_no As String = dt2.Rows(i)("lot_no")
                    Dim exp As String = dt2.Rows(i)("exp_date")
                    Dim ean As String = dt2.Rows(i)("eancode")
                    Dim qty As Double = dt2.Rows(i)("qty")
                    Dim qty_str As String = ""
                    If qty > 999 Then
                        qty_str = String.Format("{0} Kg", (qty / 1000))
                    Else
                        qty_str = String.Format("{0} g", qty)
                    End If

                    'Line1, line2, code, lot,exp,ean, weight, pcs, case, print_on
                    Dim label As String = String.Format(operationSummaryLabel, line1, line2,
                                                        code, lot_no, exp, ean, qty_str, no_of_pcs,
                                                        no_of_box, printon)
                    printer1.WriteChars(label, True)
                Next
                printer1.EndJob(True)

                'Try
                '    cr.SetDataSource(dt2)

                '    cr.PrintToPrinter(1, False, 0, 0)

                printCaseSummary(_orderId)

                printPieceSummary(_orderId)
                'Catch ex As Exception

                'End Try
            End If
        End Using




    End Sub
#End Region

#Region "Button Event"
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
            Using db As New MrpPosEntities
                Dim cnt As Integer = 0
                For Each row As DataGridViewRow In dgvScanning.Rows
                    If row.Cells(1).Value Then
                        Dim oLid As Integer = row.Cells(0).Value

                        Dim orderLine As mrp_order_line = (From ol In db.mrp_order_line Where ol.id = oLid).SingleOrDefault

                        db.mrp_order_line.DeleteObject(orderLine)
                        cnt += 1

                    End If
                Next
                If cnt > 0 Then
                    db.SaveChanges()
                    Call refreshOrderLineGrid()
                    Call setSummary()
                Else
                    MsgBox("Please select a record to delete!", MsgBoxStyle.Information, "Delete Weight")
                End If
            End Using
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Select Case _previousState
            Case 1
                Call clearLot()
                Call setTouchImage()
            Case 2
                Call setLotNoView()
            Case Else
        End Select

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Select Case _nextState
            Case 2
                Call setTouchImage()
            Case 3
                Call setWeighting()
        End Select
    End Sub


    Private Sub btnWeight_Click1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeight.Click
        If My.Settings.debug = 0 Then
            Dim isOpen As Boolean = False
            Dim cnt As Integer = 0
            Dim errmsg As String = ""
            btnWeight.Enabled = False

            If Not Port.IsOpen Then
                While isOpen = False
                    Try
                        cnt += 1
                        If Port.IsOpen = False Then
                            Port.Open()
                            isOpen = True
                        End If

                    Catch ex As Exception
                        errmsg = ex.Message
                    Finally
                        If cnt = 300 Then
                            MsgBox(errmsg, MsgBoxStyle.Critical, "Error connect Port")
                            btnWeight.Enabled = True
                            isOpen = True
                        End If
                    End Try


                End While
            End If
        Else
            tbWeight.Text = "9999"
        End If
       


    End Sub

    Private Sub btnValidateWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidateWeight.Click
        ' If Port.IsOpen = True Then Port.Close()

        ' btnWeight.Enabled = True

        If tbWeight.Text = "000" Then
            MsgBox("No Reading is given!", MsgBoxStyle.Exclamation, "Warning")
            Return
        End If

        Try
            Dim testInt As Integer = tbWeight.Text
            If testInt <= 0 Then
                MsgBox("Reading is less than zero.", MsgBoxStyle.Exclamation, "Warning")
                Return
            End If
        Catch ex As Exception
            MsgBox("Please check the Weighter!", MsgBoxStyle.Exclamation, "Warning")
            Return
        End Try



        If _orderId <= 0 Then
            Call createLot()
            Call createOrder()
        End If

        Dim lineId As Integer = createWeightOrderLine()

        Using db As New MrpPosEntities
            'Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
            '                                              On ol.product_id Equals pp.id
            '                                               Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
            '                                               Where ol.box_id = 0 And ol.order_id = _orderId And ol.id = lineId
            '                                               Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
            '                                                                .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
            '                                                                .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no}) _
            '                                                    .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = setEAN13CodeFont1(x.eancode), .serial_no = x.serial_no, _
            '                                                       .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = "Rp. " & toDispCurrency(x.unit_price) & "/Kg", .exp_date = Format(x.exp_date, "ddMMyy"), .isPrintComp = _printSlogan,
            '                                                                                                                .barcode = "*" & x.serial_no & "." & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "*"})

            Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                                                          On ol.product_id Equals pp.id
                                                           Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                           Where ol.box_id = 0 And ol.order_id = _orderId And ol.id = lineId
                                                           Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                            .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                            .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no}) _
                                                                .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = setEAN13CodeFont1(x.eancode), .serial_no = x.serial_no, _
                                                                   .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price) & "/Kg", .exp_date = Format(x.exp_date, "ddMMyy"), .isPrintComp = _printSlogan,
                                                                                                                            .barcode = setEAN13CodeSales("21" & x.code & x.qty.PadLeft(5, "0"c))})


            tbWeight.BackColor = Color.FromKnownColor(KnownColor.Window)
            tbWeight.Text = "000"


            Call refreshOrderLineGrid()
            Call refreshBoxListGrid()
            Call setSummary()

            Call printLabel(lines.ToADOTable())
            ' Call printCaseLabel()
        End Using

    End Sub


    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If MsgBox("Are you sure want to finish this production?", MsgBoxStyle.OkCancel, "Finish Operation") = MsgBoxResult.Ok Then
            Using db As New MrpPosEntities
                Dim order As mrp_order = (From o In db.mrp_order Where o.id = _orderId Select o).SingleOrDefault

                Dim orLine As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Where ol.order_id = _orderId Select ol)

                Dim cLine As IEnumerable(Of mrp_order_case) = (From ol In db.mrp_order_case Where ol.order_id = _orderId Select ol)

                Dim ttl_pcs As Integer = orLine.ToList.Count
                Dim ttl_case As Integer = cLine.ToList.Count
                Dim ttl_weight As Integer = 0
                For Each jj As mrp_order_line In orLine
                    ttl_weight += jj.qty

                Next


                order.total_weight = ttl_weight
                order.total_pcs = ttl_pcs
                order.total_cases = ttl_case
                order.write_date = Now
                order.write_uid = loginUser.id

                order.state = "Done"

                db.mrp_order.ApplyCurrentValues(order)
                db.SaveChanges()

            End Using
            If MsgBox("Do you want to print the summary Report?", MsgBoxStyle.YesNo, "Print Summary") = MsgBoxResult.Yes Then
                Call printSummaryLabel()
            End If
            Call printSummaryPdf(_orderId)
            MsgBox("Production Finish. Please start again new production!", MsgBoxStyle.Information, "Success")
            Call cleanUp()
            Call setTouchImage()

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If MsgBox("Are you sure want to Exit from weighting?", MsgBoxStyle.OkCancel, "Information") = MsgBoxResult.Ok Then
            If Port.IsOpen Then Port.Close()

            Me.Close()
        End If
    End Sub
    Private Sub btnCasePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCasePrint.Click
        If MsgBox("It will do pack for all record! Are you sure you want to case print? ", MsgBoxStyle.YesNo, "Case pack") = MsgBoxResult.Yes Then
            Call printCaseLabel(True)
            Call refreshBoxListGrid()
            Call refreshOrderLineGrid()

        End If
    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        If MsgBox("Are you sure to reprint the checked record(s)? ", MsgBoxStyle.YesNo, "Reprint") = MsgBoxResult.Yes Then
            Using db As New MrpPosEntities
                'Dim records As New List(Of Integer)
                'For Each row As DataGridViewRow In dgvScanning.Rows
                '    If row.Cells(1).Value Then
                '        Dim oLid As Integer = row.Cells(0).Value
                '        records.Add(oLid)
                '    End If
                'Next

                'Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                '                                              On ol.product_id Equals pp.id
                '                                               Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                '                                               Where ol.box_id = 0 And ol.order_id = _orderId And records.Contains(ol.id)
                '                                               Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                '                                                            .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                '                                                            .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no}) _
                '                                                .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = "(RE)" & x.line1, .line2 = x.line2, .eancode = setEAN13CodeFont1(x.eancode), .serial_no = x.serial_no, _
                '                                                   .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = "Rp. " & toDispCurrency(x.unit_price) & "/Kg", .exp_date = Format(x.exp_date, "ddMMyy"), .isPrintComp = _printSlogan,
                '                                                                                                            .barcode = "*" & x.serial_no & "." & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "*"})

                'If lines.ToList.Count > 0 Then
                '    Call printLabel(lines.ToADOTable)
                'End If
                Dim records As New List(Of Integer)
                For Each row As DataGridViewRow In dgvScanning.Rows
                    If row.Cells(1).Value Then
                        Dim oLid As Integer = row.Cells(0).Value
                        Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                                                             On ol.product_id Equals pp.id
                                                              Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                              Where ol.box_id = 0 And ol.order_id = _orderId And ol.id = oLid
                                                              Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                           .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                           .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no}) _
                                                               .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = setEAN13CodeFont1(x.eancode), .serial_no = x.serial_no, _
                                                                  .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = "Rp. " & toDispCurrency(x.unit_price) & "/Kg", .exp_date = Format(x.exp_date, "ddMMyy"), .isPrintComp = _printSlogan,
                                                                                                                           .barcode = "*" & x.serial_no & "." & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "*"})

                        If lines.ToList.Count > 0 Then
                            Call printLabel(lines.ToADOTable)
                        End If
                    End If
                Next



            End Using



        End If


    End Sub

#End Region

#Region "Combo box Event"
    Private Sub cbCasePack_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCasePack.SelectedIndexChanged
        If cbCasePack.Text = "By Case" Then

            Using db As New MrpPosEntities
                Dim products As IEnumerable(Of product_product) = (From pc In db.product_case Join pp In db.product_product
                                                                    On pp.id Equals pc.case_product_id
                                                                    Where pc.product_id = _product.id
                 Select New With {.name = pp.name, .name2 = pp.name2, .pcs_per_case = pc.pcs_per_case, .id = pc.id, .code = pp.code} _
                 ).AsEnumerable().Select(Function(x) New product_product With {.id = x.id, .pcs_per_case = x.pcs_per_case, .name = x.name, .name2 = x.name2, .code = x.code})

                If products.ToList.Count > 0 Then
                    gbCaseProduct.Visible = True
                    Call loadProductCaseIntoCbBox(products.ToList)
                End If
                'Call loadProductCaseIntoCbBox(products.ToList)
            End Using
        Else
            gbCaseProduct.Visible = False
        End If
    End Sub

    Private Sub cbProductCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductCode.SelectedIndexChanged
        If gbCaseProduct.Visible Then

            If cbProductCode.Items.Count > 0 Then
                Try
                    _case_product_id = cbProductCode.SelectedValue
                    If _case_product_id > 0 Then
                        Using db As New MrpPosEntities
                            Dim cases As product_case = (From pp In db.product_case Where pp.id = _case_product_id).FirstOrDefault
                            tbQtyPerCase.Text = cases.pcs_per_case
                            _pcs_per_case = cases.pcs_per_case
                        End Using
                    End If
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub
#End Region

#Region "List View Event"
    Private Sub lvProductImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProductImage.Click
        Dim imgKey As String = lvProductImage.SelectedItems(0).Name

        Dim l As Integer = 0
        For Each img As String In shareImageList.Images.Keys

            If imgKey.Equals(img) Then
                _selectImage = shareImageList.Images(l)
                pctWeightImage.Image = _selectImage
            End If
            l += 1
            pnlImageScan.Visible = True
        Next

        For Each prod As product_product In sharedProducts
            If prod.id = imgKey Then
                _product = prod
                Call setLotNoView()
                Exit For
            End If
        Next

    End Sub

    Private Sub dgvScanning_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvScanning.CellContentClick
        If e.ColumnIndex = 1 Then
            If dgvScanning.Rows(e.RowIndex).Cells(1).FormattedValue Then
                dgvScanning.Rows(e.RowIndex).Cells(1).Value = False
            Else
                dgvScanning.Rows(e.RowIndex).Cells(1).Value = True
            End If
        End If
    End Sub


    Private Sub dgCaseData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCaseData.CellClick
        If e.RowIndex >= 0 Then
            If dgCaseData.Rows(e.RowIndex).Cells(0).Value > 0 Then
                Dim selectVal As Integer = dgCaseData.Rows(e.RowIndex).Cells(0).Value
                If _orderId > 0 Then
                    Using db As New MrpPosEntities
                        Dim lines As IEnumerable(Of mrp_order_line) = (From cp In db.mrp_case_piece
                                                                       Join ol In db.mrp_order_line On cp.line_id Equals ol.id
                                                                       Join pp In db.product_product On ol.product_id Equals pp.id
                                                                       Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                                       Where (cp.case_id = selectVal And ol.order_id = _orderId)
                                                                       Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                        .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                                        .exp_date = lot.expired_date, .eanCodeFont = pp.ean13}) _
                                                                            .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, _
                                                                               .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
                                                                                                                                        .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
                                                                                                                                        .eanCodeFont = setEAN13Code(x.eanCodeFont), .no = 0, .check = False})

                        If lines.ToList.Count > 0 Then

                            Dim rowNo As Integer = 1
                            Dim lst As New List(Of mrp_order_line)
                            For Each ol As mrp_order_line In lines.ToList
                                ol.no = rowNo
                                rowNo += 1
                                lst.Add(ol)
                            Next
                            dgBoxLine.DataSource = lst
                            dgBoxLine.Refresh()
                        End If
                    End Using
                End If

            End If
        End If

    End Sub


#End Region

#Region "Old"
    Public lotNo As String = ""
    Public expDate As String
    Public displayExpDate As String
    Public mrpid As Integer

    Private imgKey As String

    Public _isLotCancel As Boolean = True

    Private _product As product_product
    Private _case_product_code As String = ""



    Dim lotId As Integer = 0

    Public isPrintPrice As Boolean = False
    Public isPackByCase As Boolean = False

    Private oErp As New OpenErp.Net.Openerp

#End Region


#Region "Obsolete"

    Private Sub tbSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Dim conditions As New ArrayList
            conditions.Add(New String() {"active", "=", "True"})
            conditions.Add(New String() {"to_weight", "=", "True"})
            conditions.Add(New String() {"available_in_mrppos", "=", "True"})
            'conditions.Add(New String() {"name", "ilike", tbSearch.Text})

            Dim products As List(Of ProductProduct) = oErp.searchProducts(conditions)

            lvProductImage.Items.Clear()

            Dim itm As New ListViewItem

            For Each prod As ProductProduct In products
                itm = lvProductImage.Items.Add(prod.name & "[" & IIf(prod.default_code = "False", "", prod.default_code) & "]")
                itm.ImageKey = prod.id
                itm.Name = prod.id
            Next
        End If

    End Sub



    Private Sub tbSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If tbSearch.Text.Trim = "Search Product Code, Product Name" Then
        '    tbSearch.Clear()
        'End If

    End Sub

    Private Sub btnScalling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WeightingFrm.selectedImg = _selectImage
        WeightingFrm.ShowDialog()

        If WeightingFrm.yesNo Then
            insertToPos(WeightingFrm.weightVal)
        End If
    End Sub


    Private Sub insertToPos(ByVal val As Decimal)
        'Try

        '    Dim prodLotConds As New ArrayList
        '    Dim prodLotList As List(Of OpenErp.Net.StockProductionLot)
        '    Dim prodLotId As String = ""
        '    Dim prodLotPair As New XmlRpcStruct

        '    prodLotConds.Add(New String() {"name", "=", lotNo})

        '    prodLotList = oErp.getProdLotsList(prodLotConds)

        '    For Each pl As StockProductionLot In prodLotList
        '        If pl.product_id = _product.id Then
        '            prodLotId = pl.id
        '            Exit For
        '        End If
        '    Next

        '    If prodLotId.Length <= 0 Then
        '        prodLotPair.Add("name", lotNo)
        '        prodLotPair.Add("use_date", expDate)
        '        prodLotPair.Add("product_id", _product.id)
        '        prodLotId = oErp.addProdLot(prodLotPair)
        '    End If

        '    Dim orderHead As New XmlRpcStruct
        '    Dim orderLine As New XmlRpcStruct

        '    If _orderId.Length <= 0 Then
        '        orderHead.Add("prodlot_id", prodLotId)
        '        orderHead.Add("mrp_id", mrpid)
        '        _orderId = oErp.addPosOrderHead(orderHead)
        '    End If

        '    orderLine.Add("product_id", _product.id)
        '    orderLine.Add("order_id", _orderId)
        '    orderLine.Add("qty", val.ToString)
        '    orderLine.Add("prodlot_id", prodLotId)


        '    Dim orderDetailId As Integer = oErp.addPosOrderDetail(orderLine)


        '    Dim lst As List(Of MrpOrderLine) = setOrderLineList(_product.default_code, _product.name, lotNo, displayExpDate, val.ToString, _product.ean13)
        '    Dim arr As New ArrayList
        '    arr.Add(orderDetailId)


        '    printReceipt(lst)

        '    displayDataGrid()


        '    setTotalWeight()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub

    Private Sub displayDataGrid(ByVal lst As List(Of mrp_order_line))
        'Dim oParam As New LUNA.LunaSearchParameter("order_id", _orderId)
        'Dim opt As New LUNA.LunaSearchOption
        'opt.OrderBy = "created_date"
        'Dim dao As New Mrp_order_lineDAO
        'Dim lstOrderlines As New List(Of Mrp_order_line)

        'lstOrderlines = dao.Find(opt, oParam)
        '   Dim orderLinesList As List(Of MrpOrderLine) = oErp.getOrderLines(orderIds)
        dgvScanning.DataSource = lst


    End Sub

    Private Sub printReceipt(ByVal orderLineId As List(Of mrp_order_line))
        If Not isPrintPrice Then
            Dim cr As New PieceLabel

            Try

                cr.SetDataSource(orderLineId)

                cr.PrintToPrinter(1, False, 0, 0)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else

            Dim cr As New PiecePriceLabel

            Try

                cr.SetDataSource(orderLineId)

                cr.PrintToPrinter(1, False, 0, 0)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Private Function setOrderLineList(ByVal productCode As String, ByVal productName As String, ByVal lotno As String, ByVal exp As String, ByVal qty As String, ByVal ean13 As String) As List(Of MrpOrderLine)
        Dim lstOrderlines As New List(Of MrpOrderLine)
        Dim orderLine As New MrpOrderLine

        orderLine.product_code = ean13.Substring(0, 5)
        orderLine.product_name = productName
        orderLine.prodlot_use_date = exp
        orderLine.qty = qty
        orderLine.prodlot_name = lotno
        orderLine.product_ean13 = ean13




        lstOrderlines.Add(orderLine)

        Return lstOrderlines

    End Function

    Private Function setOrderLineListAcc(ByVal oLine As mrp_order_line) As List(Of mrp_order_line)
        'Dim lstOrderlines As New List(Of Mrp_order_line)



        'Dim ttlQty As Integer = 0
        'Dim dgvRow As DataGridViewRow
        ''loop through every item in DataGridView
        'If dgvScanning.RowCount > 0 Then
        '    For Each dgvRow In dgvScanning.Rows
        '        Dim orderLine As New Mrp_order_line
        '        orderLine.product_code = dgvRow.Cells(0).Value
        '        orderLine.product_name = dgvRow.Cells(1).Value
        '        orderLine.product_name2 = dgvRow.Cells(2).Value
        '        orderLine.ean13 = dgvRow.Cells(3).Value
        '        ' orderLine.ean13 = _product.ean13
        '        orderLine.price = dgvRow.Cells(4).Value
        '        orderLine.qty = dgvRow.Cells(5).Value
        '        orderLine.exp_date = dgvRow.Cells(6).Value
        '        orderLine.lot_no = dgvRow.Cells(7).Value
        '        orderLine.product_id = dgvRow.Cells(8).Value
        '        orderLine.order_id = dgvRow.Cells(9).Value
        '        orderLine.ID = dgvRow.Cells(10).Value
        '        orderLine.product_barcode = dgvRow.Cells(11).Value
        '        lstOrderlines.Add(orderLine)

        '    Next
        'End If
        'oLine.ean13 = _product.ean13
        'lstOrderlines.Add(oLine)

        'Return lstOrderlines

    End Function

    Private Sub btnWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WeightingFrm.selectedImg = _selectImage
        WeightingFrm.ShowDialog()

        If WeightingFrm.yesNo Then
            RecordPos(WeightingFrm.weightVal)
        End If
    End Sub

    Private Sub RecordPos(ByVal weight As Decimal)
        'Dim lstLot As New List(Of Mrp_prod_lot)
        'Dim lstDao As New Mrp_prod_lotDAO

        'Dim pLot As New LUNA.LunaSearchParameter("name", lotNo)
        'Dim pLot1 As New LUNA.LunaSearchParameter("product_id", _product.ID)

        'If lotId <= 0 Then
        '    lstLot = lstDao.Find(pLot, pLot1)


        '    Dim mat As Boolean = False
        '    If lstLot.Count > 0 Then
        '        For Each lt As Mrp_prod_lot In lstLot
        '            If lt.expired_date.ToString("yyyyMMdd") = Now.AddDays(_product.day_to_expire).ToString("yyyyMMdd") Then
        '                lotId = lstLot(0).ID
        '                mat = True
        '                Exit For
        '            End If
        '        Next
        '        If Not mat Then
        '            Dim Lot As New Mrp_prod_lot
        '            Lot.create_date = Now
        '            Lot.create_uid = loginUser.ID
        '            Lot.write_date = Now
        '            Lot.write_uid = loginUser.ID
        '            Lot.name = lotNo
        '            Lot.manufacturing_date = Now
        '            Lot.expired_date = Now.AddDays(_product.day_to_expire)
        '            Lot.product_id = _product.ID
        '            lotId = Lot.Save
        '        End If
        '    Else
        '        Dim Lot As New Mrp_prod_lot
        '        Lot.create_date = Now
        '        Lot.create_uid = loginUser.ID
        '        Lot.write_date = Now
        '        Lot.write_uid = loginUser.ID
        '        Lot.name = lotNo
        '        Lot.manufacturing_date = Now
        '        Lot.expired_date = Now.AddDays(_product.day_to_expire)
        '        Lot.product_id = _product.ID
        '        lotId = Lot.Save


        '    End If
        'End If

        'Try
        '    If _orderId <= 0 Then
        '        Dim order As New Mrp_order
        '        order.create_date = Now
        '        order.create_uid = loginUser.ID
        '        order.write_date = Now
        '        order.write_uid = loginUser.ID

        '        order.product_id = _product.ID
        '        order.lot_id = lotId
        '        'order.userid = loginUser.ID
        '        'order.date_order = Now

        '        '_orderId = order.Save


        '    End If

        '    Dim orderLine As New Mrp_order_line
        '    orderLine.create_date = Now
        '    orderLine.create_uid = loginUser.ID
        '    orderLine.write_date = Now
        '    orderLine.write_uid = loginUser.ID
        '    orderLine.order_id = _orderId
        '    orderLine.prodlot_id = lotId
        '    orderLine.product_id = _product.ID
        '    orderLine.qty = weight
        '    'orderLine.Save()

        '    'orderLine.product_code = _product.code
        '    'orderLine.product_name = _product.name
        '    'orderLine.product_name2 = _product.name2
        '    'If isPrintPrice Then
        '    '    orderLine.price = Math.Ceiling((weight / 1000) * _product.price_per_kg)
        '    'Else
        '    '    orderLine.price = 0
        '    'End If
        '    'orderLine.product_barcode = "*" & lotNo & "." & _product.code & "." & weight.ToString.PadLeft(4, "0"c) & "*"
        '    ''orderLine.ean13 = setEAN13CodeFont(_product.code)
        '    'orderLine.ean13 = setEAN13CodeFont1(_product.ean13)
        '    'orderLine.lot_no = lotNo
        '    'orderLine.exp_date = Now.AddDays(_product.day_to_expire).ToString("MMddyy")



        '    Dim lstOrder As New List(Of Mrp_order_line)

        '    lstOrder.Add(orderLine)
        '    printReceipt(lstOrder)

        '    Dim lstOrder2 As New List(Of Mrp_order_line)
        '    lstOrder2 = setOrderLineListAcc(orderLine)
        '    displayDataGrid(lstOrder2)

        '    If isPackByCase Then
        '        printCaseReceipt()
        '    End If



        '    setTotalWeight()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub

    Private Sub setTotalWeight()

        Dim ttlQty As Integer = 0
        Dim dgvRow As DataGridViewRow
        'loop through every item in DataGridView
        For Each dgvRow In dgvScanning.Rows
            ttlQty += Integer.Parse(dgvRow.Cells(5).Value)
        Next
        '  lblWeight.Text = ", Total Weight: " & ttlQty & " g"
    End Sub

    Private Function getTotalWeight() As String

        Dim ttlQty As Integer = 0
        Dim dgvRow As DataGridViewRow
        'loop through every item in DataGridView
        For Each dgvRow In dgvScanning.Rows
            ttlQty += Integer.Parse(dgvRow.Cells(5).Value)
        Next
        Return ttlQty.ToString
    End Function

    Private Sub printCaseReceipt()
        'Dim ordParam As New LUNA.LunaSearchParameter("id", _orderId)
        'Dim ordLineParam As New LUNA.LunaSearchParameter("order_id", _orderId)
        'Dim ordLineParam1 As New LUNA.LunaSearchParameter("box_id", 0)

        'Dim ordLineDao As New Mrp_order_lineDAO
        'Dim lstOrderLine As New List(Of Mrp_order_line)
        'lstOrderLine = (New Mrp_order_lineDAO).Find(ordLineParam, ordLineParam1)

        'If lstOrderLine.Count > 0 Then
        '    Dim totalQty As Integer = 0
        '    If lstOrderLine.Count = _pcs_per_case Then
        '        For Each ordLine As Mrp_order_line In lstOrderLine
        '            totalQty += ordLine.qty
        '        Next


        '        Dim box As New Mrp_order_line_box
        '        box.created_date = Now
        '        box.created_uid = loginUser.ID
        '        box.write_date = Now
        '        box.write_uid = loginUser.ID
        '        box.order_id = _orderId
        '        box.no_pcs = lstOrderLine.Count
        '        box.product_id = _product.ID
        '        box.qty = totalQty
        '        box.lot_id = lotId
        '        Dim box_id As Integer = box.Save()

        '        For Each p As Mrp_order_line In lstOrderLine
        '            p.box_id = box_id
        '            'p.Save()
        '        Next

        '        Dim lst As New List(Of Mrp_order_line)
        '        Dim orderLine As New Mrp_order_line
        '        'orderLine.product_code = _product.code
        '        'orderLine.product_name = _product.name
        '        'orderLine.product_name2 = _product.name2
        '        'orderLine.ean13 = setEAN13CodeFont1(_product.ean13)
        '        'orderLine.lot_no = lotNo
        '        'orderLine.exp_date = Now.AddDays(_product.day_to_expire).ToString("ddMMyy")
        '        'orderLine.qty = totalQty
        '        'orderLine.pcs_per_case = lstOrderLine.Count

        '        lst.Add(orderLine)

        '        Dim cr As New CLabel

        '        Try


        '            '  Dim orderLinesList As List(Of MrpOrderLine) = oErp.getOrderLine(orderLineId)
        '            cr.SetDataSource(lst)
        '            cr.SetParameterValue("pcs", lstOrderLine.Count & " pcs")


        '            cr.PrintToPrinter(1, False, 0, 0)

        '        Catch ex As Exception
        '            MsgBox(ex.ToString)
        '        End Try
        '    End If

        'End If

        'If lstOrderLine.Count = _product.
        '  Dim sql As String = "select sum(ol.qty), ol.lot_id, from mrp_order_line ol where (ol.box_id = 0 or ol.box_id = '') and ol.order_id = " & _orderId
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DailySummary.Show()
    End Sub




#End Region


    Private Sub printSummaryPdf(ByVal orderId As Integer)

        Using db As New MrpPosEntities
            Dim summ1 As IEnumerable(Of MrpSummaryObj) = (From od In db.mrp_order
                       Join ol In db.mrp_order_line On ol.order_id Equals od.id
                       Join oc In db.mrp_order_case On oc.id Equals ol.box_id
                       Join pp In db.product_product On pp.id Equals od.product_id
                       Join lot In db.mrp_prod_lot On lot.id Equals od.lot_id
                       Where od.id = orderId
                        Select New With {.order_serial_no = od.name, .case_serial_no = oc.serial_no, .lot_no = lot.name, .line1 = pp.name, .line2 = pp.name2, _
                       .serial_no = ol.serial_no, .qty = ol.qty, .total_weight = od.total_weight, .total_case = od.total_cases, .total_pcs = od.total_pcs, .exp_date = lot.expired_date}). _
            AsEnumerable().Select(Function(x) New MrpSummaryObj With {.order_serial_no = x.order_serial_no, .case_serial_no = x.case_serial_no, .serial_no = x.serial_no, .qty = x.qty, _
            .line1 = x.line1, .Line2 = x.line2, .lot_no = x.lot_no, .pcs = x.total_case & " / " & x.total_pcs, .total_weight = x.total_weight, .exp_date = Format(x.exp_date, "ddMMyy")})


            Dim summ2 As IEnumerable(Of MrpSummaryObj) = (From od In db.mrp_order
                                                          Join ol In db.mrp_order_line On ol.order_id Equals od.id
                                                          Join pp In db.product_product On pp.id Equals od.product_id
                                                          Join lot In db.mrp_prod_lot On lot.id Equals od.lot_id
                                                          Where od.id = orderId And ol.box_id = 0
                                                          Select New With {.order_serial_no = od.name, .case_serial_no = "", .lot_no = lot.name, .line1 = pp.name, .line2 = pp.name2, _
                                                                           .serial_no = ol.serial_no, .qty = ol.qty, .total_weight = od.total_weight, .total_case = od.total_cases, .total_pcs = od.total_pcs, .exp_date = lot.expired_date}). _
                                                                   AsEnumerable().Select(Function(x) New MrpSummaryObj With {.order_serial_no = x.order_serial_no, .case_serial_no = x.case_serial_no, .serial_no = x.serial_no, .qty = x.qty, _
                                                                                                                             .line1 = x.line1, .Line2 = x.line2, .lot_no = x.lot_no, .pcs = x.total_case & " / " & x.total_pcs, .total_weight = x.total_weight, .exp_date = Format(x.exp_date, "ddMMyy")})



            Dim qty1 As Integer = 0
            Dim qty2 As Integer = 0


            Dim res1 As DataTable = summ1.ToADOTable
            Dim res2 As DataTable = summ2.ToADOTable


            Dim dt1 As New DataTable
            dt1 = res1.Clone

            For Each row As DataRow In res1.Rows

                dt1.Rows.Add(row.ItemArray)

            Next
            For Each row As DataRow In res2.Rows

                dt1.Rows.Add(row.ItemArray)

            Next

            Using cr As New MrpSummary
                Try

                    cr.SetDataSource(dt1)

                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New  _
                    DiskFileDestinationOptions()
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                    ' Dim CrFormatTypeOptions As New pdf
                    CrDiskFileDestinationOptions.DiskFileName = My.Settings.exportSummaryPath & dt1.Rows(0)("order_serial_no") & ".pdf"
                    CrExportOptions = cr.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions
                    End With
                    cr.Export()
                    '.ExportFormatType = ExportFormatType.PortableDocFormat
                    If System.IO.File.Exists(My.Settings.exportSummaryPath & dt1.Rows(0)("order_serial_no") & ".pdf") Then
                        Process.Start(My.Settings.exportSummaryPath & dt1.Rows(0)("order_serial_no") & ".pdf")
                    End If

                Catch ex As Exception

                End Try
            End Using

        End Using
    End Sub



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each row As DataGridViewRow In dgvScanning.Rows
            row.Cells(1).Value = True
        Next

    End Sub

    Private Sub test(ByVal lala As Integer)
        ' If Port.IsOpen = True Then Port.Close()

        ' btnWeight.Enabled = True
        tbWeight.Text = lala

        If tbWeight.Text = "000" Then
            MsgBox("No Reading is given!", MsgBoxStyle.Exclamation, "Warning")
            Return
        End If

        Try
            Dim testInt As Integer = tbWeight.Text
            If testInt <= 0 Then
                MsgBox("Reading is less than zero.", MsgBoxStyle.Exclamation, "Warning")
                Return
            End If
        Catch ex As Exception
            MsgBox("Please check the Weighter!", MsgBoxStyle.Exclamation, "Warning")
            Return
        End Try



        If _orderId <= 0 Then
            Call createLot()
            Call createOrder()
        End If

        Dim lineId As Integer = createWeightOrderLine()

        Using db As New MrpPosEntities
            Dim lines As IEnumerable(Of mrp_order_line) = (From ol In db.mrp_order_line Join pp In db.product_product
                                                          On ol.product_id Equals pp.id
                                                           Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                           Where ol.box_id = 0 And ol.order_id = _orderId And ol.id = lineId
                                                           Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                            .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                            .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no}) _
                                                                .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = setEAN13CodeFont1(x.eancode), .serial_no = x.serial_no, _
                                                                   .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = "Rp. " & toDispCurrency(x.unit_price) & "/Kg", .exp_date = Format(x.exp_date, "ddMMyy"), .isPrintComp = _printSlogan,
                                                                                                                            .barcode = "*" & x.serial_no & "." & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "*"})


            tbWeight.BackColor = Color.FromKnownColor(KnownColor.Window)
            tbWeight.Text = "000"


 

            'Call printLabel(lines.ToADOTable())
            'Call printCaseLabel()
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 1 To 23
            test(i * 857)
        Next
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 1 To 23
            test(i * 857)
        Next
        Call refreshOrderLineGrid()
        Call refreshBoxListGrid()
        Call setSummary()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        printCaseSummary(4172)
        printPieceSummary(4172)
    End Sub

End Class