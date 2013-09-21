
Option Explicit On

Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO

Public Class tcDebug

    Public Function writelog(ByVal csvString As String) As Boolean
        Dim filename As String
        filename = "c:\tanchong" & Format(Now(), "yyyyMMdd")

        Try

            Using fileWriter As New StreamWriter(filename, True)
                fileWriter.WriteLine("[" & Now() & "]" & " " & csvString)
                fileWriter.Flush()
            End Using

            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function
End Class


