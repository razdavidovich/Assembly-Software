Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SQL_Server_DB_Script_Generator

<TestClass()> Public Class clsTest_Base_Table_Object

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

#Region "Class Declaration"

    Private Shared clsBTObject As clsBaseTableObject
    Private Shared objFields As Object(,)

#End Region

    <ClassInitialize()> Public Shared Sub TestClassInitialize(ByVal testContext As TestContext)

        'Set the table arguments
        ReDim Preserve objFields(5, 2)
        objFields(0, 0) = 1                         'Table number in the collection
        objFields(1, 0) = "intID"                   'Field name
        objFields(2, 0) = "Int"                     'Field type
        objFields(3, 0) = 4                         'Field Size
        objFields(4, 0) = "Y"                       'Is Primary key
        objFields(5, 0) = "Y"                       'Is Identity field

        objFields(0, 1) = 1                         'Table number in the collection
        objFields(1, 1) = "intLanguage"             'Field name
        objFields(2, 1) = "Int"                     'Field type
        objFields(3, 1) = 4                         'Field Size
        objFields(4, 1) = "Y"                       'Is Primary key
        objFields(5, 1) = "N"                       'Is Identity field

        objFields(0, 2) = 1                         'Table number in the collection
        objFields(1, 2) = "vchDescription"          'Field name
        objFields(2, 2) = "nVarchar"                'Field type
        objFields(3, 2) = 30                        'Field Size
        objFields(4, 2) = "N"                       'Is Primary key
        objFields(5, 2) = "N"                       'Is Identity field

        clsBTObject = New clsBaseTableObject("Procedure", "Mt_Table_Test_Ta", "dbo", True, True, True, objFields)

    End Sub

    <ClassCleanup()> Public Shared Sub TestClassCleanup()
        clsBTObject = Nothing
    End Sub

    <TestMethod()> Public Sub TestGenerateConfig()

        Dim strConfig As String = clsBTObject.GenerateConfigScript
        MsgBox(strConfig)

    End Sub

    <TestMethod()> Public Sub TestGenerateSQL_Script()

        Throw New NotImplementedException("The test is not implemented yet")

    End Sub

End Class
