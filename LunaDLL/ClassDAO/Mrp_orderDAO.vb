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
'''DAO Class for table Mrp_order
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Mrp_order
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

Protected _workstation_id as integer  = 0 
<XmlElementAttribute("workstation_id")> _
Public Overridable Property workstation_id() as integer
    Get
	    Return _workstation_id
    End Get
    Set (byval value as integer)
	    If _workstation_id <> value Then
	        IsChanged = True
	        _workstation_id= value
	    End If
    End Set
End property 

Protected _date_order as DateTime  = Nothing 
<XmlElementAttribute("date_order")> _
Public Overridable Property date_order() as DateTime
    Get
	    Return _date_order
    End Get
    Set (byval value as DateTime)
	    If _date_order <> value Then
	        IsChanged = True
	        _date_order= value
	    End If
    End Set
End property 

Protected _nb_print as string  = "" 
<XmlElementAttribute("nb_print")> _
Public Overridable Property nb_print() as string
    Get
	    Return _nb_print
    End Get
    Set (byval value as string)
	    If _nb_print <> value Then
	        IsChanged = True
	        _nb_print= value
	    End If
    End Set
End property 

Protected _lot_id as integer  = 0 
<XmlElementAttribute("lot_id")> _
Public Overridable Property lot_id() as integer
    Get
	    Return _lot_id
    End Get
    Set (byval value as integer)
	    If _lot_id <> value Then
	        IsChanged = True
	        _lot_id= value
	    End If
    End Set
End property 

Protected _state as string  = "" 
<XmlElementAttribute("state")> _
Public Overridable Property state() as string
    Get
	    Return _state
    End Get
    Set (byval value as string)
	    If _state <> value Then
	        IsChanged = True
	        _state= value
	    End If
    End Set
End property 

Protected _userid as integer  = 0 
<XmlElementAttribute("userid")> _
Public Overridable Property userid() as integer
    Get
	    Return _userid
    End Get
    Set (byval value as integer)
	    If _userid <> value Then
	        IsChanged = True
	        _userid= value
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

Protected _product_id as string  = "" 
<XmlElementAttribute("product_id")> _
Public Overridable Property product_id() as string
    Get
	    Return _product_id
    End Get
    Set (byval value as string)
	    If _product_id <> value Then
	        IsChanged = True
	        _product_id= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Mrp_order from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Mrp_orderDAO
	    Dim int As Mrp_order = Mgr.Read(Id)
            _ID = int.ID
            _name = int.name
            _workstation_id = int.workstation_id
            _date_order = int.date_order
            _nb_print = int.nb_print
            _lot_id = int.lot_id
            _state = int.state
            _userid = int.userid
            _create_date = int.create_date
            _create_uid = int.create_uid
            _write_date = int.write_date
            _write_uid = int.write_uid
            _product_id = int.product_id
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Mrp_order on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Mrp_orderDAO
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
  if _nb_print.Length > 255 then Ris = False
  if _state.Length > 255 then Ris = False
  if _product_id.Length > 255 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"

'RELAZIONE INDIRETTA
Protected _ListMrp_order_line as List(Of Mrp_order_line)
<XmlElementAttribute("ListMrp_order_line")> _
Public Property ListMrp_order_line() as List(Of Mrp_order_line)
Get
	If _ListMrp_order_line Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
		Dim Mgr As New Mrp_order_lineDAO
		Dim Param1 As New LUNA.LunaSearchParameter("order_id", _ID)
		_ListMrp_order_line = Mgr.Find(Param1)
	End If
	Return _ListMrp_order_line
End Get
Set (ByVal value As List(Of Mrp_order_line))
	_ListMrp_order_line = value
End Set
End Property

'RELAZIONE DIRETTA 2
<XmlElementAttribute("Mrp_prod_lot")> _
Protected _Mrp_prod_lot As Mrp_prod_lot
Public property Mrp_prod_lot() As  Mrp_prod_lot
    Get
	    If _Mrp_prod_lot Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
		    Dim Mgr As New Mrp_prod_lotDAO
		    _Mrp_prod_lot = Mgr.Read(_lot_id)
		    Mgr.Dispose()
	    End If
	    Return _Mrp_prod_lot
    End Get
    Set(ByVal value As Mrp_prod_lot)
	    _Mrp_prod_lot = value
            _lot_id = _Mrp_prod_lot.ID
    End Set
End Property


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of Mrp_order object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _Mrp_orderDAO
Inherits LUNA.LunaBaseClassDAO(Of Mrp_order)

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
'''Read from DB table Mrp_order
''' </summary>
''' <returns>
'''Return a Mrp_order object
''' </returns>
Public Overrides Function Read(Id as integer) as Mrp_order
    Dim cls as new Mrp_order

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM Mrp_order where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("name") is DBNull.Value then cls.name = myReader("name")
                if not myReader("workstation_id") is DBNull.Value then cls.workstation_id = myReader("workstation_id")
                if not myReader("date_order") is DBNull.Value then cls.date_order = myReader("date_order")
                if not myReader("nb_print") is DBNull.Value then cls.nb_print = myReader("nb_print")
                if not myReader("lot_id") is DBNull.Value then cls.lot_id = myReader("lot_id")
                if not myReader("state") is DBNull.Value then cls.state = myReader("state")
                if not myReader("userid") is DBNull.Value then cls.userid = myReader("userid")
                if not myReader("create_date") is DBNull.Value then cls.create_date = myReader("create_date")
                if not myReader("create_uid") is DBNull.Value then cls.create_uid = myReader("create_uid")
                if not myReader("write_date") is DBNull.Value then cls.write_date = myReader("write_date")
                if not myReader("write_uid") is DBNull.Value then cls.write_uid = myReader("write_uid")
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
'''Save on DB table Mrp_order
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Mrp_order) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO Mrp_order ("
                                    sql &= " name,"
                                    sql &= " workstation_id,"
                                    sql &= " date_order,"
                                    sql &= " nb_print,"
                                    sql &= " lot_id,"
                                    sql &= " state,"
                                    sql &= " userid,"
                                    sql &= " create_date,"
                                    sql &= " create_uid,"
                                    sql &= " write_date,"
                                    sql &= " write_uid,"
                                    sql &= " product_id"
                                  sql &= ") VALUES ("
                      sql &= " @name,"
                      sql &= " @workstation_id,"
                      sql &= " @date_order,"
                      sql &= " @nb_print,"
                      sql &= " @lot_id,"
                      sql &= " @state,"
                      sql &= " @userid,"
                      sql &= " @create_date,"
                      sql &= " @create_uid,"
                      sql &= " @write_date,"
                      sql &= " @write_uid,"
                      sql &= " @product_id"
                      sql &= ")"
		        Else
			        sql = "UPDATE Mrp_order SET "
                  sql &= "name = @name,"
                  sql &= "workstation_id = @workstation_id,"
                  sql &= "date_order = @date_order,"
                  sql &= "nb_print = @nb_print,"
                  sql &= "lot_id = @lot_id,"
                  sql &= "state = @state,"
                  sql &= "userid = @userid,"
                  sql &= "create_date = @create_date,"
                  sql &= "create_uid = @create_uid,"
                  sql &= "write_date = @write_date,"
                  sql &= "write_uid = @write_uid,"
                  sql &= "product_id = @product_id"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@name", cls.name))
                DbCommand.Parameters.Add(New OleDbParameter("@workstation_id", cls.workstation_id))
                              if cls.date_order <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@date_order", OleDbType.Date)
			        DataPar.Value = cls.date_order
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@date_order", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@nb_print", cls.nb_print))
                DbCommand.Parameters.Add(New OleDbParameter("@lot_id", cls.lot_id))
                DbCommand.Parameters.Add(New OleDbParameter("@state", cls.state))
                DbCommand.Parameters.Add(New OleDbParameter("@userid", cls.userid))
                              if cls.create_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@create_date", OleDbType.Date)
			        DataPar.Value = cls.create_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@create_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@create_uid", cls.create_uid))
                              if cls.write_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@write_date", OleDbType.Date)
			        DataPar.Value = cls.write_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@write_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@write_uid", cls.write_uid))
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
    'Dim Sql As String = "UPDATE Mrp_order SET DELETED=True "
    Dim Sql As String = "DELETE FROM Mrp_order"
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
'''Delete from DB table Mrp_order. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Mrp_order. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Mrp_order, Optional ByRef ListaObj as List (of Mrp_order) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Mrp_order)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order)
    Dim Ls As New List(Of Mrp_order)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Mrp_order" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Mrp_order)
    Dim Ls As New List(Of Mrp_order)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Mrp_order" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Mrp_order)
    Dim Ls As New List(Of Mrp_order)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  Mrp_order() With {.ID = 0 ,.name = "" ,.workstation_id = 0 ,.date_order = Nothing ,.nb_print = "" ,.lot_id = 0 ,.state = "" ,.userid = 0 ,.create_date = Nothing ,.create_uid = 0 ,.write_date = Nothing ,.write_uid = 0 ,.product_id = ""  })
        while myReader.Read
	        Dim classe as new Mrp_order
	        classe.ID = myReader("ID")
                            if not myReader("name") is DBNull.Value then classe.name = myReader("name")
                            if not myReader("workstation_id") is DBNull.Value then classe.workstation_id = myReader("workstation_id")
                            if not myReader("date_order") is DBNull.Value then classe.date_order = myReader("date_order")
                            if not myReader("nb_print") is DBNull.Value then classe.nb_print = myReader("nb_print")
                            if not myReader("lot_id") is DBNull.Value then classe.lot_id = myReader("lot_id")
                            if not myReader("state") is DBNull.Value then classe.state = myReader("state")
                            if not myReader("userid") is DBNull.Value then classe.userid = myReader("userid")
                            if not myReader("create_date") is DBNull.Value then classe.create_date = myReader("create_date")
                            if not myReader("create_uid") is DBNull.Value then classe.create_uid = myReader("create_uid")
                            if not myReader("write_date") is DBNull.Value then classe.write_date = myReader("write_date")
                            if not myReader("write_uid") is DBNull.Value then classe.write_uid = myReader("write_uid")
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
