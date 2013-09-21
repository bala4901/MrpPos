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
'''Entity Class for table Mrp_order_line
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Mrp_order_line
    Inherits _Mrp_order_line

#Region "Logic Field"
    Public Overridable Property product_code As String
    Public Overridable Property product_name As String
    Public Overridable Property product_name2 As String

    Public Overridable Property price As String
    Public Overridable Property product_barcode As String
    Public Overridable Property piece As String
    Public Overridable Property ean13 As String
    Public Overridable Property exp_date As String
    Public Overridable Property lot_no As String
    Public Overridable Property pcs_per_case As String

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(ByVal Id As Integer) As Integer
        Return MyBase.Read(Id)
    End Function

    Public Overrides Function Save() As Integer
        Return MyBase.Save()
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''DAO Class for table Mrp_order_line
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class Mrp_order_lineDAO
    Inherits _Mrp_order_lineDAO

End Class