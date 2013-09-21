Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports AIMS



'''<summary>
'''This is a test class for PieceOperationTest and is intended
'''to contain all PieceOperationTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PieceOperationTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for getSummaryOrder
    '''</summary>
    <TestMethod(), _
     DeploymentItem("AIMS.exe")> _
    Public Sub getSummaryOrderTest()
        Dim target As PieceOperation_Accessor = New PieceOperation_Accessor() ' TODO: Initialize to an appropriate value
        Dim expected As mrp_order_line = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As mrp_order_line
        actual = target.getSummaryOrder
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for refreshOrderLineGrid
    '''</summary>
    <TestMethod(), _
     DeploymentItem("AIMS.exe")> _
    Public Sub refreshOrderLineGridTest()
        Dim target As PieceOperation_Accessor = New PieceOperation_Accessor() ' TODO: Initialize to an appropriate value
        target.refreshOrderLineGrid()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
