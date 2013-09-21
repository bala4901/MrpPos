#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.0.0.1 
'Author: Diego Lunadei
'Date: 22/08/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.OleDb

''' <summary>
'''DAO Class for table Summary
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Summary
	Inherits LUNA.LunaBaseClassEntity
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

#Region "Database Field Map"

Protected _ID as integer  = 0 
<XmlElementAttribute("ID")> _
Public Overridable Property ID() as integer
    Get
	    Return _ID
    End Get
    Set (byval value as integer)
	    If _ID <> value Then
	        IsChanged = True
	        _ID= value
	    End If
    End Set
End property 

Protected _product_code as string  = "" 
<XmlElementAttribute("product_code")> _
Public Overridable Property product_code() as string
    Get
	    Return _product_code
    End Get
    Set (byval value as string)
	    If _product_code <> value Then
	        IsChanged = True
	        _product_code= value
	    End If
    End Set
End property 

Protected _product_name as string  = "" 
<XmlElementAttribute("product_name")> _
Public Overridable Property product_name() as string
    Get
	    Return _product_name
    End Get
    Set (byval value as string)
	    If _product_name <> value Then
	        IsChanged = True
	        _product_name= value
	    End If
    End Set
End property 

Protected _product_name1 as string  = "" 
<XmlElementAttribute("product_name1")> _
Public Overridable Property product_name1() as string
    Get
	    Return _product_name1
    End Get
    Set (byval value as string)
	    If _product_name1 <> value Then
	        IsChanged = True
	        _product_name1= value
	    End If
    End Set
End property 

Protected _lotNo as string  = "" 
<XmlElementAttribute("lotNo")> _
Public Overridable Property lotNo() as string
    Get
	    Return _lotNo
    End Get
    Set (byval value as string)
	    If _lotNo <> value Then
	        IsChanged = True
	        _lotNo= value
	    End If
    End Set
End property 

Protected _weight as string  = "" 
<XmlElementAttribute("weight")> _
Public Overridable Property weight() as string
    Get
	    Return _weight
    End Get
    Set (byval value as string)
	    If _weight <> value Then
	        IsChanged = True
	        _weight= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Summary from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New SummaryDAO
	    Dim int As Summary = Mgr.Read(Id)
            _ID = int.ID
            _product_code = int.product_code
            _product_name = int.product_name
            _product_name1 = int.product_name1
            _lotNo = int.lotNo
            _weight = int.weight
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Summary on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New SummaryDAO
	    Ris = Mgr.Save(Me)
	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ris
End Function

Protected Function InternalIsValid() As Boolean
	Dim Ris As Boolean = True
	  if _product_code.Length > 255 then Ris = False
  if _product_name.Length > 255 then Ris = False
  if _product_name1.Length > 255 then Ris = False
  if _lotNo.Length > 255 then Ris = False
  if _weight.Length > 255 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of Summary object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _SummaryDAO
Inherits LUNA.LunaBaseClassDAO(Of Summary)

''' <summary>
'''New() create an istance of this class. Use default DB Connection
''' </summary>
''' <returns>
'''
''' </returns>
Public Sub New()
	MyBase.New()
End Sub

''' <summary>
'''New() create an istance of this class and specify an OPENED DB connection
''' </summary>
''' <returns>
'''
''' </returns>
Public Sub New(ByVal Connection As OleDBConnection)
	MyBase.New(Connection)
End Sub

''' <summary>
'''New() create an istance of this class and specify a DB connectionstring
''' </summary>
''' <returns>
'''
''' </returns>
Public Sub New(ByVal ConnectionString As string)
	MyBase.New(ConnectionString)
End Sub

