Imports System.Globalization

Public Class General
    '*************************************************************************
    '* This class holds all the general functions for Bezeq international apps
    '*************************************************************************

#Region " Class Declarations"
    'Private class declarations
    Private Shared strConnectionString As String
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
    Public Shared Property ConnectionString() As String
        Get
            'Return connection string
            Return strConnectionString
        End Get
        Set(ByVal strValue As String)
            strConnectionString = strValue
        End Set

    End Property

    'Expose a read only station ID property
    Public Shared ReadOnly Property StationID() As String
        Get
            'Return the employee id
            Return System.Net.Dns.GetHostName().ToUpper
        End Get

    End Property

    Public Shared ReadOnly Property ApplicationPath() As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory()
        End Get
    End Property

    Public Shared ReadOnly Property FileDateString() As String
        Get
            Dim strTemp As String

            'Set day format
            If Now.Day.ToString.Length = 1 Then
                strTemp = "0" + Now.Day.ToString
            Else
                strTemp = Now.Day.ToString
            End If

            'Add seperator
            strTemp += "-"

            'Set month format
            If Now.Month.ToString.Length = 1 Then
                strTemp += "0" + Now.Month.ToString
            Else
                strTemp += Now.Month.ToString
            End If

            'Add seperator
            strTemp += "-"
            strTemp += Now.Year.ToString

            Return strTemp
        End Get
    End Property

    Public Shared ReadOnly Property FileTimeString() As String
        Get
            Dim strTemp As String

            'Set day format
            If Now.Hour.ToString.Length = 1 Then
                strTemp = "0" + Now.Hour.ToString
            Else
                strTemp = Now.Hour.ToString
            End If

            'Add seperator
            strTemp += "-"

            'Set month format
            If Now.Minute.ToString.Length = 1 Then
                strTemp += "0" + Now.Minute.ToString
            Else
                strTemp += Now.Minute.ToString
            End If

            'Add seperator
            strTemp += "-"

            'Set month format
            If Now.Second.ToString.Length = 1 Then
                strTemp += "0" + Now.Second.ToString
            Else
                strTemp += Now.Second.ToString
            End If

            Return strTemp
        End Get
    End Property

#End Region

#Region "Class shared methods"

    Public Shared Function DisplayMessageBoxRTL(ByVal intMessageID As Integer, Optional ByVal strAdditionaltext As String = vbNullString, Optional ByVal ex As Exception = Nothing, Optional ByVal strExeptionAdditionlText As String = vbNullString) As MsgBoxResult
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
                MsgBox(ex.Source & vbCrLf & ex.Message.ToString + vbCrLf + strExeptionAdditionlText, 16, "Debug Message")
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
        Return MsgBox(strMessageText, intMessageType + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading, strMessageTitle)

    End Function

    Public Shared Function DisplayMessageBoxLTR(ByVal intMessageID As Integer, Optional ByVal strAdditionaltext As String = vbNullString, Optional ByVal ex As Exception = Nothing, Optional ByVal strExeptionAdditionlText As String = vbNullString) As MsgBoxResult
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
                MsgBox(ex.Source & vbCrLf & ex.Message.ToString + vbCrLf + strExeptionAdditionlText, 16, "Debug Message")
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

    Public Shared Function SerialNumberToHex(ByVal intSerialNumber As Integer, _
        ByVal intLocation As Integer) As Long
        '*************************************************************************
        '* Function Name:   SerialNumberToHex
        '* Description:     This function gets the numeric serial number and 
        '*                  generates the correct hexadecimal equivalent
        '* Created by:      Raz Davidovich
        '* Created date:    12/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strSerialHexValue As String = Now.Year.ToString.Substring(Now.Year.ToString.Length - 1) + Convert.ToString(intSerialNumber, 16).PadLeft(8, "0") + intLocation.ToString

        Return Long.Parse(strSerialHexValue.ToUpper, NumberStyles.HexNumber)

    End Function

#End Region

#Region " Class constructors"

    Shared Sub New()

        'Read the debug mode from the config file
        Try
            'Get the configuration information from the App.Config file
            Dim objDebugMode As Object
            objDebugMode = Config.ReadConfigValue("Debug", "Settings", "Application")
            If (objDebugMode Is Nothing) Then
                blnDebugMode = False
            Else
                blnDebugMode = Boolean.Parse(objDebugMode)
            End If


        Catch ex As Exception
            'Display an error message and exit
            MsgBox( _
            "Error reading the configuration file, please contact your system administrator", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Initialization Error")
        End Try
    End Sub

#End Region

End Class
