Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class PieceCaseProduct

    Public case_product_id As Integer
    Public qty_case As Integer
    Public case_product_code As String
    Public pId As String
    Public caseProd As Product_product

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Dim p As New LUNA.LunaSearchParameter("id", cbProductCode.SelectedValue)
        'Dim lst As New List(Of Product_case)
        'lst = (New Product_caseDAO).Find(p)

        'qty_case = tbQtyPerCase.Text
        'case_product_code = cbProductCode.SelectedText
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PieceCaseProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim sql As String = "SELECT product_case.id,[product_product].code, [product_case].product_id, [product_case].case_product_id, [product_case].pcs_per_case FROM [Product_case], [Product_product] "
        'sql += " WHERE [product_product].id=[product_Case].case_product_id and [product_case].product_id =" & pId

        'Dim Ls As New List(Of Product_case)
        'Try
        '    Using conn As New OleDbConnection(My.Settings.POSConnString)
        '        conn.Open()
        '        Using Command As New OleDbCommand(sql, conn)
        '            Dim myReader As OleDbDataReader = Command.ExecuteReader()
        '            While myReader.Read
        '                Dim classe As New Product_case
        '                classe.ID = myReader("ID")
        '                If Not myReader("product_id") Is DBNull.Value Then classe.product_id = myReader("product_id")
        '                If Not myReader("pcs_per_case") Is DBNull.Value Then classe.pcs_per_case = myReader("pcs_per_case")
        '                If Not myReader("case_product_id") Is DBNull.Value Then classe.case_product_id = myReader("case_product_id")
        '                If Not myReader("code") Is DBNull.Value Then classe.product_code = myReader("code")

        '                Ls.Add(classe)
        '            End While
        '            myReader.Close()

        '        End Using
        '    End Using
        '    cbProductCode.DisplayMember = "product_code"
        '    cbProductCode.ValueMember = "id"
        '    cbProductCode.DataSource = Ls


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
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

        'If Not cbProductCode.SelectedValue Is Nothing Then
        '    Dim param As New LUNA.LunaSearchParameter("id", cbProductCode.SelectedValue)
        '    Dim dao As New Product_caseDAO
        '    Dim lst As New List(Of Product_case)

        '    lst = dao.Find(param)
        '    tbQtyPerCase.Text = lst(0).pcs_per_case
        'End If
    End Sub
End Class
