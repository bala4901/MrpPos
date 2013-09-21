<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WeightingFrm
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
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.picDisplay = New System.Windows.Forms.PictureBox()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbWeight
        '
        Me.tbWeight.Enabled = False
        Me.tbWeight.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbWeight.Location = New System.Drawing.Point(12, 7)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(244, 85)
        Me.tbWeight.TabIndex = 1
        Me.tbWeight.Text = "912"
        Me.tbWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picDisplay
        '
        Me.picDisplay.Location = New System.Drawing.Point(12, 103)
        Me.picDisplay.Name = "picDisplay"
        Me.picDisplay.Size = New System.Drawing.Size(155, 206)
        Me.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDisplay.TabIndex = 2
        Me.picDisplay.TabStop = False
        '
        'btnValidate
        '
        Me.btnValidate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnValidate.Image = Global.AIMS.My.Resources.Resources.validate
        Me.btnValidate.Location = New System.Drawing.Point(173, 103)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(119, 121)
        Me.btnValidate.TabIndex = 2
        Me.btnValidate.Text = "Validate"
        Me.btnValidate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = Global.AIMS.My.Resources.Resources.cancel_icon
        Me.btnClose.Location = New System.Drawing.Point(173, 230)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(119, 79)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Cancel"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(262, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 58)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "g"
        '
        'WeightingFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(305, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.picDisplay)
        Me.Controls.Add(Me.tbWeight)
        Me.Controls.Add(Me.btnValidate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WeightingFrm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents picDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
