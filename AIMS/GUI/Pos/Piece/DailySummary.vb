Imports System.Data.OleDb

Public Class DailySummary

    Private Sub DailySummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select sum(ol.qty) as ttlQty, p.code,l.[name] as lotno,p.[name] as pName,p.name2 from mrp_order_line ol, mrp_prod_lot l, product_product p "
        sql += " where ol.product_id = p.id and ol.prodlot_id = l.id and format(ol.create_date,'yyyyMMdd') =" & "'" & Now.ToString("yyyyMMdd") & "'"
        sql += " group by l.[name],p.[name],p.[name2],p.code order by p.code"
        Try


            Using conn As New OleDbConnection(My.Settings.POSConnString)
                conn.Open()
                Using Command As New OleDbCommand(sql, conn)
                    Dim myReader As OleDbDataReader = Command.ExecuteReader()
                    Dim product_code As String = ""
                    Dim product_code_old As String = ""
                    Dim pname As String = ""
                    Dim pname2 As String = ""
                    Dim lotno As String = ""
                    Dim qty As String = ""



                    While myReader.Read
                        If Not myReader("code") Is DBNull.Value Then product_code = myReader("code")
                        If Not myReader("ttlQty") Is DBNull.Value Then qty = myReader("ttlQty")
                        If Not myReader("lotno") Is DBNull.Value Then lotno = myReader("lotno")
                        If Not myReader("pName") Is DBNull.Value Then pname = myReader("pName")
                        If Not myReader("name2") Is DBNull.Value Then pname = myReader("name2")

                        If product_code_old.Length <= 0 Then

                            RichTextBox1.Text += "Date : " & Now.ToString("dd-MMM-yyyy HH:mm:ss") & vbNewLine & vbNewLine
                            RichTextBox1.Text += pname & vbNewLine & IIf(pname2.Length > 0, pname2 & vbNewLine, "")
                            RichTextBox1.Text += "[" & product_code & "]" & vbNewLine
                            RichTextBox1.Text += "-------------------------------------------------------" & vbNewLine
                            RichTextBox1.Text += "Lot No".PadRight(30) & "qty" & vbNewLine
                            RichTextBox1.Text += "-------------------------------------------------------" & vbNewLine
                            RichTextBox1.Text += lotno.PadRight(30) & qty & vbNewLine
                            product_code_old = product_code
                        Else
                            If product_code = product_code_old Then
                                RichTextBox1.Text += lotno.PadRight(30) & qty & vbNewLine
                                product_code_old += product_code
                            Else
                                RichTextBox1.Text += vbNewLine & vbNewLine & pname & vbNewLine & IIf(pname2.Length > 0, pname2 & vbNewLine, "")
                                RichTextBox1.Text += "[" & product_code & "]" & vbNewLine
                                RichTextBox1.Text += "-------------------------------------------------------" & vbNewLine
                                RichTextBox1.Text += "Lot No".PadRight(30) & "qty" & vbNewLine
                                RichTextBox1.Text += "-------------------------------------------------------" & vbNewLine
                                RichTextBox1.Text += lotno.PadRight(30) & qty & vbNewLine
                                product_code_old = product_code
                            End If

                        End If

                    End While
                    myReader.Close()

                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim numChars As Integer
        Dim numLines As Integer
        Dim stringForPage As String
        Dim strFormat As New StringFormat()
        Dim PrintFont As Font
        PrintFont = RichTextBox1.Font
        Dim rectDraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height)
        Dim sizeMeasure As New SizeF(e.MarginBounds.Width, e.MarginBounds.Height - PrintFont.GetHeight(e.Graphics))
        strFormat.Trimming = StringTrimming.Word
        e.Graphics.MeasureString(RichTextBox1.Text, PrintFont, sizeMeasure, strFormat, numChars, numLines)
        stringForPage = RichTextBox1.Text.Substring(0, numChars)
        e.Graphics.DrawString(stringForPage, PrintFont, Brushes.Black, rectDraw, strFormat)
        'If numChars < RichTextBox1.Text.Length Then
        '    RichTextBox1 = RichTextBox1.Text.Substring(numChars)
        '    e.HasMorePages = True
        'Else
        '    e.HasMorePages = False
        'End If
    End Sub
End Class