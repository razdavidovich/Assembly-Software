Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assembly.Software.Utilities

'''<summary>
'''This is a test class for ConfigTest and is intended
'''to contain all ConfigTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Test_clsConfig

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
    '''A test for ReadConfigValue
    '''</summary>
    <TestMethod()> _
    Public Sub ReadConfigValueTest()
        Dim ItemName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim ConfigSection As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim ConfigGroup As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = Config.ReadConfigValue(ItemName, ConfigSection, ConfigGroup)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for SaveConfigValue
    '''</summary>
    <TestMethod()> _
    Public Sub SaveConfigValueTest()
        Dim ItemName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim ConfigSection As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim ConfigGroup As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim strValue As String = String.Empty ' TODO: Initialize to an appropriate value
        Config.SaveConfigValue(ItemName, ConfigSection, ConfigGroup, strValue)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Config Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub ConfigConstructorTest()
        Dim target As Config = New Config
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    ''' <summary>
    ''' Test for the registry writing function
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub Test_ConfigWriteKeyValue()
        Dim strOriginalResult As String
        Dim strResult As String
        Dim strOriginalCommonDir As String = "C:\Program Files\Common Files"
        Dim strCommonDir As String = "D:\Program Files\Common Files"

        'Save the current value to a temporary variable
        strOriginalResult = Config.ReadRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion", "CommonFilesDir")

        'Write a new value to the registry
        Config.WriteRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion", "CommonFilesDir", strCommonDir)

        'Read the current value and compare with the requested item
        strResult = Config.ReadRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion", "CommonFilesDir")
        Assert.AreEqual(strCommonDir, strResult, True, "The new registry item was not saved successfuly to the registry")

        'Write the original value back to the registry
        Config.WriteRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion", "CommonFilesDir", strOriginalCommonDir)

    End Sub

    ''' <summary>
    ''' Test for the registry writing function for not valid key specification
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    <ExpectedException(GetType(ArgumentNullException), "Could not locate the registry key")> _
    Public Sub Test_ConfigWriteNotValidKeyValue()
        Dim strCommonDir As String = "D:\Program Files\Common Files"

        'Write a new value to the registry
        Config.WriteRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion\DDD", "CommonFilesDir", strCommonDir)

    End Sub

    ''' <summary>
    ''' Test for the registry reading function for a valid key
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub Test_ConfigReadKeyValue()
        Dim strResult As String
        Dim strCommonDir As String = "C:\Program Files\Common Files"

        strResult = Config.ReadRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion", "CommonFilesDir")
        Assert.AreEqual(strCommonDir, strResult, True, "The expected registry key does not match")
    End Sub

    ''' <summary>
    ''' Test for the registry reading function for not valid key specification
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub Test_ConfigReadNotValidKeyValue()
        Dim strResult As String
        Dim strCommonDir As String = vbNullString

        strResult = Config.ReadRegistryValue(Config.enuRegistryRootItem.HKEY_LOCAL_MACHINE, "SOFTWARE\Microsoft\Windows\CurrentVersion\DDD", "CommonFilesDir")
        Assert.AreEqual(strCommonDir, strResult, True, "The expected registry key does not match")
    End Sub

End Class
