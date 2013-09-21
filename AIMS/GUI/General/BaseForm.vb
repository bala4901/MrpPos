Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI
Imports VS2005Extender

Public Class BaseForm

    Private m_ChildFormNumber As Integer = 0
    Private oDefaultRenderer As New ToolStripProfessionalRenderer(New PropertyGridEx.CustomColorScheme)

#Region "Public Methods"

    Public Sub ShowForm(ByVal form As Form)
        Cursor.Current = Cursors.AppStarting
        DockPanel.Visible = False
        If form.CanFocus = False Then
            form.MdiParent = Me
            If form.WindowState <> FormWindowState.Maximized Then form.WindowState = FormWindowState.Maximized
            form.Show()
        Else
            form.Focus()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ShowTabForm(ByVal form As WeifenLuo.WinFormsUI.DockContent)
        DockPanel.Visible = True
        m_ChildFormNumber += 1
        form.Show(DockPanel)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub Base_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuStrip.Visible = False
        VersionToolStripStatusLabel.Text = System.String.Format(VersionToolStripStatusLabel.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        ' Apply a gray professional renderer as a default renderer
        ToolStripManager.Renderer = oDefaultRenderer
        oDefaultRenderer.RoundedEdges = True

        ' Set DockPanel properties
        DockPanel.ActiveAutoHideContent = Nothing
        DockPanel.Parent = Me
        VS2005Style.Extender.SetSchema(DockPanel, VS2005Style.Extender.Schema.FromBase)

        'set Workstation ID
        WorkStationToolStripStatusLabel.Text = "Workstation " & My.Settings.CurrentWorkstationID

        Call ShowForm(LoginForm)

        VersionToolStripStatusLabel.Text = System.String.Format(LoginForm.Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Call ShowForm(LoginForm)
    End Sub

#End Region

    Private Sub ChangePasswordTSMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordTSMI.Click
        ChangePasswordForm.Show()
    End Sub


    Private Sub PieceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PieceToolStripMenuItem.Click
        Call ShowTabForm(PieceOperation)
    End Sub

    Private Sub summaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem.Click
        Call ShowTabForm(PieceSummary)
        ' DailySummary.ShowDialog()
    End Sub

    Private Sub ItemInventoryMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemInventoryMToolStripMenuItem.Click
        Call ShowTabForm(Product)
    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class