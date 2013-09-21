#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.0.0.1 
'Author: Diego Lunadei
'Date: 18/08/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.OleDb

''' <summary>
'''DAO Class for table User_access
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _User_access
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

Protected _function_id as integer  = 0 
<XmlElementAttribute("function_id")> _
Public Overridable Property function_id() as integer
    Get
	    Return _function_id
    End Get
    Set (byval value as integer)
	    If _function_id <> value Then
	        IsChanged = True
	        _function_id= value
	    End If
    End Set
End property 

Protected _write_access as integer  = 0 
<XmlElementAttribute("write_access")> _
Public Overridable Property write_access() as integer
    Get
	    Return _write_access
    End Get
    Set (byval value as integer)
	    If _write_access <> value Then
	        IsChanged = True
	        _write_access= value
	    End If
    End Set
End property 

Protected _update_access as integer  = 0 
<XmlElementAttribute("update_access")> _
Public Overridable Property update_access() as integer
    Get
	    Return _update_access
    End Get
    Set (byval value as integer)
	    If _update_access <> value Then
	        IsChanged = True
	        _update_access= value
	    End If
    End Set
End property 

Protected _delete_access as integer  = 0 
<XmlElementAttribute("delete_access")> _
Public Overridable Property delete_access() as integer
    Get
	    Return _delete_access
    End Get
    Set (byval value as integer)
	    If _delete_access <> value Then
	        IsChanged = True
	        _delete_access= value
	    End If
    End Set
End property 

Protected _view_access as integer  = 0 
<XmlElementAttribute("view_access")> _
Public Overridable Property view_access() as integer
    Get
	    Return _view_access
    End Get
    Set (byval value as integer)
	    If _view_access <> value Then
	        IsChanged = True
	        _view_access= value
	    End If
    End Set
End property 

Protected _user_id as integer  = 0 
<XmlElementAttribute("user_id")> _
Public Overridable Property user_id() as integer
    Get
	    Return _user_id
    End Get
    Set (byval value as integer)
	    If _user_id <> value Then
	        IsChanged = True
	        _user_id= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an User_access from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New User_accessDAO
	    Dim int As User_access = Mgr.Read(Id)
            _ID = int.ID
            _function_id = int.function_id
            _write_access = int.write_access
            _update_access = int.update_access
            _delete_access = int.delete_access
            _view_access = int.view_access
            _user_id = int.user_id
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an User_access on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New User_accessDAO
	    Ris = Mgr.Save(Me)
	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ris
End Function

Protected Function InternalIsValid() As Boolean
	Dim Ris As Boolean = True
	
	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of User_access object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _User_accessDAO
Inherits LUNA.LunaBaseClassDAO(Of User_access)

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
'''Read from DB table User_access
''' </summary>
''' <returns>
'''Return a User_access object
''' </returns>
Public Overrides Function Read(Id as integer) as User_access
    Dim cls as new User_access

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM User_access where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("function_id") is DBNull.Value then cls.function_id = myReader("function_id")
                if not myReader("write_access") is DBNull.Value then cls.write_access = myReader("write_access")
                if not myReader("update_access") is DBNull.Value then cls.update_access = myReader("update_access")
                if not myReader("delete_access") is DBNull.Value then cls.delete_access = myReader("delete_access")
                if not myReader("view_access") is DBNull.Value then cls.view_access = myReader("view_access")
                if not myReader("user_id") is DBNull.Value then cls.user_id = myReader("user_id")
        	   
        End If
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table User_access
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as User_access) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO User_access ("
                                    sql &= " function_id,"
                                    sql &= " write_access,"
                                    sql &= " update_access,"
                                    sql &= " delete_access,"
                                    sql &= " view_access,"
                                    sql &= " user_id"
                                  sql &= ") VALUES ("
                      sql &= " @function_id,"
                      sql &= " @write_access,"
                      sql &= " @update_access,"
                      sql &= " @delete_access,"
                      sql &= " @view_access,"
                      sql &= " @user_id"
                      sql &= ")"
		        Else
			        sql = "UPDATE User_access SET "
                  sql &= "function_id = @function_id,"
                  sql &= "write_access = @write_access,"
                  sql &= "update_access = @update_access,"
                  sql &= "delete_access = @delete_access,"
                  sql &= "view_access = @view_access,"
                  sql &= "user_id = @user_id"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@function_id", cls.function_id))
                DbCommand.Parameters.Add(New OleDbParameter("@write_access", cls.write_access))
                DbCommand.Parameters.Add(New OleDbParameter("@update_access", cls.update_access))
                DbCommand.Parameters.Add(New OleDbParameter("@delete_access", cls.delete_access))
                DbCommand.Parameters.Add(New OleDbParameter("@view_access", cls.view_access))
                DbCommand.Parameters.Add(New OleDbParameter("@user_id", cls.user_id))
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
    'Dim Sql As String = "UPDATE User_access SET DELETED=True "
    Dim Sql As String = "DELETE FROM User_access"
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
'''Delete from DB table User_access. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table User_access. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as User_access, Optional ByRef ListaObj as List (of User_access) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_access)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_access)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_access)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of User_access)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_access)
    Dim Ls As New List(Of User_access)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from User_access" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of User_access)
    Dim Ls As New List(Of User_access)
    Try

    Dim sql As String = ""
    sql ="SELECT * from User_access" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of User_access)
    Dim Ls As New List(Of User_access)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  User_access() With {.ID = 0 ,.function_id = 0 ,.write_access = 0 ,.update_access = 0 ,.delete_access = 0 ,.view_access = 0 ,.user_id = 0  })
        while myReader.Read
	        Dim classe as new User_access
	        classe.ID = myReader("ID")
                            if not myReader("function_id") is DBNull.Value then classe.function_id = myReader("function_id")
                            if not myReader("write_access") is DBNull.Value then classe.write_access = myReader("write_access")
                            if not myReader("update_access") is DBNull.Value then classe.update_access = myReader("update_access")
                            if not myReader("delete_access") is DBNull.Value then classe.delete_access = myReader("delete_access")
                            if not myReader("view_access") is DBNull.Value then classe.view_access = myReader("view_access")
                            if not myReader("user_id") is DBNull.Value then classe.user_id = myReader("user_id")
            	   
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
