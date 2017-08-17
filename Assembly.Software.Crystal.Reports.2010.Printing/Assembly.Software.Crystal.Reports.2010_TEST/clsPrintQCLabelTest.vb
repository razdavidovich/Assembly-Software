Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports PrintCrystalReportFile



'''<summary>
'''This is a test class for clsPrintQCLabelTest and is intended
'''to contain all clsPrintQCLabelTest Unit Tests
'''</summary>
<TestClass()> _
Public Class clsPrintQCLabelTest


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


    '''<summary>
    '''A test for PrintQCLabel
    '''</summary>
    <TestMethod()> _
    Public Sub PrintQCLabelTest()
        Dim target As clsPrintCRFile = New clsPrintCRFile
        Dim strReportName As String = "D:\Team Projects\Assembly Software\Infrastracrure Solutions\Assembly.Software.Crystal.Reports.2010.Printing\Assembly.Software.Crystal.Reports.2010.Printing\Reports\cycleEnd.rpt"
        Dim strRollNumber As String = "82031003712"


        Dim objParameters(0, 1) As Object

        'Filling Double Dimension Array With Parameter For Printing
        objParameters(0, 0) = "vchInventoryPackNo"
        objParameters(0, 1) = strRollNumber

        Dim intLang As Integer = 0 ' TODO: Initialize to an appropriate value
        target.PrintCRFile(strReportName, "PDFCreator", objParameters, "Portrait", "ATSFOL", "BALE_PLUS_OWNER", "sa", "eureka")
        'Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    <TestMethod()> _
  Public Sub PrintHousewareLabelTest()
        Dim target As clsPrintCRFile = New clsPrintCRFile
        Dim strReportName As String = "C:\support\labels\rptCageLable.rpt"



        Dim objReportParameters(1, 1) As Object

        'Filling Double Dimension Array With Parameter For Printing
        objReportParameters(0, 0) = "nWOID"
        objReportParameters(0, 1) = 64
        objReportParameters(1, 0) = "sUserName"
        objReportParameters(1, 1) = "liat Kompas"

        Dim intLang As Integer = 0 ' TODO: Initialize to an appropriate value
        target.PrintCRFile(strReportName, "PDFCreator", objReportParameters, "Portrait")
        'Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub


    '''<summary>
    '''A test for PrintQCLabel
    '''</summary>
    <TestMethod()> _
    Public Sub ViewQCLabelTest()
        Dim target As clsPrintCRFile = New clsPrintCRFile
        Dim strReportName As String = "D:\Team Projects\Assembly Software\Infrastracrure Solutions\Assembly.Software.Crystal.Reports.2010.Printing\Assembly.Software.Crystal.Reports.2010.Printing\Reports\cycleEnd.rpt"
        Dim strRollNumber As String = "82031003712"


        Dim objParameters(0, 1) As Object

        'Filling Double Dimension Array With Parameter For Printing
        objParameters(0, 0) = "vchInventoryPackNo"
        objParameters(0, 1) = strRollNumber

        Dim intLang As Integer = 0 ' TODO: Initialize to an appropriate value
        target.ViewCR(strReportName, "PDFCreator", objParameters, "Portrait", "ATSFOL", "BALE_PLUS_OWNER", "sa", "eureka")
        'Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
