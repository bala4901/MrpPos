Imports CookComputing.XmlRpc


Public Class Openerp

    Public Function searchProduct(ByVal conditions As ArrayList) As Object
        Return OESearch("product.product", conditions)
    End Function

    Public Function readProduct(ByVal ids As ArrayList, ByVal fields As ArrayList) As Object
        Return OERead("product.product", ids, fields)
    End Function

    Public Function LoadPosProducts(ByVal conditions As ArrayList) As Object()
        Dim ids As ArrayList = OESearch("product.product", conditions)

        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("active")
        fields.Add("name")
        fields.Add("to_weight")
        fields.Add("default_code")
        fields.Add("available_in_pos")
        fields.Add("image")
        fields.Add("ean13")

        Return readProduct(ids, fields)
    End Function

    Public Function searchProducts(ByVal conditions As ArrayList) As List(Of ProductProduct)
        Dim ids As ArrayList = OESearch("product.product", conditions)

        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("active")
        fields.Add("name")
        fields.Add("to_weight")
        fields.Add("default_code")
        fields.Add("available_in_pos")
        fields.Add("image")


        Dim objs As Object() = OERead("product.product", ids, fields)

        Dim productList As New List(Of ProductProduct)

        If objs.Length > 0 Then
            For Each obj As Object In objs
                Dim products As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim product As New ProductProduct

                For Each de As DictionaryEntry In products
                    _dictEntry = de
                    product.id = getDictValue(product.id, "id")
                    product.active = getDictValue(product.active, "active")
                    product.name = getDictValue(product.name, "name")
                    product.to_weight = getDictValue(product.to_weight, "to_weight")
                    product.default_code = getDictValue(product.default_code, "default_code")
                    product.image = getDictValue(product.image, "image")
                Next
                productList.Add(product)
            Next
        End If
        Return productList
    End Function

    Public Function addPosOrderHead(ByVal pairValues As XmlRpcStruct) As Integer
        Return OECreate("mrppos.order", pairValues)
    End Function

    Public Function addPosOrderDetail(ByVal pairValues As XmlRpcStruct) As Integer
        Return OECreate("mrppos.order.line", pairValues)
    End Function

    Public Function addProdLot(ByVal pairValues As XmlRpcStruct) As Integer
        Return OECreate("stock.production.lot", pairValues)
    End Function

    Public Function getProdLotsList(ByVal conditions As ArrayList) As List(Of StockProductionLot)
        Dim ids As ArrayList = OESearch("stock.production.lot", conditions)

        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("use_date")
        fields.Add("product_id")
        fields.Add("name")

        Dim objs As Object() = OERead("stock.production.lot", ids, fields)

        Dim ProdLotList As New List(Of StockProductionLot)

        If objs.Length > 0 Then
            For Each obj As Object In objs
                Dim prodLots As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim prodLot As New StockProductionLot

                For Each de As DictionaryEntry In prodLots
                    _dictEntry = de
                    prodLot.id = getDictValue(prodLot.id, "id")
                    prodLot.use_date = getDictValue(prodLot.use_date, "use_date")
                    prodLot.product_id = getDictValue(prodLot.product_id, "product_id")
                    prodLot.name = getDictValue(prodLot.name, "name")
                Next
                ProdLotList.Add(prodLot)
            Next
        End If

        Return ProdLotList

    End Function

    Public Function getMrpProdList(ByVal conditions As ArrayList) As List(Of MrpProduction)
        Dim ids As ArrayList = OESearch("mrp.production", conditions)

        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("product_id")
        fields.Add("name")
        fields.Add("location_src_id")
        fields.Add("date_start")
        fields.Add("date_planned")
        fields.Add("location_dest_id")

        Dim objs As Object() = OERead("mrp.production", ids, fields)

        Dim MrpProdList As New List(Of MrpProduction)

        If objs.Length > 0 Then
            For Each obj As Object In objs
                Dim mrpProds As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim mrpProd As New MrpProduction

                For Each de As DictionaryEntry In mrpProds
                    _dictEntry = de
                    mrpProd.id = getDictValue(mrpProd.id, "id")
                    mrpProd.product_id = getDictValue(mrpProd.product_id, "product_id")
                    mrpProd.name = getDictValue(mrpProd.name, "name")
                    mrpProd.location_src_id = getDictValue(mrpProd.location_src_id, "location_src_id")
                    mrpProd.date_start = getDictValue(mrpProd.date_start, "date_start")
                    mrpProd.date_planned = getDictValue(mrpProd.date_planned, "date_planned")
                    mrpProd.location_dest_id = getDictValue(mrpProd.location_dest_id, "location_dest_id")
                Next
                MrpProdList.Add(mrpProd)
            Next
        End If

        Return MrpProdList
    End Function

    Public Function getOrderHead(ByVal ids As ArrayList) As List(Of MrpProduction)


        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("name")
        fields.Add("product_id")
        fields.Add("prodlot_id")


        Dim objs As Object() = OERead("mrp_production", ids, fields)

        Dim MrpProdList As New List(Of MrpProduction)

        If objs.Length > 0 Then
            For Each obj As Object In objs
                Dim mrpProds As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim mrpProd As New MrpProduction

                For Each de As DictionaryEntry In mrpProds
                    _dictEntry = de
                    mrpProd.id = getDictValue(mrpProd.id, "id")
                    mrpProd.product_id = getDictValue(mrpProd.product_id, "product_id")
                    mrpProd.name = getDictValue(mrpProd.name, "name")
                    mrpProd.location_src_id = getDictValue(mrpProd.location_src_id, "location_src_id")
                    mrpProd.date_start = getDictValue(mrpProd.date_start, "date_start")
                    mrpProd.date_planned = getDictValue(mrpProd.date_planned, "date_planned")
                    mrpProd.location_dest_id = getDictValue(mrpProd.location_dest_id, "location_dest_id")
                Next
                MrpProdList.Add(mrpProd)
            Next
        End If

        Return MrpProdList
    End Function

    Public Function getOrderLines(ByVal ids As ArrayList) As List(Of MrpOrderLine)

        Dim lines As ArrayList = New ArrayList
        lines.Add("name")
        lines.Add("lines")

        Dim lineIds As Object() = OERead("mrppos.order", ids, lines)

        Dim orderLinesId As New ArrayList

        If lineIds.Length > 0 Then
            For Each obj As Object In lineIds
                Dim orderLines As XmlRpcStruct = TryCast(obj, XmlRpcStruct)

                For Each de As DictionaryEntry In orderLines
                    _dictEntry = de

                    If orderLinesId.Count > 0 Then Exit For

                    orderLinesId = getDictObjValue("lines")
                Next

            Next
        End If


        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("name")
        fields.Add("product_id")
        fields.Add("prodlot_id")
        fields.Add("qty")

        Dim objs As Object() = OERead("mrppos.order.line", orderLinesId, fields)

        Dim MrpOrderLineList As New List(Of MrpOrderLine)

        If objs.Length > 0 Then
            Dim rowNo As Integer = 1
            For Each obj As Object In objs
                Dim mrpProds As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim mrpProd As New MrpOrderLine

                mrpProd.no = rowNo
                mrpProd.check = False
                For Each de As DictionaryEntry In mrpProds
                    _dictEntry = de

                    mrpProd.id = getDictValue(mrpProd.id, "id")
                    mrpProd.name = getDictValue(mrpProd.name, "name")
                    mrpProd.qty = getDictValue(mrpProd.qty, "qty")

                    If de.Key = "product_id" Then
                        mrpProd.product_ids = getProducts(getDictObjValue("product_id"))
                        If mrpProd.product_ids.Count > 0 Then
                            mrpProd.product_id = mrpProd.product_ids(0).id
                            mrpProd.product_name = mrpProd.product_ids(0).name
                            mrpProd.product_ean13 = mrpProd.product_ids(0).ean13
                            mrpProd.product_code = mrpProd.product_ids(0).default_code
                            mrpProd.product_image = mrpProd.product_ids(0).image
                        End If
                    End If

                    If de.Key = "prodlot_id" Then
                        mrpProd.prodlot_ids = getStockProductionLots(getDictObjValue("prodlot_id"))
                        If mrpProd.prodlot_ids.Count > 0 Then
                            mrpProd.prodlot_id = mrpProd.prodlot_ids(0).id
                            mrpProd.prodlot_use_date = IIf(mrpProd.prodlot_ids(0).use_date.Length > 0, mrpProd.prodlot_ids(0).use_date.Substring(0, 10), "")
                            mrpProd.prodlot_name = mrpProd.prodlot_ids(0).name
                        End If
                    End If

                Next

                MrpOrderLineList.Add(mrpProd)

                rowNo += 1
            Next
        End If

        Return MrpOrderLineList
    End Function

    Public Function getOrderLine(ByVal ids As ArrayList) As List(Of MrpOrderLine)


        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("name")
        fields.Add("product_id")
        fields.Add("prodlot_id")
        fields.Add("qty")

        Dim objs As Object() = OERead("mrppos.order.line", ids, fields)

        Dim MrpOrderLineList As New List(Of MrpOrderLine)

        If objs.Length > 0 Then
            Dim rowNo As Integer = 1
            For Each obj As Object In objs
                Dim mrpProds As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim mrpProd As New MrpOrderLine

                mrpProd.no = rowNo
                mrpProd.check = False
                For Each de As DictionaryEntry In mrpProds
                    _dictEntry = de

                    mrpProd.id = getDictValue(mrpProd.id, "id")
                    mrpProd.name = getDictValue(mrpProd.name, "name")
                    mrpProd.qty = getDictValue(mrpProd.qty, "qty")

                    If de.Key = "product_id" Then
                        mrpProd.product_ids = getProducts(getDictObjValue("product_id"))
                        If mrpProd.product_ids.Count > 0 Then
                            mrpProd.product_id = mrpProd.product_ids(0).id
                            mrpProd.product_name = mrpProd.product_ids(0).name
                            mrpProd.product_ean13 = mrpProd.product_ids(0).ean13
                            mrpProd.product_code = mrpProd.product_ids(0).default_code
                            mrpProd.product_image = mrpProd.product_ids(0).image
                        End If
                    End If

                    If de.Key = "prodlot_id" Then
                        mrpProd.prodlot_ids = getStockProductionLots(getDictObjValue("prodlot_id"))
                        If mrpProd.prodlot_ids.Count > 0 Then
                            mrpProd.prodlot_id = mrpProd.prodlot_ids(0).id
                            mrpProd.prodlot_use_date = IIf(mrpProd.prodlot_ids(0).use_date.Length > 0, mrpProd.prodlot_ids(0).use_date.Substring(0, 10), "")
                            mrpProd.prodlot_name = mrpProd.prodlot_ids(0).name
                        End If
                    End If

                Next
                MrpOrderLineList.Add(mrpProd)

                rowNo += 1
            Next
        End If

        Return MrpOrderLineList
    End Function

    Private Function getProducts(ByVal ids As ArrayList) As List(Of ProductProduct)
        Dim productList As New List(Of ProductProduct)

        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("name")
        fields.Add("ean13")
        fields.Add("default_code")
        fields.Add("image")

        Dim objs As Object() = OERead("product.product", ids, fields)
        If objs.Length > 0 Then
            For Each obj As Object In objs
                Dim products As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim prod As New ProductProduct

                For Each de As DictionaryEntry In products
                    _dictEntry = de
                    prod.id = getDictValue(prod.id, "id")
                    prod.name = getDictValue(prod.name, "name")
                    prod.ean13 = getDictValue(prod.ean13, "ean13")
                    prod.default_code = getDictValue(prod.default_code, "default_code")
                    prod.image = getDictValue(prod.image, "image")
                Next
                productList.Add(prod)
            Next
        End If
        Return productList
    End Function

    Private Function getStockProductionLots(ByVal ids As ArrayList) As List(Of StockProductionLot)
        Dim stockProLotList As New List(Of StockProductionLot)

        Dim fields As ArrayList = New ArrayList
        fields.Add("id")
        fields.Add("name")
        fields.Add("use_date")

        Dim objs As Object() = OERead("stock.production.lot", ids, fields)
        If objs.Length > 0 Then
            For Each obj As Object In objs
                Dim products As XmlRpcStruct = TryCast(obj, XmlRpcStruct)
                Dim prod As New StockProductionLot

                For Each de As DictionaryEntry In products
                    _dictEntry = de
                    prod.id = getDictValue(prod.id, "id")
                    prod.name = getDictValue(prod.name, "name")
                    prod.use_date = getDictValue(prod.use_date, "use_date")
      
                Next
                stockProLotList.Add(prod)
            Next
        End If
        Return stockProLotList
    End Function



End Class