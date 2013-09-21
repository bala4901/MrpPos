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
'''DAO Class for table Product_case
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Product_case
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

Protected _product_id as integer  = 0 
<XmlElementAttribute("product_id")> _
Public Overridable Property product_id() as integer
    Get
	    Return _product_id
    End Get
    Set (byval value as integer)
	    If _product_id <> value Then
	        IsChanged = True
	        _product_id= value
	    End If
    End Set
End property 

Protected _pcs_per_case as integer  = 0 
<XmlElementAttribute("pcs_per_case")> _
Public Overridable Property pcs_per_case() as integer
    Get
	    Return _pcs_per_case
    End Get
    Set (byval value as integer)
	    If _pcs_per_case <> value Then
	        IsChanged = True
	        _pcs_per_case= value
	    End If
    End Set
End property 

Protected _case_product_id as integer  = 0 
<XmlElementAttribute("case_product_id")> _
Public Overridable Property case_product_id() as integer
    Get
	    Return _case_product_id
    End Get
    Set (byval value as integer)
	    If _case_product_id <> value Then
	        IsChanged = True
	        _case_product_id= value
	    End If
    End Set
    End Property

    Protected _product_code As String = ""
    <XmlElementAttribute("product_code")> _
    Public Overridable Property product_code() As String
        Get
            Return _product_code
        End Get
        Set(ByVal value As String)
            If _product_code <> value Then
                IsChanged = True
                _product_code = value
            End If
        End Set
    End Property

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
'''This method read an Product_case from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Product_caseDAO
	    Dim int As Product_case = Mgr.Read(Id)
            _ID = int.ID
            _product_id = int.product_id
            _pcs_per_case = int.pcs_per_case
            _case_product_id = int.case_product_id
            _create_date = int.create_date
            _create_uid = int.create_uid
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
'''This method save an Product_case on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Product_caseDAO
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
'''This class manage persistency on db of Product_case object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _Product_caseDAO
Inherits LUNA.LunaBaseClassDAO(Of Product_case)

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
'''Read from DB table Product_case
''' </summary>
''' <returns>
'''Return a Product_case object
''' </returns>
Public Overrides Function Read(Id as integer) as Product_case
    Dim cls as new Product_case

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM Product_case where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("product_id") is DBNull.Value then cls.product_id = myReader("product_id")
                if not myReader("pcs_per_case") is DBNull.Value then cls.pcs_per_case = myReader("pcs_per_case")
                if not myReader("case_product_id") is DBNull.Value then cls.case_product_id = myReader("case_product_id")
                if not myReader("create_date") is DBNull.Value then cls.create_date = myReader("create_date")
                if not myReader("create_uid") is DBNull.Value then cls.create_uid = myReader("create_uid")
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
'''Save on DB table Product_case
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Product_case) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO Product_case ("
                                    sql &= " product_id,"
                                    sql &= " pcs_per_case,"
                                    sql &= " case_product_id,"
                                    sql &= " create_date,"
                                    sql &= " create_uid,"
                                    sql &= " write_uid,"
                                    sql &= " write_date"
                                  sql &= ") VALUES ("
                      sql &= " @product_id,"
                      sql &= " @pcs_per_case,"
                      sql &= " @case_product_id,"
                      sql &= " @create_date,"
                      sql &= " @create_uid,"
                      sql &= " @write_uid,"
                      sql &= " @write_date"
                      sql &= ")"
		        Else
			        sql = "UPDATE Product_case SET "
                  sql &= "product_id = @product_id,"
                  sql &= "pcs_per_case = @pcs_per_case,"
                  sql &= "case_product_id = @case_product_id,"
                  sql &= "create_date = @create_date,"
                  sql &= "create_uid = @create_uid,"
                  sql &= "write_uid = @write_uid,"
                  sql &= "write_date = @write_date"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@product_id", cls.product_id))
                DbCommand.Parameters.Add(New OleDbParameter("@pcs_per_case", cls.pcs_per_case))
                DbCommand.Parameters.Add(New OleDbParameter("@case_product_id", cls.case_product_id))
                              if cls.create_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@create_date", OleDbType.Date)
			        DataPar.Value = cls.create_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@create_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@create_uid", cls.create_uid))
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
    'Dim Sql As String = "UPDATE Product_case SET DELETED=True "
    Dim Sql As String = "DELETE FROM Product_case"
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
'''Delete from DB table Product_case. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Product_case. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Product_case, Optional ByRef ListaObj as List (of Product_case) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_case)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_case)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_case)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Product_case)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_case)
    Dim Ls As New List(Of Product_case)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Product_case" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Product_case)
    Dim Ls As New List(Of Product_case)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Product_case" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Product_case)
    Dim Ls As New List(Of Product_case)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  Product_case() With {.ID = 0 ,.product_id = 0 ,.pcs_per_case = 0 ,.case_product_id = 0 ,.create_date = Nothing ,.create_uid = 0 ,.write_uid = 0 ,.write_date = Nothing  })
        while myReader.Read
	        Dim classe as new Product_case
	        classe.ID = myReader("ID")
                            if not myReader("product_id") is DBNull.Value then classe.product_id = myReader("product_id")
                            if not myReader("pcs_per_case") is DBNull.Value then classe.pcs_per_case = myReader("pcs_per_case")
                            if not myReader("case_product_id") is DBNull.Value then classe.case_product_id = myReader("case_product_id")
                            if not myReader("create_date") is DBNull.Value then classe.create_date = myReader("create_date")
                            if not myReader("create_uid") is DBNull.Value then classe.create_uid = myReader("create_uid")
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
