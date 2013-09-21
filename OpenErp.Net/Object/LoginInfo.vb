Imports OpenErp
Imports CookComputing.XmlRpc

Public Class LoginInfo
    Private urlLink As String = "/xmlrpc/common"


    Public Sub New(ByVal host As String, ByVal dbName As String _
                   , ByVal uName As String, ByVal pwd As String)
        _hostUrl = host
        _database = dbName
        _userName = uName
        _pwd = pwd
    End Sub



    Private _hostUrl As String

    Public ReadOnly Property HostUrl As String
        Get
            Return _hostUrl
        End Get

    End Property

    Private _database As String

    Public ReadOnly Property dName As String
        Get
            Return _database
        End Get

    End Property


    Private _userName As String

    Public ReadOnly Property UserName As String
        Get
            Return _userName
        End Get

    End Property


    Private _pwd As String

    Private Property PassWord As String
        Get
            Return _pwd
        End Get
        Set(ByVal value As String)
            _pwd = value
        End Set
    End Property


    Private _loginUserId As Integer

    Public Property LoginUserId As Integer
        Get
            Return _loginUserId
        End Get
        Set(ByVal value As Integer)
            _loginUserId = value
        End Set
    End Property

    Public Function login() As Boolean
        Dim proxy As openErpAuthentication
        proxy = CType(XmlRpcProxyGen.Create(GetType(openErpAuthentication)), openErpAuthentication)

        proxy.Url = HostUrl & urlLink

        Try
            LoginUserId = proxy.login(dName, UserName, PassWord)
            HOST = HostUrl
            db = dName
            uid = LoginUserId
            pwd = PassWord
            Return True
        Catch ex As Exception
            LoginUserId = 0
            Return False
        End Try

    End Function

    Public Function OEID() As LoginInfo
        Return Me
    End Function



End Class
