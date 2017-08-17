Imports System.Data
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assembly.Software.Utilities


'''<summary>
'''This is a test class for clsExcelExportTest and is intended
'''to contain all clsExcelExportTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Test_clsExcelExport


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
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
    '''A test for ExportDataTableToExcel
    '''</summary>
    <TestMethod()> _
    Public Sub ExportDataTableToExcelTest2()
        Dim dtsDataset As DataSet = Nothing ' TODO: Initialize to an appropriate value
        Dim intTableIndex As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim strFileName As String = String.Empty ' TODO: Initialize to an appropriate value
        clsExcelExport.ExportDataTableToExcel(dtsDataset, intTableIndex, strFileName)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for ExportDataTableToExcel
    '''</summary>
    <TestMethod()> _
    Public Sub ExportDataTableToExcelTest1()
        Dim dtsDataset As DataSet = Nothing ' TODO: Initialize to an appropriate value
        Dim strTableName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim strFileName As String = String.Empty ' TODO: Initialize to an appropriate value
        clsExcelExport.ExportDataTableToExcel(dtsDataset, strTableName, strFileName)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for ExportDatasetToExcel
    '''</summary>
    <TestMethod()> _
    Public Sub ExportDatasetToExcelTest()
        Dim source As DataSet = Nothing ' TODO: Initialize to an appropriate value
        Dim fileName As String = String.Empty ' TODO: Initialize to an appropriate value
        clsExcelExport.ExportDatasetToExcel(source, fileName)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for ExportDataTableToExcel
    '''</summary>
    <TestMethod()> _
    Public Sub ExportDataTableToExcelTest()
        Dim dtlDataTable As DataTable = Nothing ' TODO: Initialize to an appropriate value
        Dim strFileName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim strTableName As String = String.Empty ' TODO: Initialize to an appropriate value
        clsExcelExport.ExportDataTableToExcel(dtlDataTable, strFileName, strTableName)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
