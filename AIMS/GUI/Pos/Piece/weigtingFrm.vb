Imports System.IO.Ports

Public Class WeightingFrm

    Public selectedImg As Bitmap
    Public weightVal As Decimal

    Public yesNo As Boolean

    Dim WithEvents Port As SerialPort = New SerialPort(My.Settings.Comport _
                                                       , My.Settings.baudrate _
                                                       , My.Settings.parity _
                                                       , My.Settings.databits _
                                                       , My.Settings.stopbits)

    Private Sub WeightingFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picDisplay.Image = selectedImg
        Try
            If Port.IsOpen = False Then Port.Open()
        Catch ex As Exception

            'MsgBox(ex.Message)
            'Me.Close()
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        yesNo = False
        If Port.IsOpen = True Then Port.Close()
        Me.Close()
    End Sub

    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        yesNo = True
        weightVal = tbWeight.Text
        If Port.IsOpen = True Then Port.Close()
        Me.Close()
    End Sub

    Private Sub startScalling()

    End Sub

    Private Sub port_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Port.DataReceived
        Dim ll As String = ""
        Try
            ll = Port.ReadTo("ST0")
            ' tbWeight.Text = 0
        Catch ex As Exception
            Try
                If Port.IsOpen = False Then Port.Open()
            Catch ex1 As Exception

            End Try

        End Try

        Dim val As Integer
        Try
            val = Trim(ll).Replace(".", "")
            If tbWeight.Text <> val Then
                SetText(val)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Delegate Sub SetTextCallback(ByVal text As String)

    Private Sub SetText(ByVal text As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.tbWeight.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {text})
        Else
            Me.tbWeight.Text = text
        End If
    End Sub



End Class