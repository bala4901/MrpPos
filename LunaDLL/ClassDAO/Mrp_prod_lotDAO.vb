#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.0.0.1 
'Author: Diego Lunadei
'Date: 21/08/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.OleDb

''' <summary>
'''DAO Class for table Mrp_prod_lot
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Mrp_prod_lot
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

Protected _name as string  = "" 
<XmlElementAttribute("name")> _
Public Overridable Property name() as string
    Get
	    Return _name
    End Get
    Set (byval value as string)
	    If _name <> value Then
	        IsChanged = True
	        _name= value
	    End If
    End Set
End property 

Protected _expired_date as DateTime  = Nothing 
<XmlElementAttribute("expired_date")> _
Public Overridable Property expired_date() as DateTime
    Get
	    Return _expired_date
    End Get
    Set (byval value as DateTime)
	    If _expired_date <> value Then
	        IsChanged = True
	        _expired_date= value
	    End If
    End Set
End property 

Protected _manufacturing_date as DateTime  = Nothing 
<XmlElementAttribute("manufacturing_date")> _
Public Overridable Property manufacturing_date() as DateTime
    Get
	    Return _manufacturing_date
    End Get
    Set (byval value as DateTime)
	    If _manufacturing_date <> value Then
	        IsChanged = True
	        _manufacturing_date= value
	    End If
    End Set
End property 

Protected _days_to_expire as integer  = 0 
<XmlElementAttribute("days_to_expire")> _
Public Overridable Property days_to_expire() as integer
    Get
	    Return _days_to_expire
    End Get
    Set (byval value as integer)
	    If _days_to_expire <> value Then
	        IsChanged = True
	        _days_to_expire= value
	    End If
    End Set
End property 

Protected _create_uid as string  = "" 
<XmlElementAttribute("create_uid")> _
Public Overridable Property create_uid() as string
    Get
	    Return _create_uid
    End Get
    Set (byval value as string)
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


#End Region

#Region "Method"
''' <summary>
'''This method read an Mrp_prod_lot from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Mrp_prod_lotDAO
	    Dim int As Mrp_prod_lot = Mgr.Read(Id)
            _ID = int.ID
            _name = int.name
            _expired_date = int.expired_date
            _manufacturing_date = int.manufacturing_date
            _days_to_expire = int.days_to_expire
            _create_uid = int.create_uid
            _create_date = int.create_date
            _write_uid = int.write_uid
            _write_date = int.write_date
            _product_id = int.product_id
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Mrp_prod_lot on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Mrp_prod_lotDAO
	    Ris = Mgr.Save(Me)
	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ris
End Function

Protected Function InternalIsValid() As Boolean
	Dim Ris As Boolean = True
	  if _name.Length > 255 then Ris = False
  if _create_uid.Length > 255 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"

'RELAZIONE INDIRETTA
Protected _ListMrp_order as List(Of Mrp_order)
<XmlElementAttribute("ListMrp_order")> _
Public Property ListMrp_order() as List(Of Mrp_order)
Get
	If _ListMrp_order Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
		Dim Mgr As New Mrp_orderDAO
		Dim Param1 As New LUNA.LunaSearchParameter("lot_id", _ID)
		_ListMrp_order = Mgr.Find(Param1)
	End If
	Return _ListMrp_order
End Get
Set (ByVal value As List(Of Mrp_order))
	_ListMrp_order = value
