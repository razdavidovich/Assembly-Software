Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Assembly.Software.Utilities



'''<summary>
'''This is a test class for clsApplicationLogFileTest and is intended
'''to contain all clsApplicationLogFileTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Test_clsApplicationLogFile


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
    '''A test for LogFilePath
    '''</summary>
    <TestMethod()> _
    Public Sub LogFilePathTest()
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        clsApplicationLogFile.LogFilePath = expected
        actual = clsApplicationLogFile.LogFilePath
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for LogFileName
    '''</summary>
    <TestMethod()> _
    Public Sub LogFileNameTest()
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        clsApplicationLogFile.LogFileName = expected
        actual = clsApplicationLogFile.LogFileName
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for LogFileFullPath
    '''</summary>
    <TestMethod()> _
    Public Sub LogFileFullPathTest()
        Dim actual As String
        actual = clsApplicationLogFile.LogFileFullPath
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for LogFileExtension
    '''</summary>
    <TestMethod()> _
    Public Sub LogFileExtensionTest()
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        clsApplicationLogFile.LogFileExtension = expected
        actual = clsApplicationLogFile.LogFileExtension
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for WriteLog
    '''</summary>
    <TestMethod()> _
    Public Sub WriteLogTest()
        Dim strTextToWrite As String = String.Empty ' TODO: Initialize to an appropriate value
        clsApplicationLogFile.WriteLog(strTextToWrite)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for clsApplicationLogFile Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub clsApplicationLogFileConstructorTest()
        Dim target As clsApplicationLogFile = New clsApplicationLogFile
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for clsApplicationLogFile Constructor
    ''' ExpectedException(GetType(System.IO.IOException))
    '''</summary>
    <TestMethod()> _
    Public Sub clsApplicationLogFile_Error()

        clsApplicationLogFile.LogFilePath = "E:\"
        clsApplicationLogFile.WriteLog("Test Error")

    End Sub

End Class
