Imports WeifenLuo.WinFormsUI
Imports System.Linq

Public Class Product
    Inherits DockContent


    Private Sub AddNewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripButton.Click
        AddProduct.ShowDialog()
        refreshGrid()
    End Sub



    Private Sub Product_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call refreshGrid()
    End Sub

    Private Sub refreshGrid()
        Using db As New MrpPosEntities
            Dim query As IEnumerable(Of product_product) = From f In db.product_product Select f

            If query.ToList.Count > 0 Then
                ItemMasterDgv.DataSource = query.ToList
            End If
        End Using

    End Sub

    Private Sub RefreshToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripButton.Click
        Call refreshGrid()
    End Sub

    Private Sub ItemMasterDgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItemMasterDgv.CellContentClick
        Try


            If e.RowIndex >= 0 Then
                Select Case e.ColumnIndex
                    Case CodeDataGridViewTextBoxColumn.Index
                        Dim mProduct As New ModifyProduct
                        mProduct._prodId = Integer.Parse(ItemMasterDgv.Item(0, e.RowIndex).Value)
                        mProduct.ShowDialog()
                        refreshGrid()
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        Dim dgvRow As DataGridViewRow
        Dim sel As String = ""
        Dim prodcaseList As New List(Of product_case)

        If MsgBox("Are you sure want to delete the product?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then Return

        For Each dgvRow In ItemMasterDgv.SelectedRows
            sel = dgvRow.Cells(0).Value

            Using db As New MrpPosEntities

                Dim olLine As IEnumerable(Of mrp_order_line) = From k In db.mrp_order_line Where k.product_id = sel

                If olLine.ToList.Count > 0 Then
                    MsgBox("This product has been used for operation. Delete is not allow!", MsgBoxStyle.Information, "Delete")
                    Return
                End If

                Dim orderLine As product_product = (From ol In db.product_product Where ol.id = sel).SingleOrDefault
                db.product_product.DeleteObject(orderLine)
                db.SaveChanges()
            End Using

        Next

        Call refreshGrid()

    End Sub

End Class