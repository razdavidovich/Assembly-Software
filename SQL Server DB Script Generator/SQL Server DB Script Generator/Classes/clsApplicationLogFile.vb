Imports System.IO

Public Class clsApplicationLogFile
    '***************************************************************************
    '* This Class is used to write a a text string to an application log file
    '***************************************************************************

#Region "Class variables declarations"
    Private Shared strLogFilePath As String
    Private Shared strLogFileName As String
    Private Shared strLogFileExtension As String
    Private Shared strApplicationVersion As String
#End Region

#Region "Class Constructors"

    Shared Sub New()
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Get the log file settings from the application config file
        strLogFilePath = Config.ReadConfigValue("LogFilePath", "Settings", "Application")
        strLogFileName = Config.ReadConfigValue("LogFileName", "Settings", "Application")
        strLogFileExtension = Config.ReadConfigValue("log", "Settings", "Application")

        'Get the application version into the private variable
        Dim objAppInfo As clsApplicationAttributes = New clsApplicationAttributes
        strApplicationVersion = objAppInfo.ApplicationVersion

    End Sub

#End Region

#Region "Class methods"

    Public Shared Sub WriteLog(ByVal strTextToWrite As String)
        '*************************************************************************
        '* Function Name:   WriteLog
        '* Description:     This function writes a given text to the application
        '*                  log file
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Open the file for write
        Dim strFileToOpen As String = strLogFilePath & strLogFileName & "." & strLogFileExtension

        'Try to open the file for write
        Try
            Dim writer As StreamWriter = New StreamWriter(strFileToOpen, False)

            'Write the data to the text file
            writer.WriteLine("/*===== [SQL Server Script Generator]" & vbTab & "[Version: " & strApplicationVersion & "]" & " =====*/" & vbCrLf & strTextToWrite)

            'Close the file
            writer.Close()
        Catch ex As Exception
            'Raise the exception to the caller
            Throw ex
        End Try

    End Sub

#End Region

#Region "Class properties"

    Public Shared Property LogFilePath() As String
        Get
            Return strLogFilePath
        End Get
        Set(ByVal Value As String)
            strLogFilePath = Value
        End Set
    End Property

    Public Shared Property LogFileName() As String
        Get
            Return strLogFileName
        End Get
        Set(ByVal Value As String)
            strLogFileName = Value
        End Set
    End Property

    Public Shared Property LogFileExtension() As String
        Get
            Return strLogFileExtension
        End Get
        Set(ByVal Value As String)
            strLogFileExtension = Value
        End Set
    End Property
#End Region

End Class
