Imports CookComputing.XmlRpc

Public Interface openErpAuthentication
    Inherits IXmlRpcProxy

    <XmlRpcMethod("login")> _
    Function login(ByVal dbName As String, _
                              ByVal username As String, _
                              ByVal pwd As String) As Integer



End Interface

' <XmlRpcUrl("http://erp.indomaguro.co.id:8069/xmlrpc/object")> _
Public Interface openErpLib
    Inherits IXmlRpcProxy

    ''' <summary>
    ''' Create
    ''' </summary>
    ''' <param name="dbname"></param>
    ''' <param name="uid"></param>
    ''' <param name="pwd"></param>
    ''' <param name="model"></param>
    ''' <param name="method">search</param>
    ''' <param name="pairValues">args = [('vat', '=', 'ZZZZZZ')] #query clause</param>
    ''' <returns>Object</returns>
    ''' <remarks></remarks>
    <XmlRpcMethod("execute")> _
    Function Create(ByVal dbname As String, _
                              ByVal uid As Integer, _
                              ByVal pwd As String, _
                              ByVal model As String, _
                              ByVal method As String, _
                              ByVal pairValues As XmlRpcStruct) As Integer

    ''' <summary>
    ''' Read
    ''' </summary>
    ''' <param name="dbname"></param>
    ''' <param name="uid"></param>
    ''' <param name="pwd"></param>
    ''' <param name="model"></param>
    ''' <param name="method">search</param>
    ''' <param name="filters">args = [('vat', '=', 'ZZZZZZ')] #query clause</param>
    ''' <returns>Object</returns>
    ''' <remarks></remarks>
    <XmlRpcMethod("execute")> _
    Function Search(ByVal dbname As String, _
                              ByVal uid As Integer, _
                              ByVal pwd As String, _
                              ByVal model As String, _
                              ByVal method As String, _
                              ByVal filters As [Object]()) As [Object]()
    ''' <summary>
    ''' Read
    ''' </summary>
    ''' <param name="dbname"></param>
    ''' <param name="uid"></param>
    ''' <param name="pwd"></param>
    ''' <param name="model"></param>
    ''' <param name="method">Read</param>
    ''' <param name="ids">#ids is a list of id</param>
    ''' <param name="fields">fields = ['name', 'active', 'vat', 'ref'] #fields to read</param>
    ''' <returns>Object</returns>
    ''' <remarks></remarks>
    <XmlRpcMethod("execute")> _
    Function Read(ByVal dbname As String, _
                              ByVal uid As Integer, _
                              ByVal pwd As String, _
                              ByVal model As String, _
                              ByVal method As String, _
                              ByVal ids As Object, _
                              ByVal fields As Object) As Object()


    ''' <summary>
    ''' Write
    ''' </summary>
    ''' <param name="dbname"></param>
    ''' <param name="uid"></param>
    ''' <param name="pwd"></param>
    ''' <param name="model"></param>
    ''' <param name="method">write</param>
    ''' <param name="ids"></param>
    ''' <param name="values">values = {'vat': 'ZZ1ZZZ'} #data to update</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    <XmlRpcMethod("execute")> _
    Function Write(ByVal dbname As String, _
                              ByVal uid As Integer, _
                              ByVal pwd As String, _
                              ByVal model As String, _
                              ByVal method As String, _
                              ByVal ids As Object, _
                              ByVal values As Object) As Integer

    ''' <summary>
    ''' Unlink
    ''' </summary>
    ''' <param name="dbname"></param>
    ''' <param name="uid"></param>
    ''' <param name="pwd"></param>
    ''' <param name="model"></param>
    ''' <param name="method">unlink</param>
    ''' <param name="ids"># ids : list of id</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    <XmlRpcMethod("execute")> _
    Function Unlink(ByVal dbname As String, _
                              ByVal uid As Integer, _
                              ByVal pwd As String, _
                              ByVal model As String, _
                              ByVal method As String, _
                              ByVal ids As Object) As Integer



End Interface
