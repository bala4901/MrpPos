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
'''DAO Class for table User_user
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _User_user
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

Protected _user_name as string  = "" 
<XmlElementAttribute("user_name")> _
Public Overridable Property user_name() as string
    Get
	    Return _user_name
    End Get
    Set (byval value as string)
	    If _user_name <> value Then
	        IsChanged = True
	        _user_name= value
	    End If
    End Set
End property 

Protected _user_id as string  = "" 
<XmlElementAttribute("user_id")> _
Public Overridable Property user_id() as string
    Get
	    Return _user_id
    End Get
    Set (byval value as string)
	    If _user_id <> value Then
	        IsChanged = True
	        _user_id= value
	    End If
    End Set
End property 

Protected _password as string  = "" 
<XmlElementAttribute("password")> _
Public Overridable Property password() as string
    Get
	    Return _password
    End Get
    Set (byval value as string)
	    If _password <> value Then
	        IsChanged = True
	        _password= value
	    End If
    End Set
End property 

Protected _user_ean13 as string  = "" 
<XmlElementAttribute("user_ean13")> _
Public Overridable Property user_ean13() as string
    Get
	    Return _user_ean13
    End Get
    Set (byval value as string)
	    If _user_ean13 <> value Then
	        IsChanged = True
	        _user_ean13= value
	    End If
    End Set
End property 

Protected _create_uid as integer  = 0 
<XmlElementAttribute("create_uid")> _
Public Overridable Property create_uid() as integer
    Get
	    Return _create_uid
    End Get
    Set (byval value as integer)
	    If _create_uid <> value Then
	        IsChanged = True
	        _create_uid= value
	    End If
    End Set
End property 

Protected _create_date as DateTime  = Nothing 
<XmlElementAttribute("create_date")> _
Public Overridable Property create_date() as DateTime
    Get
	    Return _create_date
    End Get
    Set (byval value as DateTime)
	    If _create_date <> value Then
	        IsChanged = True
	        _create_date= value
	    End If
    End Set
End property 

Protected _write_uid as integer  = 0 
<XmlElementAttribute("write_uid")> _
Public Overridable Property write_uid() as integer
    Get
	    Return _write_uid
    End Get
    Set (byval value as integer)
	    If _write_uid <> value Then
	        IsChanged = True
	        _write_uid= value
	    End If
    End Set
End property 

Protected _write_date as DateTime  = Nothing 
<XmlElementAttribute("write_date")> _
Public Overridable Property write_date() as DateTime
    Get
	    Return _write_date
    End Get
    Set (byval value as DateTime)
	    If _write_date <> value Then
	        IsChanged = True
	        _write_date= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an User_user from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New User_userDAO
	    Dim int As User_user = Mgr.Read(Id)
            _ID = int.ID
            _user_name = int.user_name
            _user_id = int.user_id
            _password = int.password
            _user_ean13 = int.user_ean13
            _create_uid = int.create_uid
            _create_date = int.create_date
            _write_uid = int.write_uid
            _write_date = int.write_date
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an User_user on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New User_userDAO
	    Ris = Mgr.Save(Me)
	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ris
End Function

Protected Function InternalIsValid() As Boolean
	Dim Ris As Boolean = True
	  if _user_name.Length > 255 then Ris = False
  if _user_id.Length > 255 then Ris = False
  if _password.Length > 255 then Ris = False
  if _user_ean13.Length > 13 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of User_user object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _User_userDAO
Inherits LUNA.LunaBaseClassDAO(Of User_user)

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
'''Read from DB table User_user
''' </summary>
''' <returns>
'''Return a User_user object
''' </returns>
Public Overrides Function Read(Id as integer) as User_user
    Dim cls as new User_user

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM User_user where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("user_name") is DBNull.Value then cls.user_name = myReader("user_name")
                if not myReader("user_id") is DBNull.Value then cls.user_id = myReader("user_id")
                if not myReader("password") is DBNull.Value then cls.password = myReader("password")
                if not myReader("user_ean13") is DBNull.Value then cls.user_ean13 = myReader("user_ean13")
                if not myReader("create_uid") is DBNull.Value then cls.create_uid = myReader("create_uid")
                if not myReader("create_date") is DBNull.Value then cls.create_date = myReader("create_date")
                if not myReader("write_uid") is DBNull.Value then cls.write_uid = myReader("write_uid")
                if not myReader("write_date") is DBNull.Value then cls.write_date = myReader("write_date")
        	   
        End If
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table User_user
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as User_user) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO User_user ("
                                    sql &= " user_name,"
                                    sql &= " user_id,"
                                    sql &= " password,"
                                    sql &= " user_ean13,"
                                    sql &= " create_uid,"
                                    sql &= " create_date,"
                                    sql &= " write_uid,"
                                    sql &= " write_date"
                                  sql &= ") VALUES ("
                      sql &= " @user_name,"
                      sql &= " @user_id,"
                      sql &= " @password,"
                      sql &= " @user_ean13,"
                      sql &= " @create_uid,"
                      sql &= " @create_date,"
                      sql &= " @write_uid,"
                      sql &= " @write_date"
                      sql &= ")"
		        Else
			        sql = "UPDATE User_user SET "
                  sql &= "user_name = @user_name,"
                  sql &= "user_id = @user_id,"
                  sql &= "password = @password,"
                  sql &= "user_ean13 = @user_ean13,"
                  sql &= "create_uid = @create_uid,"
                  sql &= "create_date = @create_date,"
                  sql &= "write_uid = @write_uid,"
                  sql &= "write_date = @write_date"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@user_name", cls.user_name))
                DbCommand.Parameters.Add(New OleDbParameter("@user_id", cls.user_id))
                DbCommand.Parameters.Add(New OleDbParameter("@password", cls.password))
                DbCommand.Parameters.Add(New OleDbParameter("@user_ean13", cls.user_ean13))
                DbCommand.Parameters.Add(New OleDbParameter("@create_uid", cls.create_uid))
                              if cls.create_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@create_date", OleDbType.Date)
			        DataPar.Value = cls.create_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@create_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@write_uid", cls.write_uid))
                              if cls.write_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@write_date", OleDbType.Date)
			        DataPar.Value = cls.write_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@write_date", DBNull.Value))
                end if  
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
    'Dim Sql As String = "UPDATE User_user SET DELETED=True "
    Dim Sql As String = "DELETE FROM User_user"
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
'''Delete from DB table User_user. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table User_user. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as User_user, Optional ByRef ListaObj as List (of User_user) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_user)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_user)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_user)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of User_user)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of User_user)
    Dim Ls As New List(Of User_user)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from User_user" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of User_user)
    Dim Ls As New List(Of User_user)
    Try

    Dim sql As String = ""
    sql ="SELECT * from User_user" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of User_user)
    Dim Ls As New List(Of User_user)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  User_user() With {.ID = 0 ,.user_name = "" ,.user_id = "" ,.password = "" ,.user_ean13 = "" ,.create_uid = 0 ,.create_date = Nothing ,.write_uid = 0 ,.write_date = Nothing  })
        while myReader.Read
	        Dim classe as new User_user
	        classe.ID = myReader("ID")
                            if not myReader("user_name") is DBNull.Value then classe.user_name = myReader("user_name")
                            if not myReader("user_id") is DBNull.Value then classe.user_id = myReader("user_id")
                            if not myReader("password") is DBNull.Value then classe.password = myReader("password")
                            if not myReader("user_ean13") is DBNull.Value then classe.user_ean13 = myReader("user_ean13")
                            if not myReader("create_uid") is DBNull.Value then classe.create_uid = myReader("create_uid")
                            if not myReader("create_date") is DBNull.Value then classe.create_date = myReader("create_date")
                            if not myReader("write_uid") is DBNull.Value then classe.write_uid = myReader("write_uid")
                            if not myReader("write_date") is DBNull.Value then classe.write_date = myReader("write_date")
            	   
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
