Imports CookComputing.XmlRpc

Module CommonMethod

    Public HOST As String
    Public db As String
    Public pwd As String
    Public uid As Integer
    Private server As String = "/xmlrpc/object"


    Public Function OECreate(ByVal model As String, ByVal args As XmlRpcStruct) As Integer
        Dim proxy As openErpLib
        proxy = CType(XmlRpcProxyGen.Create(GetType(openErpLib)), openErpLib)

        proxy.Url = HOST & server

        Return proxy.Create(db, uid, pwd, model, "create", args)

    End Function

    Public Function OESearch(ByVal model As String, ByVal args As ArrayList) As ArrayList
        Dim proxy As openErpLib
        proxy = CType(XmlRpcProxyGen.Create(GetType(openErpLib)), openErpLib)

        proxy.Url = HOST & server

        Dim idsList As New ArrayList
        Dim ids As Object() = proxy.Search(db, uid, pwd, model, "search", args.ToArray)

        If ids.Length Then
            For Each id As Integer In ids
                idsList.Add(id)
            Next
        End If

        Return idsList

    End Function

    Public Function OERead(ByVal model As String, ByVal ids As ArrayList, ByVal fields As ArrayList) As Object
        Dim proxy As openErpLib
        proxy = CType(XmlRpcProxyGen.Create(GetType(openErpLib)), openErpLib)

        proxy.Url = HOST & server

        Return proxy.Read(db, uid, pwd, model, "read", ids.ToArray, fields.ToArray)

    End Function


    Public Function OEWrite(ByVal model As String, ByVal ids As Object, ByVal values As Object) As Integer
        Dim proxy As openErpLib
        proxy = CType(XmlRpcProxyGen.Create(GetType(openErpLib)), openErpLib)

        proxy.Url = HOST & server

        Return proxy.Write(db, uid, pwd, model, "write", ids, values)

    End Function

    Public Function OEUnlink(ByVal model As String, ByVal ids As Object) As Integer
        Dim proxy As openErpLib
        proxy = CType(XmlRpcProxyGen.Create(GetType(openErpLib)), openErpLib)

        proxy.Url = HOST & server

        Return proxy.Unlink(db, uid, pwd, model, "unlink", ids)

    End Function

#Region "Tool"
    Public Function isDictKey(ByVal dict As DictionaryEntry, ByVal valString As String) As Boolean
        If dict.Key = valString Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getDictValue(ByVal definedVal As String, ByVal keyString As String) As String

        If _dictEntry.Key = keyString Then
            If TypeOf _dictEntry.Value Is Object() Then
                Return _dictEntry.Value(0)
            End If
            Return _dictEntry.Value
        Else
            Return definedVal
        End If

    End Function

    Public Function getDictObjValue(ByVal keyString As String) As ArrayList
        Dim arrVal As New ArrayList
        If _dictEntry.Key = keyString Then
            For Each Val As Object In _dictEntry.Value
                If TypeOf Val Is Integer Then
                    arrVal.Add(Val)
                End If
            Next
        End If
        Return arrVal

    End Function

    Public Property _dictEntry As DictionaryEntry

#End Region
End Module
