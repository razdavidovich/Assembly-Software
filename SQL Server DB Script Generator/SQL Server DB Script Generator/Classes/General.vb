Imports System.Data.SqlClient
Imports Assembly.Software.DB

Public Class General
    '*************************************************************************
    '* This class holds all the general functions for Bezeq international apps
    '*************************************************************************

#Region " Class Declarations"
    'Private class declarations
    Private Shared strMasterConnectionString As String
    Private Shared strSelectedDBConnectionString As String

    Private Shared blnDebugMode As Boolean = False
#End Region

#Region " Class shared properties"

    'Expose a read only employee job type ID property
    Public Shared ReadOnly Property DebugMode() As Boolean
        Get
            'Return the employee id
            Return blnDebugMode
        End Get

    End Property

    'Expose the connection string property
    Public Shared Property MasterConnectionString() As String
        Get
            'Return connection string
            Return strMasterConnectionString
        End Get
        Set(ByVal strValue As String)
            strMasterConnectionString = strValue
        End Set

    End Property

    'Expose the connection string property
    Public Shared Property SelectedDBConnectionString() As String
        Get
            'Return connection string
            Return strSelectedDBConnectionString
        End Get
        Set(ByVal strValue As String)
            strSelectedDBConnectionString = strValue
        End Set

    End Property
#End Region

#Region " Class shared methods"

    'Public Shared Sub FillWinComboBox(ByRef cmbComboBoxToFill As ComboBox, ByVal intComboBoxDBID As Integer, _
    '            Optional ByVal intWhereID As Integer = Nothing, Optional ByVal strItemToLoad() As String = Nothing, _
    '            Optional ByVal intValues() As Integer = Nothing)
    '    '*************************************************************************
    '    '* Function Name:   FillWinComboBox
    '    '* Description:     This sub is a generic sub for filling any combo box 
    '    '*                  in an application
    '    '* Created by:      Raz Davidovich
    '    '* Created date:    20/01/2004
    '    '* Last Modifyer:   Raz Davidovich
    '    '*************************************************************************
    '    Dim objDB As New DBHelper(General.ConnectionString, DBHelper.Connection_Type.SQL_Server)
    '    Dim arrComboDataSource As New ArrayList

    '    'Get the combo box data
    '    Dim dtsComboData As DataSet = objDB.FillDataSetFromSP("dbo.FillCombo_sp", _
    '                            New SqlParameter() _
    '                            {New SqlParameter("@ComboID", SqlDbType.Int, 3), _
    '                            New SqlParameter("@WhereParam", SqlDbType.Int, 3)}, _
    '                            New Object() {intComboBoxDBID, intWhereID})

    '    'Add the - Add New - caption if needed
    '    If Not (strItemToLoad Is Nothing) Then
    '        For I As Integer = 0 To strItemToLoad.Length - 1
    '            arrComboDataSource.Add(New ComboItem(strItemToLoad(I), intValues(I)))
    '        Next
    '    End If

    '    'Loop the table and add the items to the combo
    '    For I As Integer = 0 To dtsComboData.Tables(0).Rows.Count - 1
    '        'Add the next item
    '        'cmbComboBoxToFill.Items.Add(New ComboItem(dtsComboData.Tables(0).Rows(I).Item(1), dtsComboData.Tables(0).Rows(I).Item(0)))
    '        arrComboDataSource.Add(New ComboItem(dtsComboData.Tables(0).Rows(I).Item(1), dtsComboData.Tables(0).Rows(I).Item(0)))
    '    Next

    '    'Set the combo box display and value
    '    cmbComboBoxToFill.DataSource = arrComboDataSource
    '    cmbComboBoxToFill.DisplayMember = "DisplayText"
    '    cmbComboBoxToFill.ValueMember = "Value"

    'End Sub

    Public Shared Function DisplayMessageBox(ByVal intMessageID As Integer, Optional ByVal strAdditionaltext As String = vbNullString, Optional ByVal ex As Exception = Nothing, Optional ByVal strExeptionAdditionlText As String = vbNullString) As MsgBoxResult
        '*************************************************************************
        '* Function Name:   DisplayMessageBox
        '* Description:     This function gets a message Id and retrive the msgbox
        '*                  message and parameters from the application 
        '*                  Configuration file
        '* Created by:      Raz Davidovich
        '* Created date:    12/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strMessageId As String
        Dim strMessageText As String
        Dim intMessageType As Integer
        Dim strMessageTitle As String

        'Display the error message if on debug mode
        If blnDebugMode Then
            If Not (ex Is Nothing) Then
                'Display the error message
                MessageBox.Show(ex.Source & vbCrLf & ex.Message.ToString + vbCrLf + strExeptionAdditionlText, "Debug Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        'Set the message ID string
        strMessageId = "ID_" + intMessageID.ToString

        'Get the message text
        strMessageText = Config.ReadConfigValue("MessageText", strMessageId, "Messages")
        intMessageType = Config.ReadConfigValue("MessageType", strMessageId, "Messages")
        strMessageTitle = Config.ReadConfigValue("MessageTitle", strMessageId, "Messages")

        'Add the aditionl text to the message
        strMessageText += strAdditionaltext

        'Display the messagebox and return the user response
        Return MsgBox(strMessageText, intMessageType, strMessageTitle)

    End Function

    Public Shared Function GetMessage(ByVal intMessageID As Integer, Optional ByVal strAdditionaltext As String = vbNullString, _
        Optional ByVal ex As Exception = Nothing, Optional ByVal strExeptionAdditionlText As String = vbNullString) As String
        '*************************************************************************
        '* Function Name:   DisplayMessageBox
        '* Description:     This function gets a message Id and retrive the msgbox
        '*                  message and parameters from the application 
        '*                  Configuration file
        '* Created by:      Raz Davidovich
        '* Created date:    12/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strMessageId As String
        Dim strMessageText As String

        'Display the error message if on debug mode
        If blnDebugMode Then
            If Not (ex Is Nothing) Then
                'Display the error message
                MessageBox.Show(ex.Source & vbCrLf & ex.Message.ToString + vbCrLf + strExeptionAdditionlText, "Debug Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        'Set the message ID string
        strMessageId = "ID_" + intMessageID.ToString

        'Get the message text
        strMessageText = Config.ReadConfigValue("MessageText", strMessageId, "Messages")

        'Add the aditionl text to the message
        strMessageText += strAdditionaltext

        'Display the messagebox and return the user response
        Return strMessageText

    End Function

#End Region

#Region " Class constructors"

    Shared Sub New()

        'Read the debug mode from the config file
        Try
            'Get the configuration information from the App.Config file
            blnDebugMode = Config.ReadConfigValue("Debug", "Settings", "Application")

        Catch ex As Exception
            'Display an error message and exit
            MsgBox("Error reading the configuration file, please contact your system administrator", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "Initialization Error")
            End
        End Try
    End Sub

#End Region

End Class
