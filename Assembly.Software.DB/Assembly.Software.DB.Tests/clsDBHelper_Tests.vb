'Imports Assembly.Software.DB
Imports System.Data
Imports System.Data.SqlClient

Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting



<TestClass()> Public Class clsDBHelper_Tests

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

    <TestMethod()> _
    Public Sub SQL_ServerConnectionString_Property_Test()
        ' Testing Set & get of SQL_ServerConnectionString property
        Dim clsDB_Access As New DBHelper()

        clsDB_Access.SQL_ServerConnectionString = "1234"
        Assert.AreEqual("1234", clsDB_Access.SQL_ServerConnectionString)
    End Sub

    <TestMethod()> _
    Public Sub SQLServer_CommandTimeout_Property_Test()
        ' Testing Set & get of SQLServer_CommandTimeout property
        Dim clsDB_Access As New DBHelper()

        clsDB_Access.SQLServer_CommandTimeout = 200
        Assert.AreEqual(200, clsDB_Access.SQLServer_CommandTimeout)
    End Sub

    <TestMethod()> _
    Public Sub ODBC_ConnectionString_Property_Test()
        ' Testing Set & get of ODBC_ConnectionString property
        Dim clsDB_Access As New DBHelper()

        clsDB_Access.ODBC_ConnectionString = "1234"
        Assert.AreEqual("1234", clsDB_Access.ODBC_ConnectionString)
    End Sub

    <TestMethod()> _
    Public Sub ODBC_CommandTimeout_Property_Test()
        ' Testing Set & get of ODBC_CommandTimeout property
        Dim clsDB_Access As New DBHelper()

        clsDB_Access.ODBC_CommandTimeout = 200
        Assert.AreEqual(200, clsDB_Access.ODBC_CommandTimeout)
    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub FillDataTableFromSQLText_WrongConnectionStringFormatTest()
        ' Wrong Connection string format
        Dim clsDB_Access As New DBHelper("1234", DBHelper.Connection_Type.SQL_Server)
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSQLText("SELECT Top 1 intRowID FROM dbo.TestTable1_Ta")

    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(SqlException))> _
    Public Sub FillDataTableFromSQLText_WrongConnectionStringTest()
        ' Wrong Connection string
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=WrongDB;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSQLText("SELECT Top 1 intRowID FROM dbo.TestTable1_Ta")

    End Sub


    <TestMethod()> _
    Public Sub FillDataTableFromSQLText_UsabilityTest()
        ' Execute the SQL statement against the database
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSQLText("SELECT Top 1 intRowID FROM dbo.TestTable1_Ta")

        Assert.AreEqual(1, dttResult.Rows.Count, "The rows count does not match")

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub FillDataTableFromSP_WrongConnectionStringFormatTest()
        ' Wrong Connection string format
        Dim clsDB_Access As New DBHelper("1234", DBHelper.Connection_Type.SQL_Server)
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int), _
                                                                        New SqlParameter("@vchField1", SqlDbType.NVarChar, 50), _
                                                                        New SqlParameter("@intField2", SqlDbType.Int), _
                                                                        New SqlParameter("@relField3", SqlDbType.Real)}, _
                                                                         New Object() {4, "test1", 1, Double.Parse("2.2")})


    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(SqlException))> _
    Public Sub FillDataTableFromSP_WrongConnectionStringTest()
        ' Wrong Connection string
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=WrongDB;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int), _
                                                                        New SqlParameter("@vchField1", SqlDbType.NVarChar, 50), _
                                                                        New SqlParameter("@intField2", SqlDbType.Int), _
                                                                        New SqlParameter("@relField3", SqlDbType.Real)}, _
                                                                         New Object() {4, "test1", 1, Double.Parse("2.2")})

    End Sub


    <TestMethod()> _
    Public Sub FillDataTableFromSP_UsabilityTest()
        ' Execute the SQL statement against the database
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int), _
                                                                        New SqlParameter("@vchField1", SqlDbType.NVarChar, 50), _
                                                                        New SqlParameter("@intField2", SqlDbType.Int), _
                                                                        New SqlParameter("@relField3", SqlDbType.Real)}, _
                                                                         New Object() {4, "test1", 1, Double.Parse("2.2")})

        Assert.AreEqual(1, dttResult.Rows.Count, "The rows count does not match")

    End Sub


    <TestMethod()> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_SmallerThanSetTimeout_UsingConstructor()

        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server, 120)
        ' SP runs for about 90 Seconds, Timeout is set to 120 in constructor. No timeout expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(SqlException), "Timeout expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.")> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_BiggerThanSetTimeoutUsingConstructor()
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server, 20)
        ' SP runs for about 90 Seconds, Timeout is set to 20 in constructor. Timeout Exception expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub

    <TestMethod()> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_SmallerThanSetTimeout_UsingProperty()

        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        clsDB_Access.SQLServer_CommandTimeout = 120
        ' SP runs for about 90 Seconds, Timeout is set to 120 in property. No timeout expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(SqlException), "Timeout expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.")> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_BiggerThanSetTimeout_UsingProperty()
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        clsDB_Access.SQLServer_CommandTimeout = 20
        ' SP runs for about 90 Seconds, Timeout is set to 20 in property. Timeout Exception expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub

    <TestMethod()> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_SmallerThanSetTimeout_UsingPropertyOverridingConstructor()

        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server, 20)
        clsDB_Access.SQLServer_CommandTimeout = 120
        ' SP runs for about 90 Seconds, Timeout is set to 20 in constructor , then overridden to 120 in property. No timeout expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(SqlException), "Timeout expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.")> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_BiggerThanSetTimeout_UsingPropertyOverridingConstructor()
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server, 120)
        clsDB_Access.SQLServer_CommandTimeout = 20
        ' SP runs for about 90 Seconds, Timeout is set to 120 in constructor , then overridden to 20 in property. Timeout Exception expected

        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub

    <TestMethod()> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_SmallerThanSetTimeout_UsingOnlyPropertiesEmptyConstructor()

        Dim clsDB_Access As New DBHelper()
        clsDB_Access.SQL_ServerConnectionString = "data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096"
        clsDB_Access.SQLServer_CommandTimeout = 120
        ' SP runs for about 90 Seconds, Timeout is set to 120 in property. No timeout expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(SqlException), "Timeout expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.")> _
    Public Sub SQLServer_CommandTimeoutSPResponseTime_BiggerThanSetTimeout_UsingOnlyPropertiesEmptyConstructor()
        Dim clsDB_Access As New DBHelper()
        clsDB_Access.SQL_ServerConnectionString = "data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096"
        clsDB_Access.SQLServer_CommandTimeout = 20

        ' SP runs for about 90 Seconds, Timeout is set to 20 in connection string. Timeout Exception expected
        Dim dttResult As DataTable = clsDB_Access.FillDataTableFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {6})

    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub FillDataSetFromSP_WrongConnectionStringFormatTest()
        ' Wrong Connection string format
        Dim clsDB_Access As New DBHelper("1234", DBHelper.Connection_Type.SQL_Server)
        Dim dtsResult As DataSet = clsDB_Access.FillDataSetFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {5})


    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(SqlException))> _
    Public Sub FillDataSetFromSP_WrongConnectionStringTest()
        ' Wrong Connection string
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=WrongDB;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dtsResult As DataSet = clsDB_Access.FillDataSetFromSP("BT_TestTable1_Sp", _
                                                           New SqlParameter() _
                                                               {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                 New Object() {5})

    End Sub


    <TestMethod()> _
    Public Sub FillDataSetFromSP_UsabilityTest()
        ' Execute the SQL statement against the database
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dtsResult As DataSet = clsDB_Access.FillDataSetFromSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {5})

        Assert.AreEqual(2, dtsResult.Tables.Count, "The table count does not match")

    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub FillDatasetFromSQLText_WrongConnectionStringFormatTest()
        ' Wrong Connection string format
        Dim clsDB_Access As New DBHelper("1234", DBHelper.Connection_Type.SQL_Server)
        Dim dtsResult As DataSet = clsDB_Access.FillDatasetFromSQLText("SELECT Top 1 intRowID FROM dbo.TestTable1_Ta;SELECT Top 1 intRowID FROM dbo.TestTable2_Ta")


    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(SqlException))> _
    Public Sub FillDatasetFromSQLText_WrongConnectionStringTest()
        ' Wrong Connection string
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=WrongDB;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dtsResult As DataSet = clsDB_Access.FillDatasetFromSQLText("SELECT Top 1 intRowID FROM dbo.TestTable1_Ta;SELECT Top 1 intRowID FROM dbo.TestTable2_Ta")

    End Sub


    <TestMethod()> _
    Public Sub FillDatasetFromSQLText_UsabilityTest()
        ' Execute the SQL statement against the database
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim dtsResult As DataSet = clsDB_Access.FillDatasetFromSQLText("SELECT Top 1 intRowID FROM dbo.TestTable1_Ta;SELECT Top 1 intRowID FROM dbo.TestTable2_Ta")

        Assert.AreEqual(2, dtsResult.Tables.Count, "The table count does not match")

    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub RunSP_WrongConnectionStringFormatTest()
        ' Wrong Connection string format
        Dim clsDB_Access As New DBHelper("1234", DBHelper.Connection_Type.SQL_Server)
        Dim blnResult As Boolean = clsDB_Access.RunSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {7})


    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(SqlException))> _
    Public Sub RunSP_WrongConnectionStringTest()
        ' Wrong Connection string
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=WrongDB;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim blnResult As Boolean = clsDB_Access.RunSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {7})

    End Sub


    <TestMethod()> _
    Public Sub RunSP_UsabilityTest()
        ' Execute the SQL statement against the database
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server, True, 3)
        Dim blnResult As Boolean = clsDB_Access.RunSP("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int)}, _
                                                                         New Object() {7})

        Assert.AreEqual(True, blnResult, "Running SP wasn't completed successfully")

    End Sub





    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub RunSPRetParametrs_WrongConnectionStringFormatTest()
        ' Wrong Connection string format
        Dim clsDB_Access As New DBHelper("1234", DBHelper.Connection_Type.SQL_Server, True, 3) 'try connection 3 times
        Dim objResult() As Object = clsDB_Access.RunSPRetParametrs("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int), _
                                                                        New SqlParameter("@vchOutputField1", SqlDbType.NVarChar, 50, ParameterDirection.Output), _
                                                                        New SqlParameter("@intOutputField2", SqlDbType.Int, ParameterDirection.InputOutput), _
                                                                        New SqlParameter("@relOutputField3", SqlDbType.Real, ParameterDirection.Output)}, _
                                                                         New Object() {8, "", 1, 0})


    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(SqlException))> _
    Public Sub RunSPRetParametrs_WrongConnectionStringTest()
        ' Wrong Connection string
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=WrongDB;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim objResult() As Object = clsDB_Access.RunSPRetParametrs("BT_TestTable1_Sp", _
                                                                   New SqlParameter() _
                                                                       {New SqlParameter("@Operation", SqlDbType.Int), _
                                                                        New SqlParameter("@vchOutputField1", SqlDbType.NVarChar, 50, ParameterDirection.Output), _
                                                                        New SqlParameter("@intOutputField2", SqlDbType.Int, ParameterDirection.InputOutput), _
                                                                        New SqlParameter("@relOutputField3", SqlDbType.Real, ParameterDirection.Output)}, _
                                                                         New Object() {8, "", 1, 0})

    End Sub


    <TestMethod()> _
    Public Sub RunSPRetParametrs_UsabilityTest()
        ' Execute the SQL statement against the database
        Dim clsDB_Access As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
        Dim objResult() As Object
        objResult = clsDB_Access.RunSPRetParametrs("BT_TestTable1_Sp", _
                                                       New SqlParameter() _
                                                           {New SqlParameter("@Operation", SqlDbType.Int), _
                                                            New SqlParameter("@vchOutputField1", SqlDbType.NVarChar, 50, ParameterDirection.Output, Nothing, 1, 1, Nothing, _
                                                     System.Data.DataRowVersion.Current, Nothing), _
                                                            New SqlParameter("@intOutputField2", SqlDbType.Int, 1, ParameterDirection.InputOutput, False, 10, 0, "", DataRowVersion.Default, Nothing), _
                                                            New SqlParameter("@relOutputField3", SqlDbType.Real, 1, ParameterDirection.Output, False, 10, 0, "", DataRowVersion.Default, Nothing)}, _
                                                             New Object() {8, "", 1, 0})

        Dim objExpectedResult() As Object = New Object() {"OutputTest1", 2, Single.Parse("2.5")}



        Assert.AreEqual(objExpectedResult(0), objResult(0), "First param not identical")
        Assert.AreEqual(objExpectedResult(1), objResult(1), "Second param not identical")
        Assert.AreEqual(objExpectedResult(2), objResult(2), "Third param not identical")

    End Sub

    '<TestMethod()> _
    'Public Sub FillDataSetFromSP_ParallelRunTest()
    '    ' Execute the SQL statement against the database
    '    Dim clsDB_Access1 As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)
    '    Dim clsDB_Access2 As New DBHelper("data source=ASSEMBLYSRV;initial catalog=Assembly.Software.DB.Tests;persist security info=False;user id=sa;password=lipton;workstation id=;packet size=4096", DBHelper.Connection_Type.SQL_Server)

    '    clsDB_Access1.ConnectSQLServer_Test()
    '    clsDB_Access2.ConnectSQLServer_Test()

    '    Dim dtsResult1 As DataSet = clsDB_Access1.FillDataSetFromSP_Test("BT_TestTable1_Sp", _
    '                                                               New SqlParameter() _
    '                                                                   {New SqlParameter("@Operation", SqlDbType.Int)}, _
    '                                                                     New Object() {5})


    '    Dim dtsResult2 As DataSet = clsDB_Access2.FillDataSetFromSP_Test("BT_TestTable1_Sp", _
    '                                                               New SqlParameter() _
    '                                                                   {New SqlParameter("@Operation", SqlDbType.Int)}, _
    '                                                                     New Object() {5})


    '    clsDB_Access1.CloseConnectionSQLServer_Test()
    '    clsDB_Access2.CloseConnectionSQLServer_Test()

    '    Assert.AreEqual(2, dtsResult1.Tables.Count, "The table count does not match")
    '    Assert.AreEqual(2, dtsResult2.Tables.Count, "The table count does not match")

    'End Sub


    <TestMethod()> _
   <ExpectedException(GetType(Exception))> _
   Public Sub RunSPRetParametrsWithTransaction_Failed()
        'check roll back functionality
        Dim clsDB_Access As New DBHelper("data source=assemblysrv\sql2000;initial catalog=Tama;persist security info=False;uid=sa;Pwd=lipton;", DBHelper.Connection_Type.SQL_Server, 120)
        clsDB_Access.ConnectSQLServerWithTransaction()
        Try
            Dim objResult() As Object = clsDB_Access.RunSPRetParametrsWithTransaction("Test_Sp", _
                                  New SqlParameter() {New SqlParameter("@Operation", SqlDbType.Int, 4), _
                                                      New SqlParameter("@intRowsAffected", SqlDbType.Int, 4, ParameterDirection.Output, Nothing, 1, 1, Nothing, DataRowVersion.Current, Nothing)}, _
                                  New Object() {1, 0})
            clsDB_Access.CommitTransaction()

        Catch ex1 As Exception
            clsDB_Access.RollBackTransaction()
            Throw ex1
        Finally
            clsDB_Access.CloseTransaction()
        End Try



    End Sub

    <TestMethod()> _
  Public Sub RunSPRetParametrsWithTransaction_NoParameters()
        ' Execute the SQL Stored procedure against the database
        Dim clsDB_Access As New DBHelper("data source=assemblysrv\sql2000;initial catalog=Tama;persist security info=False;uid=sa;Pwd=lipton;", DBHelper.Connection_Type.SQL_Server, 120)
        clsDB_Access.ConnectSQLServerWithTransaction()
        Try
            clsDB_Access.RunSPWithTransaction("Test_Sp", _
                                  New SqlParameter() {}, _
                                  New Object() {1, 0})
            clsDB_Access.CommitTransaction()
        Catch ex As Exception
            clsDB_Access.RollBackTransaction()

        Finally
            clsDB_Access.CloseTransaction()
        End Try



    End Sub


End Class
