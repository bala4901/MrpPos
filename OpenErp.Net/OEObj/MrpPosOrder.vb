Public Class MrpPosOrder
    Public Property company_id As String
    Public Property create_date As String
    Public Property create_uid As String
    Public Property date_order As String
    Public Property id As String
    Public Property name As String
    Public Property nb_print As String
    Public Property note As String
    Public Property pos_reference As String
    Public Property prodlot_id As String
    Public Property session_id As String
    Public Property shop_id As String
    Public Property state As String
    Public Property user_id As String
    Public Property write_date As String
    Public Property write_uid As String
    Public Property lines As List(Of MrpOrderLine)


    Public Property MrpPosOrders As List(Of MrpPosOrder)
End Class
