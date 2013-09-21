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
'''DAO Class for table Mrp_order_line_box
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Mrp_order_line_box
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

Protected _no_pcs as string  = "" 
<XmlElementAttribute("no_pcs")> _
Public Overridable Property no_pcs() as string
    Get
	    Return _no_pcs
    End Get
    Set (byval value as string)
	    If _no_pcs <> value Then
	        IsChanged = True
	        _no_pcs= value
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

Protected _qty as integer  = 0 
<XmlElementAttribute("qty")> _
Public Overridable Property qty() as integer
    Get
	    Return _qty
    End Get
    Set (byval value as integer)
	    If _qty <> value Then
	        IsChanged = True
	        _qty= value
	    End If
    End Set
End property 

Protected _order_id as integer  = 0 
<XmlElementAttribute("order_id")> _
Public Overridable Property order_id() as integer
    Get
	    Return _order_id
    End Get
    Set (byval value as integer)
	    If _order_id <> value Then
	        IsChanged = True
	        _order_id= value
	    End If
    End Set
End property 

Protected _created_date as DateTime  = Nothing 
<XmlElementAttribute("created_date")> _
Public Overridable Property created_date() as DateTime
    Get
	    Return _created_date
    End Get
    Set (byval value as DateTime)
	    If _created_date <> value Then
	        IsChanged = True
	        _created_date= value
	    End If
    End Set
End property 

Protected _created_uid as integer  = 0 
<XmlElementAttribute("created_uid")> _
Public Overridable Property created_uid() as integer
    Get
	    Return _created_uid
    End Get
    Set (byval value as integer)
	    If _created_uid <> value Then
	        IsChanged = True
	        _created_uid= value
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

Protected _lot_id as string  = "" 
<XmlElementAttribute("lot_id")> _
Public Overridable Property lot_id() as string
    Get
	    Return _lot_id
    End Get
    Set (byval value as string)
	    If _lot_id <> value Then
	        IsChanged = True
	        _lot_id= value
	    End If
    End Set
End property 

Protected _order_line_id as integer  = 0 
<XmlElementAttribute("order_line_id")> _
Public Overridable Property order_line_id() as integer
    Get
	    Return _order_line_id
    End Get
    Set (byval value as integer)
	    If _order_line_id <> value Then
	        IsChanged = True
	        _order_line_id= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Mrp_order_line_box from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Mrp_order_line_boxDAO
	    Dim int As Mrp_order_line_box = Mgr.Read(Id)
            _ID = int.ID
            _name = int.name
            _no_pcs = int.no_pcs
            _product_id = int.product_id
            _qty = int.qty
            _order_id = int.order_id
            _created_date = int.created_date
            _created_uid = int.created_uid
            _write_date = int.write_date
            _write_uid = int.write_uid
            _lot_id = int.lot_id
            _order_line_id = int.order_line_id
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Mrp_order_line_box on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Mrp_order_line_boxDAO
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
  if _no_pcs.Length > 255 then Ris = False
  if _product_id.Length > 255 then Ris = False
  if _lot_id.Length > 255 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of Mrp_order_line_box object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _Mrp_order_line_boxDAO
Inherits LUNA.LunaBaseClassDAO(Of Mrp_order_line_box)

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
'''Read from DB table Mrp_order_line_box
''' </summary>
''' <returns>
'''Return a Mrp_order_line_box object
''' </returns>
Public Overrides Function Read(Id as integer) as Mrp_order_line_box
    Dim cls as new Mrp_order_line_box

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM Mrp_order_line_box where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("name") is DBNull.Value then cls.name = myReader("name")
                if not myReader("no_pcs") is DBNull.Value then cls.no_pcs = myReader("no_pcs")
                if not myReader("product_id") is DBNull.Value then cls.product_id = myReader("product_id")
                if not myReader("qty") is DBNull.Value then cls.qty = myReader("qty")
                if not myReader("order_id") is DBNull.Value then cls.order_id = myReader("order_id")
                if not myReader("created_date") is DBNull.Value then cls.created_date = myReader("created_date")
                if not myReader("created_uid") is DBNull.Value then cls.created_uid = myReader("created_uid")
                if not myReader("write_date") is DBNull.Value then cls.write_date = myReader("write_date")
                if not myReader("write_uid") is DBNull.Value then cls.write_uid = myReader("write_uid")
                if not myReader("lot_id") is DBNull.Value then cls.lot_id = myReader("lot_id")
                if not myReader("order_line_id") is DBNull.Value then cls.order_line_id = myReader("order_line_id")
        	   
        End If
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table Mrp_order_line_box
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Mrp_order_line_box) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                                sql = "INSERT INTO Mrp_order_line_box ("
                                    sql &= " name,"
                                    sql &= " no_pcs,"
                                    sql &= " product_id,"
                                    sql &= " qty,"
                                    sql &= " order_id,"
                                    sql &= " created_date,"
                                    sql &= " created_uid,"
                                    sql &= " write_date,"
                                    sql &= " write_uid,"
                                    sql &= " lot_id,"
                                    sql &= " order_line_id"
                                  sql &= ") VALUES ("
                      sql &= " @name,"
                      sql &= " @no_pcs,"
                      sql &= " @product_id,"
                      sql &= " @qty,"
                      sql &= " @order_id,"
                      sql &= " @created_date,"
                      sql &= " @created_uid,"
                      sql &= " @write_date,"
                      sql &= " @write_uid,"
                      sql &= " @lot_id,"
                      sql &= " @order_line_id"
                      sql &= ")"
		        Else
			        sql = "UPDATE Mrp_order_line_box SET "
                  sql &= "name = @name,"
                  sql &= "no_pcs = @no_pcs,"
                  sql &= "product_id = @product_id,"
                  sql &= "qty = @qty,"
                  sql &= "order_id = @order_id,"
                  sql &= "created_date = @created_date,"
                  sql &= "created_uid = @created_uid,"
                  sql &= "write_date = @write_date,"
                  sql &= "write_uid = @write_uid,"
                  sql &= "lot_id = @lot_id,"
                  sql &= "order_line_id = @order_line_id"
			        sql &= " WHERE ID= " & cls.ID
		        End if

                 DbCommand.Parameters.Add(New OleDbParameter("@name", cls.name))
                DbCommand.Parameters.Add(New OleDbParameter("@no_pcs", cls.no_pcs))
                DbCommand.Parameters.Add(New OleDbParameter("@product_id", cls.product_id))
                DbCommand.Parameters.Add(New OleDbParameter("@qty", cls.qty))
                DbCommand.Parameters.Add(New OleDbParameter("@order_id", cls.order_id))
                              if cls.created_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@created_date", OleDbType.Date)
			        DataPar.Value = cls.created_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@created_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@created_uid", cls.created_uid))
                              if cls.write_date <> Date.MinValue then
                    Dim DataPar As New OleDbParameter("@write_date", OleDbType.Date)
			        DataPar.Value = cls.write_date
			        DbCommand.Parameters.Add(DataPar)
                else
                    DbCommand.Parameters.Add(New OleDbParameter("@write_date", DBNull.Value))
                end if  
                DbCommand.Parameters.Add(New OleDbParameter("@write_uid", cls.write_uid))
                DbCommand.Parameters.Add(New OleDbParameter("@lot_id", cls.lot_id))
                DbCommand.Parameters.Add(New OleDbParameter("@order_line_id", cls.order_line_id))
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
    'Dim Sql As String = "UPDATE Mrp_order_line_box SET DELETED=True "
    Dim Sql As String = "DELETE FROM Mrp_order_line_box"
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
'''Delete from DB table Mrp_order_line_box. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Mrp_order_line_box. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Mrp_order_line_box, Optional ByRef ListaObj as List (of Mrp_order_line_box) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order_line_box)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order_line_box)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order_line_box)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Mrp_order_line_box)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Mrp_order_line_box)
    Dim Ls As New List(Of Mrp_order_line_box)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Mrp_order_line_box" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Mrp_order_line_box)
    Dim Ls As New List(Of Mrp_order_line_box)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Mrp_order_line_box" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Mrp_order_line_box)
    Dim Ls As New List(Of Mrp_order_line_box)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  Mrp_order_line_box() With {.ID = 0 ,.name = "" ,.no_pcs = "" ,.product_id = "" ,.qty = 0 ,.order_id = 0 ,.created_date = Nothing ,.created_uid = 0 ,.write_date = Nothing ,.write_uid = 0 ,.lot_id = "" ,.order_line_id = 0  })
        while myReader.Read
	        Dim classe as new Mrp_order_line_box
	        classe.ID = myReader("ID")
                            if not myReader("name") is DBNull.Value then classe.name = myReader("name")
                            if not myReader("no_pcs") is DBNull.Value then classe.no_pcs = myReader("no_pcs")
                            if not myReader("product_id") is DBNull.Value then classe.product_id = myReader("product_id")
                            if not myReader("qty") is DBNull.Value then classe.qty = myReader("qty")
                            if not myReader("order_id") is DBNull.Value then classe.order_id = myReader("order_id")
                            if not myReader("created_date") is DBNull.Value then classe.created_date = myReader("created_date")
                            if not myReader("created_uid") is DBNull.Value then classe.created_uid = myReader("created_uid")
                            if not myReader("write_date") is DBNull.Value then classe.write_date = myReader("write_date")
                            if not myReader("write_uid") is DBNull.Value then classe.write_uid = myReader("write_uid")
                            if not myReader("lot_id") is DBNull.Value then classe.lot_id = myReader("lot_id")
                            if not myReader("order_line_id") is DBNull.Value then classe.order_line_id = myReader("order_line_id")
            	   
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
