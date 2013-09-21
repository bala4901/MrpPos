<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaseOperation
    Inherits WeifenLuo.WinFormsUI.DockContent

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaseOperation))
        Me.TitleToolStrip = New System.Windows.Forms.ToolStrip()
        Me.TitleToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvScanning = New System.Windows.Forms.DataGridView()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WritedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_image = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_ean13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodlot_use_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodlot_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MrpOrderLineBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlImageScan = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnCasePrint = New System.Windows.Forms.Button()
        Me.btnWeight = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnReprint = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.lblLotExp = New System.Windows.Forms.Label()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TitleToolStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvScanning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MrpOrderLineBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlImageScan.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleToolStrip
        '
        Me.TitleToolStrip.BackColor = System.Drawing.Color.Indigo
        Me.TitleToolStrip.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TitleToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TitleToolStripLabel})
        Me.TitleToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TitleToolStrip.Name = "TitleToolStrip"
        Me.TitleToolStrip.Size = New System.Drawing.Size(903, 28)
        Me.TitleToolStrip.TabIndex = 6
        Me.TitleToolStrip.Text = "ToolStrip3"
        '
        'TitleToolStripLabel
        '
        Me.TitleToolStripLabel.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleToolStripLabel.ForeColor = System.Drawing.Color.White
        Me.TitleToolStripLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TitleToolStripLabel.Name = "TitleToolStripLabel"
        Me.TitleToolStripLabel.Size = New System.Drawing.Size(182, 25)
        Me.TitleToolStripLabel.Text = "Case Scanning"
        Me.TitleToolStripLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(903, 600)
        Me.Panel1.TabIndex = 7
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvScanning)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(903, 600)
        Me.SplitContainer1.SplitterDistance = 301
        Me.SplitContainer1.TabIndex = 0
        '
        'dgvScanning
        '
        Me.dgvScanning.AllowUserToAddRows = False
        Me.dgvScanning.AllowUserToDeleteRows = False
        Me.dgvScanning.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvScanning.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvScanning.AutoGenerateColumns = False
        Me.dgvScanning.BackgroundColor = System.Drawing.Color.White
        Me.dgvScanning.ColumnHeadersHeight = 28
        Me.dgvScanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvScanning.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.NoDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn, Me.product_name, Me.product_code, Me.QtyDataGridViewTextBoxColumn, Me.CreatedateDataGridViewTextBoxColumn, Me.WritedateDataGridViewTextBoxColumn, Me.OrderidDataGridViewTextBoxColumn, Me.product_image, Me.product_ean13, Me.prodlot_use_date, Me.prodlot_id})
        Me.dgvScanning.DataSource = Me.MrpOrderLineBindingSource3
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvScanning.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvScanning.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvScanning.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvScanning.Location = New System.Drawing.Point(0, 0)
        Me.dgvScanning.MultiSelect = False
        Me.dgvScanning.Name = "dgvScanning"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvScanning.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvScanning.RowHeadersVisible = False
        Me.dgvScanning.RowHeadersWidth = 70
        Me.dgvScanning.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Cyan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvScanning.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvScanning.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvScanning.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvScanning.RowTemplate.Height = 24
        Me.dgvScanning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvScanning.ShowEditingIcon = False
        Me.dgvScanning.Size = New System.Drawing.Size(301, 600)
        Me.dgvScanning.StandardTab = True
        Me.dgvScanning.TabIndex = 1
        Me.dgvScanning.TabStop = False
        Me.dgvScanning.VirtualMode = True
        '
        'check
        '
        Me.check.DataPropertyName = "check"
        Me.check.FalseValue = "0"
        Me.check.Frozen = True
        Me.check.HeaderText = ""
        Me.check.Name = "check"
        Me.check.TrueValue = "1"
        Me.check.Visible = False
        Me.check.Width = 30
        '
        'NoDataGridViewTextBoxColumn
        '
        Me.NoDataGridViewTextBoxColumn.DataPropertyName = "no"
        Me.NoDataGridViewTextBoxColumn.HeaderText = "No."
        Me.NoDataGridViewTextBoxColumn.Name = "NoDataGridViewTextBoxColumn"
        Me.NoDataGridViewTextBoxColumn.Width = 70
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'product_name
        '
        Me.product_name.DataPropertyName = "product_name"
        Me.product_name.HeaderText = "Name"
        Me.product_name.Name = "product_name"
        '
        'product_code
        '
        Me.product_code.DataPropertyName = "product_code"
        Me.product_code.HeaderText = "Code"
        Me.product_code.Name = "product_code"
        '
        'QtyDataGridViewTextBoxColumn
        '
        Me.QtyDataGridViewTextBoxColumn.DataPropertyName = "qty"
        Me.QtyDataGridViewTextBoxColumn.HeaderText = "Qty"
        Me.QtyDataGridViewTextBoxColumn.Name = "QtyDataGridViewTextBoxColumn"
        '
        'CreatedateDataGridViewTextBoxColumn
        '
        Me.CreatedateDataGridViewTextBoxColumn.DataPropertyName = "create_date"
        Me.CreatedateDataGridViewTextBoxColumn.HeaderText = "create_date"
        Me.CreatedateDataGridViewTextBoxColumn.Name = "CreatedateDataGridViewTextBoxColumn"
        Me.CreatedateDataGridViewTextBoxColumn.Visible = False
        '
        'WritedateDataGridViewTextBoxColumn
        '
        Me.WritedateDataGridViewTextBoxColumn.DataPropertyName = "write_date"
        Me.WritedateDataGridViewTextBoxColumn.HeaderText = "write_date"
        Me.WritedateDataGridViewTextBoxColumn.Name = "WritedateDataGridViewTextBoxColumn"
        Me.WritedateDataGridViewTextBoxColumn.Visible = False
        '
        'OrderidDataGridViewTextBoxColumn
        '
        Me.OrderidDataGridViewTextBoxColumn.DataPropertyName = "order_id"
        Me.OrderidDataGridViewTextBoxColumn.HeaderText = "order_id"
        Me.OrderidDataGridViewTextBoxColumn.Name = "OrderidDataGridViewTextBoxColumn"
        Me.OrderidDataGridViewTextBoxColumn.Visible = False
        '
        'product_image
        '
        Me.product_image.DataPropertyName = "product_image"
        Me.product_image.HeaderText = "product_image"
        Me.product_image.Name = "product_image"
        Me.product_image.Visible = False
        '
        'product_ean13
        '
        Me.product_ean13.DataPropertyName = "product_ean13"
        Me.product_ean13.HeaderText = "product_ean13"
        Me.product_ean13.Name = "product_ean13"
        Me.product_ean13.Visible = False
        '
        'prodlot_use_date
        '
        Me.prodlot_use_date.DataPropertyName = "prodlot_use_date"
        Me.prodlot_use_date.HeaderText = "prodlot_use_date"
        Me.prodlot_use_date.Name = "prodlot_use_date"
        Me.prodlot_use_date.Visible = False
        '
        'prodlot_id
        '
        Me.prodlot_id.DataPropertyName = "prodlot_id"
        Me.prodlot_id.HeaderText = "prodlot_id"
        Me.prodlot_id.Name = "prodlot_id"
        Me.prodlot_id.Visible = False
        '
        'MrpOrderLineBindingSource3
        '
        Me.MrpOrderLineBindingSource3.DataSource = GetType(OpenErp.Net.MrpOrderLine)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pnlImageScan)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(598, 570)
        Me.Panel4.TabIndex = 5
        '
        'pnlImageScan
        '
        Me.pnlImageScan.BackgroundImage = Global.AIMS.My.Resources.Resources.shopsavvy_icon
        Me.pnlImageScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlImageScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImageScan.Controls.Add(Me.Panel5)
        Me.pnlImageScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlImageScan.Location = New System.Drawing.Point(0, 0)
        Me.pnlImageScan.Name = "pnlImageScan"
        Me.pnlImageScan.Size = New System.Drawing.Size(598, 570)
        Me.pnlImageScan.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnCasePrint)
        Me.Panel5.Controls.Add(Me.btnWeight)
        Me.Panel5.Controls.Add(Me.btnCancel)
        Me.Panel5.Controls.Add(Me.btnReprint)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 468)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(596, 100)
        Me.Panel5.TabIndex = 12
        '
        'btnCasePrint
        '
        Me.btnCasePrint.BackgroundImage = Global.AIMS.My.Resources.Resources.Box_icon
        Me.btnCasePrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCasePrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCasePrint.Location = New System.Drawing.Point(198, 0)
        Me.btnCasePrint.Name = "btnCasePrint"
        Me.btnCasePrint.Size = New System.Drawing.Size(99, 98)
        Me.btnCasePrint.TabIndex = 4
        Me.btnCasePrint.Text = "Case Print"
        Me.btnCasePrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCasePrint.UseVisualStyleBackColor = True
        '
        'btnWeight
        '
        Me.btnWeight.BackgroundImage = Global.AIMS.My.Resources.Resources.scale_48x48
        Me.btnWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnWeight.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnWeight.Location = New System.Drawing.Point(99, 0)
        Me.btnWeight.Name = "btnWeight"
        Me.btnWeight.Size = New System.Drawing.Size(99, 98)
        Me.btnWeight.TabIndex = 3
        Me.btnWeight.Text = "Weight Scale"
        Me.btnWeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWeight.UseVisualStyleBackColor = True
        Me.btnWeight.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.AIMS.My.Resources.Resources.cancel_icon
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(495, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 98)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnReprint
        '
        Me.btnReprint.BackgroundImage = Global.AIMS.My.Resources.Resources.printer
        Me.btnReprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReprint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnReprint.Location = New System.Drawing.Point(0, 0)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(99, 98)
        Me.btnReprint.TabIndex = 1
        Me.btnReprint.Text = "Reprint"
        Me.btnReprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReprint.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.lblWeight)
        Me.Panel3.Controls.Add(Me.lblLotExp)
        Me.Panel3.Controls.Add(Me.tbSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(598, 30)
        Me.Panel3.TabIndex = 4
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblWeight.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblWeight.Location = New System.Drawing.Point(191, 0)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(153, 17)
        Me.lblWeight.TabIndex = 10
        Me.lblWeight.Text = ", Total Weight: {0} g"
        '
        'lblLotExp
        '
        Me.lblLotExp.AutoSize = True
        Me.lblLotExp.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblLotExp.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblLotExp.Location = New System.Drawing.Point(0, 0)
        Me.lblLotExp.Name = "lblLotExp"
        Me.lblLotExp.Size = New System.Drawing.Size(191, 17)
        Me.lblLotExp.TabIndex = 9
        Me.lblLotExp.Text = "Lot No : {0} - [ Exp: {1} ]"
        '
        'tbSearch
        '
        Me.tbSearch.BackColor = System.Drawing.Color.LightCyan
        Me.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.tbSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbSearch.Location = New System.Drawing.Point(358, 0)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(236, 23)
        Me.tbSearch.TabIndex = 8
        Me.tbSearch.Text = "Scanned Ean13 Barcode"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Location = New System.Drawing.Point(0, 467)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(598, 133)
        Me.Panel2.TabIndex = 3
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(117, 109)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'CaseOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(903, 628)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TitleToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CaseOperation"
        Me.TabText = "Case Operation"
        Me.Text = "Case Operation"
        Me.TitleToolStrip.ResumeLayout(False)
        Me.TitleToolStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvScanning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MrpOrderLineBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.pnlImageScan.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TitleToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TitleToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvScanning As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblLotExp As System.Windows.Forms.Label
    Friend WithEvents pnlImageScan As System.Windows.Forms.Panel
    Friend WithEvents ProducteanDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MrpOrderLineBindingSource3 As System.Windows.Forms.BindingSource
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnReprint As System.Windows.Forms.Button
    Friend WithEvents btnWeight As System.Windows.Forms.Button
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WritedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_image As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_ean13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodlot_use_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodlot_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCasePrint As System.Windows.Forms.Button
    Friend WithEvents lblWeight As System.Windows.Forms.Label
End Class
