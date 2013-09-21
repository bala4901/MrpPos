Imports WeifenLuo.WinFormsUI
Imports System.Linq
Imports Npgsql
Imports System.IO
Imports OpenErp.Net
Imports CookComputing.XmlRpc
Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class CaseOperation
    Inherits DockContent


    Public lotNo As String
    Public expDate As String
    Public displayExpDate As String
    Public mrpid As Integer
    Private selectImage As Bitmap
    Private imgKey As String

    Public _isLotCancel As Boolean = True

    Private _product As ProductProduct
    Private _orderId As String = ""

    Private oErp As New OpenErp.Net.Openerp



    Dim ll As New Dictionary(Of String, String)

    Private Sub PieceOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'If _isLotCancel Then
        '    Me.Close()
        'Else
        '    lblLotExp.Text = String.Format(lblLotExp.Text, lotNo, displayExpDate)
        '    pnlImageScan.Visible = False
        'End If
        'lblLotExp.Text = String.Format(lblLotExp.Text, lotNo, displayExpDate)
        lblWeight.Text = String.Format(lblWeight.Text, "0")


    End Sub


#Region "Private"


    Private Sub insertToPos(ByVal val As Decimal)
        Try

            Dim prodLotConds As New ArrayList
            Dim prodLotList As List(Of OpenErp.Net.StockProductionLot)
            Dim prodLotId As String = ""
            Dim prodLotPair As New XmlRpcStruct

            prodLotConds.Add(New String() {"name", "=", lotNo})

            prodLotList = oErp.getProdLotsList(prodLotConds)

            For Each pl As StockProductionLot In prodLotList
                If pl.product_id = _product.id Then
                    prodLotId = pl.id
                    Exit For
                End If
            Next

            If prodLotId.Length <= 0 Then
                prodLotPair.Add("name", lotNo)
                prodLotPair.Add("use_date", expDate)
                prodLotPair.Add("product_id", _product.id)
                prodLotId = oErp.addProdLot(prodLotPair)
            End If

            Dim orderHead As New XmlRpcStruct
            Dim orderLine As New XmlRpcStruct

            If _orderId.Length <= 0 Then
                orderHead.Add("prodlot_id", prodLotId)
                orderHead.Add("mrp_id", mrpid)
                _orderId = oErp.addPosOrderHead(orderHead)
            End If

            orderLine.Add("product_id", _product.id)
            orderLine.Add("order_id", _orderId)
            orderLine.Add("qty", val.ToString)
            orderLine.Add("prodlot_id", prodLotId)

            Dim orderDetailId As Integer = oErp.addPosOrderDetail(orderLine)


            Dim lst As List(Of MrpOrderLine) = setOrderLineList(_product.default_code, _product.name, lotNo, displayExpDate, val.ToString, _product.ean13)
            Dim arr As New ArrayList
            arr.Add(orderDetailId)


            printReceipt(lst)



            '  displayDataGrid()

            setTotalWeight()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub displayDataGrid(ByVal lst As List(Of MrpOrderLine))
        'Dim orderIds As New ArrayList
        'orderIds.Add(_orderId)
        'Dim orderLinesList As List(Of MrpOrderLine) = oErp.getOrderLines(orderIds)
        dgvScanning.DataSource = lst
        setTotalWeight()


    End Sub

    Private Sub printReceipt(ByVal orderLineId As List(Of MrpOrderLine))
        Dim cr As New PieceLabel

        Try


            '  Dim orderLinesList As List(Of MrpOrderLine) = oErp.getOrderLine(orderLineId)

            cr.SetDataSource(orderLineId)

            cr.PrintToPrinter(1, False, 0, 0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region


#Region "Event"

    Private Sub tbSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSearch.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

            If tbSearch.Text.Length <= 0 Then Return

            If tbSearch.Text.Substring(0, 1) = "*" Then
                If tbSearch.Text.Substring(tbSearch.Text.Length - 1) = "*" Then
                Else
                    MsgBox("Not a valid barcode")
                End If
            Else

            End If

            Dim barcode As String = ""

            Dim startName As String = tbSearch.Text.IndexOf("*")
            Dim endName As String = tbSearch.Text.LastIndexOf("*")
            If (endName > startName) Then
                barcode = tbSearch.Text.Substring(startName + 1, endName - 1)
            End If
            Dim barcodeContent As String() = Split(barcode, ",")
            Dim stockLot As List(Of StockProductionLot)

            If barcodeContent.Count < 3 Then
                MsgBox("Please scanned the correct barcode")
                Return
            End If

            Try


                If _product Is Nothing Then

                    For Each prod As ProductProduct In shareProducts
                        If barcodeContent(1) = prod.ean13.Substring(0, 5) Then
                            _product = prod

                        End If
                    Next
                    lotNo = barcodeContent(0)

                    Dim conds As New ArrayList
                    conds.Add(New String() {"name", "=", lotNo})
                    ' conds.Add(New String() {"product_id", "=", _product.id})


                    stockLot = oErp.getProdLotsList(conds)

                    If stockLot.Count > 0 Then
                        lblLotExp.Text = String.Format(lblLotExp.Text, lotNo, stockLot(0).use_date.Substring(0, 10))
                        displayExpDate = stockLot(0).use_date.Substring(0, 10)
                    Else
                        MsgBox("Lot in not found in the system")
                        Return

                    End If

                Else
                    If barcodeContent(0) <> lotNo Then
                        MsgBox("Lot No is not matching")
                        Return
                    End If

                    If barcodeContent(1) <> _product.ean13.Substring(0, 5) Then
                        MsgBox("Product code is not matching")
                        Return
                    End If
                End If

                Dim lst As List(Of MrpOrderLine) = setOrderLineLists(_product.ean13, _product.name, lotNo, displayExpDate, barcodeContent(2), _product.ean13)
                displayDataGrid(lst)

            Catch ex As Exception
                MsgBox("Some errors in the barcode, Please check")
                Return
            End Try

        End If

    End Sub



    Private Sub tbSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearch.TextChanged
        If tbSearch.Text.Trim = "Scanned Ean13 Barcode" Then
            tbSearch.Clear()
        End If

    End Sub

    Private Sub btnScalling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WeightingFrm.selectedImg = selectImage
        WeightingFrm.ShowDialog()

        If WeightingFrm.yesNo Then
            insertToPos(WeightingFrm.weightVal)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlImageScan.Visible = False
        tbSearch.Visible = True
    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        If dgvScanning.RowCount <= 0 Then
            MsgBox("No record found!", MsgBoxStyle.Information, "Information")
            Return
        End If
        Try
            Dim lst As List(Of MrpOrderLine)

            Dim dgvRow As DataGridViewRow
            Dim arr As New ArrayList
            For Each dgvRow In dgvScanning.SelectedRows
                arr.Add(dgvRow.Cells(2).Value)
                lst = setOrderLineList(_product.default_code, _product.name, lotNo, displayExpDate, dgvRow.Cells(5).Value, _product.ean13)

                printReceipt(lst)
            Next

        Catch ex As Exception

        End Try
    End Sub



#End Region

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

    Private Function setOrderLineLists(ByVal productCode As String, ByVal productName As String, ByVal lotno As String, ByVal exp As String, ByVal qty As String, ByVal ean13 As String) As List(Of MrpOrderLine)
        Dim lstOrderlines As New List(Of MrpOrderLine)


        Dim dgvRow As DataGridViewRow
        Dim cnt As Integer = 1
        For Each dgvRow In dgvScanning.Rows

            Dim orderLines As New MrpOrderLine
            orderLines.product_code = ean13.Substring(0, 5)
            orderLines.product_name = productName
            orderLines.prodlot_use_date = exp
            orderLines.qty = dgvRow.Cells(5).Value
            orderLines.prodlot_name = lotno
            orderLines.product_ean13 = ean13
            orderLines.product_id = dgvRow.Cells(2).Value
            orderLines.no = cnt
            lstOrderlines.Add(orderLines)
            cnt += 1
        Next



        Dim orderLine As New MrpOrderLine

        orderLine.product_code = ean13.Substring(0, 5)
        orderLine.product_name = productName
        orderLine.prodlot_use_date = exp
        orderLine.qty = qty
        orderLine.prodlot_name = lotno
        orderLine.product_ean13 = ean13
        orderLine.product_id = _product.id
        orderLine.no = cnt


        lstOrderlines.Add(orderLine)

        Return lstOrderlines

    End Function
    Private Sub btnWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeight.Click
        WeightingFrm.selectedImg = selectImage
        WeightingFrm.ShowDialog()

        If WeightingFrm.yesNo Then
            insertToPos(WeightingFrm.weightVal)
        End If
    End Sub

    Private Sub setTotalWeight()

        Dim ttlQty As Integer = 0
        Dim dgvRow As DataGridViewRow
        'loop through every item in DataGridView
        For Each dgvRow In dgvScanning.Rows
            ttlQty += Integer.Parse(dgvRow.Cells(5).Value)
        Next
        lblWeight.Text = ", Total Weight: " & ttlQty & " g"
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


    Private Sub btnCasePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCasePrint.Click
        Dim lst As List(Of MrpOrderLine) = setOrderLineList(_product.ean13, _product.name, lotNo, displayExpDate, getTotalWeight, _product.ean13)
        printReceipt(lst)
    End Sub
End Class