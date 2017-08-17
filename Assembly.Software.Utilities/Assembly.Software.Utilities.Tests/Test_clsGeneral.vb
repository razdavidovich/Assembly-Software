Imports Microsoft.VisualBasic

Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Assembly.Software.Utilities



'''<summary>
'''This is a test class for GeneralTest and is intended
'''to contain all GeneralTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Test_clsGeneral


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
    '''A test for FileTimeString
    '''</summary>
    <TestMethod()> _
    Public Sub FileTimeStringTest()
        Dim actual As String
        actual = General.FileTimeString
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for FileDateString
    '''</summary>
    <TestMethod()> _
    Public Sub FileDateStringTest()
        Dim actual As String
        actual = General.FileDateString
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for DebugMode
    '''</summary>
    <TestMethod()> _
    Public Sub DebugModeTest()
        Dim actual As Boolean
        actual = General.DebugMode
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ConnectionString
    '''</summary>
    <TestMethod()> _
    Public Sub ConnectionStringTest()
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        General.ConnectionString = expected
        actual = General.ConnectionString
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ApplicationPath
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationPathTest()
        Dim actual As String
        actual = General.ApplicationPath
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for SerialNumberToHex
    '''</summary>
    <TestMethod()> _
    Public Sub SerialNumberToHexTest()
        Dim intSerialNumber As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim intLocation As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Long = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Long
        actual = General.SerialNumberToHex(intSerialNumber, intLocation)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for DisplayMessageBoxRTL
    '''</summary>
    <TestMethod()> _
    Public Sub DisplayMessageBoxRTLTest()
        Dim intMessageID As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim strAdditionaltext As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim ex As Exception = Nothing ' TODO: Initialize to an appropriate value
        Dim strExeptionAdditionlText As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As MsgBoxResult = New MsgBoxResult ' TODO: Initialize to an appropriate value
        Dim actual As MsgBoxResult
        actual = General.DisplayMessageBoxRTL(intMessageID, strAdditionaltext, ex, strExeptionAdditionlText)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for DisplayMessageBoxLTR
    '''</summary>
    <TestMethod()> _
    Public Sub DisplayMessageBoxLTRTest()
        Dim intMessageID As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim strAdditionaltext As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim ex As Exception = Nothing ' TODO: Initialize to an appropriate value
        Dim strExeptionAdditionlText As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As MsgBoxResult = New MsgBoxResult ' TODO: Initialize to an appropriate value
        Dim actual As MsgBoxResult
        actual = General.DisplayMessageBoxLTR(intMessageID, strAdditionaltext, ex, strExeptionAdditionlText)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for General Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub GeneralConstructorTest()
        Dim target As General = New General
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
