Imports WeifenLuo.WinFormsUI
Imports System.Linq

Public Class CutStyleFrm
    Inherits DockContent


    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MrpPos.cutstyle' table. You can move, or remove it, as needed.
        Me.CutstyleTableAdapter.Fill(Me.MrpPos.cutstyle)
    End Sub

    Private Sub AddNewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripButton.Click
        AddCutStyle.ShowDialog()
        refreshGrid()
    End Sub

    Private Sub refreshGrid()
        Using db As New MrpPosEntities
            Dim query As IEnumerable(Of cutstyle) = From f In db.cutstyles Select f

            If query.ToList.Count > 0 Then
                ItemMasterDgv.DataSource = query.ToList
            End If
        End Using
    End Sub

    Private Sub ItemMasterDgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItemMasterDgv.CellContentClick
        Try

            If e.RowIndex >= 0 Then
                Select Case e.ColumnIndex
                    Case NameDataGridViewTextBoxColumn.Index
                        Dim customer As New AddCutStyle
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
        Dim prodcaseList As New List(Of cutstyle)

        For Each dgvRow In ItemMasterDgv.SelectedRows
            sel = dgvRow.Cells(0).Value

        Next

    End Sub

    Private Sub RefreshToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripButton.Click
        refreshGrid()
    End Sub
End Class