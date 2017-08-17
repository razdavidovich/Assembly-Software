Imports Assembly.Software.DB

Public Class frmMainForm

    Private sb As New System.Text.StringBuilder
    Private strCurrentDBName As String = "master"
    Private blnComboboxLoading As Boolean

    Private blnShowScriptHeader As Boolean = True
    Private blnDropCommand As Boolean = True
    Private blnGenerateTablesKeys As Boolean = True

    Private Sub btnConnectToServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectToServer.Click
        'Clear previous erros from the screen
        erpFormErrors.Clear()

        If btnConnectToServer.Text = "&Disconnect" Then
            btnConnectToServer.Text = "&Connect to Server"
            cmbDatabases.DataSource = Nothing
            SetFormState(True)
            btnGenerateToClipboard.Enabled = False
            btnGenerateToFile.Enabled = False
            lvwObjectsToScript.Items.Clear()

            'Hide the select all\ clear all items in the menu
            With tlbUltraToolbarManager.Toolbars(0).Tools
                .Item("SelectAll").SharedProps.Visible = False
                .Item("ClearSelection").SharedProps.Visible = False
            End With

            Exit Sub
        End If

        'Validate the user input
        With txtServerName
            If .Text.Trim.Length = 0 Then
                erpFormErrors.SetError(txtServerName, General.GetMessage(100))
                .Focus()
                Return
            End If
        End With

        If Not chkWindowsAuthentication.Checked Then
            With txtUserName
                If .Text.Trim.Length = 0 Then
                    erpFormErrors.SetError(txtUserName, General.GetMessage(101))
                    .Focus()
                    Return
                End If
            End With

            With txtPassword
                If .Text.Trim.Length = 0 Then
                    erpFormErrors.SetError(txtPassword, General.GetMessage(102))
                    .Focus()
                    Return
                End If
            End With
        End If

        '================================
        'try to connect to the SQL server
        '================================
        'Set the connection string
        sb = New System.Text.StringBuilder
        sb.Append("Data Source=" + txtServerName.Text + ";")
        sb.Append("Initial Catalog=master;")
        strCurrentDBName = "master"
        If chkWindowsAuthentication.Checked Then
            sb.Append("Integrated Security=True;")
        Else
            sb.Append("uid=" + txtUserName.Text + ";")
            sb.Append("Pwd=" + txtPassword.Text + ";")
        End If


        'Try to fill the database combobox
        If FillDatabaseComboBox(sb.ToString) Then

            General.MasterConnectionString = sb.ToString

            If Not chkWindowsAuthentication.Checked Then
                btnConnectToServer.Text = "&Disconnect"
                SetFormState(False)

                'Save the last server name to the config file
                Config.SaveConfigValue("ServerName", "Settings", "Database", txtServerName.Text)
                Config.SaveConfigValue("UserID", "Settings", "Database", txtUserName.Text)
                Config.SaveConfigValue("WindowsAuthentication", "Settings", "Database", chkWindowsAuthentication.Checked.ToString)
            End If
        End If
    End Sub

    Private Sub chkWindowsAuthentication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWindowsAuthentication.CheckedChanged

        'Enable/Disable the SQL Server user and password textboxes
        txtUserName.Enabled = Not chkWindowsAuthentication.Checked
        txtPassword.Enabled = Not chkWindowsAuthentication.Checked

    End Sub

    Private Function FillDatabaseComboBox(ByVal strConnectionString As String) As Boolean
        '*************************************************************************
        '* Function Name:   FillDatabaseComboBox
        '* Description:     This function trys to connect to the SQL Database
        '*                  and fill the database combobox with relevant databases
        '* Created by:      Raz Davidovich
        '* Created date:    05/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Set the flag that marks that a combobox is being loaded
        blnComboboxLoading = True

        'Generate a new DBHelper calss to access the database
        Dim clsDB_Access As New DBHelper(strConnectionString, DBHelper.Connection_Type.SQL_Server)

        'Get the database SQL query to run
        Dim strGet_DB_SQL As String = Config.ReadConfigValue("GetDatabases", "SQL", "Database")

        Dim dtlDatabases As DataTable
        Try
            'Get the data into a data table
            dtlDatabases = clsDB_Access.FillDataTableFromSQLText(strGet_DB_SQL)

        Catch ex As Exception
            General.DisplayMessageBox(5, Nothing, ex)
            Return False
        End Try

        'Bind the combobox to the databases data table

        With cmbDatabases
            .DataSource = dtlDatabases
            .DisplayMember = "name"
            .ValueMember = "name"
            .SelectedIndex = -1
        End With

        'Reset the flag that marks that a combobox is being loaded
        blnComboboxLoading = False

        Return True

    End Function

    Private Function FillTablesListView(ByVal strConnectionString As String) As Boolean
        '*************************************************************************
        '* Function Name:   FillDatabaseComboBox
        '* Description:     This function trys to connect to the SQL Database
        '*                  and fill the database combobox with relevant databases
        '* Created by:      Raz Davidovich
        '* Created date:    05/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Generate a new DBHelper calss to access the database
        Dim clsDB_Access As New DBHelper(strConnectionString, DBHelper.Connection_Type.SQL_Server)

        'Get the database SQL query to run
        Dim strGet_DB_SQL As String = Config.ReadConfigValue("GetTablesInDB", "SQL", "Database")

        Dim dtlTablesList As DataTable
        Try
            'Get the data into a data table
            dtlTablesList = clsDB_Access.FillDataTableFromSQLText(strGet_DB_SQL)

        Catch ex As Exception
            General.DisplayMessageBox(5, Nothing, ex)
            Return False
        End Try

        'Load the data to the list view
        'Clear the existing items in the listview
        lvwObjectsToScript.Items.Clear()

        'Load the table list to the listview
        Dim lvwSubItem As ListViewItem
        For Each dtrTempRow As DataRow In dtlTablesList.Rows
            'Load the tables listview
            With lvwObjectsToScript
                lvwSubItem = .Items.Add(dtrTempRow.Item(1).ToString, 0)
                lvwSubItem.SubItems.Add(dtrTempRow.Item(0).ToString)

                lvwSubItem.Tag = GenerateBaseTableObject(dtrTempRow.Item(1).ToString, blnShowScriptHeader, blnDropCommand, blnGenerateTablesKeys)
            End With
        Next

        Return True

    End Function

    Private Sub SetFormState(ByVal blnEnableControls As Boolean)
        '*************************************************************************
        '* Function Name:   SetFormState
        '* Description:     This sub enable\Disable the form controls 
        '*                  
        '* Created by:      Raz Davidovich
        '* Created date:    12/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        txtServerName.Enabled = blnEnableControls
        txtUserName.Enabled = blnEnableControls
        txtPassword.Enabled = blnEnableControls
        chkWindowsAuthentication.Enabled = blnEnableControls
        cmbDatabases.Enabled = Not blnEnableControls

    End Sub

    Private Sub frmMainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Load the last successful server login information
        txtServerName.Text = Config.ReadConfigValue("ServerName", "Settings", "Database")
        txtUserName.Text = Config.ReadConfigValue("UserID", "Settings", "Database")
        chkWindowsAuthentication.Checked = Boolean.Parse(Config.ReadConfigValue("WindowsAuthentication", "Settings", "Database"))

    End Sub

    Private Sub cmbDatabases_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDatabases.SelectedIndexChanged

        'Check for selection
        If (cmbDatabases.SelectedIndex <> -1) And (Not blnComboboxLoading) Then

            'Replace the connection string to the new database
            sb.Replace(strCurrentDBName, cmbDatabases.SelectedValue)
            strCurrentDBName = cmbDatabases.SelectedValue



            'Set the connection string
            Dim objSb As System.Text.StringBuilder = New System.Text.StringBuilder
            objSb.Append("Data Source=" + txtServerName.Text + ";")
            objSb.Append("Initial Catalog=" + strCurrentDBName + ";")
            If chkWindowsAuthentication.Checked Then
                objSb.Append("Integrated Security=True;")
            Else
                objSb.Append("uid=" + txtUserName.Text + ";")
                objSb.Append("Pwd=" + txtPassword.Text + ";")
            End If

            General.SelectedDBConnectionString = objSb.ToString


            'Load the tables into the list view
            If FillTablesListView(General.SelectedDBConnectionString) Then
                'Show the select all\ clear all items in the menu
                With tlbUltraToolbarManager.Toolbars(0).Tools
                    .Item("SelectAll").SharedProps.Visible = True
                    .Item("ClearSelection").SharedProps.Visible = True
                End With

                'Enable the buttons
                btnGenerateToClipboard.Enabled = True
                btnGenerateToFile.Enabled = True

            End If

        End If

    End Sub

    Private Sub tlbUltraToolbarManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tlbUltraToolbarManager.ToolClick
        Select Case e.Tool.Key
            Case "Exit_App"    ' ButtonTool
                'Verify that the user wish to exit the application
                If General.DisplayMessageBox(2) = MsgBoxResult.Yes Then
                    End
                End If

            Case "About"    ' ButtonTool
                'Display the about form
                Dim frm As New frmAssemblyAbout
                frm.ShowDialog()

            Case "IncludeDescriptive"    ' StateButtonTool
                'Set the display descriptive header On\Off
                blnShowScriptHeader = Not blnShowScriptHeader

                'Reload the tables objects
                'ReLoadProjectTables()

                'Up Cast the tool to StateButtonTool
                Dim stateTool As Infragistics.Win.UltraWinToolbars.StateButtonTool
                stateTool = CType(e.Tool, Infragistics.Win.UltraWinToolbars.StateButtonTool)

                'Change the checkbox display 
                stateTool.Checked = blnShowScriptHeader

            Case "GenerateDROP"    ' StateButtonTool
                'Set the generate drop command On\Off
                blnDropCommand = Not blnDropCommand

                'Reload the tables objects
                'ReLoadProjectTables()

                'Up Cast the tool to StateButtonTool
                Dim stateTool As Infragistics.Win.UltraWinToolbars.StateButtonTool
                stateTool = CType(e.Tool, Infragistics.Win.UltraWinToolbars.StateButtonTool)

                'Change the checkbox display 
                stateTool.Checked = blnDropCommand

            Case "GenKeysInfo"    ' StateButtonTool
                'Set the generate drop command On\Off
                blnGenerateTablesKeys = Not blnGenerateTablesKeys

                'Reload the tables objects
                'ReLoadProjectTables()

                'Up Cast the tool to StateButtonTool
                Dim stateTool As Infragistics.Win.UltraWinToolbars.StateButtonTool
                stateTool = CType(e.Tool, Infragistics.Win.UltraWinToolbars.StateButtonTool)

                'Change the checkbox display 
                stateTool.Checked = blnGenerateTablesKeys

            Case "SelectAll"    ' ButtonTool
                'Select all the listview items
                ListViewSelection(lvwObjectsToScript, True)
                
            Case "ClearSelection"    ' ButtonTool
                'Clear all listview items
                ListViewSelection(lvwObjectsToScript, False)

        End Select
    End Sub

    Private Sub ListViewSelection(ByVal lvwListView As ListView, ByVal blnSelect As Boolean)
        '*************************************************************************
        '* Function Name:   ListViewSelection
        '* Description:     This private function select or unselect all the 
        '*                  listview items
        '* Created by:      Raz Davidovich
        '* Created date:    24/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Loop the listiew and generate the SQL drop command
        For Each lvwSubItem As ListViewItem In lvwListView.Items
            lvwSubItem.Checked = blnSelect
        Next

    End Sub

    Private Function CheckListViewSelection() As Boolean
        '*************************************************************************
        '* Function Name:   CheckListViewSelection
        '* Description:     This private function returns true if one or more
        '*                  tables has been selected by the user
        '* Created by:      Raz Davidovich
        '* Created date:    24/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Loop the listiew and generate the SQL drop command
        For Each lvwSubItem As ListViewItem In lvwObjectsToScript.Items
            If lvwSubItem.Checked Then Return True
        Next

        'Display an error message to the user
        General.DisplayMessageBox(4)

        'No selection found, return false
        Return False

    End Function

    Private Sub btnGenerateToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateToClipboard.Click

        'Verify that the user has selected at least one table to script
        If Not CheckListViewSelection() Then Exit Sub

        'Display a busy cursor
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'Generate the script & show the preview form
        Dim frmPreviewSQL As New frmScriptPreview(GenerateSQL())
        frmPreviewSQL.ShowDialog()

        'Display a normal cursor
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Function GenerateSQL() As String
        '*************************************************************************
        '* Function Name:   GenerateSQL
        '* Description:     This private function generate and returns the SQL
        '*                  script for the selected tables
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim tmpTableObject As clsTableObject
        Dim strSQLScript As String = String.Empty

        'Loop the listiew and generate the SQL drop command
        For Each lvwSubItem As ListViewItem In lvwObjectsToScript.Items
            If lvwSubItem.Checked Then
                'Get the table object stored in the listview tag
                tmpTableObject = lvwSubItem.Tag
                strSQLScript += tmpTableObject.GenerateObjectScript
            End If
        Next

        'Return the SQL script
        Return strSQLScript

    End Function

    Private Function GenerateConfig() As String
        '*************************************************************************
        '* Function Name:   GenerateConfig
        '* Description:     This private function generate and returns the config
        '*                  values for the selected tables
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim tmpTableObject As clsTableObject
        Dim sbrConfigScript As New System.Text.StringBuilder

        'Loop the listiew and generate the SQL drop command
        For Each lvwSubItem As ListViewItem In lvwObjectsToScript.Items
            If lvwSubItem.Checked Then
                'Get the table object stored in the listview tag
                tmpTableObject = lvwSubItem.Tag
                sbrConfigScript.AppendLine(tmpTableObject.GenerateObjectScript)
            End If
        Next

        'Return the SQL script
        Return sbrConfigScript.ToString

    End Function

    Private Sub btnGenerateToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateToFile.Click

        'Verify that the user has selected at least one table to script
        If Not CheckListViewSelection() Then Exit Sub

        'Display a save as... dialogbox
        Dim dlg As New SaveFileDialog
        With dlg
            .Filter = "sql files (*.sql)|*.sql"
            .FilterIndex = 1
            .RestoreDirectory = True

            Dim dlgAnswer As DialogResult
            dlgAnswer = dlg.ShowDialog(Me)
            If dlgAnswer = DialogResult.OK Then
                'Generate the script
                Dim strScript As String = GenerateSQL()

                'Save the script to a file
                clsApplicationLogFile.LogFileExtension = dlg.FileName.Substring(dlg.FileName.LastIndexOf(".") + 1)
                clsApplicationLogFile.LogFileName = dlg.FileName.Substring(dlg.FileName.LastIndexOf("\") + 1, dlg.FileName.LastIndexOf(".") - dlg.FileName.LastIndexOf("\") - 1)
                clsApplicationLogFile.LogFilePath = dlg.FileName.Substring(0, dlg.FileName.LastIndexOf("\") + 1)
                clsApplicationLogFile.WriteLog(strScript)

                General.DisplayMessageBox(3)
            End If
        End With

    End Sub

End Class
