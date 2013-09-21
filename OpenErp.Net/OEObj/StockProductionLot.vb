Public Class StockProductionLot
    Public Property id As String
    Public Property create_uid As String
    Public Property create_date As String
    Public Property write_date As String
    Public Property write_uid As String
    Public Property name As String
    Public Property company_id As String
    Public Property prefix As String
    Public Property product_id As String
    Public Property dates As String
    Public Property ref As String
    Public Property life_date As String
    Public Property removal_date As String
    Public Property alert_date As String
    Public Property use_date As String

    Public Property StockProductionLots As List(Of StockProductionLot)
End Class