End Set
End Property


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of Mrp_prod_lot object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _Mrp_prod_lotDAO
Inherits LUNA.LunaBaseClassDAO(Of Mrp_prod_lot)

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
'''Read from DB table Mrp_prod_lot
''' </summary>
''' <returns>
'''Return a Mrp_prod_lot object
''' </returns>
Public Overrides Function Read(Id as integer) as Mrp_prod_lot
    Dim cls as new Mrp_prod_lot

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM Mrp_prod_lot where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("name") is DBNull.Value then cls.name = myReader("name")
                if not myReader("expired_date") is DBNull.Value then cls.expired_date = myReader("expired_date")
                if not myReader("manufacturing_date") is DBNull.Value then cls.manufacturing_date = myReader("manufacturing_date")
                if not myReader("days_to_expire") is DBNull.Value then cls.days_to_expire = myReader("days_to_expire")
                if not myReader("create_uid") is DBNull.Value then cls.create_uid = myReader("create_uid")
                if not myReader("create_date") is DBNull.Value then cls.create_date = myReader("create_date")
                if not myReader("write_uid") is DBNull.Value then cls.write_uid = myReader("write_uid")
                if not myReader("write_date") is DBNull.Value then cls.write_date = myReader("write_date")
                if not myReader("product_id") is DBNull.Value then cls.product_id = myReader("product_id")
        	   
        End If
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table Mrp_prod_lot
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Mrp_prod_lot) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO Mrp_prod_lot ("
                                    sql &= " name,"
                                    sql &= " expired_date,"
                                    sql &= " manufacturing_date,"
                                    sql &= " days_to_expire,"
                                    sql &= " create_uid,"
                                    sql &= " create_date,"
                                    sql &= " write_uid,"
                                    sql &= " write_date,"
                                    sql &= " product_id"
                                  sql &= ") VALUES ("
                      sql &= " @name,"
                      sql &= " @expired_date,"
                      sql &= " @manufacturing_date,"
                      sql &= " @days_to_expire,"
                      sql &= " @create_uid,"
                      sql &= " @create_date,"
                      sql &= " @write_uid,"
                      sql &= " @write_date,"
                      sql &= " @product_id"
                      sql &= ")"
		        Else
			        sql = "UPDATE Mrp_prod_lot SET "
                  sql &= "name = @name,"
                  sql &= "expired_date = @expired_date,"
                  sql &= "manufacturing_date = @manufacturing_date,"
                  sql &= "days_to_expire = @days_to_expire,"
                  sql &= "create_uid = @create_uid,"
                  sql &= "create_date = @create_date,"
                  sql &= "write_uid = @write_uid,"
                  sql &= "write_date = @write_date,"
                  sql &= "product_id = @product_id"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@name", cls.name))
                              if cls.expired_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@expired_date", OleDbType.Date)
			        DataPar.Value = cls.expired_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@expired_date", DBNull.Value))
                end if  
                              if cls.manufacturing_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@manufacturing_date", OleDbType.Date)
			        DataPar.Value = cls.manufacturing_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@manufacturing_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@days_to_expire", cls.days_to_expire))
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
                DbCommand.Parameters.Add(New OleDbParameter("@product_id", cls.product_id))
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
    'Dim Sql As String = "UPDATE Mrp_prod_lot SET DELETED=True "
    Dim Sql As String = "DELETE FROM Mrp_prod_lot"
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
'''Delete from DB table Mrp_prod_lot. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Mrp_prod_lot. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Mrp_prod_lot, Optional ByRef ListaObj as List (of Mrp_prod_lot) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_prod_lot)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_prod_lot)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_prod_lot)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Mrp_prod_lot)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_prod_lot)
    Dim Ls As New List(Of Mrp_prod_lot)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Mrp_prod_lot" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Mrp_prod_lot)
    Dim Ls As New List(Of Mrp_prod_lot)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Mrp_prod_lot" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Mrp_prod_lot)
    Dim Ls As New List(Of Mrp_prod_lot)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  Mrp_prod_lot() With {.ID = 0 ,.name = "" ,.expired_date = Nothing ,.manufacturing_date = Nothing ,.days_to_expire = 0 ,.create_uid = "" ,.create_date = Nothing ,.write_uid = 0 ,.write_date = Nothing ,.product_id = 0  })
        while myReader.Read
	        Dim classe as new Mrp_prod_lot
	        classe.ID = myReader("ID")
                            if not myReader("name") is DBNull.Value then classe.name = myReader("name")
                            if not myReader("expired_date") is DBNull.Value then classe.expired_date = myReader("expired_date")
                            if not myReader("manufacturing_date") is DBNull.Value then classe.manufacturing_date = myReader("manufacturing_date")
                            if not myReader("days_to_expire") is DBNull.Value then classe.days_to_expire = myReader("days_to_expire")
                            if not myReader("create_uid") is DBNull.Value then classe.create_uid = myReader("create_uid")
                            if not myReader("create_date") is DBNull.Value then classe.create_date = myReader("create_date")
                            if not myReader("write_uid") is DBNull.Value then classe.write_uid = myReader("write_uid")
                            if not myReader("write_date") is DBNull.Value then classe.write_date = myReader("write_date")
                            if not myReader("product_id") is DBNull.Value then classe.product_id = myReader("product_id")
            	   
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
