Imports Numeria.IO
Imports System.Linq

Public Class AddCustomer

    Public _custID As Integer = 0

    Private _maxAddressLines As Integer = 4


    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If Not validation() Then Return
        Using db As New MrpPosEntities
            If _custID <= 0 Then
                Try
                    Dim rwCnt As Integer = (From p In db.customer_customer Select p).Count
                    Dim customer As New customer_customer
                    customer.address1 = tbAddr1.Text
                    ' customer.address2 = tbAddr2.Text
                    customer.code = tbCustCode.Text
                    ' customer.comment = tbMessage.Text
                    ' customer.kode_pos = tbPosCode.Text
                    customer.created_date = Now
                    customer.write_date = Now
                    customer.name = tbCustName.Text
                    If rwCnt > 0 Then
                        customer.id = db.customer_customer.Select(Function(x) x.id).Max + 1
                    Else
                        customer.id = 1
                    End If
                    db.customer_customer.AddObject(customer)
                    db.SaveChanges()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            Else
                Try
                    Dim cust As IEnumerable(Of customer_customer) = From cc In db.customer_customer Where cc.id = _custID

                    Dim custs As New List(Of customer_customer)
                    custs = cust.ToList

                    custs(0).name = tbCustName.Text
                    custs(0).code = tbCustCode.Text
                    custs(0).address1 = tbAddr1.Text
                    '  custs(0).address2 = tbAddr2.Text
                    '  custs(0).kode_pos = tbPosCode.Text
                    custs(0).write_date = Now
                    '  custs(0).comment = tbMessage.Text

                    db.SaveChanges()


                    MsgBox("Record Save Successfully!", MsgBoxStyle.OkOnly, "Success")

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            Me.Close()
        End Using
    End Sub


    Private Function validation() As Boolean
        If tbCustCode.Text.Length <= 0 Then
            tbCustCode.Focus()
            MsgBox("Cust# is compulsary", MsgBoxStyle.Information, "Add Customer")
            Return False
        End If
        If tbCustName.Text.Length <= 0 Then
            tbCustName.Focus()
            MsgBox("Cust Name is compulsary", MsgBoxStyle.Information, "Add Customer")
            Return False
        End If

        Return True
    End Function

    Private Sub AddCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _custID > 0 Then
            Using db As New MrpPosEntities
                Dim cust As IEnumerable(Of customer_customer) = From p In db.customer_customer Where p.id = _custID
                Dim custs As List(Of customer_customer) = cust.ToList
                tbAddr1.Text = custs(0).address1
                ' tbAddr2.Text = custs(0).address2
                tbCustCode.Text = cust(0).code
                tbCustName.Text = cust(0).name
                ' tbMessage.Text = cust(0).comment
                ' tbPosCode.Text = cust(0).kode_pos


            End Using

        End If
    End Sub

    Private Sub tbAddr1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbAddr1.KeyPress
        If Me.tbAddr1.Lines.Length >= _maxAddressLines & e.KeyChar = "\r" Then
            e.Handled = True
        End If



    End Sub


    Private Sub tbAddr1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbAddr1.TextChanged
        If Me.tbAddr1.Lines.Length > _maxAddressLines Then
            Me.tbAddr1.Undo()
            Me.tbAddr1.ClearUndo()
            MsgBox("Only " & _maxAddressLines & " lines are allowed.")
        End If
    End Sub
End Class