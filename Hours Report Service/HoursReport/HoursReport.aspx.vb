Imports System.Diagnostics
Imports System.Data.SqlClient

Partial Class HoursReport

#Region " Web Form Declaration Code "
    Inherits Page

    Protected WithEvents vlrValidateOperationText As RequiredFieldValidator

#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
        If strUserName.Trim.Length > 0 Then
            strUserName = Mid(strUserName, InStr(strUserName, "\", CompareMethod.Text) + 1, Len(strUserName))
            lblUserName.Text = "שלום " & GetUserName(strUserName)

            'Check if the user has been identify
            If intEmployeeID = -1 Then Response.Redirect("ErrorMessage.aspx")
        End If


        'Load tasks to the Task to perform combo box (For recognized user)
        FillTasksComboBox(intEmployeeID, 0)

        'Load actions to the Action Performed combo box
        FillActionTypeComboBox()

        'Load cars information to the combo box
        FillCarsComboBox()

    End Sub

#End Region

    Private Sub btnClearForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearForm.Click
        'Clear the form from data entry
        ClearForm()

    End Sub

    Private Sub btnBackToMain_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackToMain.Click
        'Return to the magma portal
        Response.Redirect("../default.htm")
    End Sub

    Private Sub rblOrderBySelector_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rblOrderBySelector.SelectedIndexChanged
        'Sort the Task to perform combo box
        FillTasksComboBox(intEmployeeID, CInt(rblOrderBySelector.SelectedItem.Value))

    End Sub

    Private Function FillTasksComboBox(ByVal intUserID As Integer, ByVal intSortOrder As Integer) As Boolean
        '**********************************************************************
        '* NAME:        GetUserName                                           *
        '* DESCRIPTION: This function returns that real user name in hebrew   *
        '*              based on the authenticated user to the web site       *
        '* WRITEN BY:   Raz Davidovich                                        *
        '* DATE:        02/05/2003                                            *
        '********************************************************************** 
        Dim commObj As SqlCommand = New SqlCommand
        Dim param1 As SqlParameter

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "GetUserTasks_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intUserID", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = intEmployeeID
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intSortType", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = intSortOrder
        commObj.Parameters.Add(param1)

        'Run the stored procedure
        Try
            'Read the tasks information to a data reader
            Dim rdrTaskReader As SqlDataReader = commObj.ExecuteReader(CommandBehavior.CloseConnection)

            'Clear the items from the combo box
            ddlTaskPerformed.Items.Clear()

            'Add the first constant task
            Dim itmNewItem As New ListItem("=== בחר פרוייקט לדיווח ===", "-1")
            ddlTaskPerformed.Items.Add(itmNewItem)
            ddlTaskPerformed.Items(0).Selected = True

            'Load the new items to the tasks combo box
            While rdrTaskReader.Read()
                'ddlTaskPerformed.Items.Add(rdrTaskReader.GetString(0))  'UserTasks field
                itmNewItem = New ListItem(rdrTaskReader.GetString(1), rdrTaskReader.GetValue(0).ToString)
                ddlTaskPerformed.Items.Add(itmNewItem)
            End While

            'Close the reader
            rdrTaskReader.Close()

            Return True
        Catch e As Exception
            Return False

        Finally
            'Release the objects
            commObj = Nothing
            param1 = Nothing
        End Try

        'Close the connection to the database
        CloseConnectionToDatbase()

    End Function

    Private Function FillCarsComboBox() As Boolean
        '**********************************************************************
        '* NAME:        FillCarsComboBox                                      *
        '* DESCRIPTION: This function loads all cars information to the cars  *
        '*              combo box on the main form                            *
        '* WRITEN BY:   Raz Davidovich                                        *
        '* DATE:        04/06/2003                                            *
        '********************************************************************** 
        Dim commObj As SqlCommand = New SqlCommand
        Dim itmNewItem As ListItem

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "GetCarsInformation_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Run the stored procedure
        Try
            'Read the tasks information to a data reader
            Dim rdrCarsReader As SqlDataReader = commObj.ExecuteReader(CommandBehavior.CloseConnection)

            'Load the new items to the tasks combo box
            While rdrCarsReader.Read()
                itmNewItem = New ListItem(rdrCarsReader.GetString(1), rdrCarsReader.GetValue(0).ToString)
                ddlCarReport.Items.Add(itmNewItem)
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

    Private Function FillActionTypeComboBox() As Boolean
        '**********************************************************************
        '* NAME:        FillActionTypeComboBox                                *
        '* DESCRIPTION: This function loads all action types information to   *
        '*              the action types combo box on the main form           *
        '* WRITEN BY:   Raz Davidovich                                        *
        '* DATE:        04/06/2003                                            *
        '********************************************************************** 
        Dim commObj As SqlCommand = New SqlCommand
        Dim itmNewItem As ListItem

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "GetOperations_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Run the stored procedure
        Try
            'Read the tasks information to a data reader
            Dim rdrActionTypesReader As SqlDataReader = commObj.ExecuteReader(CommandBehavior.CloseConnection)

            'Load the new items to the tasks combo box
            While rdrActionTypesReader.Read()
                itmNewItem = New ListItem(rdrActionTypesReader.GetString(1), rdrActionTypesReader.GetValue(0).ToString)
                ddlActionPerformed.Items.Add(itmNewItem)
            End While

            'Close the reader
            rdrActionTypesReader.Close()

            Return True
        Catch e As Exception
            Return False

        Finally
            commObj = Nothing
        End Try

        'Close the connection to the database
        CloseConnectionToDatbase()

    End Function

    Private Function SaveTaskReport() As Boolean
        '**********************************************************************
        '* NAME:        SaveTaskReport                                        *
        '* DESCRIPTION: This saves the user report to the database            *
        '* WRITEN BY:   Raz Davidovich                                        *
        '* DATE:        05/06/2003                                            *
        '********************************************************************** 
        Dim commObj As SqlCommand = New SqlCommand
        Dim param1 As SqlParameter

        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()
        commObj.Connection = connObj
        commObj.CommandText = "SaveUserHourReport_sp"
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
        param1 = New SqlParameter("@intTaskID", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = CInt(ddlTaskPerformed.SelectedItem.Value)
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@fltHourToReport", SqlDbType.Float)
        param1.Direction = ParameterDirection.Input
        param1.Value = CSng(ddlHoursToReport.SelectedItem.Value)
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intDriveOperation", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = CInt(ddlCarReport.SelectedItem.Value)
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intOperation", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = CInt(ddlActionPerformed.SelectedItem.Value)
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@vchTaskOperationText", SqlDbType.VarChar, 100)
        param1.Direction = ParameterDirection.Input
        param1.Value = txtOperationDescription.Text.ToString
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

    Private Sub ClearForm()
        '********************************************************************
        '* NAME:        ClearForm                                           *
        '* DESCRIPTION: This sub clears the form from all data entry        *
        '* WRITEN BY:   Raz Davidovich                                      *
        '* DATE:        16/06/2003                                          *
        '********************************************************************

        'Clear the user selection on the form
        ddlActionPerformed.ClearSelection()
        ddlCarReport.ClearSelection()
        ddlHoursToReport.SelectedIndex() = 17
        ddlTaskPerformed.ClearSelection()
        txtOperationDescription.Text = vbNullString
        lblErrorDescription.Visible = False

    End Sub

    Private Sub btnSaveTask_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveTask.Click
        'Validate that All controls on the page have valid values
        With lblErrorDescription
            If Page.IsValid Then
                If SaveTaskReport() Then
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

    Private Sub cmdAbsenceReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAbsenceReport.Click
        'Go to the Hours report web form
        Response.Redirect("AbsenceReport.aspx")

    End Sub

    Private Sub btnReports_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReports.Click
        'Navigate to the reports page
        Response.Redirect("ReportsContainer.htm")

    End Sub

End Class
