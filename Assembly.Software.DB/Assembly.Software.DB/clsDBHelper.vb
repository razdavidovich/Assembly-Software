'General imports statement
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.OleDb

''' <summary>
''' This class contains a general functions for data handling agains a SQL
''' Server, this class will be used to run general operation like filling 
''' a dataset
''' </summary>
''' <remarks></remarks>
<CLSCompliant(True)> _
Public Class DBHelper

#Region "Class Declarations"

    Private strODBC_ConnectionString As String = String.Empty
    Private intODBC_CommandTimeout As Integer = -1 ' Added By Zvika Oscar 24/12/2008
    Private DBHelperOdbcConnection As OdbcConnection

    Private strSQLServer_ConnectionString As String = String.Empty ' Added By Zvika Oscar 21/12/2008
    Private intSQLServer_CommandTimeout As Integer = -1 ' Added By Zvika Oscar 24/12/2008
    Private DBHelperSQLServerConnection As SqlConnection ' Added By Zvika Oscar 21/12/2008

    Private intNoOfTimesToTryConnection As Integer = 1

    Private cmdTransactionCommand As SqlCommand
    Private objsqlTransaction As SqlTransaction

    Public Enum Connection_Type
        SQL_Server = 1
        ODBC = 2
    End Enum

#End Region

#Region "Class Constructors"

    Public Sub New()

    End Sub

    Public Sub New(ByVal strConnectionString As String, ByVal intConnectionType As Connection_Type, _
                         Optional ByVal blnCheckConnectionAgain As Boolean = False, Optional ByVal intNoOfTimesToTryConnection As Integer = 0)
        ' intConnectionTimeoutInSeconds means the property wasn't set. no need to use it, staying with default timeout.
        MyClass.new(strConnectionString, intConnectionType, -1)

        'added by liat 31.5.09
        If blnCheckConnectionAgain And intNoOfTimesToTryConnection > 1 Then
            Me.intNoOfTimesToTryConnection = intNoOfTimesToTryConnection
        End If
    End Sub


    Public Sub New(ByVal strConnectionString As String, ByVal intConnectionType As Connection_Type, ByVal intCommandTimeout As Integer, _
                         Optional ByVal blnCheckConnectionAgain As Boolean = False, Optional ByVal intNoOfTimesToTryConnection As Integer = 0)
        '******************************************************************************
        '* NAME:        New()                                              
        '* DESCRIPTION: Class constructor, initializes ConnectionString, ConnectionTimeout (in seconds) according to Connection_Type
        '*              
        '*
        '* WRITTEN BY:  Zvika Oscar                                                   
        '* DATE:        24/12/2008                                                    
        '******************************************************************************

        If intConnectionType = Connection_Type.ODBC Then
            Me.strODBC_ConnectionString = strConnectionString
            Me.intODBC_CommandTimeout = intCommandTimeout
        Else
            Me.strSQLServer_ConnectionString = strConnectionString
            Me.intSQLServer_CommandTimeout = intCommandTimeout
        End If

        'added by liat 31.5.09
        If blnCheckConnectionAgain And intNoOfTimesToTryConnection > 1 Then
            Me.intNoOfTimesToTryConnection = intNoOfTimesToTryConnection
        End If

    End Sub

#End Region

