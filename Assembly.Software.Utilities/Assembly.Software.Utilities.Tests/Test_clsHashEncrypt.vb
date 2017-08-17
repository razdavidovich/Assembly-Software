Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Assembly.Software.Utilities



'''<summary>
'''This is a test class for clsHashEncryptTest and is intended
'''to contain all clsHashEncryptTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Test_clsHashEncrypt

    Private Const EMPTY_STRING_PASSWORD As String = "/1lQFHwsWY9dN+uuwpuog69Ul0X4w4Tx2Tp2tIJjB5Y="
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
    '''A test for EncodeString
    '''</summary>
    <TestMethod()> _
    Public Sub EncodeString_Empty_String_Test()
        Dim str As String = String.Empty
        Dim expected As String = EMPTY_STRING_PASSWORD
        Dim actual As String
        actual = clsHashEncrypt.EncodeString(str)
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for DecodeString
    '''</summary>
    <TestMethod()> _
    Public Sub DecodeString_Empty_String_Test()
        Dim str As String = EMPTY_STRING_PASSWORD
        Dim expected As String = String.Empty
        Dim actual As String
        actual = clsHashEncrypt.DecodeString(str)
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for ConvertStringToByteArray
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Assembly.Software.Utilities.dll")> _
    Public Sub ConvertStringToByteArrayTest()
        Dim s As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected() As Byte = Nothing ' TODO: Initialize to an appropriate value
        Dim actual() As Byte
        actual = clsHashEncrypt_Accessor.ConvertStringToByteArray(s)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for clsHashEncrypt Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub clsHashEncryptConstructorTest()
        Dim target As clsHashEncrypt = New clsHashEncrypt
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
