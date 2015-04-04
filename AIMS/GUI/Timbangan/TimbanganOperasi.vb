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


Public Class TimbanganOperasi
    Inherits DockContent

    Private _loadCBCustomer As Boolean = False
    Private _loadCBCutstyle As Boolean = False
    Private _loadCBProduct As Boolean = False

    Private _groupSales As String = Nothing
    Private _customerID As Integer = 0
    Private _cutId As Integer = 0

    Private _summaryText1 As String = ""
    Private _summaryText2 As String = ""

    Dim WithEvents Port As SerialPort = New SerialPort(My.Settings.Comport _
                                                  , My.Settings.baudrate _
                                                  , My.Settings.parity _
                                                  , My.Settings.databits _
                                                  , My.Settings.stopbits)

    Private Delegate Sub SetTextCallback(ByVal text As String)

#Region "Form Events"

    Private Sub TimbanganOperasi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure want to Exit from weighting?", MsgBoxStyle.OkCancel, "Information") = MsgBoxResult.Ok Then
            If Port.IsOpen Then Port.Close()
        Else
            Return


        End If
    End Sub
    Private Sub TimbanganOperasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call registerOperation()
        Call loadCBCustomer()
        Call loadCBCutstyle()
        Call loadCBProduct()
        ' Call cbProduct_SelectedIndexChanged(sender, e)

        If Port.IsOpen Then Port.Close()
        tbWeight.Text = "000"

        refreshSalesGV()

    End Sub



#End Region
#Region "GUI"

    Private Sub loadCBCustomer()
        Using db As New MrpPosEntities
            Dim cust As IEnumerable(Of customer_customer) = From pp In db.customer_customer Order By pp.name

            cbCustomer.DataSource = cust.ToList
            cbCustomer.DisplayMember = "name"
            cbCustomer.ValueMember = "id"
            cbCustomer.Refresh()

            _loadCBCustomer = True
        End Using
    End Sub
    Private Sub loadCBCutstyle()
        Using db As New MrpPosEntities
            Dim cut As IEnumerable(Of cutstyle) = From pp In db.cutstyles Order By pp.name

            cbCutStyle.DataSource = cut.ToList
            cbCutStyle.DisplayMember = "name"
            cbCutStyle.ValueMember = "id"
            cbCutStyle.Refresh()

            _loadCBCustomer = True
        End Using
    End Sub

    Private Sub loadCBProduct()
        Using db As New MrpPosEntities
            Dim query As IEnumerable(Of product_product) = From p In db.product_product Where p.is_case_product = False Order By p.name Select p

            cbProduct.DataSource = query.ToList
            cbProduct.DisplayMember = "name"
            cbProduct.ValueMember = "id"
            cbProduct.Refresh()

            _loadCBProduct = True

        End Using
    End Sub




    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _customerID = cbCustomer.SelectedValue
        _cutId = cbCutStyle.SelectedValue
        Call TimbangOperation()

    End Sub

    Private Sub registerOperation()
        pnlImageScan.Visible = True
        pnlOperation.Visible = False

        btnNext.Visible = True
        btnBack.Visible = False
        btnReprint.Visible = False
        btnCancel.Visible = False
        btnDelete.Visible = False
        btnWeight.Enabled = False
        btnValidateWeight.Enabled = False
    End Sub


    Private Sub TimbangOperation()

        pnlOperation.Visible = True

        pnlImageScan.Visible = True
        btnNext.Visible = False
        btnBack.Visible = True
        btnReprint.Visible = True
        btnCancel.Visible = True
        btnDelete.Visible = True
        btnWeight.Enabled = True
        btnValidateWeight.Enabled = True
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Call registerOperation()
    End Sub

   
#End Region

