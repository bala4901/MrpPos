Imports System.Windows.Forms
Imports System.Linq

Public Class CaseProduct

    Public case_product_id As Integer
    Public qty_case As Integer
    Public product_code As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If validation() Then
            Dim pId As Integer = cbProductCode.SelectedValue
            case_product_id = pId
            qty_case = tbQtyPerCase.Text
            product_code = cbProductCode.Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CaseProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using db As New MrpPosEntities
            Dim products As IEnumerable(Of product_product) = From pp In db.product_product Where pp.is_case_product = 1

            cbProductCode.DataSource = products.ToList
            cbProductCode.DisplayMember = "code"
            cbProductCode.ValueMember = "id"
            cbProductCode.Refresh()
        End Using

    End Sub

    Private Function validation() As Boolean
        Try
            Dim qty As Integer = tbQtyPerCase.Text
        Catch ex As InvalidCastException
            MsgBox("Qty Per case must be integer")
            Return False
        End Try
        Return True
    End Function
End Class
