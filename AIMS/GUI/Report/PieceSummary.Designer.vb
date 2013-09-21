<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PieceSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PieceSummary))
        Me.TitleToolStrip = New System.Windows.Forms.ToolStrip()
        Me.TitleToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvLines = New System.Windows.Forms.DataGridView()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbLotNo = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tbSerialNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MrpPos = New AIMS.MrpPos()
        Me.MrplinesummaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitpriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseserialnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TitleToolStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MrplinesummaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.dgvLines)
        Me.Panel1.Controls.Add(Me.pnlSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(903, 600)
        Me.Panel1.TabIndex = 7
        '
        'dgvLines
        '
        Me.dgvLines.AllowUserToAddRows = False
        Me.dgvLines.AllowUserToDeleteRows = False
        Me.dgvLines.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLines.AutoGenerateColumns = False
        Me.dgvLines.BackgroundColor = System.Drawing.Color.White
        Me.dgvLines.ColumnHeadersHeight = 28
        Me.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.SerialnoDataGridViewTextBoxColumn, Me.CodeDataGridViewTextBoxColumn, Me.Line1DataGridViewTextBoxColumn, Me.Line2DataGridViewTextBoxColumn, Me.PriceDataGridViewTextBoxColumn, Me.UnitpriceDataGridViewTextBoxColumn, Me.CaseserialnoDataGridViewTextBoxColumn, Me.CaseidDataGridViewTextBoxColumn, Me.LotidDataGridViewTextBoxColumn, Me.LotnoDataGridViewTextBoxColumn, Me.ProductidDataGridViewTextBoxColumn, Me.WeightDataGridViewTextBoxColumn})
        Me.dgvLines.DataSource = Me.MrplinesummaryBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLines.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLines.Location = New System.Drawing.Point(0, 163)
        Me.dgvLines.MultiSelect = False
        Me.dgvLines.Name = "dgvLines"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLines.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLines.RowHeadersVisible = False
        Me.dgvLines.RowHeadersWidth = 70
        Me.dgvLines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Cyan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvLines.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLines.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvLines.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvLines.RowTemplate.Height = 24
        Me.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLines.ShowEditingIcon = False
        Me.dgvLines.Size = New System.Drawing.Size(903, 437)
        Me.dgvLines.StandardTab = True
        Me.dgvLines.TabIndex = 2
        Me.dgvLines.TabStop = False
        Me.dgvLines.VirtualMode = True
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.dtTo)
        Me.pnlSearch.Controls.Add(Me.Label5)
        Me.pnlSearch.Controls.Add(Me.dtFrom)
        Me.pnlSearch.Controls.Add(Me.Label4)
        Me.pnlSearch.Controls.Add(Me.tbLotNo)
        Me.pnlSearch.Controls.Add(Me.TextBox1)
        Me.pnlSearch.Controls.Add(Me.tbSerialNo)
        Me.pnlSearch.Controls.Add(Me.Label3)
        Me.pnlSearch.Controls.Add(Me.Label2)
        Me.pnlSearch.Controls.Add(Me.Label1)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(903, 163)
        Me.pnlSearch.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.AIMS.My.Resources.Resources.validate
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.Location = New System.Drawing.Point(626, 27)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(99, 90)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtTo
        '
        Me.dtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(439, 88)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(160, 29)
        Me.dtTo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(358, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "To :"
        '
        'dtFrom
        '
        Me.dtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(164, 87)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(160, 29)
        Me.dtFrom.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pack Date :"
        '
        'tbLotNo
        '
        Me.tbLotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLotNo.Location = New System.Drawing.Point(439, 10)
        Me.tbLotNo.Name = "tbLotNo"
        Me.tbLotNo.Size = New System.Drawing.Size(160, 29)
        Me.tbLotNo.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(164, 48)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 29)
        Me.TextBox1.TabIndex = 4
        '
        'tbSerialNo
        '
        Me.tbSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSerialNo.Location = New System.Drawing.Point(164, 13)
        Me.tbSerialNo.Name = "tbSerialNo"
        Me.tbSerialNo.Size = New System.Drawing.Size(160, 29)
        Me.tbSerialNo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(358, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Lot No :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Case Serial No :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serial No :"
        '
        'MrpPos
        '
        Me.MrpPos.DataSetName = "MrpPos"
        Me.MrpPos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MrplinesummaryBindingSource
        '
        Me.MrplinesummaryBindingSource.DataMember = "mrp_line_summary"
        Me.MrplinesummaryBindingSource.DataSource = Me.MrpPos
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        '
        'SerialnoDataGridViewTextBoxColumn
        '
        Me.SerialnoDataGridViewTextBoxColumn.DataPropertyName = "serial_no"
        Me.SerialnoDataGridViewTextBoxColumn.HeaderText = "serial_no"
        Me.SerialnoDataGridViewTextBoxColumn.Name = "SerialnoDataGridViewTextBoxColumn"
        '
        'CodeDataGridViewTextBoxColumn
        '
        Me.CodeDataGridViewTextBoxColumn.DataPropertyName = "code"
        Me.CodeDataGridViewTextBoxColumn.HeaderText = "code"
        Me.CodeDataGridViewTextBoxColumn.Name = "CodeDataGridViewTextBoxColumn"
        '
        'Line1DataGridViewTextBoxColumn
        '
        Me.Line1DataGridViewTextBoxColumn.DataPropertyName = "line1"
        Me.Line1DataGridViewTextBoxColumn.HeaderText = "line1"
        Me.Line1DataGridViewTextBoxColumn.Name = "Line1DataGridViewTextBoxColumn"
        '
        'Line2DataGridViewTextBoxColumn
        '
        Me.Line2DataGridViewTextBoxColumn.DataPropertyName = "line2"
        Me.Line2DataGridViewTextBoxColumn.HeaderText = "line2"
        Me.Line2DataGridViewTextBoxColumn.Name = "Line2DataGridViewTextBoxColumn"
        '
        'PriceDataGridViewTextBoxColumn
        '
        Me.PriceDataGridViewTextBoxColumn.DataPropertyName = "price"
        Me.PriceDataGridViewTextBoxColumn.HeaderText = "price"
        Me.PriceDataGridViewTextBoxColumn.Name = "PriceDataGridViewTextBoxColumn"
        '
        'UnitpriceDataGridViewTextBoxColumn
        '
        Me.UnitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price"
        Me.UnitpriceDataGridViewTextBoxColumn.HeaderText = "unit_price"
        Me.UnitpriceDataGridViewTextBoxColumn.Name = "UnitpriceDataGridViewTextBoxColumn"
        '
        'CaseserialnoDataGridViewTextBoxColumn
        '
        Me.CaseserialnoDataGridViewTextBoxColumn.DataPropertyName = "case_serial_no"
        Me.CaseserialnoDataGridViewTextBoxColumn.HeaderText = "case_serial_no"
        Me.CaseserialnoDataGridViewTextBoxColumn.Name = "CaseserialnoDataGridViewTextBoxColumn"
        '
        'CaseidDataGridViewTextBoxColumn
        '
        Me.CaseidDataGridViewTextBoxColumn.DataPropertyName = "case_id"
        Me.CaseidDataGridViewTextBoxColumn.HeaderText = "case_id"
        Me.CaseidDataGridViewTextBoxColumn.Name = "CaseidDataGridViewTextBoxColumn"
        '
        'LotidDataGridViewTextBoxColumn
        '
        Me.LotidDataGridViewTextBoxColumn.DataPropertyName = "lot_id"
        Me.LotidDataGridViewTextBoxColumn.HeaderText = "lot_id"
        Me.LotidDataGridViewTextBoxColumn.Name = "LotidDataGridViewTextBoxColumn"
        '
        'LotnoDataGridViewTextBoxColumn
        '
        Me.LotnoDataGridViewTextBoxColumn.DataPropertyName = "lot_no"
        Me.LotnoDataGridViewTextBoxColumn.HeaderText = "lot_no"
        Me.LotnoDataGridViewTextBoxColumn.Name = "LotnoDataGridViewTextBoxColumn"
        '
        'ProductidDataGridViewTextBoxColumn
        '
        Me.ProductidDataGridViewTextBoxColumn.DataPropertyName = "product_id"
        Me.ProductidDataGridViewTextBoxColumn.HeaderText = "product_id"
        Me.ProductidDataGridViewTextBoxColumn.Name = "ProductidDataGridViewTextBoxColumn"
        '
        'WeightDataGridViewTextBoxColumn
        '
        Me.WeightDataGridViewTextBoxColumn.DataPropertyName = "weight"
        Me.WeightDataGridViewTextBoxColumn.HeaderText = "weight"
        Me.WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
        '
        'PieceSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(903, 628)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TitleToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PieceSummary"
        Me.TabText = "Case Operation"
        Me.Text = "Case Operation"
        Me.TitleToolStrip.ResumeLayout(False)
        Me.TitleToolStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MrplinesummaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TitleToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TitleToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ProducteanDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvLines As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tbSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbLotNo As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialnoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitpriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseserialnoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotnoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MrplinesummaryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MrpPos As AIMS.MrpPos
End Class
