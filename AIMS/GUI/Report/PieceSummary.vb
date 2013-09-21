Imports WeifenLuo.WinFormsUI
Imports System.Linq
Imports Npgsql
Imports System.IO
Imports OpenErp.Net
Imports CookComputing.XmlRpc
Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class PieceSummary
    Inherits DockContent



    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Using db As New MrpPosEntities
            Dim olines As IEnumerable(Of MrpLineSummary) = From ol In db.mrp_order_line Join cs In db.mrp_order_case
                                                           On ol.box_id Equals cs.id
                                                           Join pr In db.product_product On ol.product_id Equals pr.id
                                                           Join lot In db.mrp_prod_lot On lot.id Equals ol.prodlot_id

            'Select New With {.id = ol.id, .code = pp.code, .line1 = pp.name, .line2 = pp.name2, .eancode = pp.ean13, _
            '                                                                           .lot_no = lot.name, .qty = ol.qty, .price = ol.price, .unit_price = pp.price_per_kg,
            '                                                                           .exp_date = lot.expired_date, .eanCodeFont = pp.ean13}) _
            '                                                               .AsEnumerable().Select(Function(x) New mrp_order_line With {.id = x.id, .code = x.code, .line1 = x.line1, .line2 = x.line2, .eancode = x.eancode, _
            '                                                                  .lot_no = x.lot_no, .qty = x.qty, .price = toDispCurrency(x.price), .unit_price = toDispCurrency(x.unit_price), .exp_date = Format(x.exp_date, "ddMMyy"), _
            '                                                                                                                           .barcode = "*" & x.lot_no & "." & x.qty.PadLeft(5, "0"c) & "." & x.id.ToString.PadLeft(8, "0"c) & "*", _
            '                                                                                                                           .eanCodeFont = setEAN13Code(x.eanCodeFont), .no = 0, .check = False})

            dgvLines.DataSource = olines
            dgvLines.Refresh()
        End Using
    End Sub
End Class