Imports OpenErp.Net

Module OErpShared

    Private oeUIDInfo As OpenErp.Net.LoginInfo

    Public Function OELogin(ByVal uName As String, ByVal pwd As String) As Boolean
        Dim login As New OpenErp.Net.LoginInfo(My.Settings.HostUrl _
                              , My.Settings.Database _
                              , My.Settings.uid _
                              , My.Settings.pwd)

        If login.login Then
            oeUIDInfo = login.OEID
            Return True
        Else
            Return False
        End If

    End Function

    Public Function getLoginInfo() As OpenErp.Net.LoginInfo
        Return oeUIDInfo
    End Function

    Public Property shareImageList() As ImageList
    Public Property shareProducts() As List(Of ProductProduct)
    Public Property sharedProducts() As List(Of Product_product)

    Public Property loginUser() As User_user

End Module