#Region "RS232 Method"

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

    Private Sub btnWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeight.Click
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



   

        If _groupSales Is Nothing Then
            _groupSales = getGroupSales()
        End If

        Dim salesId As Integer = createSales()
        Call createPrintLabel(salesId)


        Call refreshSalesGV()
        Try
            Call printlabel()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ''Complete Weighting
        tbWeight.BackColor = Color.FromKnownColor(KnownColor.Window)
        tbWeight.Text = "000"
        'Call refreshOrderLineGrid()
        'Call refreshBoxListGrid()
        'Call setSummary()

        'Call printLabel(lines.ToADOTable())
        'Call printCaseLabel()
    End Sub

    Private Function getGroupSales() As String
        Return Guid.NewGuid.ToString
    End Function

    Private Function createSales() As Integer
        Dim id As Integer = 0
        Dim productID As Integer = cbProduct.SelectedValue
        Using db As New MrpPosEntities
            Dim rwCnt As Integer = (From p In db.timbangan_sales Select p).Count
            Dim prodS As IEnumerable(Of product_product) = From ol In db.product_product Where ol.id = productID Select ol

            Dim cutS As IEnumerable(Of cutstyle) = From ol In db.cutstyles Where ol.id = _cutId

            If prodS.ToList.Count <= 0 Then
                MsgBox("no record found")
            End If
            Dim prod As List(Of product_product) = prodS.ToList

            Dim cut As List(Of cutstyle) = cutS.ToList


            Dim sales As New timbangan_sales
            If rwCnt > 0 Then
                id = getNextId(db.timbangan_sales.Select(Function(x) x.id).Max)

            Else
                id = 1
            End If

            sales.id = id
            sales.create_date = Now
            sales.write_date = Now
            sales.write_id = loginUser.id
            sales.create_id = loginUser.id
            sales.customer_id = cbCustomer.SelectedValue
            sales.cut_id = cbCutStyle.SelectedValue
            sales.group_sale = _groupSales
            sales.product_id = cbProduct.SelectedValue
            sales.price = getUnitPrice(prod(0).price_per_kg)
            sales.qty = tbWeight.Text
            sales.total_price = calculatePrice(tbWeight.Text, prod(0).price_per_kg, cut(0).charge)

            db.timbangan_sales.AddObject(sales)
            db.SaveChanges()

            Return id
        End Using
    End Function

    Private Sub createPrintLabel(ByVal referenceID As Integer)
        Dim id As Integer = 0
        Dim productID As Integer = cbProduct.SelectedValue
        Using db As New MrpPosEntities

            Dim rwCnt As Integer = (From p In db.labelprintsales Select p).Count
            Dim prodS As IEnumerable(Of product_product) = From ol In db.product_product Where ol.id = productID


            Dim custS As IEnumerable(Of customer_customer) = From ol In db.customer_customer Where ol.id = _customerID


            Dim cutS As IEnumerable(Of cutstyle) = From ol In db.cutstyles Where ol.id = _cutId


            If rwCnt > 0 Then
                id = getNextId(db.timbangan_sales.Select(Function(x) x.id).Max)
            Else
                id = 1
            End If


            Dim cust As List(Of customer_customer) = custS.ToList
            Dim cut As List(Of cutstyle) = cutS.ToList
            Dim prod As List(Of product_product) = prodS.ToList

            Dim barcode As String = ""
            Dim prefix As String = "21"
            Dim code As String = prod(0).code
            Dim weight As String = tbWeight.Text.PadLeft(5, "0"c)
            Dim bc As String = setEAN13CodeSales(prefix & code & weight)
            barcode = setEAN13CodeFont1(bc)


            Dim label As New labelprintsale
            label.id = id
            label.is_print = 0
            label.label_type = "TIMBANGAN"
            label.postal_code = cust(0).kode_pos
            label.price_per_kg = prod(0).price_per_kg
            label.product_id = prod(0).id
            label.product_name = prod(0).name
            label.product_code = prod(0).code
            label.quantity = tbWeight.Text
            label.sum_price = calculatePrice(tbWeight.Text, prod(0).price_per_kg, cut(0).charge)
            label.reference_id = referenceID
            label.unit_price = getUnitPrice(prod(0).price_per_kg)
            label.uom = "g"
            label.write_by = loginUser.id
            label.write_on = Now
            label.create_by = loginUser.id
            label.create_on = Now
            label.address1 = cust(0).address1
            label.address2 = cust(0).address2
            label.comment = cust(0).comment
            label.customer_id = cust(0).id
            label.customer_name = cust(0).name
            label.cust_code = cust(0).code
            label.cut_id = cut(0).id
            label.cut_name = cut(0).name
            label.cut_charges = cut(0).charge
            label.ean_code = barcode

            db.labelprintsales.AddObject(label)
            db.SaveChanges()

        End Using


    End Sub

    Private Function calculatePrice(ByVal qty As Decimal, ByVal price_per_kg As Decimal, ByVal charge As Decimal) As Decimal
        Dim unitprice As Decimal = getUnitPrice(price_per_kg)
        Return formatDecimal((qty * unitprice) + charge)
    End Function

    Private Function getUnitPrice(ByVal price_per_kg As Decimal) As Decimal
        Return formatDecimal(price_per_kg / 1000)
    End Function


    Private Sub refreshSalesGV()
        If _groupSales Is Nothing Then Return

        Using db As New MrpPosEntities
            Dim rwCnt As Integer = (From p In db.timbangan_sales Select p).Count
            Dim saless As IEnumerable(Of labelprintsale) = From ol In db.labelprintsales
                                                           Join ss In db.timbangan_sales On ol.reference_id Equals ss.id
                                                           Where ss.group_sale = _groupSales Select ol
            Dim salesLst As List(Of labelprintsale) = saless.ToList
            salesGV.DataSource = salesLst
            salesGV.Refresh()
        End Using


    End Sub

    Private Sub printlabel()

        Using db As New MrpPosEntities
            Dim lines As IEnumerable(Of labelprintsale) = From ol In db.labelprintsales Where ol.is_print = 0 And ol.label_type = "TIMBANGAN"

            Using cr As New Sales1Customer


                Try

                    cr.SetDataSource(lines.ToADOTable)

                    cr.PrintToPrinter(1, False, 0, 0)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Using
            Using cr1 As New Sales1Kasir


                Try

                    cr1.SetDataSource(lines.ToADOTable)

                    cr1.PrintToPrinter(1, False, 0, 0)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Using

            Dim line As List(Of labelprintsale) = lines.ToList
            For Each l As labelprintsale In line
                l.is_print = 1
                l.printed_on = Now
                l.write_on = Now
                l.write_by = loginUser.id
                db.SaveChanges()
            Next
        End Using



    End Sub

    Private Sub printlabel(ByVal id As Integer)

        Using db As New MrpPosEntities
            Dim lines As IEnumerable(Of labelprintsale) = From ol In db.labelprintsales Where ol.id = id And ol.label_type = "TIMBANGAN"

            Using cr As New Sales1Customer


                Try

                    cr.SetDataSource(lines.ToADOTable)

                    cr.PrintToPrinter(1, False, 0, 0)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Using
            Using cr1 As New Sales1Kasir


                Try

                    cr1.SetDataSource(lines.ToADOTable)

                    cr1.PrintToPrinter(1, False, 0, 0)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Using
            Dim line As List(Of labelprintsale) = lines.ToList
            For Each l As labelprintsale In line
                l.is_print = 1
                l.printed_on = Now
                l.write_on = Now
                l.write_by = loginUser.id
                db.SaveChanges()
            Next
        End Using



    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        If MsgBox("Are you sure to reprint the checked record(s)? ", MsgBoxStyle.YesNo, "Reprint") = MsgBoxResult.Yes Then

            Dim cnt As Integer = 0
            Dim selectedRowCount As Integer = salesGV.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim currentRow As DataGridViewRow = salesGV.SelectedRows(0)
                Dim id As Integer = currentRow.Cells(1).Value
                Call printlabel(id)
            End If
            

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub



    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
            Using db As New MrpPosEntities
                Dim cnt As Integer = 0
                Dim selectedRowCount As Integer = salesGV.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If selectedRowCount > 0 Then
                    Dim currentRow As DataGridViewRow = salesGV.SelectedRows(0)
                    Dim id As Integer = currentRow.Cells(1).Value
                    Dim pid As Integer = currentRow.Cells(0).Value
                    Dim orderLine As timbangan_sales = (From ol In db.timbangan_sales Where ol.id = id).SingleOrDefault
                    Dim labelPrint As labelprintsale = (From ol In db.labelprintsales Where ol.id = pid).SingleOrDefault

                    db.timbangan_sales.DeleteObject(orderLine)
                    db.labelprintsales.DeleteObject(labelPrint)
                    db.SaveChanges()
                    Call refreshSalesGV()
                Else
                    MsgBox("Please select a record to delete!", MsgBoxStyle.Information, "Delete Weight")
                End If
               
            End Using
        End If
    End Sub


End Class