''' <summary>
'''Read from DB table Summary
''' </summary>
''' <returns>
'''Return a Summary object
''' </returns>
Public Overrides Function Read(Id as integer) as Summary
    Dim cls as new Summary

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM Summary where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("product_code") is DBNull.Value then cls.product_code = myReader("product_code")
                if not myReader("product_name") is DBNull.Value then cls.product_name = myReader("product_name")
                if not myReader("product_name1") is DBNull.Value then cls.product_name1 = myReader("product_name1")
                if not myReader("lotNo") is DBNull.Value then cls.lotNo = myReader("lotNo")
                if not myReader("weight") is DBNull.Value then cls.weight = myReader("weight")
        	   
        End If
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table Summary
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Summary) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO Summary ("
                                    sql &= " product_code,"
                                    sql &= " product_name,"
                                    sql &= " product_name1,"
                                    sql &= " lotNo,"
                                    sql &= " weight"
                                  sql &= ") VALUES ("
                      sql &= " @product_code,"
                      sql &= " @product_name,"
                      sql &= " @product_name1,"
                      sql &= " @lotNo,"
                      sql &= " @weight"
                      sql &= ")"
		        Else
			        sql = "UPDATE Summary SET "
                  sql &= "product_code = @product_code,"
                  sql &= "product_name = @product_name,"
                  sql &= "product_name1 = @product_name1,"
                  sql &= "lotNo = @lotNo,"
                  sql &= "weight = @weight"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@product_code", cls.product_code))
                DbCommand.Parameters.Add(New OleDbParameter("@product_name", cls.product_name))
                DbCommand.Parameters.Add(New OleDbParameter("@product_name1", cls.product_name1))
                DbCommand.Parameters.Add(New OleDbParameter("@lotNo", cls.lotNo))
                DbCommand.Parameters.Add(New OleDbParameter("@weight", cls.weight))
                                DbCommand.CommandType = CommandType.Text
		        DbCommand.CommandText = sql
		        DbCommand.ExecuteNonQuery()

                              If cls.ID=0 Then
			        Dim IdInserito as integer = 0
			        Sql = "select @@identity"
			        DbCommand.CommandText = Sql
			        Idinserito = DbCommand.ExecuteScalar()
			        cls.ID = Idinserito
			        Ris = Idinserito
		        else
			        Ris  =  cls.ID
		        End If
                		        DbCommand.Dispose()

	        Catch ex As Exception
		        ManageError(ex)
	        End Try
        else
	        Ris  =  cls.ID
        End If

    Else
	    throw new ApplicationException("Object data is not valid")
    End If
    Return Ris
End Function

Private Sub DestroyPermanently(Id as integer) 
    Try

    Dim UpdateCommand As OleDbCommand = New OleDbCommand()
    UpdateCommand.Connection = _cn

    '******IMPORTANT: You can use this commented instruction to make a logical delete .
    '******Replace DELETED Field with your logic deleted field name.
    'Dim Sql As String = "UPDATE Summary SET DELETED=True "
    Dim Sql As String = "DELETE FROM Summary"
    Sql &= " Where ID = " & Id 

    UpdateCommand.CommandText = Sql
    If Not DbTransaction Is Nothing Then UpdateCommand.Transaction = DbTransaction
    UpdateCommand.ExecuteNonQuery()
    UpdateCommand.Dispose()
    Catch ex As Exception
	    ManageError(ex)
    End Try
End Sub

''' <summary>
'''Delete from DB table Summary. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Summary. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Summary, Optional ByRef ListaObj as List (of Summary) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Summary)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Summary)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Summary)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Summary)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Summary)
    Dim Ls As New List(Of Summary)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Summary" 
    For Each Par As LUNA.LunaSearchParameter In Parameter
	    If Not Par Is Nothing Then
		    If Sql.IndexOf("WHERE") = -1 Then Sql &= " WHERE " Else Sql &=  " " & Par.LogicOperatorStr & " "
		    Sql &= Par.FieldName & " " & Par.SqlOperator & " " & Ap(Par.Value)
	    End if
    Next

    If SearchOption.OrderBy.Length Then Sql &= " ORDER BY " & SearchOption.OrderBy

    Ls = GetData(Sql)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Summary)
    Dim Ls As New List(Of Summary)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Summary" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Summary)
    Dim Ls As New List(Of Summary)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  Summary() With {.ID = 0 ,.product_code = "" ,.product_name = "" ,.product_name1 = "" ,.lotNo = "" ,.weight = ""  })
        while myReader.Read
	        Dim classe as new Summary
	        classe.ID = myReader("ID")
                            if not myReader("product_code") is DBNull.Value then classe.product_code = myReader("product_code")
                            if not myReader("product_name") is DBNull.Value then classe.product_name = myReader("product_name")
                            if not myReader("product_name1") is DBNull.Value then classe.product_name1 = myReader("product_name1")
                            if not myReader("lotNo") is DBNull.Value then classe.lotNo = myReader("lotNo")
                            if not myReader("weight") is DBNull.Value then classe.weight = myReader("weight")
            	   
	        Ls.Add(classe)
        end while
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function
End Class
