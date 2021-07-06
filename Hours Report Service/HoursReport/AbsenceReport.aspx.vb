Imports System.Diagnostics
Imports System.Data.SqlClient

Partial Class AbsenceReport
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

        'Set the current date as the defaukt date
        cdrActionDate.SelectedDate = Now

        'Get user information and display a welcome label
        'Read the user name from the global variables
        Dim strUserName As String = Request.ServerVariables("AUTH_USER")

        'Cut the user name from the domain
        If Len(Trim(strUserName)) > 0 Then
            strUserName = Mid(strUserName, InStr(strUserName, "\", CompareMethod.Text) + 1, Len(strUserName))
            lblUserName.Text = "שלום " & GetUserName(strUserName)

            'Check if the user has been identify
            If intEmployeeID = -1 Then Response.Redirect("Error.aspx")
        End If

        'Fill the absence combo box
        FillAbsenceTypeComboBox()

    End Sub

#End Region


    Private Sub cmdAbsenceReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAbsenceReport.Click
        'Return to the Hours report web form
        Response.Redirect("HoursReport.aspx")
    End Sub

    Private Function FillAbsenceTypeComboBox() As Boolean
        '************************************************************************
        '* NAME:        FillAbsenceTypeComboBox                                 *
        '* DESCRIPTION: This function loads all absence type information to the *
        '*              absence type combo box on the absence form              *
        '* WRITEN BY:   Raz Davidovich                                          *
        '* DATE:        04/06/2003                                              *
        '************************************************************************ 
        Dim commObj As SqlCommand = New SqlCommand
        Dim itmNewItem As ListItem

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "GetAbsenceInformation_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Run the stored procedure
        Try
            'Read the tasks information to a data reader
            Dim rdrCarsReader As SqlDataReader = commObj.ExecuteReader(CommandBehavior.CloseConnection)

            'Load the new items to the tasks combo box
            While rdrCarsReader.Read()
                itmNewItem = New ListItem(rdrCarsReader.GetString(1), rdrCarsReader.GetValue(0).ToString)
                ddlAbsenceType.Items.Add(itmNewItem)
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

    Private Sub ClearForm()
        '********************************************************************
        '* NAME:        ClearForm                                           *
        '* DESCRIPTION: This sub clears the form from all data entry        *
        '* WRITEN BY:   Raz Davidovich                                      *
        '* DATE:        16/06/2003                                          *
        '********************************************************************

        'Clear the user selection on the form
        ddlAbsenceType.ClearSelection()
        ddlHoursToReport.SelectedIndex() = 17
        txtAbsenceDescription.Text = vbNullString
        lblErrorDescription.Visible = False

    End Sub

    Private Function SaveAbsenceReport() As Boolean
        '************************************************************************
        '* NAME:        SaveAbsenceReport                                       *
        '* DESCRIPTION: This saves the user Absence report to the database      *
        '* WRITEN BY:   Raz Davidovich                                          *
        '* DATE:        05/06/2003                                              *
        '************************************************************************ 
        Dim commObj As SqlCommand = New SqlCommand
        Dim param1 As SqlParameter

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "SaveUserAbsenceReport_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intUserID", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = intEmployeeID
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@datReportDate", SqlDbType.DateTime)
        param1.Direction = ParameterDirection.Input
        param1.Value = cdrActionDate.SelectedDate.ToShortDateString.ToString
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intAbsenceType", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = CInt(ddlAbsenceType.SelectedItem.Value)
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@fltHourToReport", SqlDbType.Float)
        param1.Direction = ParameterDirection.Input
        param1.Value = CSng(ddlHoursToReport.SelectedItem.Value)
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@vchAbsenceDescription", SqlDbType.VarChar, 100)
        param1.Direction = ParameterDirection.Input
        param1.Value = txtAbsenceDescription.Text.ToString
        commObj.Parameters.Add(param1)

        'Run the stored procedure
        Try
            'Save the data to the database
            Dim intResult As Integer = commObj.ExecuteNonQuery()

            Return True
        Catch e As Exception
            Return False

        Finally
            commObj = Nothing
            param1 = Nothing
        End Try

        'Close the connection to the database
        CloseConnectionToDatbase()

    End Function

    Private Sub btnClearForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearForm.Click
        'Clear the form from data entry
        ClearForm()

    End Sub

    Private Sub btnBackToMain_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackToMain.Click
        'Return to the magma portal
        Response.Redirect("../default.htm")

    End Sub

    Private Sub btnSaveTask_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveTask.Click
        'Validate that All controls on the page have valid values
        With lblErrorDescription
            If Page.IsValid Then
                If SaveAbsenceReport() Then
                    'Clear all saved data from the form
                    ClearForm()

                    'All OK, display a success label
                    .ForeColor = Color.ForestGreen
                    .Text = "הדיווח נשמר בהצלחה לבסיס הנתונים"
                    .Visible = True
                Else
                    'Save Failed, display an error message
                    .ForeColor = Color.Red
                    .Text = "חובה למלא את כל השדות המסומנים בכוכבית !!!"
                    .Visible = True
                End If
            Else
                'Save Failed, display an error message
                .ForeColor = Color.Red
                .Text = "חובה למלא את כל השדות המסומנים בכוכבית !!!"
                .Visible = True
            End If
        End With
    End Sub

    Private Sub btnReports_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReports.Click
        'Navigate to the reports page
        Response.Redirect("ReportsContainer.htm")

    End Sub
End Class
