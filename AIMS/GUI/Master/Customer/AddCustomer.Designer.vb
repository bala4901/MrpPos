<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCustomer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddCustomer))
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.tbAddr1 = New System.Windows.Forms.TextBox()
        Me.tbCustCode = New System.Windows.Forms.TextBox()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.ProductcaseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MrpPos = New AIMS.MrpPos()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tbCustName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ProductcaseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CancelBtn.Location = New System.Drawing.Point(525, 198)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(92, 81)
        Me.CancelBtn.TabIndex = 123
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CancelBtn.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OKButton.BackgroundImage = Global.AIMS.My.Resources.Resources.validate
        Me.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.OKButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumPurple
        Me.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple
        Me.OKButton.ForeColor = System.Drawing.Color.Black
        Me.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OKButton.Location = New System.Drawing.Point(623, 198)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(92, 81)
        Me.OKButton.TabIndex = 122
        Me.OKButton.Text = "OK"
        Me.OKButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'tbAddr1
        '
        Me.tbAddr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddr1.Location = New System.Drawing.Point(208, 90)
        Me.tbAddr1.MaxLength = 50
        Me.tbAddr1.Multiline = True
        Me.tbAddr1.Name = "tbAddr1"
        Me.tbAddr1.Size = New System.Drawing.Size(388, 99)
        Me.tbAddr1.TabIndex = 107
        '
        'tbCustCode
        '
        Me.tbCustCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCustCode.Location = New System.Drawing.Point(210, 9)
        Me.tbCustCode.MaxLength = 5
        Me.tbCustCode.Name = "tbCustCode"
        Me.tbCustCode.Size = New System.Drawing.Size(137, 35)
        Me.tbCustCode.TabIndex = 106
        '
        'lblProductCode
        '
        Me.lblProductCode.AutoSize = True
        Me.lblProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductCode.Location = New System.Drawing.Point(13, 15)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(108, 29)
        Me.lblProductCode.TabIndex = 120
        Me.lblProductCode.Text = "* Cust # :"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLabel.Location = New System.Drawing.Point(27, 96)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(127, 29)
        Me.DescriptionLabel.TabIndex = 124
        Me.DescriptionLabel.Text = "Address 1:"
        '
        'ProductcaseBindingSource
        '
        Me.ProductcaseBindingSource.DataMember = "Product_case"
        Me.ProductcaseBindingSource.DataSource = Me.MrpPos
        '
        'MrpPos
        '
        Me.MrpPos.DataSetName = "MrpPos"
        Me.MrpPos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'tbCustName
        '
        Me.tbCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCustName.Location = New System.Drawing.Point(210, 49)
        Me.tbCustName.MaxLength = 35
        Me.tbCustName.Name = "tbCustName"
        Me.tbCustName.Size = New System.Drawing.Size(388, 35)
        Me.tbCustName.TabIndex = 130
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 29)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "* Name :"
        '
        'AddCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(728, 291)
        Me.Controls.Add(Me.tbCustName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.tbAddr1)
        Me.Controls.Add(Me.tbCustCode)
        Me.Controls.Add(Me.lblProductCode)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Product"
        CType(Me.ProductcaseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents tbAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents tbCustCode As System.Windows.Forms.TextBox
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MrpPos As AIMS.MrpPos
    Friend WithEvents ProductcaseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbCustName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
