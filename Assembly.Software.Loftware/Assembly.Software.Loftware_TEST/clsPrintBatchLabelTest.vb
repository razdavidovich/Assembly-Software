Imports System.Data
Imports System.Collections
    Imports Loftware.Common
    Imports Microsoft.VisualStudio.TestTools.UnitTesting
    Imports System.Collections.Generic

'''<summary>
'''This is a test class for clsPrintBatchLabelTest and is intended
'''to contain all clsPrintBatchLabelTest Unit Tests
'''</summary>
<TestClass()>
Public Class clsPrintBatchLabelTest


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
    '''A test for PrintLabelFromDataTable
    '''</summary>
    <TestMethod()>
    Public Sub PrintLabelFromDataTable_Test()

        'Initialize the test parameters
        Dim target As clsPrintBatchLabels = New clsPrintBatchLabels
        Dim strLoftwareServerIPAddress As String = "192.168.2.182"
        Dim strLoftwareServerPort As Integer = 2723
        Dim strPrinterID As Integer = 4
        Dim strLabelName As String = "Delube.lwl"
        Dim intSerializedLabels As Integer = 2
        Dim intNumberOfCopies As Integer = 1
        Dim dtlParams As DataTable = GenerateDataTable()
        Dim lngErrorNumber As Long = 0
        Dim lngErrorNumberExpected As Long = 0
        Dim strErrorDescription As String = String.Empty
        Dim strErrorDescriptionExpected As String = String.Empty
        Dim lstReturnedStatus As List(Of clsRowPrintStatus)

        'Execute the tests
        lstReturnedStatus = target.PrintLabel(strLoftwareServerIPAddress, strLoftwareServerPort, strPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies,
                                        dtlParams, lngErrorNumber, strErrorDescription)

        'Check the expected error numbers and error description
        Assert.AreEqual(lngErrorNumberExpected, lngErrorNumber)
        Assert.AreEqual(strErrorDescriptionExpected, strErrorDescription)

        'Check the return value for the 
        Assert.AreEqual(2, lstReturnedStatus.Count(), "The number of returned status objects does not match the expected number")
        Assert.AreEqual(LLMStatusCodes.Success, lstReturnedStatus(0).PrintedJobStatus, "The expected status of the first print command does not match")
        Assert.AreEqual(LLMStatusCodes.Success, lstReturnedStatus(1).PrintedJobStatus, "The expected status of the first print command does not match")

    End Sub

    <TestMethod()>
    Public Sub PrintLabelFromHashtable_Test()
        'Initialize the test parameters
        Dim target As clsPrintBatchLabels = New clsPrintBatchLabels
        Dim strLoftwareServerIPAddress As String = "192.168.2.182"
        Dim strLoftwareServerPort As Integer = 2723
        Dim strPrinterID As Integer = 4
        Dim strLabelName As String = "Delube.lwl"
        Dim intSerializedLabels As Integer = 2
        Dim intNumberOfCopies As Integer = 1
        Dim htlParams As Hashtable = GenerateHashtable()
        Dim lngErrorNumber As Long = 0
        Dim lngErrorNumberExpected As Long = 0
        Dim strErrorDescription As String = String.Empty
        Dim strErrorDescriptionExpected As String = String.Empty
        Dim lstReturnedStatus As List(Of clsRowPrintStatus)

        'Execute the tests
        lstReturnedStatus = target.PrintLabel(strLoftwareServerIPAddress, strLoftwareServerPort, strPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies,
                                        htlParams, lngErrorNumber, strErrorDescription)

        'Check the expected error numbers and error description
        Assert.AreEqual(lngErrorNumberExpected, lngErrorNumber)
        Assert.AreEqual(strErrorDescriptionExpected, strErrorDescription)

        'Check the return value for the 
        Assert.AreEqual(1, lstReturnedStatus.Count(), "The number of returned status objects does not match the expected number")
        Assert.AreEqual(LLMStatusCodes.Success, lstReturnedStatus(0).PrintedJobStatus, "The expected status of the first print command does not match")

    End Sub

    Public Sub PrintLabelFromDictionary_test()
        'Initialize the test parameters
        Dim target As clsPrintBatchLabels = New clsPrintBatchLabels
        Dim strLoftwareServerIPAddress As String = "192.168.2.182"
        Dim strLoftwareServerPort As Integer = 2723
        Dim strPrinterID As Integer = 4
        Dim strLabelName As String = "Delube.lwl"
        Dim intSerializedLabels As Integer = 2
        Dim intNumberOfCopies As Integer = 1
        Dim dictParams As Dictionary(Of String, String) = GenerateDictionary()
        Dim lngErrorNumber As Long = 0
        Dim lngErrorNumberExpected As Long = 0
        Dim strErrorDescription As String = String.Empty
        Dim strErrorDescriptionExpected As String = String.Empty
        Dim lstReturnedStatus As List(Of clsRowPrintStatus)

        'Execute the tests
        lstReturnedStatus = target.PrintLabel(strLoftwareServerIPAddress, strLoftwareServerPort, strPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies,
                                        dictParams, lngErrorNumber, strErrorDescription)

        'Check the expected error numbers and error description
        Assert.AreEqual(lngErrorNumberExpected, lngErrorNumber)
        Assert.AreEqual(strErrorDescriptionExpected, strErrorDescription)

        'Check the return value for the 
        Assert.AreEqual(2, lstReturnedStatus.Count(), "The number of returned status objects does not match the expected number")
        Assert.AreEqual(LLMStatusCodes.Success, lstReturnedStatus(0).PrintedJobStatus, "The expected status of the first print command does not match")
        Assert.AreEqual(LLMStatusCodes.Success, lstReturnedStatus(1).PrintedJobStatus, "The expected status of the first print command does not match")
    End Sub

    Private Function GenerateHashtable() As Hashtable
        Dim htlHashtable As New Hashtable

        htlHashtable.Add("brcPellet", "Test 22")
        htlHashtable.Add("brcQty", "999")

        Return htlHashtable
    End Function

    Private Function GenerateDataTable() As DataTable
        ' Create new datatable
        Dim dtlDataTable As New DataTable

        ' Create columns
        dtlDataTable.Columns.Add("brcPellet", Type.GetType("System.String"))
        dtlDataTable.Columns.Add("brcQty", Type.GetType("System.String"))
        dtlDataTable.Columns.Add("NullValue", Type.GetType("System.String"))

        ' Declare row
        Dim dtrRow As DataRow

        ' create new row
        dtrRow = dtlDataTable.NewRow
        dtrRow("brcPellet") = "Test 1"
        dtrRow("brcQty") = "Test 2"
        dtrRow("NullValue") = DBNull.Value
        dtlDataTable.Rows.Add(dtrRow)

        ' create new row
        dtrRow = dtlDataTable.NewRow
        dtrRow("brcPellet") = "4651HHD234ET"
        dtrRow("brcQty") = "555"
        dtrRow("NullValue") = DBNull.Value
        dtlDataTable.Rows.Add(dtrRow)

        ' return the datatable filled with 2 columns and 1 rows
        Return dtlDataTable

    End Function

    Private Function GenerateDictionary() As Dictionary(Of String, String)
        Dim dictDictionary As New Dictionary(Of String, String)
        dictDictionary.Add("brcPellet", "Test 22")
        dictDictionary.Add("brcQty", "999")

        Return dictDictionary

    End Function


End Class

