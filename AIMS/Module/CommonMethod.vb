Imports System.Reflection
Imports System.Data.SqlClient
Imports OpenErp.Net
Imports System.Text.RegularExpressions
Imports System.Data.Objects
Imports System.Linq.Expressions

Module CommonMethod

    Private _imgList As ImageList
    Private _oid As OpenErp.Net.Openerp
    ''' <summary>
    ''' Write exception into database
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="errorMessage"></param>
    ''' <param name="errorDetails"></param>
    ''' <remarks></remarks>
    Public Function WriteErrorLog(ByVal source As String, ByVal errorMessage As String, ByVal errorDetails As String) As Long
        ''Get the name of the method that called this method
        'Dim st As StackTrace = New StackTrace()
        'Dim sf As StackFrame = st.GetFrame(1)
        'Dim mb As MethodBase = sf.GetMethod()

        'Dim queryAdapter As New AIMSDataSetTableAdapters.QueriesTableAdapter
        'Try
        '    queryAdapter.LogError_sp(mb.Name, source, errorMessage, errorDetails, WriteErrorLog)
        'Catch sqlEx As SqlException
        '    Call HandleSqlException(sqlEx)
        'Catch ex As Exception
        '    Call WriteErrorLog(ex.Source, ex.Message, ex.ToString)
        '    Exit Function
        'Finally
        '    queryAdapter.Dispose()
        'End Try

    End Function

    Public Function MethodCaller(ByVal st As StackTrace, ByVal sf As StackFrame) As MethodBase
        sf = st.GetFrame(1)
        Dim mb As MethodBase = sf.GetMethod()
        Return mb
    End Function

    ''' <summary>
    ''' Validate user input to prevent SQL injection
    ''' </summary>
    ''' <param name="InputString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsUserInputSafe(ByVal InputString As String) As Boolean
        If InputString.Contains("~") Or _
            InputString.Contains("`") Or _
            InputString.Contains(".") Or _
            InputString.Contains("!") Or _
            InputString.Contains("@") Or _
            InputString.Contains("#") Or _
            InputString.Contains("$") Or _
            InputString.Contains("%") Or _
            InputString.Contains("^") Or _
            InputString.Contains("&") Or _
            InputString.Contains("*") Or _
            InputString.Contains("--") Or _
            InputString.Contains("+") Or _
            InputString.Contains("=") Or _
            InputString.Contains("|") Or _
            InputString.Contains("\") Or _
            InputString.Contains("{") Or _
            InputString.Contains("[") Or _
            InputString.Contains("}") Or _
            InputString.Contains("]") Or _
            InputString.Contains(":") Or _
            InputString.Contains(";") Or _
            InputString.Contains("'") Or _
            InputString.Contains("<") Or _
            InputString.Contains(",") Or _
            InputString.Contains(">") Or _
            InputString.Contains("?") Or _
            InputString.Contains("/") Then
            Return False 'User input is unsafe
        Else
            Return True 'User input is safe
        End If
    End Function

    Public Function PasswordHash(ByVal password As String) As String
        '*** Chu Kher Boon
        '*** 23-Jun-07
        '*** Hash string to store as password

        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim UTF8 As New System.Text.UTF8Encoding
        Dim result() As Byte
        Dim hashedPassword As String

        result = md5.ComputeHash(UTF8.GetBytes(password))
        hashedPassword = Convert.ToBase64String(result)
        Return hashedPassword

    End Function

    Public Sub HandleSqlException(ByVal sqlEx As SqlException)
        Select Case sqlEx.Class
            Case 10 'Status Information
                MsgBox(sqlEx.Message, MsgBoxStyle.Information)
            Case 17 'Insufficient Resources
                MsgBox("Database insufficient resource error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 18 'Nonfatal Internal Error Detected
                MsgBox("Database internal error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 19 'SQL Server Error in Resource
                MsgBox("Database resource error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 20 'SQL Server Fatal Error in Current Process
                MsgBox("Database connection error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 21 'SQL Server Fatal Error in Database (dbid) Processes
                MsgBox("Database process error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 22 'SQL Server Fatal Error Table Integrity Suspect
                MsgBox("Database table integrity error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 23 'SQL Server Fatal Error: Database Integrity Suspect
                MsgBox("Database integrity error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case 24 'Hardware Error
                MsgBox("Server hardware error. Please contact your System Administrator", MsgBoxStyle.Exclamation)
            Case Else
                MsgBox(sqlEx.Message, MsgBoxStyle.Exclamation)
        End Select
    End Sub

    Public Property ImgList As ImageList
        Get
            Return _imgList
        End Get
        Set(ByVal value As ImageList)
            _imgList = value
        End Set

    End Property

    Public Property OID As OpenErp.Net.Openerp
        Get
            Return _oid
        End Get
        Set(ByVal value As OpenErp.Net.Openerp)
            _oid = value
        End Set

    End Property

    Public Function isDictKey(ByVal dict As DictionaryEntry, ByVal valString As String) As Boolean
        If dict.Key = valString Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function setEAN13CodeFont(ByVal barcode As String) As String
        'V 1.0
        'Parameters : a 12 digits length string
        'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer
        Dim first As Integer
        Dim checksum As Integer = 0
        Dim CodeBarre As String = ""
        Dim tableA As Boolean


        Dim chaine As String = barcode.PadRight(12, "0"c)
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

    Public Function setEAN13CodeFont1(ByVal barcode As String) As String
        'V 1.0
        'Parameters : a 12 digits length string
        'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer
        Dim first As Integer
        Dim checksum As Integer = 0
        Dim CodeBarre As String = ""
        Dim tableA As Boolean


        Dim chaine As String = barcode.PadRight(12, "0"c)
        'Check for 12 characters
        'And they are really digits
        If Regex.IsMatch(chaine, "^\d{13}$") Then
            '' Calculation of the checksum
            'For i = 1 To 11 Step 2
            '    checksum += Convert.ToInt32(chaine.Substring(i, 1))
            'Next
            'checksum *= 3
            'For i = 0 To 11 Step 2
            '    checksum += Convert.ToInt32(chaine.Substring(i, 1))
            'Next

            'chaine = chaine & "" & (10 - checksum Mod 10) Mod 10
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

  
    Public Function setEAN13CodeSales(ByVal productcode As String) As String
        'V 1.0
        'Parameters : a 12 digits length string
        'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer
        Dim first As Integer
        Dim checksum As Integer = 0
        Dim CodeBarre As String = ""
        Dim tableA As Boolean
        Dim product_code As String = productcode.PadRight(5, "0"c)


        Dim chaine As String = (product_code).PadRight(12, "0"c)
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
        End If
        Return chaine
    End Function

    Public Function setEAN13Code(ByVal productcode As String) As String
        'V 1.0
        'Parameters : a 12 digits length string
        'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer
        Dim first As Integer
        Dim checksum As Integer = 0
        Dim CodeBarre As String = ""
        Dim tableA As Boolean
        Dim product_code As String = productcode.PadRight(5, "0"c)
        Dim indCode As String = "899"
        Dim manufacturercode As String = "7026"

        Dim chaine As String = (indCode & manufacturercode & product_code).PadRight(12, "0"c)
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
        End If
        Return chaine
    End Function


    Public Function getFileDbPath() As String
        Return My.Application.Info.DirectoryPath & "\database\filedb.fdb"
    End Function

    Public Function getNextId(ByVal cId As Object) As Long
        Try

            Return CType(cId, Long) + 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function toDispCurrency(ByVal val As String) As String
        If val.Length <= 0 Then
            Return 0
        Else
            Dim decVal As Decimal = Decimal.Parse(val)
            If decVal <= 0 Then
                Return 0
            End If

            Dim retVal As String = decVal.ToString("#,#")


          
            Return retVal
        End If
    End Function

    Public Function formatDecimal(ByVal val As String, Optional ByVal decPlace As Integer = 3) As Double

        Return FormatNumber(CDbl(val), decPlace)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToADOTable(Of T)(varlist As IEnumerable(Of T)) As DataTable
        Dim dtReturn As New DataTable()
        ' Use reflection to get property names, to create table
        ' column names
        Dim oProps As PropertyInfo() = GetType(T).GetProperties()
        For Each pi As PropertyInfo In oProps
            Dim colType As Type = pi.PropertyType
            If (colType.IsGenericType) AndAlso (colType.GetGenericTypeDefinition() = GetType(Nullable(Of ))) Then
                colType = colType.GetGenericArguments()(0)
            End If
            dtReturn.Columns.Add(New DataColumn(pi.Name, colType))
        Next
        For Each rec As T In varlist
            Dim dr As DataRow = dtReturn.NewRow()
            For Each pi As PropertyInfo In oProps
                dr(pi.Name) = If(pi.GetValue(rec, Nothing) Is Nothing, DBNull.Value, pi.GetValue(rec, Nothing))
            Next
            dtReturn.Rows.Add(dr)
        Next

        Return (dtReturn)
    End Function

    Public Function generateSerialNo(ByVal id As String) As String
        Dim sTrim As String = ""
        Dim alpha As String = ""
        Dim digitControl As Integer = 6

        If id.Length > 6 Then
            alpha = id.Substring(0, id.Length - digitControl)

            alpha = Decimal2ExcelAZ(CType(alpha, Long))

            sTrim = id.Substring(id.Length - digitControl)
        Else
            alpha = "A"
            sTrim = id.PadLeft(digitControl, "0"c)
        End If

        Return alpha & sTrim


    End Function
    Public Function generateCaseSerialNo(ByVal id As String) As String
        Dim sTrim As String = ""
        Dim alpha As String = ""
        Dim digitControl As Integer = 5

        If id.Length > 5 Then
            alpha = id.Substring(0, id.Length - digitControl)

            alpha = Decimal2ExcelAZ(CType(alpha, Long))

            sTrim = id.Substring(id.Length - digitControl)
        Else
            alpha = "A"
            sTrim = id.PadLeft(digitControl, "0"c)
        End If

        Return "C" & alpha & sTrim


    End Function

    Private Function Decimal2ExcelAZ(ByVal number As Long) As String
        If number < 0 Then
            Throw New Exception("Number cannot be negative")
        ElseIf number < 26 Then
            REM 65 is the ASCII of "A"
            Return New String(Chr(64 + number) + "")
        Else
            Return Decimal2ExcelAZ(number \ 26 - 1) + Decimal2ExcelAZ(number Mod 26)
        End If
    End Function

    Public Function generateOrderSerialNo(ByVal id As String) As String
        Dim sTrim As String = ""
        Dim alpha As String = ""
        Dim digitControl As Integer = 6

        If id.Length > 6 Then
            alpha = id.Substring(0, id.Length - digitControl)

            alpha = Decimal2ExcelAZ(CType(alpha, Long))

            sTrim = id.Substring(id.Length - digitControl)
        Else
            alpha = "A"
            sTrim = id.PadLeft(digitControl, "0"c)
        End If

        Return "O" & alpha & sTrim


    End Function


End Module
