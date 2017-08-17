Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Assembly.Software.Loftware

<TestClass()> 
Public Class clsLoftwareServerTests


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

    <TestMethod()> _
    Public Sub CheckServerStatusOK_TEST()
        'Initialize the test parameters
        Dim target As New clsLoftwareServer
        Dim strLoftwareServerIPAddress As String = "192.168.2.40"
        Dim strLoftwareServerPort As Integer = 2723
        Dim intExpectedValse As Integer = clsLoftwareServer.ServerStatusType.OK

        Assert.AreEqual(intExpectedValse, Convert.ToInt32(target.ServerStatus(strLoftwareServerIPAddress, strLoftwareServerPort)), "The Loftware server did not respond as expected, please check the exception returned")

    End Sub

    <TestMethod()> _
    Public Sub CheckServerStatusInvalid_TEST()
        'Initialize the test parameters
        Dim target As New clsLoftwareServer
        Dim strLoftwareServerIPAddress As String = "192.168.2.40"
        Dim strLoftwareServerPort As Integer = 2722
        Dim intExpectedValse As Integer = clsLoftwareServer.ServerStatusType.Invalid

        Assert.AreEqual(intExpectedValse, Convert.ToInt32(target.ServerStatus(strLoftwareServerIPAddress, strLoftwareServerPort)), "The Loftware server did not respond as expected, please check the exception returned")

    End Sub

    <TestMethod()> _
    Public Sub GetPrintersList_TEST()
        Dim target As New clsLoftwareServer
        Dim strLoftwareServerIPAddress As String = "192.168.2.40"
        Dim intLoftwareServerPort As Integer = 2723
        Dim lstActualValue As List(Of clsPrinter)

        lstActualValue = target.GetPrintersList(strLoftwareServerIPAddress, intLoftwareServerPort)
        Assert.AreEqual("Loftware Zebra 140", lstActualValue(3).PrinterName, "The printer name does not match")
        Assert.AreEqual(8, lstActualValue.Count, "The number of printers on the server does not match")
        Assert.AreEqual("Carrier Tape labels", lstActualValue(3).PrinterAlias, "The printer alias name does not match")
        Assert.AreEqual(4, lstActualValue(3).PrinterNumber, "The printer number does not match")

    End Sub

    <TestMethod()> _
    Public Sub GetLabelsList_TEST()
        Dim target As New clsLoftwareServer
        Dim strLoftwareServerIPAddress As String = "192.168.2.40"
        Dim intLoftwareServerPort As Integer = 2723
        Dim lstActualValue As List(Of String)

        Dim strFolderLocation As String = String.Empty
        lstActualValue = target.GetLabelsList(strLoftwareServerIPAddress, intLoftwareServerPort, strFolderLocation)
        Assert.AreEqual(35, lstActualValue.Count, "The number of fields in the supplied label does not match")

    End Sub

    <TestMethod()> _
    Public Sub GetLabelFields_TEST()
        Dim target As New clsLoftwareServer
        Dim strLoftwareServerIPAddress As String = "192.168.2.40"
        Dim intLoftwareServerPort As Integer = 2723
        Dim lstActualValue As Dictionary(Of String, Integer)

        Dim strLabelName As String = "UnitTestLabel.lwl"
        Dim strFolderName As String = ""

        lstActualValue = target.GetLabelFields(strLoftwareServerIPAddress, intLoftwareServerPort, strFolderName, strLabelName)
        Assert.AreEqual(2, lstActualValue.Count, "The number of fields in the supplied label does not match")

    End Sub

    <TestMethod()> _
    Public Sub GetLabelFields_Folder_TEST()
        Dim target As New clsLoftwareServer
        Dim strLoftwareServerIPAddress As String = "192.168.2.40"
        Dim intLoftwareServerPort As Integer = 2723
        Dim lstActualValue As Dictionary(Of String, Integer)

        Dim strLabelName As String = "UnitTestLabel.lwl"
        Dim strFolderName As String = "UnitTestFolder"

        lstActualValue = target.GetLabelFields(strLoftwareServerIPAddress, intLoftwareServerPort, strFolderName, strLabelName)
        Assert.AreEqual(2, lstActualValue.Count, "The number of fields in the supplied label does not match")

    End Sub


End Class