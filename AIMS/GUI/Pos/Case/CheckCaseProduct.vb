Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Linq

Public Class CheckCaseProduct

    Public case_product_id As Integer
    Public qty_case As Integer
    Public case_product_code As String
    Public pId As String
    Public caseProd As product_product

    Public prd_id As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Using db As New MrpPosEntities
            Dim pc As product_case = (From p In db.product_case Where p.id = cbProductCode.SelectedValue).FirstOrDefault
            case_product_id = pc.product_id
        End Using

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PieceCaseProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using db As New MrpPosEntities
            Dim prod As IEnumerable(Of product_product) = (From pc In db.product_case
                                                          Join p In db.product_product On pc.case_product_id Equals p.id
                                                          Where p.id = prd_id
                                                          Select New With {.id = pc.id, .code = p.code}) _
                                                      .AsEnumerable().Select(Function(x) New product_product With {.id = x.id, .code = x.code})


            cbProductCode.DataSource = prod
            cbProductCode.ValueMember = "id"
            cbProductCode.DisplayMember = "code"
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

    Private Sub cbProductCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductCode.SelectedIndexChanged

        If Not cbProductCode.SelectedValue Is Nothing Then
            Dim val As Integer = cbProductCode.SelectedValue
            Using db As New MrpPosEntities
                Dim pcase As product_case = (From p In db.product_case Where p.id = val).FirstOrDefault

                tbQtyPerCase.Text = pcase.pcs_per_case
            End Using
 
        End If
    End Sub
End Class
