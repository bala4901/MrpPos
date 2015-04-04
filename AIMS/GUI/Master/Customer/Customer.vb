Imports WeifenLuo.WinFormsUI
Imports System.Linq

Public Class Customer
    Inherits DockContent


    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Customer_customerTableAdapter.Fill(Me.MrpPos.customer_customer)

    End Sub

    Private Sub AddNewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripButton.Click
        AddCustomer.ShowDialog()
        refreshGrid()
    End Sub

    Private Sub refreshGrid()
        Using db As New MrpPosEntities
            Dim query As IEnumerable(Of customer_customer) = From f In db.customer_customer Select f

            If query.ToList.Count > 0 Then
                ItemMasterDgv.DataSource = query.ToList
            End If
        End Using
    End Sub

    Private Sub ItemMasterDgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItemMasterDgv.CellContentClick
        Try

            If e.RowIndex >= 0 Then
                Select Case e.ColumnIndex
                    Case CodeDataGridViewTextBoxColumn.Index
                        Dim customer As New AddCustomer
                        customer._custID = Integer.Parse(ItemMasterDgv.Item(0, e.RowIndex).Value)
                        customer.ShowDialog()
                        refreshGrid()
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        Dim dgvRow As DataGridViewRow
        Dim sel As String = ""
        Dim prodcaseList As New List(Of customer_customer)

        For Each dgvRow In ItemMasterDgv.SelectedRows
            sel = dgvRow.Cells(0).Value

        Next

    End Sub

    Private Sub RefreshToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripButton.Click
        Call refreshGrid()
    End Sub
End Class