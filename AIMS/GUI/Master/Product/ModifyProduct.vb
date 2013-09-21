Imports Numeria.IO
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class ModifyProduct

    Private _imagePath As String = ""
    Public _prodId As Integer
    Private clearPic As Boolean = False

#Region "Events"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Try
            If validation() Then
                Dim appPath As String = getFileDbPath()
                Using db As New MrpPosEntities
                    Dim prods As IEnumerable(Of product_product) = From pp In db.product_product Where pp.id = _prodId

                    Dim products As New List(Of product_product)
                    products = prods.ToList
                    products(0).name = tbLine1.Text
                    products(0).name2 = tbLine2.Text
                    products(0).ean13 = tbEan13.Text

                    Dim caseTrue As Integer = IIf(chkCaseProduct.Checked, 1, 0)
                    products(0).is_case_product = caseTrue
                    products(0).price_per_kg = tbPrice.Text
                    products(0).day_to_expire = tbday2Expiry.Text
                    products(0).write_uid = loginUser.id
                    products(0).write_date = Now

                    ' If chkCaseProduct.Checked Then
                    products(0).no_of_barcode = tbBarcodeToPrint.Text
                   

            If _imagePath.Length > 0 Then
                If Not products(0).image Is Nothing Then
                    If products(0).image.Length > 0 Then
                        FileDB.Delete(appPath, Guid.Parse(products(0).image))
                    End If
                End If

                products(0).image = savePicture()

            End If

            If clearPic Then
                Dim ok = FileDB.Delete(appPath, Guid.Parse(products(0).image))
                products(0).image = ""
            End If

            db.product_product.ApplyCurrentValues(products(0))

            Dim prodCase As IEnumerable(Of product_case) = From pc In db.product_case Where pc.product_id = _prodId Select pc
            For Each pr As product_case In prodCase.ToList

                db.product_case.DeleteObject(pr)
            Next


            db.SaveChanges()

            If Not chkCaseProduct.Checked Then
                If dgCaseProduct.RowCount > 0 Then
                    Dim maxID As Integer = (From p In db.product_case Select p).Count
                    Dim dgvRow As DataGridViewRow
                    For Each dgvRow In dgCaseProduct.Rows
                        Dim caseProd As New product_case
                        caseProd.case_product_id = dgvRow.Cells(2).Value
                        caseProd.pcs_per_case = dgvRow.Cells(1).Value
                        caseProd.product_id = _prodId
                        caseProd.write_date = Now
                        caseProd.write_uid = loginUser.id
                        caseProd.create_date = Now
                        caseProd.create_uid = loginUser.id
                        maxID += 1
                        caseProd.id = maxID
                        db.product_case.AddObject(caseProd)
                    Next
                    db.SaveChanges()
                End If
            End If
            MsgBox("Record Save Successfully!", MsgBoxStyle.OkOnly, "Success")
            Me.Close()

                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        OpenImage()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        pbImage.Image = My.Resources.placeholder
        clearPic = True
    End Sub

    Private Sub tbProductCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbProductCode.TextChanged
        tbEan13.Text = setEAN13Code(tbProductCode.Text)
    End Sub

    Private Sub chkCaseProduct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCaseProduct.CheckedChanged
        If chkCaseProduct.Checked Then
            dgCaseProduct.Enabled = False
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            lblToPrint.Visible = True
            ' tbBarcodeToPrint.Visible = True
        Else
            dgCaseProduct.Enabled = True
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            lblToPrint.Visible = False
            '  tbBarcodeToPrint.Visible = False
        End If

        '   dgCaseProduct.Rows.Clear()

    End Sub

#End Region

