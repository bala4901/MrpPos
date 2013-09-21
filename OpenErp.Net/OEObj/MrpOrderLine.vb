Imports System.Text.RegularExpressions

Public Class MrpOrderLine
    Public Property id As String
    Public Property create_uid As String
    Public Property create_date As String
    Public Property write_date As String
    Public Property write_uid As String
    Public Property product_id As String
    Public Property name As String
    Public Property order_id As String
    Public Property company_id As String
    Public Property qty As String
    Public Property prodlot_id As String
    Public Property no As String
    Public Property check As Boolean

    Public Property product_ids As List(Of ProductProduct)
    Public Property product_name As String

    Public Property product_image As String
    Public Property product_code As String

    Public Property prodlot_ids As List(Of StockProductionLot)
    Public Property prodlot_name As String
    Public Property prodlot_use_date As String



    Public Property MrpOrderLines As List(Of MrpOrderLine)

    Private _product_ean As String
    Public Property product_ean13() As String
        Get
            Return EAN13(_product_ean, CStr(qty))
        End Get
        Set(ByVal value As String)
            _product_ean = value
        End Set
    End Property


    Public ReadOnly Property prodlot_barcode() As String
        Get
            Return "*" & prodlot_name & "," & product_code & "," & qty.PadLeft(4, "0"c) & "*"
        End Get
    End Property


    Public ReadOnly Property prodlot_text() As String
        Get
            Return name
        End Get
    End Property


    Public Function EAN13(ByVal ean13s As String, ByVal weight As String) As String
        'V 1.0
        'Parameters : a 12 digits length string
        'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer
        Dim first As Integer
        Dim checksum As Integer = 0
        Dim CodeBarre As String = ""
        Dim tableA As Boolean
        Dim product_code As String = ean13s.Substring(0, 5)
        Dim indCode As String = "899"
        Dim weightCode As String = weight.PadLeft(4, "0"c)
        Dim chaine As String = (indCode & product_code & weightCode).PadRight(12, "0"c)
        'Check for 12 characters
        'And they are really digits
        If Regex.IsMatch(chaine, "^\d{12}$") Then
            ' Calculation of the checksum
            For i = 1 To 11 Step 2
                checksum += Convert.ToInt32(chaine.Substring(i, 1))
            Next
            checksum *= 3
            For i = 0 To 11 Step 2
                checksum += Convert.ToInt32(chaine.Substring(i, 1))
            Next

            chaine = chaine & "" & (10 - checksum Mod 10) Mod 10
            'The first digit is taken just as it is, the second one come from table A
            CodeBarre = chaine.Substring(0, 1) & ChrW(65 + Convert.ToInt32(chaine.Substring(1, 1)))
            first = Convert.ToInt32(chaine.Substring(0, 1))
            For i = 2 To 6
                tableA = False
                Select Case i
                    Case 2
                        If first >= 0 AndAlso first <= 3 Then
                            tableA = True
                        End If
                        Exit Select
                    Case 3
                        If first = 0 OrElse first = 4 OrElse first = 7 OrElse first = 8 Then
                            tableA = True
                        End If
                        Exit Select
                    Case 4
                        If first = 0 OrElse first = 1 OrElse first = 4 OrElse first = 5 OrElse first = 9 Then
                            tableA = True
                        End If
                        Exit Select
                    Case 5
                        If first = 0 OrElse first = 2 OrElse first = 5 OrElse first = 6 OrElse first = 7 Then
                            tableA = True
                        End If
                        Exit Select
                    Case 6
                        If first = 0 OrElse first = 3 OrElse first = 6 OrElse first = 8 OrElse first = 9 Then
                            tableA = True
                        End If
                        Exit Select
                End Select

                If tableA Then
                    CodeBarre += ChrW(65 + Convert.ToInt32(chaine.Substring(i, 1)))
                Else
                    CodeBarre += ChrW(75 + Convert.ToInt32(chaine.Substring(i, 1)))
                End If
            Next
            CodeBarre += "*"
            'Add middle separator
            For i = 7 To 12
                CodeBarre += ChrW(97 + Convert.ToInt32(chaine.Substring(i, 1)))
            Next
            'Add end mark
            CodeBarre += "+"
        End If
        Return CodeBarre
    End Function

End Class
