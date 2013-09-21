<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm))
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PieceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemInventoryMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.VersionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoginToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.WorkStationToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DockPanel = New WeifenLuo.WinFormsUI.DockPanel()
        Me.TopPanel.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopPanel
        '
        Me.TopPanel.Controls.Add(Me.MenuStrip)
        Me.TopPanel.Controls.Add(Me.PictureBox2)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(858, 48)
        Me.TopPanel.TabIndex = 249
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.White
        Me.MenuStrip.BackgroundImage = CType(resources.GetObject("MenuStrip.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemToolStripMenuItem, Me.PieceToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem1, Me.SummaryToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(858, 48)
        Me.MenuStrip.TabIndex = 245
        Me.MenuStrip.Text = "MenuStrip2"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordTSMI, Me.LogoutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.SystemToolStripMenuItem.ForeColor = System.Drawing.Color.Indigo
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(62, 44)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'ChangePasswordTSMI
        '
        Me.ChangePasswordTSMI.BackColor = System.Drawing.Color.MediumPurple
        Me.ChangePasswordTSMI.ForeColor = System.Drawing.Color.White
        Me.ChangePasswordTSMI.Name = "ChangePasswordTSMI"
        Me.ChangePasswordTSMI.Size = New System.Drawing.Size(173, 22)
        Me.ChangePasswordTSMI.Text = "Change password"
        Me.ChangePasswordTSMI.Visible = False
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.BackColor = System.Drawing.Color.MediumPurple
        Me.LogoutToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.BackColor = System.Drawing.Color.MediumPurple
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'PieceToolStripMenuItem
        '
        Me.PieceToolStripMenuItem.ForeColor = System.Drawing.Color.Indigo
        Me.PieceToolStripMenuItem.Name = "PieceToolStripMenuItem"
        Me.PieceToolStripMenuItem.Size = New System.Drawing.Size(59, 44)
        Me.PieceToolStripMenuItem.Text = "Scaling"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.Indigo
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(65, 44)
        Me.ToolStripMenuItem2.Text = "Barcode"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemInventoryMToolStripMenuItem})
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Indigo
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(59, 44)
        Me.ToolStripMenuItem1.Text = "Master"
        '
        'ItemInventoryMToolStripMenuItem
        '
        Me.ItemInventoryMToolStripMenuItem.BackColor = System.Drawing.Color.MediumPurple
        Me.ItemInventoryMToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemInventoryMToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ItemInventoryMToolStripMenuItem.Name = "ItemInventoryMToolStripMenuItem"
        Me.ItemInventoryMToolStripMenuItem.Size = New System.Drawing.Size(139, 24)
        Me.ItemInventoryMToolStripMenuItem.Text = "Product"
        '
        'SummaryToolStripMenuItem
        '
        Me.SummaryToolStripMenuItem.ForeColor = System.Drawing.Color.Indigo
        Me.SummaryToolStripMenuItem.Name = "SummaryToolStripMenuItem"
        Me.SummaryToolStripMenuItem.Size = New System.Drawing.Size(74, 44)
        Me.SummaryToolStripMenuItem.Text = "Summary"
        Me.SummaryToolStripMenuItem.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(858, 48)
        Me.PictureBox2.TabIndex = 248
        Me.PictureBox2.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VersionToolStripStatusLabel, Me.LoginToolStripStatusLabel, Me.WorkStationToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 498)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(858, 22)
        Me.StatusStrip1.TabIndex = 250
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'VersionToolStripStatusLabel
        '
        Me.VersionToolStripStatusLabel.Name = "VersionToolStripStatusLabel"
        Me.VersionToolStripStatusLabel.Size = New System.Drawing.Size(678, 17)
        Me.VersionToolStripStatusLabel.Spring = True
        Me.VersionToolStripStatusLabel.Text = "AIMS Version"
        Me.VersionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LoginToolStripStatusLabel
        '
        Me.LoginToolStripStatusLabel.Margin = New System.Windows.Forms.Padding(0, 3, 30, 2)
        Me.LoginToolStripStatusLabel.Name = "LoginToolStripStatusLabel"
        Me.LoginToolStripStatusLabel.Size = New System.Drawing.Size(64, 17)
        Me.LoginToolStripStatusLabel.Text = "Not Logon"
        '
        'WorkStationToolStripStatusLabel
        '
        Me.WorkStationToolStripStatusLabel.Name = "WorkStationToolStripStatusLabel"
        Me.WorkStationToolStripStatusLabel.Size = New System.Drawing.Size(71, 17)
        Me.WorkStationToolStripStatusLabel.Text = "Workstation"
        '
        'MainImageList
        '
        Me.MainImageList.ImageStream = CType(resources.GetObject("MainImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MainImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MainImageList.Images.SetKeyName(0, "unchecked.ico")
        Me.MainImageList.Images.SetKeyName(1, "checked.ico")
        '
        'DockPanel
        '
        Me.DockPanel.ActiveAutoHideContent = Nothing
        Me.DockPanel.AllowRedocking = False
        Me.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel.DocumentStyle = WeifenLuo.WinFormsUI.DocumentStyles.DockingWindow
        Me.DockPanel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.DockPanel.Location = New System.Drawing.Point(0, 48)
        Me.DockPanel.Name = "DockPanel"
        Me.DockPanel.Size = New System.Drawing.Size(858, 472)
        Me.DockPanel.TabIndex = 252
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 520)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DockPanel)
        Me.Controls.Add(Me.TopPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "BaseForm"
        Me.Tag = "MRP POS Weight"
        Me.Text = "MRP POS Weight"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TopPanel.ResumeLayout(False)
        Me.TopPanel.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TopPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents VersionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LoginToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MainImageList As System.Windows.Forms.ImageList
    Friend WithEvents DockPanel As WeifenLuo.WinFormsUI.DockPanel

    Friend WithEvents WorkStationToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel

    Friend WithEvents ChangePasswordTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PieceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemInventoryMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem

End Class
