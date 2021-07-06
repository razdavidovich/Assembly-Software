Imports System.Diagnostics
Imports System.Data.SqlClient

Partial Class ReportsFilter
    Inherits Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As Object

    Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        Dim itmNewItem As ListItem

        'Fill the report year combo box
        For I As Integer = 2000 To Now.Year
            itmNewItem = New ListItem(I.ToString, I.ToString)
            cmbReportYear.Items.Add(itmNewItem)
        Next

        'Set the default month and year to the reports combobox
        cmbReportMonth.SelectedValue = Now.Month.ToString
        cmbReportYear.SelectedValue = Now.Year.ToString

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Load the Javascript Events only once
        If Not Me.IsPostBack Then
            FillReportsComboBox()

            'Add the top frame navigation back to the hours report form
            btnBack.Attributes.Add("onClick", "return window.top.navigate(""HoursReport.aspx"");")

            'Add the Report generation action (JavaScript)
            btnGenerateReport.Attributes.Add("onClick", "return GenerateReport(" + intEmployeeID.ToString + ");")
        End If

    End Sub

    Private Function FillReportsComboBox() As Boolean
        '************************************************************************
        '* NAME:        FillReportsComboBox                                     *
        '* DESCRIPTION: This function loads all cars information to the         *
        '*              reports combo box on the main form                      *
        '* WRITEN BY:   Raz Davidovich                                          *
        '* DATE:        18/03/2008                                              *
        '************************************************************************ 
        Dim commObj As SqlCommand = New SqlCommand
        Dim param1 As SqlParameter
        Dim itmNewItem As ListItem

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intComboID", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = 35
        commObj.Parameters.Add(param1)

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "dbo.GetComboBoxesData_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Run the stored procedure
        Try
            'Read the tasks information to a data reader
            Dim rdrCarsReader As SqlDataReader = commObj.ExecuteReader(CommandBehavior.CloseConnection)

            'Load the new items to the tasks combo box
            While rdrCarsReader.Read()
                itmNewItem = New ListItem(rdrCarsReader.GetString(1), rdrCarsReader.GetString(0))
                cmbReportToExecute.Items.Add(itmNewItem)
            End While

            'Close the reader
            rdrCarsReader.Close()

            Return True
        Catch e As Exception
            Return False

        Finally
            commObj = Nothing
        End Try

        'Close the connection to the database
        CloseConnectionToDatbase()

    End Function

End Class
