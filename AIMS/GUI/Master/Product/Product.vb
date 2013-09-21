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
        'Dim p As New LUNA.LunaSearchOption
        'p.OrderBy = "code"

        'Dim products As New List(Of Product_product)

        'products = (New Product_productDAO).GetAll("code")
        'ItemMasterDgv.DataSource = products
    End Sub

    Private Sub RefreshToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripButton.Click
        Call refreshGrid()
    End Sub

    Private Sub ItemMasterDgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItemMasterDgv.CellContentClick
        Try

     
            If e.RowIndex >= 0 Then
                Select e.ColumnIndex
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
        Dim prodcaseList As New List(Of Product_case)

        For Each dgvRow In ItemMasterDgv.SelectedRows
            sel = dgvRow.Cells(0).Value

        Next

    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Product_productTableAdapter.FillBy(Me.MrpPos.product_product)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Product_productTableAdapter.Fill(Me.MrpPos.product_product)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class