#Region "Private"
    Private Sub OpenImage()
        'Set the Filter.
        OpenFileDialog1.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|BMP Files: (*.BMP;*.DIB;*.RLE)|*.BMP;*.DIB;*.RLE|JPEG Files: (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF Files: (*.GIF)|*.GIF|TIFF Files: (*.TIF;*.TIFF)|*.TIF;*.TIFF|PNG Files: (*.PNG)|*.PNG|All Files|*.*"

        'Clear the file name
        OpenFileDialog1.FileName = ""

        'Show it
        If OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            'Get the image name
            Dim img As String = OpenFileDialog1.FileName
            _imagePath = OpenFileDialog1.FileName

            'Create a new Bitmap and display it
            pbImage.Image = System.Drawing.Bitmap.FromFile(img)
            clearPic = False
        End If
    End Sub

    Private Function savePicture() As String
        Dim appPath As String = My.Application.Info.DirectoryPath & "\database\filedb.fdb"

        If Not System.IO.File.Exists(appPath) Then
            FileDB.CreateEmptyFile(appPath)
        End If

        Dim info = FileDB.Store(appPath, _imagePath)

        Return info.id.ToString
    End Function

    Private Function validation() As Boolean

        Dim errormsg As New List(Of String)
        Dim result1 As Boolean = True
        Dim result2 As Boolean = True
        Dim msg As String = ""

        If String.IsNullOrEmpty(tbProductCode.Text) Then
            errormsg.Add("Product Code cannot left empty.")
            result1 = False
        End If
        If String.IsNullOrEmpty(tbLine1.Text) Then
            errormsg.Add("Line1 cannot left empty.")
            result1 = False
        End If
        If String.IsNullOrEmpty(tbEan13.Text) Then
            errormsg.Add("Ean 13 cannot left empty.")
            result1 = False
        End If
        If String.IsNullOrEmpty(tbday2Expiry.Text) Then
            errormsg.Add("Day To Expire cannot left empty.")
            result1 = False
        End If

        If result1 Then

            Try
                Dim no_of_days As Integer = tbday2Expiry.Text

                If no_of_days <= 3 Then
                    errormsg.Add("Days to Expire must greater than 3 days.")
                End If
            Catch ex As InvalidCastException
                errormsg.Add("Days to Expire must be number.")
            End Try

            Try
                If Not String.IsNullOrEmpty(tbPrice.Text) Then
                    Dim price_per_kg As Integer = tbPrice.Text
                End If


            Catch ex As InvalidCastException
                errormsg.Add("Days to Expire must be number.")
            End Try



        End If

        Try
            Dim testInt As Integer = tbBarcodeToPrint.Text
            If testInt <= 0 Then
                tbBarcodeToPrint.Text = 1
            End If
        Catch ex As Exception
            errormsg.Add("Please insert number to the no of print")
        End Try


        If errormsg.Count > 0 Then
            For Each Err As String In errormsg
                msg += Err & vbNewLine
            Next

            MsgBox(msg)

            Return False
        End If
        Return True

    End Function




#End Region




    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim csProduct As New CaseProduct
        If csProduct.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim dgvRow As DataGridViewRow

            Dim prodcaseList As New List(Of product_case)

            Dim exists As Boolean = False

            If dgCaseProduct.RowCount > 0 Then

                For Each dgvRow In dgCaseProduct.Rows
                    Dim prod As New product_case
                    If dgvRow.Cells(2).Value = csProduct.case_product_id Then
                        prod.product_code = dgvRow.Cells(0).Value
                        prod.pcs_per_case = csProduct.qty_case
                        prod.case_product_id = dgvRow.Cells(2).Value
                        prodcaseList.Add(prod)
                        exists = True
                    Else
                        prod.product_code = dgvRow.Cells(0).Value
                        prod.pcs_per_case = dgvRow.Cells(1).Value
                        prod.case_product_id = dgvRow.Cells(2).Value
                        prodcaseList.Add(prod)
                    End If

                Next
            End If



            If Not exists Then
                Dim newprod As New product_case
                newprod.case_product_id = csProduct.case_product_id
                newprod.pcs_per_case = csProduct.qty_case
                newprod.product_code = csProduct.product_code

                prodcaseList.Add(newprod)
            End If

            dgCaseProduct.DataSource = prodcaseList
            dgCaseProduct.Refresh()

        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dgvRow As DataGridViewRow
        Dim sel As String = ""
        Dim prodcaseList As New List(Of product_case)
        If dgCaseProduct.RowCount > 0 Then
            For Each dgvRow In dgCaseProduct.SelectedRows
                sel = dgvRow.Cells(0).Value
                Exit For
            Next

            If sel.Length > 0 Then
                For Each dgvRow In dgCaseProduct.Rows
                    Dim prod As New product_case
                    If dgvRow.Cells(0).Value = sel Then
                        Continue For
                    Else
                        prod.product_code = dgvRow.Cells(0).Value
                        prod.pcs_per_case = dgvRow.Cells(1).Value
                        prod.case_product_id = dgvRow.Cells(2).Value
                        prodcaseList.Add(prod)
                    End If

                Next

                dgCaseProduct.DataSource = prodcaseList
                dgCaseProduct.Refresh()
            End If

        End If
    End Sub

    Private Sub ModifyProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appPath As String = getFileDbPath()

        Using db As New MrpPosEntities
            Dim product As IEnumerable(Of product_product) = From p In db.product_product Where p.id = _prodId
            Dim products As List(Of product_product) = product.tolist
            tbProductCode.Text = products(0).code
            tbLine1.Text = products(0).name
            tbLine2.Text = products(0).name2
            tbEan13.Text = products(0).ean13
            tbPrice.Text = product(0).price_per_kg
            tbday2Expiry.Text = products(0).day_to_expire
            tbBarcodeToPrint.Text = products(0).no_of_barcode
            tbPrice.Text = products(0).price_per_kg
            chkCaseProduct.Checked = IIf(products(0).is_case_product = 1, True, False)

            If Not products(0).image Is Nothing Then
                If products(0).image.Length > 0 Then
                    Dim outputStream As New MemoryStream
                    Dim info = FileDB.Read(appPath, Guid.Parse(products(0).image), outputStream)


                    pbImage.Image = Image.FromStream(outputStream)
                End If
            End If
            Dim product_cases As IEnumerable(Of product_case) = (From pc In db.product_case
                                                                Join pp In db.product_product
                                                                On pc.case_product_id Equals pp.id
                                                                Where pc.product_id = _prodId
                                                                Select New With {.product_code = pp.code, .pcs_per_case = pc.pcs_per_case, .case_product_id = pc.case_product_id, .product_id = pc.product_id}) _
                                                            .AsEnumerable().Select(Function(x) New product_case With {.product_code = x.product_code, .pcs_per_case = x.pcs_per_case, .case_product_id = x.case_product_id, .product_id = x.product_id})

            dgCaseProduct.DataSource = product_cases.ToList
        End Using


    End Sub

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub
End Class