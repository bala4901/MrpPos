Imports Numeria.IO
Imports System.Linq

Public Class AddCutStyle

    Public _custID As Integer = 0




    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If Not validation() Then Return
        Using db As New MrpPosEntities
            If _custID <= 0 Then
                Try
                    Dim rwCnt As Integer = (From p In db.cutstyles Select p).Count
                    Dim cut As New cutstyle
                    cut.charge = tbCharge.Text
                    cut.name = tbCutname.Text

                    If rwCnt > 0 Then
                        cut.id = db.cutstyles.Select(Function(x) x.id).Max + 1
                    Else
                        cut.id = 1
                    End If
                    db.cutstyles.AddObject(cut)
                    db.SaveChanges()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            Else
                Try
                    Dim cust As IEnumerable(Of cutstyle) = From cc In db.cutstyles Where cc.id = _custID

                    Dim custs As New List(Of cutstyle)
                    custs = cust.ToList

                    custs(0).charge = tbCharge.Text
                    custs(0).name = tbCutname.Text
         

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
        If tbCutname.Text.Length <= 0 Then
            tbCutname.Focus()
            MsgBox("Cut Name is compulsary", MsgBoxStyle.Information, "Add CutStyle")
            Return False
        End If
        If tbCharge.Text.Length <= 0 Then
            tbCharge.Focus()
            MsgBox("Charge is compulsary", MsgBoxStyle.Information, "Add CutStyle")
            Return False
        End If
        Try
            Dim testInt As Integer = tbCharge.Text
           
        Catch ex As Exception
            tbCharge.Focus()
            MsgBox("Please insert number to the charge")
        End Try
        Return True
    End Function

    Private Sub AddCutStyle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _custID > 0 Then
            Using db As New MrpPosEntities
                Dim cust As IEnumerable(Of cutstyle) = From p In db.cutstyles Where p.id = _custID
                Dim custs As List(Of cutstyle) = cust.ToList
               
                tbCutname.Text = cust(0).name
                tbCharge.Text = cust(0).charge
   

            End Using

        End If
    End Sub
End Class