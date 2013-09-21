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
'''DAO Class for table Product_product
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Product_product
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

Protected _code as string  = "" 
<XmlElementAttribute("code")> _
Public Overridable Property code() as string
    Get
	    Return _code
    End Get
    Set (byval value as string)
	    If _code <> value Then
	        IsChanged = True
	        _code= value
	    End If
    End Set
End property 

Protected _ean13 as string  = "" 
<XmlElementAttribute("ean13")> _
Public Overridable Property ean13() as string
    Get
	    Return _ean13
    End Get
    Set (byval value as string)
	    If _ean13 <> value Then
	        IsChanged = True
	        _ean13= value
	    End If
    End Set
End property 

Protected _price_per_kg as integer  = 0 
<XmlElementAttribute("price_per_kg")> _
Public Overridable Property price_per_kg() as integer
    Get
	    Return _price_per_kg
    End Get
    Set (byval value as integer)
	    If _price_per_kg <> value Then
	        IsChanged = True
	        _price_per_kg= value
	    End If
    End Set
End property 

Protected _day_to_expire as integer  = 0 
<XmlElementAttribute("day_to_expire")> _
Public Overridable Property day_to_expire() as integer
    Get
	    Return _day_to_expire
    End Get
    Set (byval value as integer)
	    If _day_to_expire <> value Then
	        IsChanged = True
	        _day_to_expire= value
	    End If
    End Set
End property 

Protected _name2 as string  = "" 
<XmlElementAttribute("name2")> _
Public Overridable Property name2() as string
    Get
	    Return _name2
    End Get
    Set (byval value as string)
	    If _name2 <> value Then
	        IsChanged = True
	        _name2= value
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

Protected _image as string  = "" 
<XmlElementAttribute("image")> _
Public Overridable Property image() as string
    Get
	    Return _image
    End Get
    Set (byval value as string)
	    If _image <> value Then
	        IsChanged = True
	        _image= value
	    End If
    End Set
End property 

Protected _is_case_item as integer  = 0 
<XmlElementAttribute("is_case_item")> _
Public Overridable Property is_case_item() as integer
    Get
	    Return _is_case_item
    End Get
    Set (byval value as integer)
	    If _is_case_item <> value Then
	        IsChanged = True
	        _is_case_item= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Product_product from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Product_productDAO
	    Dim int As Product_product = Mgr.Read(Id)
            _ID = int.ID
            _name = int.name
            _code = int.code
            _ean13 = int.ean13
            _price_per_kg = int.price_per_kg
            _day_to_expire = int.day_to_expire
            _name2 = int.name2
            _create_date = int.create_date
            _create_uid = int.create_uid
            _write_date = int.write_date
            _write_uid = int.write_uid
            _image = int.image
            _is_case_item = int.is_case_item
    	    Mgr.Dispose()
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Product_product on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Dim Mgr As New Product_productDAO
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
  if _code.Length > 255 then Ris = False
  if _ean13.Length > 13 then Ris = False
  if _name2.Length > 255 then Ris = False
  if _image.Length > 536870910 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''This class manage persistency on db of Product_product object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _Product_productDAO
Inherits LUNA.LunaBaseClassDAO(Of Product_product)

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
'''Read from DB table Product_product
''' </summary>
''' <returns>
'''Return a Product_product object
''' </returns>
Public Overrides Function Read(Id as integer) as Product_product
    Dim cls as new Product_product

    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = "SELECT * FROM Product_product where ID = " & Id
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        myReader.Read()
        if myReader.HasRows then
            cls.ID = myReader("ID")
                if not myReader("name") is DBNull.Value then cls.name = myReader("name")
                if not myReader("code") is DBNull.Value then cls.code = myReader("code")
                if not myReader("ean13") is DBNull.Value then cls.ean13 = myReader("ean13")
                if not myReader("price_per_kg") is DBNull.Value then cls.price_per_kg = myReader("price_per_kg")
                if not myReader("day_to_expire") is DBNull.Value then cls.day_to_expire = myReader("day_to_expire")
                if not myReader("name2") is DBNull.Value then cls.name2 = myReader("name2")
                if not myReader("create_date") is DBNull.Value then cls.create_date = myReader("create_date")
                if not myReader("create_uid") is DBNull.Value then cls.create_uid = myReader("create_uid")
                if not myReader("write_date") is DBNull.Value then cls.write_date = myReader("write_date")
                if not myReader("write_uid") is DBNull.Value then cls.write_uid = myReader("write_uid")
                if not myReader("image") is DBNull.Value then cls.image = myReader("image")
                if not myReader("is_case_item") is DBNull.Value then cls.is_case_item = myReader("is_case_item")
        	   
        End If
        myReader.Close()
        myCommand.Dispose()

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table Product_product
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Product_product) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Dim DbCommand As OleDbCommand = New OleDbCommand()
	        Try
		        Dim sql As String = String.Empty
		        DbCommand.Connection = _cn
		        If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
		        If cls.ID = 0 Then
                        sql = "INSERT INTO Product_product ("
                        sql &= " [name],"
                        sql &= " [code],"
                        sql &= " [ean13],"
                        sql &= " [price_per_kg],"
                        sql &= " [day_to_expire],"
                        sql &= " [name2],"
                        sql &= " [create_date],"
                        sql &= " [create_uid],"
                        sql &= " [write_date],"
                        sql &= " [write_uid],"
                        sql &= " [image],"
                        sql &= " [is_case_item]"
                        sql &= ") VALUES ("
                        sql &= " @name,"
                        sql &= " @code,"
                        sql &= " @ean13,"
                        sql &= " @price_per_kg,"
                        sql &= " @day_to_expire,"
                        sql &= " @name2,"
                        sql &= " @create_date,"
                        sql &= " @create_uid,"
                        sql &= " @write_date,"
                        sql &= " @write_uid,"
                        sql &= " @image,"
                        sql &= " @is_case_item"
                        sql &= ")"
                    Else
                        sql = "UPDATE Product_product SET "
                        sql &= "[name] = @name,"
                        sql &= "[code] = @code,"
                        sql &= "[ean13] = @ean13,"
                        sql &= "[price_per_kg] = @price_per_kg,"
                        sql &= "[day_to_expire] = @day_to_expire,"
                        sql &= "[name2] = @name2,"
                        sql &= "[create_date] = @create_date,"
                        sql &= "[create_uid] = @create_uid,"
                        sql &= "[write_date] = @write_date,"
                        sql &= "[write_uid] = @write_uid,"
                        sql &= "[image] = @image,"
                        sql &= "[is_case_item] = @is_case_item"
                        sql &= " WHERE ID= " & cls.ID
                    End If

                    DbCommand.Parameters.Add(New OleDbParameter("@name", cls.name))
                    DbCommand.Parameters.Add(New OleDbParameter("@code", cls.code))
                    DbCommand.Parameters.Add(New OleDbParameter("@ean13", cls.ean13))
                    DbCommand.Parameters.Add(New OleDbParameter("@price_per_kg", cls.price_per_kg))
                    DbCommand.Parameters.Add(New OleDbParameter("@day_to_expire", cls.day_to_expire))
                    DbCommand.Parameters.Add(New OleDbParameter("@name2", cls.name2))
                    If cls.create_date <> Date.MinValue Then
                        Dim DataPar As New OleDbParameter("@create_date", OleDbType.Date)
                        DataPar.Value = cls.create_date
                        DbCommand.Parameters.Add(DataPar)
                    Else
                        DbCommand.Parameters.Add(New OleDbParameter("@create_date", DBNull.Value))
                    End If
                    DbCommand.Parameters.Add(New OleDbParameter("@create_uid", cls.create_uid))
                    If cls.write_date <> Date.MinValue Then
                        Dim DataPar As New OleDbParameter("@write_date", OleDbType.Date)
                        DataPar.Value = cls.write_date
                        DbCommand.Parameters.Add(DataPar)
                    Else
                        DbCommand.Parameters.Add(New OleDbParameter("@write_date", DBNull.Value))
                    End If
                    DbCommand.Parameters.Add(New OleDbParameter("@write_uid", cls.write_uid))
                    DbCommand.Parameters.Add(New OleDbParameter("@image", cls.image))
                    DbCommand.Parameters.Add(New OleDbParameter("@is_case_item", cls.is_case_item))
                    DbCommand.CommandType = CommandType.Text
                    DbCommand.CommandText = sql
                    DbCommand.ExecuteNonQuery()

                    If cls.ID = 0 Then
                        Dim IdInserito As Integer = 0
                        sql = "select @@identity"
                        DbCommand.CommandText = sql
                        IdInserito = DbCommand.ExecuteScalar()
                        cls.ID = IdInserito
                        Ris = IdInserito
                    Else
                        Ris = cls.ID
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
    'Dim Sql As String = "UPDATE Product_product SET DELETED=True "
    Dim Sql As String = "DELETE FROM Product_product"
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
'''Delete from DB table Product_product. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Product_product. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Product_product, Optional ByRef ListaObj as List (of Product_product) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_product)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_product)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_product)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Product_product)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Product_product)
    Dim Ls As New List(Of Product_product)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Product_product" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Product_product)
    Dim Ls As New List(Of Product_product)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Product_product" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Private Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Product_product)
    Dim Ls As New List(Of Product_product)
    Try
        Dim myCommand As OleDbCommand = _cn.CreateCommand()
        myCommand.CommandText = sql
        If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
        Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
        If AddEmptyItem Then Ls.Add(New  Product_product() With {.ID = 0 ,.name = "" ,.code = "" ,.ean13 = "" ,.price_per_kg = 0 ,.day_to_expire = 0 ,.name2 = "" ,.create_date = Nothing ,.create_uid = 0 ,.write_date = Nothing ,.write_uid = 0 ,.image = "" ,.is_case_item = 0  })
        while myReader.Read
	        Dim classe as new Product_product
	        classe.ID = myReader("ID")
                            if not myReader("name") is DBNull.Value then classe.name = myReader("name")
                            if not myReader("code") is DBNull.Value then classe.code = myReader("code")
                            if not myReader("ean13") is DBNull.Value then classe.ean13 = myReader("ean13")
                            if not myReader("price_per_kg") is DBNull.Value then classe.price_per_kg = myReader("price_per_kg")
                            if not myReader("day_to_expire") is DBNull.Value then classe.day_to_expire = myReader("day_to_expire")
                            if not myReader("name2") is DBNull.Value then classe.name2 = myReader("name2")
                            if not myReader("create_date") is DBNull.Value then classe.create_date = myReader("create_date")
                            if not myReader("create_uid") is DBNull.Value then classe.create_uid = myReader("create_uid")
                            if not myReader("write_date") is DBNull.Value then classe.write_date = myReader("write_date")
                            if not myReader("write_uid") is DBNull.Value then classe.write_uid = myReader("write_uid")
                            if not myReader("image") is DBNull.Value then classe.image = myReader("image")
                            if not myReader("is_case_item") is DBNull.Value then classe.is_case_item = myReader("is_case_item")
            	   
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
