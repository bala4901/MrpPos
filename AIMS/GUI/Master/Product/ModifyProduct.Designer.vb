<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModifyProduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModifyProduct))
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.tbLine1 = New System.Windows.Forms.TextBox()
        Me.tbLine2 = New System.Windows.Forms.TextBox()
        Me.tbProductCode = New System.Windows.Forms.TextBox()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.MaxLocationQtyLabel = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbEan13 = New System.Windows.Forms.TextBox()
        Me.tbPrice = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.chkCaseProduct = New System.Windows.Forms.CheckBox()
        Me.tbday2Expiry = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgCaseProduct = New System.Windows.Forms.DataGridView()
        Me.ProductcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PcspercaseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseproductidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductcaseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MrpPos = New AIMS.MrpPos()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tbBarcodeToPrint = New System.Windows.Forms.TextBox()
        Me.lblToPrint = New System.Windows.Forms.Label()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCaseProduct, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CancelBtn.Location = New System.Drawing.Point(525, 296)
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
        Me.OKButton.Location = New System.Drawing.Point(623, 296)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(92, 81)
        Me.OKButton.TabIndex = 122
        Me.OKButton.Text = "OK"
        Me.OKButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'tbLine1
        '
        Me.tbLine1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLine1.Location = New System.Drawing.Point(210, 49)
        Me.tbLine1.MaxLength = 35
        Me.tbLine1.Name = "tbLine1"
        Me.tbLine1.Size = New System.Drawing.Size(388, 35)
        Me.tbLine1.TabIndex = 107
        '
        'tbLine2
        '
        Me.tbLine2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLine2.Location = New System.Drawing.Point(210, 87)
        Me.tbLine2.MaxLength = 35
        Me.tbLine2.Name = "tbLine2"
        Me.tbLine2.Size = New System.Drawing.Size(388, 35)
        Me.tbLine2.TabIndex = 108
        '
        'tbProductCode
        '
        Me.tbProductCode.Enabled = False
        Me.tbProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProductCode.Location = New System.Drawing.Point(210, 9)
        Me.tbProductCode.MaxLength = 5
        Me.tbProductCode.Name = "tbProductCode"
        Me.tbProductCode.Size = New System.Drawing.Size(137, 35)
        Me.tbProductCode.TabIndex = 106
        '
        'lblProductCode
        '
        Me.lblProductCode.AutoSize = True
        Me.lblProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductCode.Location = New System.Drawing.Point(13, 15)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(189, 29)
        Me.lblProductCode.TabIndex = 120
        Me.lblProductCode.Text = "* Product Code :"
        '
        'MaxLocationQtyLabel
        '
        Me.MaxLocationQtyLabel.AutoSize = True
        Me.MaxLocationQtyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxLocationQtyLabel.Location = New System.Drawing.Point(23, 90)
        Me.MaxLocationQtyLabel.Name = "MaxLocationQtyLabel"
        Me.MaxLocationQtyLabel.Size = New System.Drawing.Size(96, 29)
        Me.MaxLocationQtyLabel.TabIndex = 125
        Me.MaxLocationQtyLabel.Text = " Line 2 :"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLabel.Location = New System.Drawing.Point(15, 55)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(106, 29)
        Me.DescriptionLabel.TabIndex = 124
        Me.DescriptionLabel.Text = "* Line 1 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 29)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Barcode :"
        '
        'tbEan13
        '
        Me.tbEan13.Enabled = False
        Me.tbEan13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEan13.Location = New System.Drawing.Point(210, 125)
        Me.tbEan13.MaxLength = 16
        Me.tbEan13.Name = "tbEan13"
        Me.tbEan13.Size = New System.Drawing.Size(188, 35)
        Me.tbEan13.TabIndex = 127
        '
        'tbPrice
        '
        Me.tbPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrice.Location = New System.Drawing.Point(210, 162)
        Me.tbPrice.MaxLength = 7
        Me.tbPrice.Name = "tbPrice"
        Me.tbPrice.Size = New System.Drawing.Size(137, 35)
        Me.tbPrice.TabIndex = 129
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 29)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Price/Kg :"
        '
        'pbImage
        '
        Me.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbImage.Image = Global.AIMS.My.Resources.Resources.placeholder
        Me.pbImage.InitialImage = Global.AIMS.My.Resources.Resources.placeholder
        Me.pbImage.Location = New System.Drawing.Point(604, 9)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(117, 109)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImage.TabIndex = 130
        Me.pbImage.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLoad.Location = New System.Drawing.Point(604, 125)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(47, 46)
        Me.btnLoad.TabIndex = 131
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Location = New System.Drawing.Point(658, 125)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(63, 46)
        Me.btnClear.TabIndex = 132
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'chkCaseProduct
        '
        Me.chkCaseProduct.AutoSize = True
        Me.chkCaseProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCaseProduct.Location = New System.Drawing.Point(372, 9)
        Me.chkCaseProduct.Name = "chkCaseProduct"
        Me.chkCaseProduct.Size = New System.Drawing.Size(177, 33)
        Me.chkCaseProduct.TabIndex = 133
        Me.chkCaseProduct.Text = "Case Product"
        Me.chkCaseProduct.UseVisualStyleBackColor = True
        '
        'tbday2Expiry
        '
        Me.tbday2Expiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbday2Expiry.Location = New System.Drawing.Point(210, 201)
        Me.tbday2Expiry.MaxLength = 4
        Me.tbday2Expiry.Name = "tbday2Expiry"
        Me.tbday2Expiry.Size = New System.Drawing.Size(137, 35)
        Me.tbday2Expiry.TabIndex = 135
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 29)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Day To Expire :"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.AIMS.My.Resources.Resources.add
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAdd.Location = New System.Drawing.Point(354, 252)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 60)
        Me.btnAdd.TabIndex = 137
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgCaseProduct
        '
        Me.dgCaseProduct.AllowUserToAddRows = False
        Me.dgCaseProduct.AllowUserToDeleteRows = False
        Me.dgCaseProduct.AutoGenerateColumns = False
        Me.dgCaseProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCaseProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductcodeDataGridViewTextBoxColumn, Me.PcspercaseDataGridViewTextBoxColumn, Me.CaseproductidDataGridViewTextBoxColumn, Me.ProductidDataGridViewTextBoxColumn})
        Me.dgCaseProduct.DataSource = Me.ProductcaseBindingSource
        Me.dgCaseProduct.Location = New System.Drawing.Point(28, 252)
        Me.dgCaseProduct.Name = "dgCaseProduct"
        Me.dgCaseProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCaseProduct.Size = New System.Drawing.Size(319, 126)
        Me.dgCaseProduct.TabIndex = 136
        '
        'ProductcodeDataGridViewTextBoxColumn
        '
        Me.ProductcodeDataGridViewTextBoxColumn.DataPropertyName = "product_code"
        Me.ProductcodeDataGridViewTextBoxColumn.HeaderText = "Product Code"
        Me.ProductcodeDataGridViewTextBoxColumn.Name = "ProductcodeDataGridViewTextBoxColumn"
        '
        'PcspercaseDataGridViewTextBoxColumn
        '
        Me.PcspercaseDataGridViewTextBoxColumn.DataPropertyName = "pcs_per_case"
        Me.PcspercaseDataGridViewTextBoxColumn.HeaderText = "No. Pcs per Case"
        Me.PcspercaseDataGridViewTextBoxColumn.Name = "PcspercaseDataGridViewTextBoxColumn"
        Me.PcspercaseDataGridViewTextBoxColumn.Width = 150
        '
        'CaseproductidDataGridViewTextBoxColumn
        '
        Me.CaseproductidDataGridViewTextBoxColumn.DataPropertyName = "case_product_id"
        Me.CaseproductidDataGridViewTextBoxColumn.HeaderText = "case_product_id"
        Me.CaseproductidDataGridViewTextBoxColumn.Name = "CaseproductidDataGridViewTextBoxColumn"
        Me.CaseproductidDataGridViewTextBoxColumn.Visible = False
        '
        'ProductidDataGridViewTextBoxColumn
        '
        Me.ProductidDataGridViewTextBoxColumn.DataPropertyName = "product_id"
        Me.ProductidDataGridViewTextBoxColumn.HeaderText = "product_id"
        Me.ProductidDataGridViewTextBoxColumn.Name = "ProductidDataGridViewTextBoxColumn"
        Me.ProductidDataGridViewTextBoxColumn.Visible = False
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
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.AIMS.My.Resources.Resources.clear
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelete.Location = New System.Drawing.Point(353, 318)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 60)
        Me.btnDelete.TabIndex = 138
        Me.btnDelete.Text = "Remove"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'tbBarcodeToPrint
        '
        Me.tbBarcodeToPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBarcodeToPrint.Location = New System.Drawing.Point(623, 195)
        Me.tbBarcodeToPrint.MaxLength = 1
        Me.tbBarcodeToPrint.Name = "tbBarcodeToPrint"
        Me.tbBarcodeToPrint.Size = New System.Drawing.Size(63, 35)
        Me.tbBarcodeToPrint.TabIndex = 142
        Me.tbBarcodeToPrint.Text = "1"
        '
        'lblToPrint
        '
        Me.lblToPrint.AutoSize = True
        Me.lblToPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToPrint.Location = New System.Drawing.Point(353, 201)
        Me.lblToPrint.Name = "lblToPrint"
        Me.lblToPrint.Size = New System.Drawing.Size(278, 29)
        Me.lblToPrint.TabIndex = 141
        Me.lblToPrint.Text = "No. Case Label to Print : "
        '
        'ModifyProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(728, 389)
        Me.Controls.Add(Me.tbBarcodeToPrint)
        Me.Controls.Add(Me.lblToPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgCaseProduct)
        Me.Controls.Add(Me.tbday2Expiry)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkCaseProduct)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.pbImage)
        Me.Controls.Add(Me.tbPrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbEan13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.tbLine1)
        Me.Controls.Add(Me.tbLine2)
        Me.Controls.Add(Me.tbProductCode)
        Me.Controls.Add(Me.lblProductCode)
        Me.Controls.Add(Me.MaxLocationQtyLabel)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ModifyProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Product"
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCaseProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductcaseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents tbLine1 As System.Windows.Forms.TextBox
    Friend WithEvents tbLine2 As System.Windows.Forms.TextBox
    Friend WithEvents tbProductCode As System.Windows.Forms.TextBox
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents MaxLocationQtyLabel As System.Windows.Forms.Label
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbEan13 As System.Windows.Forms.TextBox
    Friend WithEvents tbPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents chkCaseProduct As System.Windows.Forms.CheckBox
    Friend WithEvents tbday2Expiry As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgCaseProduct As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MrpPos As AIMS.MrpPos
    Friend WithEvents ProductcodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PcspercaseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseproductidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductcaseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbBarcodeToPrint As System.Windows.Forms.TextBox
    Friend WithEvents lblToPrint As System.Windows.Forms.Label
End Class
