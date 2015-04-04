<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimbanganOperasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimbanganOperasi))
        Me.TitleToolStrip = New System.Windows.Forms.ToolStrip()
        Me.TitleToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlImageScan = New System.Windows.Forms.Panel()
        Me.pnlRegister = New System.Windows.Forms.Panel()
        Me.pnlOperation = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.salesGV = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.checkColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ProductnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EancodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceperkgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitpriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SumpriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelprintsalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MrpPos = New AIMS.MrpPos()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbProduct = New System.Windows.Forms.ComboBox()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCutStyle = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnReprint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lvProductImage = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pctWeightImage = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnWeight = New System.Windows.Forms.Button()
        Me.btnValidateWeight = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TitleToolStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlImageScan.SuspendLayout()
        Me.pnlRegister.SuspendLayout()
        Me.pnlOperation.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.salesGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelprintsalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pctWeightImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TitleToolStrip.Size = New System.Drawing.Size(1135, 28)
        Me.TitleToolStrip.TabIndex = 6
        Me.TitleToolStrip.Text = "ToolStrip3"
        '
        'TitleToolStripLabel
        '
        Me.TitleToolStripLabel.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleToolStripLabel.ForeColor = System.Drawing.Color.White
        Me.TitleToolStripLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TitleToolStripLabel.Name = "TitleToolStripLabel"
        Me.TitleToolStripLabel.Size = New System.Drawing.Size(267, 25)
        Me.TitleToolStripLabel.Text = "Timbangan Operation"
        Me.TitleToolStripLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 600)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1135, 600)
        Me.SplitContainer1.SplitterDistance = 740
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pnlImageScan)
        Me.Panel4.Controls.Add(Me.lvProductImage)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(740, 600)
        Me.Panel4.TabIndex = 5
        '
        'pnlImageScan
        '
        Me.pnlImageScan.BackgroundImage = Global.AIMS.My.Resources.Resources.scale_320x320
        Me.pnlImageScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlImageScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImageScan.Controls.Add(Me.pnlRegister)
        Me.pnlImageScan.Controls.Add(Me.Panel5)
        Me.pnlImageScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlImageScan.Location = New System.Drawing.Point(0, 0)
        Me.pnlImageScan.Name = "pnlImageScan"
        Me.pnlImageScan.Size = New System.Drawing.Size(740, 600)
        Me.pnlImageScan.TabIndex = 3
        Me.pnlImageScan.Visible = False
        '
        'pnlRegister
        '
        Me.pnlRegister.Controls.Add(Me.pnlOperation)
        Me.pnlRegister.Controls.Add(Me.cbCustomer)
        Me.pnlRegister.Controls.Add(Me.Label3)
        Me.pnlRegister.Controls.Add(Me.cbCutStyle)
        Me.pnlRegister.Controls.Add(Me.Label2)
        Me.pnlRegister.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRegister.Location = New System.Drawing.Point(0, 0)
        Me.pnlRegister.Name = "pnlRegister"
        Me.pnlRegister.Size = New System.Drawing.Size(738, 498)
        Me.pnlRegister.TabIndex = 13
        '
        'pnlOperation
        '
        Me.pnlOperation.Controls.Add(Me.Panel10)
        Me.pnlOperation.Controls.Add(Me.Panel9)
        Me.pnlOperation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOperation.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperation.Name = "pnlOperation"
        Me.pnlOperation.Size = New System.Drawing.Size(738, 498)
        Me.pnlOperation.TabIndex = 135
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.salesGV)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 89)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(738, 409)
        Me.Panel10.TabIndex = 139
        '
        'salesGV
        '
        Me.salesGV.AllowUserToAddRows = False
        Me.salesGV.AllowUserToDeleteRows = False
        Me.salesGV.AllowUserToResizeRows = False
        Me.salesGV.AutoGenerateColumns = False
        Me.salesGV.BackgroundColor = System.Drawing.Color.White
        Me.salesGV.ColumnHeadersHeight = 34
        Me.salesGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.salesGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.ReferenceidDataGridViewTextBoxColumn, Me.checkColumn, Me.ProductnameDataGridViewTextBoxColumn, Me.ProductcodeDataGridViewTextBoxColumn, Me.EancodeDataGridViewTextBoxColumn, Me.PriceperkgDataGridViewTextBoxColumn, Me.UnitpriceDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn, Me.SumpriceDataGridViewTextBoxColumn})
        Me.salesGV.DataSource = Me.LabelprintsalesBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.salesGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.salesGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.salesGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.salesGV.Location = New System.Drawing.Point(0, 0)
        Me.salesGV.MultiSelect = False
        Me.salesGV.Name = "salesGV"
        Me.salesGV.RowHeadersVisible = False
        Me.salesGV.RowHeadersWidth = 70
        Me.salesGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.salesGV.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.salesGV.RowTemplate.Height = 34
        Me.salesGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.salesGV.ShowEditingIcon = False
        Me.salesGV.Size = New System.Drawing.Size(738, 409)
        Me.salesGV.StandardTab = True
        Me.salesGV.TabIndex = 10
        Me.salesGV.TabStop = False
        Me.salesGV.VirtualMode = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'ReferenceidDataGridViewTextBoxColumn
        '
        Me.ReferenceidDataGridViewTextBoxColumn.DataPropertyName = "reference_id"
        Me.ReferenceidDataGridViewTextBoxColumn.HeaderText = "reference_id"
        Me.ReferenceidDataGridViewTextBoxColumn.Name = "ReferenceidDataGridViewTextBoxColumn"
        Me.ReferenceidDataGridViewTextBoxColumn.Visible = False
        '
        'checkColumn
        '
        Me.checkColumn.DataPropertyName = "check"
        Me.checkColumn.FalseValue = ""
        Me.checkColumn.HeaderText = ""
        Me.checkColumn.Name = "checkColumn"
        Me.checkColumn.TrueValue = ""
        Me.checkColumn.Width = 35
        '
        'ProductnameDataGridViewTextBoxColumn
        '
        Me.ProductnameDataGridViewTextBoxColumn.DataPropertyName = "product_name"
        Me.ProductnameDataGridViewTextBoxColumn.HeaderText = "P.Name"
        Me.ProductnameDataGridViewTextBoxColumn.Name = "ProductnameDataGridViewTextBoxColumn"
        '
        'ProductcodeDataGridViewTextBoxColumn
        '
        Me.ProductcodeDataGridViewTextBoxColumn.DataPropertyName = "product_code"
        Me.ProductcodeDataGridViewTextBoxColumn.HeaderText = "P.Code"
        Me.ProductcodeDataGridViewTextBoxColumn.Name = "ProductcodeDataGridViewTextBoxColumn"
        '
        'EancodeDataGridViewTextBoxColumn
        '
        Me.EancodeDataGridViewTextBoxColumn.DataPropertyName = "ean_code"
        Me.EancodeDataGridViewTextBoxColumn.HeaderText = "Barcode"
        Me.EancodeDataGridViewTextBoxColumn.Name = "EancodeDataGridViewTextBoxColumn"
        Me.EancodeDataGridViewTextBoxColumn.Visible = False
        '
        'PriceperkgDataGridViewTextBoxColumn
        '
        Me.PriceperkgDataGridViewTextBoxColumn.DataPropertyName = "price_per_kg"
        Me.PriceperkgDataGridViewTextBoxColumn.HeaderText = "Price/Kg"
        Me.PriceperkgDataGridViewTextBoxColumn.Name = "PriceperkgDataGridViewTextBoxColumn"
        '
        'UnitpriceDataGridViewTextBoxColumn
        '
        Me.UnitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price"
        Me.UnitpriceDataGridViewTextBoxColumn.HeaderText = "Price/g"
        Me.UnitpriceDataGridViewTextBoxColumn.Name = "UnitpriceDataGridViewTextBoxColumn"
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Weight"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        '
        'SumpriceDataGridViewTextBoxColumn
        '
        Me.SumpriceDataGridViewTextBoxColumn.DataPropertyName = "sum_price"
        Me.SumpriceDataGridViewTextBoxColumn.HeaderText = "Total Price"
        Me.SumpriceDataGridViewTextBoxColumn.Name = "SumpriceDataGridViewTextBoxColumn"
        '
        'LabelprintsalesBindingSource
        '
        Me.LabelprintsalesBindingSource.DataMember = "labelprintsales"
        Me.LabelprintsalesBindingSource.DataSource = Me.MrpPos
        '
        'MrpPos
        '
        Me.MrpPos.DataSetName = "MrpPos"
        Me.MrpPos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label4)
        Me.Panel9.Controls.Add(Me.cbProduct)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(738, 89)
        Me.Panel9.TabIndex = 138
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 42)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "* Product :"
        '
        'cbProduct
        '
        Me.cbProduct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbProduct.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Location = New System.Drawing.Point(249, 19)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(362, 50)
        Me.cbProduct.TabIndex = 138
        '
        'cbCustomer
        '
        Me.cbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCustomer.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Items.AddRange(New Object() {"By Pcs", "By Case"})
        Me.cbCustomer.Location = New System.Drawing.Point(306, 15)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(362, 50)
        Me.cbCustomer.TabIndex = 134
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 42)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "* Cut Style :"
        '
        'cbCutStyle
        '
        Me.cbCutStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCutStyle.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCutStyle.FormattingEnabled = True
        Me.cbCutStyle.Items.AddRange(New Object() {"By Pcs", "By Case"})
        Me.cbCutStyle.Location = New System.Drawing.Point(306, 71)
        Me.cbCutStyle.Name = "cbCutStyle"
        Me.cbCutStyle.Size = New System.Drawing.Size(172, 50)
        Me.cbCutStyle.TabIndex = 123
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 42)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "* Customer :"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnReprint)
        Me.Panel5.Controls.Add(Me.btnDelete)
        Me.Panel5.Controls.Add(Me.btnNext)
        Me.Panel5.Controls.Add(Me.btnBack)
        Me.Panel5.Controls.Add(Me.btnCancel)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 498)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(738, 100)
        Me.Panel5.TabIndex = 12
        '
        'btnReprint
        '
        Me.btnReprint.BackgroundImage = Global.AIMS.My.Resources.Resources.printer
        Me.btnReprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReprint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnReprint.Location = New System.Drawing.Point(297, 0)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(99, 98)
        Me.btnReprint.TabIndex = 11
        Me.btnReprint.Text = "Reprint"
        Me.btnReprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReprint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.AIMS.My.Resources.Resources.Gnome_edit_delete_svg
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDelete.Location = New System.Drawing.Point(198, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 98)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.BackgroundImage = Global.AIMS.My.Resources.Resources.go_next
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNext.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnNext.Location = New System.Drawing.Point(99, 0)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(99, 98)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Next"
        Me.btnNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.AIMS.My.Resources.Resources.go_previous
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBack.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBack.Location = New System.Drawing.Point(0, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(99, 98)
        Me.btnBack.TabIndex = 6
        Me.btnBack.Text = "Previous"
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.AIMS.My.Resources.Resources.cancel_icon
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(637, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 98)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lvProductImage
        '
        Me.lvProductImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProductImage.Location = New System.Drawing.Point(0, 0)
        Me.lvProductImage.Name = "lvProductImage"
        Me.lvProductImage.Size = New System.Drawing.Size(740, 600)
        Me.lvProductImage.TabIndex = 2
        Me.lvProductImage.UseCompatibleStateImageBehavior = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Panel7)
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 222)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(391, 378)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Weigther"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pctWeightImage)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(385, 158)
        Me.Panel2.TabIndex = 5
        '
        'pctWeightImage
        '
        Me.pctWeightImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctWeightImage.Location = New System.Drawing.Point(127, 0)
        Me.pctWeightImage.Name = "pctWeightImage"
        Me.pctWeightImage.Size = New System.Drawing.Size(131, 158)
        Me.pctWeightImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctWeightImage.TabIndex = 0
        Me.pctWeightImage.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(258, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(127, 158)
        Me.Panel8.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(127, 158)
        Me.Panel3.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.tbWeight)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 174)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(385, 100)
        Me.Panel7.TabIndex = 4
        '
        'tbWeight
        '
        Me.tbWeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbWeight.Enabled = False
        Me.tbWeight.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbWeight.Location = New System.Drawing.Point(0, 0)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(330, 85)
        Me.tbWeight.TabIndex = 2
        Me.tbWeight.Text = "000"
        Me.tbWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(330, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 58)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "g"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnWeight)
        Me.Panel6.Controls.Add(Me.btnValidateWeight)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 274)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(385, 101)
        Me.Panel6.TabIndex = 3
        '
        'btnWeight
        '
        Me.btnWeight.BackgroundImage = Global.AIMS.My.Resources.Resources.scale_48x48
        Me.btnWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnWeight.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnWeight.Location = New System.Drawing.Point(99, 0)
        Me.btnWeight.Name = "btnWeight"
        Me.btnWeight.Size = New System.Drawing.Size(99, 101)
        Me.btnWeight.TabIndex = 7
        Me.btnWeight.Text = "Weight Scale"
        Me.btnWeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWeight.UseVisualStyleBackColor = True
        '
        'btnValidateWeight
        '
        Me.btnValidateWeight.BackgroundImage = Global.AIMS.My.Resources.Resources.validate
        Me.btnValidateWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnValidateWeight.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnValidateWeight.Location = New System.Drawing.Point(0, 0)
        Me.btnValidateWeight.Name = "btnValidateWeight"
        Me.btnValidateWeight.Size = New System.Drawing.Size(99, 101)
        Me.btnValidateWeight.TabIndex = 5
        Me.btnValidateWeight.Text = "Validate"
        Me.btnValidateWeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnValidateWeight.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 222)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Summary"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 16)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(385, 203)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(117, 109)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'TimbanganOperasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1135, 628)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TitleToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TimbanganOperasi"
        Me.TabText = "Timbangan Operation"
        Me.Text = "Timbangan Operation"
        Me.TitleToolStrip.ResumeLayout(False)
        Me.TitleToolStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlImageScan.ResumeLayout(False)
        Me.pnlRegister.ResumeLayout(False)
        Me.pnlRegister.PerformLayout()
        Me.pnlOperation.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.salesGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelprintsalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.pctWeightImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TitleToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TitleToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lvProductImage As System.Windows.Forms.ListView
    Friend WithEvents ProducteanDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWeight As System.Windows.Forms.Button
    Friend WithEvents btnValidateWeight As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlImageScan As System.Windows.Forms.Panel
    Friend WithEvents pnlRegister As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCutStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pctWeightImage As System.Windows.Forms.PictureBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlOperation As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents salesGV As System.Windows.Forms.DataGridView
    Friend WithEvents MrpPos As AIMS.MrpPos
    Friend WithEvents LabelprintsalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnReprint As System.Windows.Forms.Button
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents checkColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ProductnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductcodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EancodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceperkgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitpriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumpriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