#Region "Class Private Functions"

    Private Sub ConnectODBC()
        'Check for existing connection string
        If strODBC_ConnectionString.Trim.Length > 0 Then
            If DBHelperOdbcConnection Is Nothing Then DBHelperOdbcConnection = New OdbcConnection(strODBC_ConnectionString)

            Try
                DBHelperOdbcConnection.Open()
            Catch ex As Exception
                Throw ex
            End Try
        Else
            Throw New DataException("Please specify a valid ODBC connection string")
        End If
    End Sub

    Private Sub ConnectSQLServer()
        '******************************************************************************
        '* NAME:        ConnectSQLServer()                                              
        '* DESCRIPTION: Opening connection to SQL Server
        '*
        '* WRITTEN BY:  Zvika Oscar                                                   
        '* DATE:        21/12/2008                                                    
        '******************************************************************************
        'Check for existing connection string
        If strSQLServer_ConnectionString.Trim.Length > 0 Then
            If DBHelperSQLServerConnection Is Nothing Then DBHelperSQLServerConnection = New SqlConnection(strSQLServer_ConnectionString)

            Try
                DBHelperSQLServerConnection.Open()
            Catch ex As Exception
                Throw ex
            End Try
        Else
            Throw New DataException("Please specify a valid SQLServer connection string")
        End If
    End Sub

    Private Sub SetSQLServerCommandTimeout(ByRef cmdSqlCommand As SqlCommand)
        '******************************************************************************
        '* NAME:        SetSQLServerCommandTimeout()                                              
        '* DESCRIPTION: Setting Command Timeout according to SQLServer_CommandTimeout
        '*              When connectionTimeouts are -1, they weren't explicitly set, therefore staying with default 30 secs
        '*              If There is timeout set in the connection string, it doesn't affect the actual Timeout
        '*
        '* WRITTEN BY:  Zvika Oscar                                                   
        '* DATE:        21/12/2008                                                    
        '******************************************************************************
        If intSQLServer_CommandTimeout <> -1 Then
            cmdSqlCommand.CommandTimeout = intSQLServer_CommandTimeout
        End If

    End Sub

    Private Sub SetODBCCommandTimeout(ByRef cmdODBCCommand As OdbcCommand)
        '******************************************************************************
        '* NAME:        SetODBCCommandTimeout()                                              
        '* DESCRIPTION: Setting Command Timeout according to ODBC_CommandTimeout
        '*              When connectionTimeouts are -1, they weren't explicitly set, therefore staying with default 30 secs
        '*              If There is timeout set in the connection string, it doesn't affect the actual Timeout
        '*
        '* WRITTEN BY:  Zvika Oscar                                                   
        '* DATE:        21/12/2008                                                    
        '******************************************************************************
        If intODBC_CommandTimeout <> -1 Then
            cmdODBCCommand.CommandTimeout = intODBC_CommandTimeout
        End If

    End Sub

#End Region

#Region "Class Properties"

    Public Property SQL_ServerConnectionString() As String
        Get
            Return strSQLServer_ConnectionString
        End Get
        Set(ByVal value As String)
            strSQLServer_ConnectionString = value
        End Set
    End Property

    Public Property SQLServer_CommandTimeout() As Integer
        Get
            Return intSQLServer_CommandTimeout
        End Get
        Set(ByVal value As Integer)
            intSQLServer_CommandTimeout = value
        End Set
    End Property

    Public Property ODBC_ConnectionString() As String
        Get
            Return strODBC_ConnectionString
        End Get
        Set(ByVal value As String)
            strODBC_ConnectionString = value
        End Set
    End Property

    Public Property ODBC_CommandTimeout() As Integer
        Get
            Return intODBC_CommandTimeout
        End Get
        Set(ByVal value As Integer)
            intODBC_CommandTimeout = value
        End Set
    End Property

#End Region

