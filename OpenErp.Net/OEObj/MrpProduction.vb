Public Class MrpProduction
    Public Property id As String
    Public Property create_uid As String
    Public Property create_date As String
    Public Property write_date As String
    Public Property write_uid As String
    Public Property origin As String
    Public Property product_uom As String
    Public Property product_uos_qty As String
    Public Property product_qty As String
    Public Property product_uos As String
    Public Property user_id As String
    Public Property location_src_id As String
    Public Property cycle_total As String
    Public Property date_start As String
    Public Property company_id As String
    Public Property priority As String
    Public Property state As String
    Public Property bom_id As String
    Public Property date_finished As String
    Public Property name As String
    Public Property product_id As String
    Public Property date_planned As String
    Public Property move_prod_id As String
    Public Property routing_id As String
    Public Property hour_total As String
    Public Property location_dest_id As String
    Public Property picking_id As String
    Public Property allow_reorder As String

    Public Property MrpProductions As List(Of MrpProduction)

End Class
