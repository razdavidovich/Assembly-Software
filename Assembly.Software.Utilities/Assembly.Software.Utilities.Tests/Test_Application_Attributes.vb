Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assembly.Software.Utilities

<TestClass()> _
Public Class clsTest_Application_Attributes

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

#Region "Test Class Declarations"

    Private Shared clsMyAppAttributes As clsApplicationAttributes

#End Region

#Region "Test Class Constructors/Destructors"

    <ClassInitialize()> _
    Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)

        clsMyAppAttributes = New clsApplicationAttributes

    End Sub

    <ClassCleanup()> _
    Public Shared Sub MyClassCleanup()

    End Sub

#End Region

#Region "Class Tests"

    '''<summary>
    '''A test for clsApplicationAttributes Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub clsApplicationAttributesConstructorTest()
        Assert.IsNotNull(clsMyAppAttributes, "The Constructor test failed, the target class equals nothing")

    End Sub

    '''<summary>
    '''A test for AppBuildVersion
    '''</summary>
    <TestMethod()> _
    Public Sub AppBuildVersionTest()
        Dim actual As String
        actual = clsMyAppAttributes.AppBuildVersion
        Assert.AreEqual("2.0.0.0", actual, "The application build test result does not match")

    End Sub

    '''<summary>
    '''A test for ApplicationCopyright
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationCopyrightTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ApplicationCopyright
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ApplicationDescription
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationDescriptionTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ApplicationDescription
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ApplicationTitle
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationTitleTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ApplicationTitle
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ApplicationTrademark
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationTrademarkTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ApplicationTrademark
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ApplicationVersion
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationVersionTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ApplicationVersion
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AppMajorVersion
    '''</summary>
    <TestMethod()> _
    Public Sub AppMajorVersionTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.AppMajorVersion
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AppMinorVersion
    '''</summary>
    <TestMethod()> _
    Public Sub AppMinorVersionTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.AppMinorVersion
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AppRevisionVersion
    '''</summary>
    <TestMethod()> _
    Public Sub AppRevisionVersionTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.AppRevisionVersion
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CLSCompliant
    '''</summary>
    <TestMethod()> _
    Public Sub CLSCompliantTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.CLSCompliant
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CompanyName
    '''</summary>
    <TestMethod()> _
    Public Sub CompanyNameTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.CompanyName
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ExecutablePath
    '''</summary>
    <TestMethod()> _
    Public Sub ExecutablePathTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ExecutablePath
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for GUID
    '''</summary>
    <TestMethod()> _
    Public Sub GUIDTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.GUID
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ProductName
    '''</summary>
    <TestMethod()> _
    Public Sub ProductNameTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ProductName
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for StartupPath
    '''</summary>
    <TestMethod()> _
    Public Sub StartupPathTest()
        Dim target As clsApplicationAttributes = New clsApplicationAttributes ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.StartupPath
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

#End Region

End Class