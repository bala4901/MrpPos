<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LotFrm))
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCasePack = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPrice = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelBtn.BackgroundImage = Global.AIMS.My.Resources.Resources.cancel_icon
        Me.CancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CancelBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumPurple
        Me.CancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple
        Me.CancelBtn.ForeColor = System.Drawing.Color.Black
        Me.CancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CancelBtn.Location = New System.Drawing.Point(427, 208)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(92, 75)
        Me.CancelBtn.TabIndex = 111
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CancelBtn.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OKButton.BackgroundImage = Global.AIMS.My.Resources.Resources.go_next
        Me.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.OKButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumPurple
        Me.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple
        Me.OKButton.ForeColor = System.Drawing.Color.Black
        Me.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OKButton.Location = New System.Drawing.Point(525, 208)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(92, 75)
        Me.OKButton.TabIndex = 110
        Me.OKButton.Text = "Next"
        Me.OKButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'txtLotNo
        '
        Me.txtLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNo.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotNo.Location = New System.Drawing.Point(307, 11)
        Me.txtLotNo.MaxLength = 8
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(308, 50)
        Me.txtLotNo.TabIndex = 107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 42)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "* Lot No :"
        '
        'cbCasePack
        '
        Me.cbCasePack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCasePack.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCasePack.FormattingEnabled = True
        Me.cbCasePack.Items.AddRange(New Object() {"By Pcs", "By Case"})
        Me.cbCasePack.Location = New System.Drawing.Point(307, 75)
        Me.cbCasePack.Name = "cbCasePack"
        Me.cbCasePack.Size = New System.Drawing.Size(171, 50)
        Me.cbCasePack.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 42)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "* How to Pack :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(228, 42)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "* Print Price :"
        '
        'cbPrice
        '
        Me.cbPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPrice.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPrice.FormattingEnabled = True
        Me.cbPrice.Items.AddRange(New Object() {"No", "Yes"})
        Me.cbPrice.Location = New System.Drawing.Point(307, 144)
        Me.cbPrice.Name = "cbPrice"
        Me.cbPrice.Size = New System.Drawing.Size(171, 50)
        Me.cbPrice.TabIndex = 120
        '
        'LotFrm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(625, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbPrice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbCasePack)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.txtLotNo)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LotFrm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCasePack As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbPrice As System.Windows.Forms.ComboBox
End Class
