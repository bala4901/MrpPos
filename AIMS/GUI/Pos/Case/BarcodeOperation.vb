Imports WeifenLuo.WinFormsUI
Imports System.Linq
Imports System.IO
Imports Numeria.IO
Imports CrystalDecisions.Shared


Public Class BarcodeOperation
    Inherits DockContent

    Private _prd_id As Integer = 0
    Private _lot_id As Integer = 0
    Private _isPhotoLoad As Boolean = False
    Private dtFormat As String = "dd MMM yyyy HH:mm:ss"
    Private casePriceLabel As String = "^XA" _
                                    & "^MMT" _
                                    & "^PW398" _
                                    & "^LL0319" _
                                    & "^LS0" _
                                    & "^FT106,77^A0N,28,28^FH\^FD{0}^FS" _
                                    & "^FT105,41^A0N,28,28^FH\^FD{1}^FS" _
                                    & "^FT206,170^A0N,14,14^FH\^FDU. Price :^FS" _
                                    & "^FT238,140^A0N,14,14^FH\^FDExp:^FS" _
                                    & "^FT230,112^A0N,14,14^FH\^FDLot #:^FS" _
                                    & "^FT27,197^A0N,28,28^FH\^FDRp. {2}^FS" _
                                    & "^FT266,170^A0N,20,19^FH\^FDRp. {3}/kg^FS" _
                                    & "^FT16,104^A0N,14,14^FH\^FDWeight:^FS" _
                                    & "^FT266,141^A0N,20,19^FH\^FD{4}^FS" _
                                    & "^FT14,164^A0N,14,14^FH\^FDPrice^FS" _
                                    & "^FT266,113^A0N,20,19^FH\^FDWeight^FS" _
                                    & "^FT26,140^A0N,28,28^FH\^FD{5}^FS" _
                                    & "^FT170,212^A0N,28,28^FH\^FD{6}^FS" _
                                    & "^BY2,3,61^FT39,289^B3N,N,,Y,N" _
                                    & "^FD{7}^FS" _
                                    & "^PQ1,0,1,Y^XZ" '0: Line1 1:Line2 2:price 3:unit price 4:exp date 5:weight 6:ean 7:barcode

    Private caselbl As String = "^XA" _
    & "^MMT" _
    & "^PW398" _
    & "^LL0319" _
    & "^LS0" _
    & "^FT106,77^A0N,28,28^FH\^FD{0}^FS" _
    & "^FT105,41^A0N,28,28^FH\^FD{1}^FS" _
    & "^FT238,140^A0N,14,14^FH\^FDExp:^FS" _
    & "^FT230,112^A0N,14,14^FH\^FDLot #:^FS" _
    & "^FT72,184^A0N,28,28^FH\^FD{2}^FS" _
    & "^FT19,138^A0N,14,14^FH\^FDWeight:^FS" _
    & "^FT266,141^A0N,20,19^FH\^FD{3}^FS" _
    & "^FT19,176^A0N,14,14^FH\^FDQty:^FS" _
    & "^FT266,113^A0N,20,19^FH\^FDWeight^FS" _
    & "^FT73,141^A0N,28,28^FH\^FD{4}^FS" _
    & "^FT181,188^A0N,28,28^FH\^FD{5}^FS" _
    & "^BY2,3,61^FT41,277^B3N,N,,Y,N" _
    & "^FD{6}^FS" _
    & "^PQ1,0,1,Y^XZ" '0: Line1, 1: Line2 2:QTY, 3:EXP DATE , 4: WEIGHT, 5: EAN CODE, 6: BARCODE


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


    Private Sub BarcodeOperation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbPrice.SelectedText = "Yes"
        cbPrintSummary.SelectedText = "Yes"
        cbSlogan.SelectedText = "Yes"
        pctWeightImage.Image = My.Resources.placeholder
        Call loadDgvLine()
        Call setSummary()
    End Sub

    Private Sub tbBarcode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call insertToDgvLine()
            Call loadDgvLine()
            Call setSummary()
        End If
    End Sub

    Private Sub insertToDgvLine()
        Dim barcode As String = tbBarcode.Text
        If Not barcode.Contains(".") Then
            MsgBox("Please check barcode value!!", MsgBoxStyle.Exclamation, "Barcode Value")
            Return
        End If
        Dim serial As String = barcode.Substring(0, barcode.IndexOf("."))

        tbBarcode.Clear()

        Using db As New MrpPosEntities

            Dim oLine As mrp_order_line = (From p In db.mrp_order_line Where p.serial_no = serial).FirstOrDefault
            If Not oLine Is Nothing Then
                Dim iCnt As Integer = (From p In db.mrp_case_piece Where p.line_id = oLine.id And p.status = 0 And p.case_id = 0).Count

                If iCnt > 0 Then
                    MsgBox("You have scanned!!", MsgBoxStyle.Exclamation, "Double Scanned")
                    Return
                End If

                If _lot_id > 0 Then
                    If oLine.prodlot_id <> _lot_id Then
                        MsgBox("Only allow same lot!!", MsgBoxStyle.Exclamation, "Lot Not Valid")
                        Return
                    End If
                End If


                Dim rwCnt As Integer = (From p In db.mrp_case_piece Select p).Count

                Dim case_piece As New mrp_case_piece
                case_piece.case_id = 0
                case_piece.line_id = oLine.id
                case_piece.order_id = 0
                case_piece.write_by = loginUser.id
                case_piece.create_by = loginUser.id
                case_piece.write_date = Now
                case_piece.create_date = Now
                case_piece.status = 0

                If rwCnt > 0 Then
                    case_piece.id = getNextId(db.mrp_case_piece.Select(Function(x) x.id).Max)
                Else
                    case_piece.id = 1
                End If

                db.mrp_case_piece.AddObject(case_piece)
                db.SaveChanges()
            Else
                MsgBox("The barcode is not valid or not found!!", MsgBoxStyle.Exclamation, "Not Valid")
            End If

        End Using
    End Sub

    Private Sub loadDgvLine()
        Using db As New MrpPosEntities
            Dim lines As IEnumerable(Of mrp_order_line) = (From cp In db.mrp_case_piece
                                                                      Join ol In db.mrp_order_line On cp.line_id Equals ol.id
                                                                      Join pp In db.product_product On ol.product_id Equals pp.id
                                                                      Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                                      Where (cp.case_id = 0 And cp.order_id = 0)
                                                                      Select New With {.id = cp.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                       .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg, .prodlot_id = lot.id,
                                                                                       .exp_date = lot.expired_date, .eanCodeFont = pp.ean13, .serial_no = ol.serial_no, .product_id = pp.id}) _
                                                                           .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, .prodlot_id = x.prodlot_id, _
                                                                              .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
                                                                                                                                       .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
                                                                                                                                       .eanCodeFont = setEAN13Code(x.eanCodeFont), .no = 0, .check = False, .serial_no = x.serial_no, .product_id = x.product_id})
            If lines.ToList.Count > 0 Then
                _prd_id = lines(0).product_id
                _lot_id = lines(0).prodlot_id

                If Not _isPhotoLoad Then
                    _isPhotoLoad = False
                    Dim prod As product_product = (From p In db.product_product Where p.id = _prd_id).FirstOrDefault
                    Dim appPath As String = getFileDbPath()
                    Dim outputStream As New MemoryStream
                    If Not String.IsNullOrEmpty(prod.image) Then
                        Dim info = FileDB.Read(appPath, Guid.Parse(prod.image), outputStream)
                        pctWeightImage.Image = Image.FromStream(outputStream)
                        _isPhotoLoad = True
                    End If

                End If

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
                _prd_id = 0
                _lot_id = 0
                pctWeightImage.Image = My.Resources.placeholder
                dgvScanning.DataSource = DBNull.Value
                dgvScanning.Refresh()
            End If

        End Using
    End Sub

    Private Function getSummaryOrder() As mrp_order_line
        Using db As New MrpPosEntities


            Dim lines As IEnumerable(Of mrp_order_line) = (From cp In db.mrp_case_piece
                                                           Join ol In db.mrp_order_line On cp.line_id Equals ol.id
                                                           Join pp In db.product_product On ol.product_id Equals pp.id
                                                                  Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                                  Where cp.order_id = 0 And cp.status = 0 And cp.case_id = 0
                                                                  Select New With {.id = cp.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
                                                                                   .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
                                                                                   .exp_date = lot.expired_date, .eanCodeFont = pp.ean13}) _
                                                                       .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, _
                                                                          .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
                                                                                                                                   .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
                                                                                                                         .eanCodeFont = setEAN13Code(x.eanCodeFont), .no = 0, .check = False})
            Dim no_of_box As Integer = 0

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

    Private Sub btnCasePrint_Click(sender As System.Object, e As System.EventArgs) Handles btnCasePrint.Click
        If MsgBox("It will do pack for all record! Are you sure you want to case print? ", MsgBoxStyle.YesNo, "Case pack") = MsgBoxResult.Yes Then


            Call printCaseLabel()
            Call loadDgvLine()
            _lot_id = 0
            _prd_id = 0

        End If
    End Sub

    Private Sub printCaseLabel()
        Dim print As Boolean = False
        Dim box_id As Integer = 0
        Dim _case_product_id As Integer = 0
        Dim _printCasePrice As Boolean = IIf(cbPrice.Text = "Yes", True, False)
        Dim _printSlogan As Boolean = IIf(cbSlogan.Text = "Yes", True, False)
        Dim _printSummary As Boolean = IIf(cbPrintSummary.Text = "Yes", True, False)

        Using db As New MrpPosEntities
            Dim cnt As Integer = (From p In db.product_case Where p.product_id = _prd_id).Count



            Dim lines As IEnumerable(Of mrp_order_line) = (From cp In db.mrp_case_piece
                                                           Join ol In db.mrp_order_line On ol.id Equals cp.line_id
                                                           Join pp In db.product_product On ol.product_id Equals pp.id
                                                           Join lot In db.mrp_prod_lot On ol.prodlot_id Equals lot.id
                                                           Where cp.order_id = 0 And cp.case_id = 0
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

                If chkCaseProduct.Checked Then
                    _case_product_id = cbCaseProduct.SelectedValue
                End If

                If _case_product_id <= 0 Then
                    case_prod = (From pp In db.product_product Where pp.id = _prd_id Select pp).SingleOrDefault
                Else
                    case_prod = (From pp In db.product_product Where pp.id = _case_product_id Select pp).SingleOrDefault
                End If

                Dim prod As product_product = (From pp In db.product_product Where pp.id = _prd_id Select pp).SingleOrDefault


                Dim case_serial_no As String = ""

                box_id = createCaseOrder(case_prod.id, no_of_pcs, totalWeight, case_serial_no)


                Try
                    Dim ord As mrp_order_line = lines.ToList()(0)
                    Dim listOrderLine As New List(Of mrp_order_line)
                    Dim dt As DataTable = lines.ToADOTable()
                    Dim dt2 As New DataTable
                    dt2 = dt.Clone
                    Dim printer As New LinePrinter(My.Settings.printer)
                    Dim eancode = setEAN13CodeFont1(case_prod.ean13)
                    Dim bccode As String = case_serial_no & "." & ord.lot_no & "." & ord.exp_date & "." & totalWeight
                    For Each row As DataRow In dt.Rows
                        '0: Line1 1:Line2 2:price 3:unit price 4:exp date 5:weight 6:ean 7:barcode
                        Dim weight_str As String = ""
                        If totalWeight > 999 Then
                            weight_str = String.Format("{0} Kg", (totalWeight / 1000))
                        Else
                            weight_str = String.Format("{0} g", totalWeight)
                        End If
                        If _printCasePrice Then
                            'csPriceLabel
                            'Line1, Line2, price, unit_price, exp, qty, lot, weight, ean, barcode
                            Dim Label As String = String.Format(csPriceLabel, case_prod.name, case_prod.name2, (totalWeight / 1000) * prod.price_per_kg,
                                                                ord.exp_date, case_prod.pcs_per_case, ord.lot_no, weight_str, eancode, bccode)
                            printer.WriteChars(Label, True)


                        Else
                            ''Line1, Line2, qty, serial, exp, lot, weight, ean, barcode
                            Dim Label As String = String.Format(csLabel, case_prod.name, case_prod.name2, no_of_pcs, case_serial_no,
                                                                ord.exp_date, ord.lot_no, weight_str, eancode, bccode)

                            printer.WriteChars(Label, True)

                        End If


                        'row("code") = "Rp. " & prod.price_per_kg & "/Kg"
                        'row("line1") = case_prod.name
                        'row("line2") = case_prod.name2
                        'row("qty") = totalWeight
                        'row("unit_price") = no_of_pcs
                        'row("eancode") = setEAN13CodeFont1(case_prod.ean13)
                        'row("exp_date") = ord.exp_date
                        'row("lot_no") = ord.lot_no
                        'row("isPrintComp") = _printSlogan
                        'row("serial_no") = case_serial_no
                        'row("price") = (totalWeight / 1000) * prod.price_per_kg
                        'row("barcode") = "*" & case_serial_no & "." & ord.lot_no & "." & ord.exp_date & "." & totalWeight & "*"
                        'dt2.Rows.Add(row.ItemArray)
                        Exit For
                    Next
                    printer.EndJob(True)



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

                    db.SaveChanges()



                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If

            Dim cLines As IEnumerable(Of mrp_case_piece) = From cp In db.mrp_case_piece Where cp.status = 0
            For Each cLine As mrp_case_piece In cLines.ToList
                cLine.case_id = box_id
                cLine.status = 1
                db.mrp_case_piece.ApplyCurrentValues(cLine)
                db.SaveChanges()
            Next



            If _printSummary Then
                If box_id > 0 Then

                    printCaseSummary(box_id)

                End If


            End If


            _prd_id = 0
            _lot_id = 0
        End Using


    End Sub

    Private Sub printCaseSummary(ByVal box_id As Integer)
        Using db As New MrpPosEntities
            Dim cr As New cSummary
            Dim casePiece As IEnumerable(Of mrp_order_line) = (From cp In db.mrp_case_piece
                                                               Join ol In db.mrp_order_line On cp.line_id Equals ol.id
                                                               Join oc In db.mrp_order_case On cp.case_id Equals oc.id
                                                               Where (cp.case_id = box_id)
                                                                      Select New With {.case_serial_no = oc.serial_no, .serial_no = ol.serial_no, .qty = ol.qty, .total_qty = oc.qty, .unit_price = oc.no_of_pcs}) _
                                                                           .AsEnumerable().Select(Function(x) New mrp_order_line With {.case_serial_no = x.case_serial_no, .serial_no = x.serial_no, .qty = x.qty, _
                                                                                                                                      .total_weight = x.total_qty, .unit_price = x.unit_price})
            Dim dt As DataTable = casePiece.ToADOTable


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


        End Using
    End Sub

    Private Function createCaseOrder(ByVal product_id As Integer, ByVal no_pcs As Integer, ByVal ttlWeight As Integer, ByRef serial_no As String) As Integer
        Using db As New MrpPosEntities
            Dim rwCnt As Integer = (From p In db.mrp_order_case Select p).Count

            Dim cas As New mrp_order_case
            cas.create_date = Now
            cas.create_id = loginUser.id
            cas.write_date = Now
            cas.write_id = loginUser.id
            cas.order_id = 0
            cas.no_of_pcs = no_pcs
            cas.qty = ttlWeight

            cas.product_id = product_id



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

    Private Sub chkCaseProduct_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCaseProduct.CheckedChanged
        If _prd_id <= 0 Then
            MsgBox("Please scan the item first!", MsgBoxStyle.Information, "Scan Barcode First")
            chkCaseProduct.Checked = False
        Else
            Using db As New MrpPosEntities
                Dim cnt As Integer = (From p In db.product_case Where p.product_id = _prd_id).Count
                If cnt > 0 Then
                    If chkCaseProduct.Checked Then
                        gbGroupProduct.Enabled = True
                        Call loadCBCaseProduct()
                    Else
                        gbGroupProduct.Enabled = False
                        chkCaseProduct.Checked = False
                    End If
                Else
                    MsgBox("This item do not have case product code!", MsgBoxStyle.Information, "Case Product Code")
                    chkCaseProduct.Checked = False
                End If
            End Using
          
        End If
      

    End Sub

    Private Sub loadCBCaseProduct()
        Using db As New MrpPosEntities
            Dim prod As IEnumerable(Of product_product) = (From pc In db.product_case
                                                       Join p In db.product_product On pc.case_product_id Equals p.id
                                                       Where pc.product_id = _prd_id
                                                       Select New With {.id = pc.id, .code = p.code}) _
                                                   .AsEnumerable().Select(Function(x) New product_product With {.id = x.id, .code = x.code})

            cbCaseProduct.ValueMember = "id"
            cbCaseProduct.DisplayMember = "code"
            cbCaseProduct.DataSource = prod.ToList
       
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
            Using db As New MrpPosEntities
                Dim cnt As Integer = 0
                For Each row As DataGridViewRow In dgvScanning.Rows
                    If row.Cells(1).Value Then
                        Dim oLid As Integer = row.Cells(0).Value

                        Dim orderLine As mrp_case_piece = (From ol In db.mrp_case_piece Where ol.id = oLid).SingleOrDefault

                        db.mrp_case_piece.DeleteObject(orderLine)
                        cnt += 1

                    End If
                Next
                If cnt > 0 Then
                    db.SaveChanges()
                    Call loadDgvLine()
                    Call setSummary()
                Else
                    MsgBox("Please select a record to delete!", MsgBoxStyle.Information, "Delete Weight")
                End If
            End Using
        End If
    End Sub

    Private Sub dgvScanning_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvScanning.CellContentClick
        If e.ColumnIndex = 1 Then
            If dgvScanning.Rows(e.RowIndex).Cells(1).FormattedValue Then
                dgvScanning.Rows(e.RowIndex).Cells(1).Value = False
            Else
                dgvScanning.Rows(e.RowIndex).Cells(1).Value = True
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If MsgBox("Are you sure want to Exit from Barcode Scanning?", MsgBoxStyle.OkCancel, "Information") = MsgBoxResult.Ok Then
            Me.Close()


        End If
    End Sub
End Class