#Region "Class Methods"


    ''' <summary>
    ''' This function will fill a Dataset from a stored procedure
    ''' </summary>
    ''' <param name="SPName">The name of the stored procedure to run</param>
    ''' <param name="SPParameters">List of SQLParameters to provide to the SP</param>
    ''' <param name="SPValues">List of values (object type, allow all primitive types) to provide to the SP</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FillDataSetFromSP(ByVal SPName As String, Optional ByVal SPParameters() As SqlParameter = Nothing, Optional ByVal SPValues() As Object = Nothing) As DataSet
        '*************************************************************************
        '* Function Name:   FillDataSetFromSP
        '* Description:     This is a general function to fill a dataset from any
        '*                  stored procedure (Based on Web.Config database configuration
        '* Created by:      Raz Davidovich
        '* Created date:    14/01/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim adpAdapter As New SqlDataAdapter()

        '*************************************************************
        '31.5.09 changed by liat :  loop for number of times to check connection if failed
        ''Try to get a connection to the database
        Dim blnSuccess As Boolean = False
        Dim intNoOfTrying As Integer = 0
        Do While Not blnSuccess And intNoOfTrying <= Me.intNoOfTimesToTryConnection
            Try
                ConnectSQLServer()
                blnSuccess = True
            Catch ex As Exception
                intNoOfTrying = intNoOfTrying + 1
                If intNoOfTrying = Me.intNoOfTimesToTryConnection Then
                    Throw New Exception("Error Connecting to the server " + ex.Message)
                End If
            End Try
        Loop
        '*******************************************************



        'Set the stored procedure to the command and the command to the data adapter
        adpAdapter.SelectCommand = New SqlCommand(SPName, DBHelperSQLServerConnection)
        adpAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Added By Zvika Oscar 24/12/2008
        SetSQLServerCommandTimeout(adpAdapter.SelectCommand)

        'Assign all parameters with its values
        If Not SPParameters Is Nothing Then
            Dim i As Integer
            For i = 0 To SPParameters.Length - 1
                adpAdapter.SelectCommand.Parameters.Add(SPParameters(i)).Value = SPValues(i)
            Next i
        End If

        'Create a new data set
        Dim dstDataSet As DataSet = New DataSet()


        Try
            'Fill the new data set
            adpAdapter.Fill(dstDataSet)
        Catch ex As Exception
            Throw ex
        Finally
            'Close the connection to the database
            adpAdapter.SelectCommand.Connection.Close()
            adpAdapter.SelectCommand.Parameters.Clear()
            adpAdapter.SelectCommand.Dispose()

        End Try

        'Return the data set
        Return dstDataSet

    End Function


    Public Function FillDataTableFromSP(ByVal SPName As String, Optional ByVal SPParameters() As SqlParameter = Nothing, Optional ByVal SPValues() As Object = Nothing) As DataTable
        '*************************************************************************
        '* Function Name:   FillDataSetFromSP
        '* Description:     This is a general function to fill a dataset from any
        '*                  stored procedure (Based on Web.Config database configuration
        '* Created by:      Raz Davidovich
        '* Created date:    14/01/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim adpAdapter As New SqlDataAdapter()

        '*************************************************************
        '31.5.09 changed by liat :  loop for number of times to check connection if failed
        ''Try to get a connection to the database
        Dim blnSuccess As Boolean = False
        Dim intNoOfTrying As Integer = 0
        Do While Not blnSuccess And intNoOfTrying <= Me.intNoOfTimesToTryConnection
            Try
                ConnectSQLServer()
                blnSuccess = True
