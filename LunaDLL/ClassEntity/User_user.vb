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
'''Entity Class for table User_user
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class User_user
	Inherits _User_user

#Region "Logic Field"

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

Public Overrides Function Read(Id As Integer) As Integer
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
'''DAO Class for table User_user
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class User_userDAO
	Inherits _User_userDAO

End Class