Partial Public Class Product_Product
    Public Property pcs_per_case As Integer
End Class

Partial Public Class Product_Case
    Public Property product_code As String
End Class


Partial Public Class mrp_order_line
    Public Property code As String
    Public Property lot_no As String
    Public Property total_weight As String
    Public Property unit_price As String
    Public Property exp_date As String
    Public Property eancode As String
    Public Property line1 As String
    Public Property line2 As String
    Public Property barcode As String
    Public Property eanCodeFont As String
    Public Property check As Boolean
    Public Property no As String
    Public Property no_of_pcs As String
    Public Property total_price As String
    Public Property no_of_box As String
    Public Property isPrintComp As Boolean
    Public Property case_serial_no As String

End Class


Partial Public Class mrp_order_case

    Public Property no As String

End Class


