Imports OpenErp.Net

Public Class LotFrm

    Private oErp As New OpenErp.Net.Openerp

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If validation() Then

            PieceOperation.lotNo = txtLotNo.Text

            PieceOperation.isPackByCase = IIf(cbCasePack.Text = "By Case", True, False)
            PieceOperation.isPrintPrice = IIf(cbPrice.Text = "Yes", True, False)

            PieceOperation._isLotCancel = False
            Me.Close()
        End If
    End Sub

    Private Sub LotFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' txtLotNo.Text = Now.ToString("yyyyMMdd")
        'dtExpDate.Value = Now.AddYears(1)
        ' loadMrpData()
        cbCasePack.SelectedIndex = 0
        cbPrice.SelectedIndex = 0
    End Sub

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        PieceOperation._isLotCancel = True
        Me.Close()
    End Sub

    Private Sub loadMrpData()
        'Dim conditions As New ArrayList

        'conditions.Add(New String() {"state", "=", "draft"})
        'Dim MrpProds As List(Of MrpProduction) = oErp.getMrpProdList(conditions)

        'cbMrpProd.DataSource = MrpProds
        'cbMrpProd.ValueMember = "id"
        'cbMrpProd.DisplayMember = "name"


    End Sub

    Private Function validation() As Boolean
        Dim errormsg As New List(Of String)
        Dim result1 As Boolean = True
        Dim result2 As Boolean = True
        Dim msg As String = ""

        If txtLotNo.Text.Length <= 0 Then
            errormsg.Add("Lot No cannot be empty")
        End If

        If cbCasePack.Text.Length <= 0 Then
            errormsg.Add("Please select how to pack")
        End If

        If cbPrice.Text.Length <= 0 Then
            errormsg.Add("Please select whether to print price")
        End If

        If errormsg.Count > 0 Then
            For Each Err As String In errormsg
                msg += Err & vbNewLine
            Next

            MsgBox(msg)

            Return False
        End If
        Return True


    End Function
End Class