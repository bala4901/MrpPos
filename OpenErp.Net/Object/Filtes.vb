Public Class Filtes

    Public Sub New(ByVal field As String, ByVal oper As String _
               , ByVal value As String)
        _field = field
        _oper = oper
        _value = value
    End Sub

    Private _field As String

    Public Property Field As String
        Get
            Return _field
        End Get
        Set(ByVal value As String)
            _field = value
        End Set

    End Property

    Private _oper As String
    Public Property Oper As String
        Get
            Return _oper
        End Get
        Set(ByVal value As String)
            _oper = value
        End Set

    End Property

    Private _value As String
    Public Property Val As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set

    End Property

End Class
