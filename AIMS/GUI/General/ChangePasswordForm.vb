Imports System.Data.SqlClient


Public Class ChangePasswordForm

#Region "Event Handlers"

    Private Sub ChangePasswordForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserIDTb.Text = currentUserId
        OldPasswordTb.Clear()
        NewPasswordTb.Clear()
        CmfPasswordTb.Clear()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If IsUserInputValid() = True Then
            If ChangePassword(OldPasswordTb.Text.Trim, NewPasswordTb.Text.Trim) = True Then
                MsgBox("Password changed successfully.", MsgBoxStyle.Information)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

#End Region

#Region "Private Method"

    Private Function ChangePassword(ByVal oldPassword As String, ByVal newPassword As String) As Boolean
        'Dim dataAdapter As New QueriesTableAdapter
        'Try
        '    oldPassword = PasswordHash(oldPassword)
        '    newPassword = PasswordHash(newPassword)
        '    dataAdapter.ChangePassword_sp(currentUserId, oldPassword, newPassword)
        '    Return True
        'Catch sqlEx As SqlException
        '    MsgBox(sqlEx.Message, MsgBoxStyle.Exclamation)
        '    Return False
        'Catch ex As Exception
        '    Dim errorId As Long = WriteErrorLog(ex.Source, ex.Message, ex.ToString)
        '    MsgBox("Error while changing user password. Please contact your System Administrator." & vbCrLf & "Error ID: " & errorId, MsgBoxStyle.Critical, "Error encountered")
        '    Call WriteErrorLog(ex.Source, ex.Message, ex.ToString)
        '    Return False
        'Finally
        '    dataAdapter.Dispose()
        'End Try
    End Function

    Private Function IsUserInputValid() As Boolean
        IsUserInputValid = True

        If OldPasswordTb.Text.Trim = String.Empty Then
            MsgBox("Old password cannot be empty. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            OldPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If IsUserInputSafe(Trim(OldPasswordTb.Text)) = False Then
            MsgBox("Invalid value entered. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            OldPasswordTb.SelectAll()
            OldPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If NewPasswordTb.Text.Trim = String.Empty Then
            MsgBox("New password cannot be empty. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            NewPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If IsUserInputSafe(Trim(NewPasswordTb.Text)) = False Then
            MsgBox("Invalid value entered. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            NewPasswordTb.SelectAll()
            NewPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If CmfPasswordTb.Text.Trim = String.Empty Then
            MsgBox("Confirm password cannot be empty. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            CmfPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If IsUserInputSafe(Trim(CmfPasswordTb.Text)) = False Then
            MsgBox("Invalid value entered. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            CmfPasswordTb.SelectAll()
            CmfPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If NewPasswordTb.Text <> CmfPasswordTb.Text Then
            MsgBox("The new password and confirm password does not tally. Please enter again.", MsgBoxStyle.Exclamation, "Invalid Value")
            CmfPasswordTb.SelectAll()
            CmfPasswordTb.Focus()
            IsUserInputValid = False
            Exit Function
        End If

    End Function

#End Region

End Class