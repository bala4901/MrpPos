<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CutStyleFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CutStyleFrm))
        Me.ItemMasterDgv = New System.Windows.Forms.DataGridView()
        Me.CutstyleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MrpPos = New AIMS.MrpPos()
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AddNewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MenuToolStrip = New System.Windows.Forms.ToolStrip()
        Me.RefreshToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TitleToolStrip = New System.Windows.Forms.ToolStrip()
        Me.TitleToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.CutstyleTableAdapter = New AIMS.MrpPosTableAdapters.cutstyleTableAdapter()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ChargeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ItemMasterDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CutstyleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuToolStrip.SuspendLayout()
        Me.TitleToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItemMasterDgv
        '
        Me.ItemMasterDgv.AllowUserToAddRows = False
        Me.ItemMasterDgv.AllowUserToDeleteRows = False
        Me.ItemMasterDgv.AllowUserToResizeRows = False
        Me.ItemMasterDgv.AutoGenerateColumns = False
        Me.ItemMasterDgv.BackgroundColor = System.Drawing.Color.White
        Me.ItemMasterDgv.ColumnHeadersHeight = 34
        Me.ItemMasterDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ItemMasterDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.ChargeDataGridViewTextBoxColumn})
        Me.ItemMasterDgv.DataSource = Me.CutstyleBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ItemMasterDgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.ItemMasterDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemMasterDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.ItemMasterDgv.Location = New System.Drawing.Point(0, 53)
        Me.ItemMasterDgv.MultiSelect = False
        Me.ItemMasterDgv.Name = "ItemMasterDgv"
        Me.ItemMasterDgv.ReadOnly = True
        Me.ItemMasterDgv.RowHeadersVisible = False
        Me.ItemMasterDgv.RowHeadersWidth = 70
        Me.ItemMasterDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.ItemMasterDgv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.ItemMasterDgv.RowTemplate.Height = 34
        Me.ItemMasterDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ItemMasterDgv.ShowEditingIcon = False
        Me.ItemMasterDgv.Size = New System.Drawing.Size(910, 458)
        Me.ItemMasterDgv.StandardTab = True
        Me.ItemMasterDgv.TabIndex = 9
        Me.ItemMasterDgv.TabStop = False
        Me.ItemMasterDgv.VirtualMode = True
        '
        'CutstyleBindingSource
        '
        Me.CutstyleBindingSource.DataMember = "cutstyle"
        Me.CutstyleBindingSource.DataSource = Me.MrpPos
        '
        'MrpPos
        '
        Me.MrpPos.DataSetName = "MrpPos"
        Me.MrpPos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteToolStripButton.Image = Global.AIMS.My.Resources.Resources.delete
        Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.DeleteToolStripButton.Text = "Delete"
        Me.DeleteToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AddNewToolStripButton
        '
        Me.AddNewToolStripButton.Image = Global.AIMS.My.Resources.Resources._new
        Me.AddNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddNewToolStripButton.Name = "AddNewToolStripButton"
        Me.AddNewToolStripButton.Size = New System.Drawing.Size(70, 22)
        Me.AddNewToolStripButton.Text = "Add New"
        Me.AddNewToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuToolStrip
        '
        Me.MenuToolStrip.BackColor = System.Drawing.Color.Transparent
        Me.MenuToolStrip.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MenuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MenuToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripButton, Me.AddNewToolStripButton, Me.DeleteToolStripButton})
        Me.MenuToolStrip.Location = New System.Drawing.Point(0, 28)
        Me.MenuToolStrip.Name = "MenuToolStrip"
        Me.MenuToolStrip.Size = New System.Drawing.Size(910, 25)
        Me.MenuToolStrip.TabIndex = 7
        Me.MenuToolStrip.Text = "ToolStrip1"
        '
        'RefreshToolStripButton
        '
        Me.RefreshToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshToolStripButton.Image = Global.AIMS.My.Resources.Resources.refresh
        Me.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshToolStripButton.Name = "RefreshToolStripButton"
        Me.RefreshToolStripButton.Size = New System.Drawing.Size(65, 22)
        Me.RefreshToolStripButton.Text = "Refresh"
        Me.RefreshToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TitleToolStrip
        '
        Me.TitleToolStrip.BackColor = System.Drawing.Color.Indigo
        Me.TitleToolStrip.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TitleToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TitleToolStripLabel})
        Me.TitleToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TitleToolStrip.Name = "TitleToolStrip"
        Me.TitleToolStrip.Size = New System.Drawing.Size(910, 28)
        Me.TitleToolStrip.TabIndex = 8
        Me.TitleToolStrip.Text = "ToolStrip3"
        '
        'TitleToolStripLabel
        '
        Me.TitleToolStripLabel.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleToolStripLabel.ForeColor = System.Drawing.Color.White
        Me.TitleToolStripLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TitleToolStripLabel.Name = "TitleToolStripLabel"
        Me.TitleToolStripLabel.Size = New System.Drawing.Size(119, 25)
        Me.TitleToolStripLabel.Text = "Cut Style"
        Me.TitleToolStripLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'CutstyleTableAdapter
        '
        Me.CutstyleTableAdapter.ClearBeforeFill = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Cut Style Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.NameDataGridViewTextBoxColumn.Width = 150
        '
        'ChargeDataGridViewTextBoxColumn
        '
        Me.ChargeDataGridViewTextBoxColumn.DataPropertyName = "charge"
        Me.ChargeDataGridViewTextBoxColumn.HeaderText = "Charge (Rp)"
        Me.ChargeDataGridViewTextBoxColumn.Name = "ChargeDataGridViewTextBoxColumn"
        Me.ChargeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ChargeDataGridViewTextBoxColumn.Width = 150
        '
        'CutStyleFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 511)
        Me.Controls.Add(Me.ItemMasterDgv)
        Me.Controls.Add(Me.MenuToolStrip)
        Me.Controls.Add(Me.TitleToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CutStyleFrm"
        Me.TabText = "Cut Style"
        Me.Text = "Cut Style"
        CType(Me.ItemMasterDgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CutstyleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MrpPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuToolStrip.ResumeLayout(False)
        Me.MenuToolStrip.PerformLayout()
        Me.TitleToolStrip.ResumeLayout(False)
        Me.TitleToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ItemMasterDgv As System.Windows.Forms.DataGridView
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddNewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents RefreshToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TitleToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TitleToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Name2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ean13DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceperkgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MrpPos As AIMS.MrpPos
    Friend WithEvents CutstyleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CutstyleTableAdapter As AIMS.MrpPosTableAdapters.cutstyleTableAdapter
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ChargeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
