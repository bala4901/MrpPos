<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePasswordForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePasswordForm))
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.UserIDTb = New System.Windows.Forms.TextBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.OldPasswordTb = New System.Windows.Forms.TextBox()
        Me.CmfPasswordTb = New System.Windows.Forms.TextBox()
        Me.lblCurrentPassword = New System.Windows.Forms.Label()
        Me.NewPasswordTb = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.OKButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumPurple
        Me.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple
        Me.OKButton.ForeColor = System.Drawing.Color.Black
        Me.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OKButton.Location = New System.Drawing.Point(249, 159)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(92, 29)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CloseButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumPurple
        Me.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple
        Me.CloseButton.ForeColor = System.Drawing.Color.Black
        Me.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloseButton.Location = New System.Drawing.Point(151, 159)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(92, 29)
        Me.CloseButton.TabIndex = 4
        Me.CloseButton.Text = "Cancel"
        Me.CloseButton.UseVisualStyleBackColor = False
        '
        'UserIDTb
        '
        Me.UserIDTb.BackColor = System.Drawing.SystemColors.Control
        Me.UserIDTb.Location = New System.Drawing.Point(132, 27)
        Me.UserIDTb.MaxLength = 20
        Me.UserIDTb.Name = "UserIDTb"
        Me.UserIDTb.ReadOnly = True
        Me.UserIDTb.Size = New System.Drawing.Size(168, 21)
        Me.UserIDTb.TabIndex = 329
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUserID.Location = New System.Drawing.Point(26, 31)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(50, 13)
        Me.lblUserID.TabIndex = 328
        Me.lblUserID.Text = "User ID :"
        Me.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OldPasswordTb
        '
        Me.OldPasswordTb.BackColor = System.Drawing.SystemColors.Window
        Me.OldPasswordTb.Location = New System.Drawing.Point(132, 58)
        Me.OldPasswordTb.MaxLength = 15
        Me.OldPasswordTb.Name = "OldPasswordTb"
        Me.OldPasswordTb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.OldPasswordTb.Size = New System.Drawing.Size(168, 21)
        Me.OldPasswordTb.TabIndex = 0
        '
        'CmfPasswordTb
        '
        Me.CmfPasswordTb.Location = New System.Drawing.Point(132, 114)
        Me.CmfPasswordTb.MaxLength = 15
        Me.CmfPasswordTb.Name = "CmfPasswordTb"
        Me.CmfPasswordTb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.CmfPasswordTb.Size = New System.Drawing.Size(168, 21)
        Me.CmfPasswordTb.TabIndex = 2
        '
        'lblCurrentPassword
        '
        Me.lblCurrentPassword.AutoSize = True
        Me.lblCurrentPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentPassword.Location = New System.Drawing.Point(26, 62)
        Me.lblCurrentPassword.Name = "lblCurrentPassword"
        Me.lblCurrentPassword.Size = New System.Drawing.Size(79, 13)
        Me.lblCurrentPassword.TabIndex = 326
        Me.lblCurrentPassword.Text = "Old Password :"
        Me.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NewPasswordTb
        '
        Me.NewPasswordTb.Location = New System.Drawing.Point(132, 86)
        Me.NewPasswordTb.MaxLength = 15
        Me.NewPasswordTb.Name = "NewPasswordTb"
        Me.NewPasswordTb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.NewPasswordTb.Size = New System.Drawing.Size(168, 21)
        Me.NewPasswordTb.TabIndex = 1
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblNewPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNewPassword.Location = New System.Drawing.Point(26, 90)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(84, 13)
        Me.lblNewPassword.TabIndex = 325
        Me.lblNewPassword.Text = "New Password :"
        Me.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblConfirmPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConfirmPassword.Location = New System.Drawing.Point(26, 118)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(100, 13)
        Me.lblConfirmPassword.TabIndex = 327
        Me.lblConfirmPassword.Text = "Confirm Password :"
        Me.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChangePasswordForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(355, 200)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.UserIDTb)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.OldPasswordTb)
        Me.Controls.Add(Me.CmfPasswordTb)
        Me.Controls.Add(Me.lblCurrentPassword)
        Me.Controls.Add(Me.NewPasswordTb)
        Me.Controls.Add(Me.lblNewPassword)
        Me.Controls.Add(Me.lblConfirmPassword)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ChangePasswordForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents UserIDTb As System.Windows.Forms.TextBox
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents OldPasswordTb As System.Windows.Forms.TextBox
    Friend WithEvents CmfPasswordTb As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentPassword As System.Windows.Forms.Label
    Friend WithEvents NewPasswordTb As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label
End Class