8:          Catch ex As Exception
                intNoOfTrying = intNoOfTrying + 1
                If intNoOfTrying = Me.intNoOfTimesToTryConnection Then
                    Throw New Exception("Error Connecting to the server " + ex.Message)
                End If
            End Try
        Loop
        '*******************************************************


        'Set the stored procedure to the command and the command to the data adapter
        adpAdapter.SelectCommand = New SqlCommand(SPName, DBHelperSQLServerConnection)
        adpAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Added By Zvika Oscar 24/12/2008
        SetSQLServerCommandTimeout(adpAdapter.SelectCommand)

        'Assign all parameters with its values
        If Not SPParameters Is Nothing Then
            Dim i As Integer
            For i = 0 To SPParameters.Length - 1
                adpAdapter.SelectCommand.Parameters.Add(SPParameters(i)).Value = SPValues(i)
            Next i
        End If

        'Create a new data set
        Dim dttDataTable As DataTable = New DataTable()

        Try
            'Fill the new data set
            adpAdapter.Fill(dttDataTable)
        Catch ex As Exception
            'Throw ex
            Throw New Exception("Error executiog query " + ex.Message)
        Finally
            'Close the connection to the database
            adpAdapter.SelectCommand.Connection.Close()
            adpAdapter.SelectCommand.Parameters.Clear()
            adpAdapter.SelectCommand.Dispose()
        End Try

        'Return the data set
        Return dttDataTable

    End Function

    Public Function RunSP(ByVal SPName As String, Optional ByVal SPParameters() As SqlParameter = Nothing, Optional ByVal SPValues() As Object = Nothing) As Boolean
        '*************************************************************************
        '* Function Name:   FillDataSetFromSP
        '* Description:     This is a general function to fill a dataset from any
        '*                  stored procedure (Based on Web.Config database configuration
        '* Created by:      Raz Davidovich
        '* Created date:    14/01/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        ''Try to get a connection to the database
        '31.5.09 added by liat :  loop for number of times to check connection if failed
        Dim blnSuccess As Boolean = False
        Dim intNoOfTrying As Integer = 0
        Do While Not blnSuccess And intNoOfTrying <= Me.intNoOfTimesToTryConnection
            Try
                ConnectSQLServer()
                blnSuccess = True
            Catch ex As Exception
                intNoOfTrying = intNoOfTrying + 1
                If intNoOfTrying = Me.intNoOfTimesToTryConnection Then
                    Throw New Exception("Error Connecting to the server " + ex.Message)
                End If
            End Try
        Loop


        'Set the stored procedure to the command and the command to the data adapter
        Dim cmdCommand As SqlCommand = New SqlCommand(SPName, DBHelperSQLServerConnection)
        cmdCommand.CommandType = CommandType.StoredProcedure

        ' Added By Zvika Oscar 24/12/2008
        SetSQLServerCommandTimeout(cmdCommand)

        'Assign all parameters with its values
        Dim i As Integer
        If Not SPParameters Is Nothing Then
            For i = 0 To SPParameters.Length - 1

                Try
                    cmdCommand.Parameters.Add(SPParameters(i)).Value = SPValues(i)
                Catch ex As Exception
                    Throw ex
                End Try

            Next i
        End If

        'Run the procedure
        Try
            cmdCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            'Close the connection to the database
            cmdCommand.Connection.Close()
            cmdCommand.Parameters.Clear()
            cmdCommand.Dispose()
        End Try

        Return True

    End Function

    ''' <summary>
    ''' This is a general function to run a stored procedure and return it's OUTPUT parameter
    ''' </summary>
    ''' <param name="SPName">The name of the Stored procedure we wish to run</param>
    ''' <param name="SPParameters">The stored procudure SQL parameters array</param>
    ''' <param name="SPValues">The stored procedure values for the list of the parameters array</param>
    ''' <returns>The stored procedure output parameter</returns>
    ''' <remarks>This function is working against SQL Server ONLY</remarks>
    Public Function RunSPRetParametrs(ByVal SPName As String, ByVal SPParameters() As SqlParameter, Optional ByVal SPValues() As Object = Nothing) As Object()
        '*************************************************************************
        '* Function Name:   FillDataSetFromSP
        '* Description:     This is a general function to run a stored procedure 
        '*                  and return it's OUTPUT parameter
        '* Created by:      Raz Davidovich
        '* Created date:    14/01/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        
        'Try to get a connection to the database
        '31.5.09 added by liat :  loop for number of times to check connection if failed
        Dim blnSuccess As Boolean = False
        Dim intNoOfTrying As Integer = 0
        Do While Not blnSuccess And intNoOfTrying <= Me.intNoOfTimesToTryConnection
            Try
                ConnectSQLServer()
                blnSuccess = True
            Catch ex As Exception
                intNoOfTrying = intNoOfTrying + 1
                If intNoOfTrying = Me.intNoOfTimesToTryConnection Then
                    Throw New Exception("Error Connecting to the server " + ex.Message)
                End If
            End Try
        Loop

        'Set the stored procedure to the command and the command to the data adapter
        Dim cmdCommand As SqlCommand = New SqlCommand(SPName, DBHelperSQLServerConnection)
        cmdCommand.CommandType = CommandType.StoredProcedure

        ' Added By Zvika Oscar 24/12/2008
        SetSQLServerCommandTimeout(cmdCommand)

        'Assign all parameters with its values
        Dim i As Integer
        If Not SPValues Is Nothing Then
            For i = 0 To SPParameters.Length - 1
                cmdCommand.Parameters.Add(SPParameters(i)).Value = SPValues(i)
            Next i
        End If

        'Run the procedure
        Try
            cmdCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error executing query " + ex.Message)
        Finally
            cmdCommand.Connection.Close()
            cmdCommand.Parameters.Clear()
            cmdCommand.Dispose()
        End Try

        'Run and get the returned parameters
        Dim tmpParam As SqlParameter
        Dim tmpObj() As Object = Nothing

        For Each tmpParam In SPParameters
            'Check if the parameter is an output parameter
            If tmpParam.Direction = ParameterDirection.Output Or tmpParam.Direction = ParameterDirection.InputOutput Then
                'Get the value into the return object array
                If tmpObj Is Nothing Then
                    ReDim Preserve tmpObj(0)
                Else
                    ReDim Preserve tmpObj(tmpObj.Length)
                End If

                tmpObj(tmpObj.Length - 1) = tmpParam.Value
            End If
        Next

        'Return the values array
        Return tmpObj

    End Function


    ''' <summary>
    ''' This is a general function to fill a dataset from the given SQL text
    ''' </summary>
    ''' <param name="SQL_Text">The SQL statement to run, this SQL can be embeded with parameters that will be replaced
    ''' with the values supplied in the SPValues object array</param>
    ''' <param name="SPValues">A list of replace values to be used to replace parameters in the SQL</param>
    ''' <returns>The SQL result set from the database in a dataset object</returns>
    ''' <remarks>The parameters specified in the SQL statement must be in in the following format: @x
    ''' where x is the index number of value we wish to replace in the SPValues object array.
    ''' The parameter can appear anywhere in the SQL statment and will be replaced at runtime.
    ''' The following is an example for a parameterized SQL statement:
    ''' Select * From dbo.Employee_Ta
    ''' Where intEmployeeID = @1
    ''' In case we supplied 1234 in the first index of the SPValues objects array, the SQL that will execute will be
    ''' Select * From dbo.Employee_Ta
    ''' Where intEmployeeID = 1234
    ''' </remarks>
    Public Function FillDatasetFromSQLText(ByVal SQL_Text As String, Optional ByVal SPValues() As Object = Nothing) As DataSet
        '*************************************************************************
        '* Function Name:   FillDatasetFromSQLText
        '* Description:     This is a general function to fill a dataset from the
        '*                  given SQL text 
        '* Created by:      Raz Davidovich
        '* Created date:    06/07/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim adpAdapter As New SqlDataAdapter

        'Assign all parameters with its values
        Dim i As Integer
        If Not SPValues Is Nothing Then
            For i = 1 To SPValues.Length
                SQL_Text = SQL_Text.Replace("@" & i, SPValues(i - 1))
            Next i
        End If

        'Set the stored procedure to the command and the command to the data adapter
        adpAdapter.SelectCommand = New SqlCommand
        adpAdapter.SelectCommand.CommandType = CommandType.Text
        adpAdapter.SelectCommand.CommandText = SQL_Text

        ' Added By Zvika Oscar 24/12/2008
        SetSQLServerCommandTimeout(adpAdapter.SelectCommand)


        '*************************************************************
        '31.5.09 changed by liat :  loop for number of times to check connection if failed
        ''Try to get a connection to the database
        Dim blnSuccess As Boolean = False
        Dim intNoOfTrying As Integer = 0
        Do While Not blnSuccess And intNoOfTrying <= Me.intNoOfTimesToTryConnection
            Try
                ConnectSQLServer()
                blnSuccess = True
            Catch ex As Exception
                intNoOfTrying = intNoOfTrying + 1
                If intNoOfTrying = Me.intNoOfTimesToTryConnection Then
                    Throw New Exception("Error Connecting to the server " + ex.Message)
                End If
            End Try
        Loop
        '*******************************************************

        'Create a new data set
        Dim dstDataSet As DataSet = New DataSet

        Try
            ' 
            adpAdapter.SelectCommand.Connection = DBHelperSQLServerConnection

            'Fill the new data set
            adpAdapter.Fill(dstDataSet)
        Catch ex As Exception
            Throw ex
        Finally
            'Close the connection to the database
            adpAdapter.SelectCommand.Connection.Close()
            adpAdapter.SelectCommand.Parameters.Clear()
            adpAdapter.SelectCommand.Dispose()

        End Try

        'Return the data set
        Return dstDataSet


    End Function

    ''' <summary>
    ''' This is a general function to fill a dataset from the given SQL text
    ''' </summary>
    ''' <param name="SQL_Text">The SQL statement to run, this SQL can be embeded with parameters that will be replaced
    ''' with the values supplied in the SPValues object array</param>
    ''' <param name="SPValues">A list of replace values to be used to replace parameters in the SQL</param>
    ''' <returns>The SQL result set from the database in a datatable object</returns>
    ''' <remarks>The parameters specified in the SQL statement must be in in the following format: @x
    ''' where x is the index number of value we wish to replace in the SPValues object array.
    ''' The parameter can appear anywhere in the SQL statment and will be replaced at runtime.
    ''' The following is an example for a parameterized SQL statement:
    ''' Select * From dbo.Employee_Ta
    ''' Where intEmployeeID = @1
    ''' In case we supplied 1234 in the first index of the SPValues objects array, the SQL that will execute will be
    ''' Select * From dbo.Employee_Ta
    ''' Where intEmployeeID = 1234
    ''' </remarks>
    Public Function FillDataTableFromSQLText(ByVal SQL_Text As String, Optional ByVal SPValues() As Object = Nothing) As DataTable
        '*************************************************************************
        '* Function Name:   FillDatasetFromSQLText
        '* Description:     This is a general function to fill a dataset from the
        '*                  given SQL text 
        '* Created by:      Adir Sharabi
        '* Created date:    8/05/2005
        '* Last Modifyer:   Adir Sharabi
        '*************************************************************************
        Dim adpAdapter As New SqlDataAdapter
        'Assign all parameters with its values
        If Not SPValues Is Nothing Then
            Dim i As Integer
            For i = 1 To SPValues.Length
                SQL_Text = SQL_Text.Replace("@" & i, SPValues(i - 1))
            Next i
        End If


      

        '*************************************************************
        '31.5.09 changed by liat :  loop for number of times to check connection if failed
        'Try to get a connection to the database
        Dim blnSuccess As Boolean = False
        Dim intNoOfTrying As Integer = 0
        Do While Not blnSuccess And intNoOfTrying <= Me.intNoOfTimesToTryConnection
            Try
                ConnectSQLServer()
                blnSuccess = True
            Catch ex As Exception
                intNoOfTrying = intNoOfTrying + 1
                If intNoOfTrying = Me.intNoOfTimesToTryConnection Then
                    Throw New Exception("Error Connecting to the server " + ex.Message)
                End If
            End Try
        Loop
        '*******************************************************


        'Set the stored procedure to the command and the command to the data adapter
        adpAdapter.SelectCommand = New SqlCommand
        adpAdapter.SelectCommand.CommandType = CommandType.Text
        adpAdapter.SelectCommand.CommandText = SQL_Text
        adpAdapter.SelectCommand.Connection = DBHelperSQLServerConnection

        ' Added By Zvika Oscar 24/12/2008
        SetSQLServerCommandTimeout(adpAdapter.SelectCommand)



        'Create a new data set
        Dim dttDataTable As DataTable = New DataTable


        Try
            'Fill the new data set
            adpAdapter.Fill(dttDataTable)
        Catch ex As Exception
            Throw ex
        End Try

        'Close the connection to the database
        adpAdapter.SelectCommand.Connection.Close()
        adpAdapter.SelectCommand.Parameters.Clear()
        adpAdapter.SelectCommand.Dispose()

        'Return the data set
        Return dttDataTable

    End Function

    Public Function ODBC_DatasetFromSQLText(ByVal SQL_Text As String, Optional ByVal SPValues() As Object = Nothing) As DataSet
        '*************************************************************************
        '* Function Name:   FillDatasetFromSQLText
        '* Description:     This is a general function to fill a dataset from the
        '*                  given SQL text 
        '* Created by:      Raz Davidovich
        '* Created date:    06/07/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        Try
            ConnectODBC()
        Catch ex As Exception
            Throw ex
        End Try

        Dim adpAdapter As New OdbcDataAdapter

        'Assign all parameters with its values
        Dim i As Integer
        If Not SPValues Is Nothing Then
            For i = 1 To SPValues.Length
                SQL_Text = SQL_Text.Replace("@" & i, SPValues(i - 1))
            Next i
        End If

        'Set the stored procedure to the command and the command to the data adapter
        adpAdapter.SelectCommand = New OdbcCommand
        adpAdapter.SelectCommand.CommandType = CommandType.Text
        adpAdapter.SelectCommand.CommandText = SQL_Text

        adpAdapter.SelectCommand.Connection = DBHelperOdbcConnection

        ' Added By Zvika Oscar 24/12/2008
        SetODBCCommandTimeout(adpAdapter.SelectCommand)

        'Create a new data set
        Dim dstDataSet As DataSet = New DataSet


        Try
            'Fill the new data set
            adpAdapter.Fill(dstDataSet)
        Catch ex As Exception
            Throw ex
        End Try

        'Close the connection to the database
        adpAdapter.SelectCommand.Connection.Close()
        adpAdapter.SelectCommand.Parameters.Clear()
        adpAdapter.SelectCommand.Dispose()

        'Return the data set
        Return dstDataSet


    End Function

    Public Function ODBC_DataTableFromSQLText(ByVal SQL_Text As String, Optional ByVal SPValues() As Object = Nothing) As DataTable
        '*************************************************************************
        '* Function Name:   FillDatasetFromSQLText
        '* Description:     This is a general function to fill a dataset from the
        '*                  given SQL text 
        '* Created by:      Adir Sharabi
        '* Created date:    8/05/2005
        '* Last Modifyer:   Adir Sharabi
        '*************************************************************************

        Try
            ConnectODBC()
        Catch ex As Exception
            Throw ex
        End Try

        Dim adpAdapter As New OdbcDataAdapter

        'Assign all parameters with its values
        If Not SPValues Is Nothing Then
            Dim i As Integer
            For i = 1 To SPValues.Length
                SQL_Text = SQL_Text.Replace("@" & i, SPValues(i - 1))
            Next i
        End If

        'Set the stored procedure to the command and the command to the data adapter
        adpAdapter.SelectCommand = New OdbcCommand
        adpAdapter.SelectCommand.CommandType = CommandType.Text
        adpAdapter.SelectCommand.CommandText = SQL_Text
        adpAdapter.SelectCommand.Connection = DBHelperOdbcConnection

        ' Added By Zvika Oscar 24/12/2008
        SetODBCCommandTimeout(adpAdapter.SelectCommand)

        'Create a new data set
        Dim dstDataTable As DataTable = New DataTable


        Try
            'Fill the new data set
            adpAdapter.Fill(dstDataTable)
        Catch ex As Exception
            Throw ex
        End Try

        'Close the connection to the database
        adpAdapter.SelectCommand.Connection.Close()
        adpAdapter.SelectCommand.Parameters.Clear()
        adpAdapter.SelectCommand.Dispose()

        'Return the data set
        Return dstDataTable


    End Function


    Public Sub ConnectSQLServerWithTransaction()
        '******************************************************************************
        '* NAME:        ConnectSQLServerWithTransaction()                                              
        '* DESCRIPTION: Opening connection to SQL Server with Transaction
        '*
        '* WRITTEN BY:  Liat Kompas                                                  
        '* DATE:        05/06/2011                                                    
        '******************************************************************************
        'Check for existing connection string
        If strSQLServer_ConnectionString.Trim.Length > 0 Then
            If DBHelperSQLServerConnection Is Nothing Then DBHelperSQLServerConnection = New SqlConnection(strSQLServer_ConnectionString)

            Try
                DBHelperSQLServerConnection.Open()

                objsqlTransaction = DBHelperSQLServerConnection.BeginTransaction
            Catch ex As Exception
                Throw ex
            End Try
        Else
            Throw New DataException("Please specify a valid SQLServer connection string")
        End If
    End Sub

    ''' <summary>
    ''' This is a general function to run a stored procedure
    ''' </summary>
    ''' <param name="SPName">The name of the Stored procedure we wish to run</param>
    ''' <param name="SPParameters">The stored procudure SQL parameters array</param>
    ''' <param name="SPValues">The stored procedure values for the list of the parameters array</param>
    ''' <returns>The stored procedure output parameter</returns>
    ''' <remarks>This function is working against SQL Server ONLY</remarks>
    Public Function RunSPWithTransaction(ByVal SPName As String, Optional ByVal SPParameters() As SqlParameter = Nothing, Optional ByVal SPValues() As Object = Nothing) As Boolean
        '*************************************************************************
        '* Function Name:   RunSPInTransaction
        '* Description:     This is a general rutine to run store procedure
        '*                  
        '* Created by:      Liat Komaps
        '* Created date:    05/06/2011
        '* Last Modifyer:   
        '*************************************************************************

        
        'Set the stored procedure to the command and the command to the data adapter
        cmdTransactionCommand = New SqlCommand(SPName, DBHelperSQLServerConnection)
        cmdTransactionCommand.CommandType = CommandType.StoredProcedure

        'Set SQL command timeout
        SetSQLServerCommandTimeout(cmdTransactionCommand)

        'Assign all parameters with its values
        Dim i As Integer
        If Not SPParameters Is Nothing Then
            For i = 0 To SPParameters.Length - 1

                Try
                    cmdTransactionCommand.Parameters.Add(SPParameters(i)).Value = SPValues(i)
                Catch ex As Exception
                    Throw ex
                End Try

            Next i
        End If

        'Run the procedure
        Try
            cmdTransactionCommand.Transaction = objsqlTransaction
            cmdTransactionCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            
        End Try

        Return True

    End Function


    ''' <summary>
    ''' This is a general function to run a stored procedure and return it's OUTPUT parameter
    ''' </summary>
    ''' <param name="SPName">The name of the Stored procedure we wish to run</param>
    ''' <param name="SPParameters">The stored procudure SQL parameters array</param>
    ''' <param name="SPValues">The stored procedure values for the list of the parameters array</param>
    ''' <returns>The stored procedure output parameter</returns>
    ''' <remarks>This function is working against SQL Server ONLY</remarks>
    Public Function RunSPRetParametrsWithTransaction(ByVal SPName As String, ByVal SPParameters() As SqlParameter, Optional ByVal SPValues() As Object = Nothing) As Object()
        '*************************************************************************
        '* Function Name:   RunSPRetParametrsWithTransaction
        '* Description:     This is a general function to run a stored procedure 
        '*                  and return it's OUTPUT parameter
        '* Created by:      Liat Komaps
        '* Created date:    05/06/2011
        '* Last Modifyer:   
        '*************************************************************************

        'Set the stored procedure to the command and the command to the data adapter
        cmdTransactionCommand = New SqlCommand(SPName, DBHelperSQLServerConnection)
        cmdTransactionCommand.CommandType = CommandType.StoredProcedure

        'Set SQL command timeout
        SetSQLServerCommandTimeout(cmdTransactionCommand)

        'Assign all parameters with its values
        Dim i As Integer
        If Not SPValues Is Nothing Then
            For i = 0 To SPParameters.Length - 1
                cmdTransactionCommand.Parameters.Add(SPParameters(i)).Value = SPValues(i)
            Next i
        End If

        'Run the procedure
        Try
            cmdTransactionCommand.Transaction = objsqlTransaction
            cmdTransactionCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error executing query " + ex.Message)
        Finally

        End Try

        'Run and get the returned parameters
        Dim tmpParam As SqlParameter
        Dim tmpObj() As Object = Nothing

        For Each tmpParam In SPParameters
            'Check if the parameter is an output parameter
            If tmpParam.Direction = ParameterDirection.Output Or tmpParam.Direction = ParameterDirection.InputOutput Then
                'Get the value into the return object array
                If tmpObj Is Nothing Then
                    ReDim Preserve tmpObj(0)
                Else
                    ReDim Preserve tmpObj(tmpObj.Length)
                End If

                tmpObj(tmpObj.Length - 1) = tmpParam.Value
            End If
        Next

        'Return the values array
        Return tmpObj

    End Function

    Public Function ExecuteSQL_OverOLE_DB_Connection(ByVal strConnectionString As String, ByVal strSQLToRun As String) As Boolean
        '*************************************************************************
        '* Function Name:   ExecuteSQL_OverOLE_DB_Connection
        '* Description:     This function opens a connection based on a given
        '*                  connection string, and executes the given SQL
        '* Created by:      Raz Davidovich
        '* Created date:    28/08/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim cnnConnection As New OleDbConnection(strConnectionString)
        Dim cmdCommand As OleDbCommand = Nothing

        'Try to open the connection
        Try
            cnnConnection.Open()

            'Execute the SQL
            cmdCommand = New OleDbCommand(strSQLToRun, cnnConnection)
            cmdCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            'Cleanup
            cmdCommand.Dispose()
            cnnConnection.Dispose()

        End Try

        'All OK, return true
        Return True

    End Function

    Public Sub CommitTransaction()
        '*************************************************************************
        '* Function Name:   CommitTransaction
        '* Description:     Commit SQL transaction
        '*                  
        '* Created by:      Liat Komaps
        '* Created date:    05/06/2011
        '* Last Modifyer:   
        '*************************************************************************

        'commit the transaction
        If Not (cmdTransactionCommand.Transaction Is Nothing) Then
            'objsqlTransaction.Commit()
            cmdTransactionCommand.Transaction.Commit()
        End If

    End Sub
    Public Sub CloseTransaction()
        '*************************************************************************
        '* Function Name:   CloseTransaction
        '* Description:     Close connection to the database
        '*                  
        '* Created by:      Liat Komaps
        '* Created date:    05/06/2011
        '* Last Modifyer:   
        '*************************************************************************
        If Not (cmdTransactionCommand Is Nothing) Then
            'Close the connection to the database
            cmdTransactionCommand.Connection.Close()
            'Clear Parameters
            If cmdTransactionCommand.Parameters.Count <> 0 Then
                cmdTransactionCommand.Parameters.Clear()
            End If
            cmdTransactionCommand.Dispose()
        End If
    End Sub

    Public Sub RollBackTransaction()
        '*************************************************************************
        '* Function Name:   RollBackTransaction
        '* Description:     Roll Back the transaction
        '*                  
        '* Created by:      Liat Komaps
        '* Created date:    05/06/2011
        '* Last Modifyer:   
        '*************************************************************************
        'Roll Back the transaction
        If Not (objsqlTransaction Is Nothing) Then
            objsqlTransaction.Rollback()
        End If

    End Sub


#End Region

End Class
