Imports Numeria.IO
Imports System.Linq

Public Class AddProduct

    Private _imagePath As String = ""

#Region "Events"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Try
            If validation() Then
                Using context As New MrpPosEntities

                    Dim rwCnt As Integer = (From p In context.product_product Select p).Count

                    Dim product As New product_product
                    product.code = tbProductCode.Text
                    product.name = tbLine1.Text
                    product.name2 = tbLine2.Text
                    product.ean13 = tbEan13.Text

                    Dim caseTrue As Integer = IIf(chkCaseProduct.Checked, 1, 0)

                    product.no_of_barcode = tbBarcodeToPrint.Text

                    product.is_case_product = caseTrue
                    product.price_per_kg = tbPrice.Text
                    product.day_to_expire = tbday2Expiry.Text
                    product.write_uid = loginUser.id
                    product.create_uid = loginUser.id
                    product.write_date = Now
                    product.create_date = Now
                    If rwCnt > 0 Then
                        product.id = context.product_product.Select(Function(x) x.id).Max + 1
                    Else
                        product.id = 1
                    End If

                    If _imagePath.Length > 0 Then
                        product.image = savePicture()
                    End If

                    context.product_product.AddObject(product)



                    If Not chkCaseProduct.Checked Then
                        If dgCaseProduct.RowCount > 0 Then
                            Dim maxID As Integer = context.product_case.Select(Function(x) x.id).Max + 1
                            'context.product_case.Select(Function(x) x.id).Max
                            Dim dgvRow As DataGridViewRow
                            For Each dgvRow In dgCaseProduct.Rows
                                Dim caseProd As New product_case
                                caseProd.case_product_id = dgvRow.Cells(2).Value
                                caseProd.pcs_per_case = dgvRow.Cells(1).Value
                                caseProd.product_id = product.id
                                caseProd.write_date = Now
                                caseProd.write_uid = loginUser.id
                                caseProd.create_date = Now
                                caseProd.create_uid = loginUser.id
                                '  maxID += 1

                                caseProd.id = maxID


                                context.product_case.AddObject(caseProd)

                            Next
                        End If




                    End If
                    context.SaveChanges()
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
    End Sub

    Private Sub tbProductCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbProductCode.TextChanged
        tbEan13.Text = setEAN13Code(tbProductCode.Text)
    End Sub

    Private Sub chkCaseProduct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCaseProduct.CheckedChanged
        If chkCaseProduct.Checked Then
            dgCaseProduct.Enabled = False
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            lblToPrint.Visible = False
            ' tbBarcodeToPrint.Visible = False
        Else
            dgCaseProduct.Enabled = True
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            lblToPrint.Visible = True
            '    tbBarcodeToPrint.Visible = True
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
            Dim prod As New MrpPosEntities
            Dim p As IEnumerable(Of product_product) = From pr In prod.product_product Where pr.code = tbProductCode.Text

            If p.ToList.Count > 0 Then
                errormsg.Add("This product code was added before.")
            End If

            Dim p1 As IEnumerable(Of product_product) = From pr In prod.product_product Where pr.ean13 = tbEan13.Text
            If p1.ToList.Count > 0 Then
                errormsg.Add("This product code was added before.")
            End If


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
                Else
                    tbPrice.Text = 0
                End If


            Catch ex As InvalidCastException
                errormsg.Add("Days to Expire must be number.")
            End Try

            Try
                Dim intProd As Integer = tbProductCode.Text


            Catch ex As InvalidCastException
                errormsg.Add("Product Code must be Number.")
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
                        '  prod.product_code = dgvRow.Cells(0).Value
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

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub

    Private Sub tbBarcodeToPrint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBarcodeToPrint.TextChanged

    End Sub
End Class