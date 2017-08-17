Imports System.IO
Imports System.Diagnostics

Public Class clsApplicationLogFile
    '***************************************************************************
    '* This Class is used to write a a text string to an application log file
    '***************************************************************************

#Region "Class variables declarations"
    Private Shared strLogFilePath As String
    Private Shared strLogFileName As String
    Private Shared strLogFileExtension As String
    Private Shared objLoker As Object = New Object()
    Private Shared strLogFileNameDateFormat As String

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
        strLogFileNameDateFormat = Config.ReadConfigValue("LogFileNameDateFormat", "Settings", "Application")
        strLogFileExtension = Config.ReadConfigValue("log", "Settings", "Application")

        'Set the default application log file properties in case 
        'it was not defined at the config file
        If strLogFilePath Is Nothing Then strLogFilePath = System.AppDomain.CurrentDomain.BaseDirectory()
        If strLogFileName Is Nothing Then strLogFileName = "ApplicationLogfile"
        If strLogFileNameDateFormat Is Nothing Then strLogFileNameDateFormat = "ww-yyyy"
        If strLogFileExtension Is Nothing Then strLogFileExtension = "log"

        'Make sure that the file path ends with \
        strLogFilePath += IIf(strLogFilePath.EndsWith("\"), String.Empty, "\")

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

        ' Added by Haniel Shiffer in 01/02/2009
        ' Locking critical section
        SyncLock objLoker
            'Set the file name date time string
            Dim strFileNameDateTimeString As String = Now.ToString(strLogFileNameDateFormat.Replace("ww", DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.System, FirstWeekOfYear.System).ToString.PadLeft(2, "0")))

            'Open the file for write
            Dim strFileToOpen As String = strLogFilePath + strLogFileName + "_" + strFileNameDateTimeString + "." & strLogFileExtension

            'Try to open the file for write
            Try
                Dim writer As StreamWriter = New StreamWriter(strFileToOpen, True)

                'Write the data to the text file
                writer.WriteLine("[" + Now.ToString("dd/MM/yyyy HH:mm:ss") + "] " + strTextToWrite)

                'Close the file
                writer.Close()
            Catch ex As Exception
                WriteToWindowsEventViewerLog(ex.Message + vbCrLf + "The error occured while trying to write the message:" + vbCrLf + _
                                 strTextToWrite + vbCrLf + "To the file " + strFileToOpen, EventLogEntryType.Error)
            End Try
        End SyncLock

    End Sub

    Public Shared Sub WriteLogNoTimeStamp(ByVal strTextToWrite As String)
        '*************************************************************************
        '* Function Name:   WriteLog
        '* Description:     This function writes a given text to the application
        '*                  log file
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        ' Added by Haniel Shiffer in 01/02/2009
        ' Locking critical section
        SyncLock objLoker

            'Set the file name date time string
            Dim strFileNameDateTimeString As String = Now.ToString(strLogFileNameDateFormat.Replace("ww", DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.System, FirstWeekOfYear.System).ToString.PadLeft(2, "0")))

            'Open the file for write
            Dim strFileToOpen As String = strLogFilePath + strLogFileName + "_" + strFileNameDateTimeString + "." & strLogFileExtension

            'Try to open the file for write
            Try
                Dim writer As StreamWriter = New StreamWriter(strFileToOpen, True)

                'Write the data to the text file
                writer.WriteLine(strTextToWrite)

                'Close the file
                writer.Close()
            Catch ex As Exception
                WriteToWindowsEventViewerLog(ex.Message + vbCrLf + "The error occured while trying to write the message:" + vbCrLf + _
                                 strTextToWrite + vbCrLf + "To the file " + strFileToOpen, EventLogEntryType.Error)
            End Try

        End SyncLock

    End Sub

    Public Shared Sub WriteToWindowsEventViewerLog(ByVal strTextToWrite As String, ByVal enuEntryType As EventLogEntryType, _
                                                   Optional strLogName As String = "Application")
        '*************************************************************************
        '* Function Name:   WriteToWindowsEventViewerLog
        '* Description:     This sub logs the given text to the windows event 
        '*                  viewer
        '* Created by:      Raz Davidovich
        '* Created date:    14/02/2010
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        If Not EventLog.SourceExists("Assembly.Software.Utilities") Then
            ' Create the source, if it does not already exist.
            ' An event log source should not be created and immediately used.
            ' There is a latency time to enable the source, it should be created
            ' prior to executing the application that uses the source.
            ' Execute this sample a second time to use the new source.
            EventLog.CreateEventSource("Assembly.Software.Utilities", strLogName)

            Return
        End If

        'Write the exception data to the event viewer
        Dim elLog As New EventLog(strLogName, Environment.MachineName, "Assembly.Software.Utilities")
        elLog.WriteEntry(strTextToWrite, enuEntryType)
        elLog.Dispose()

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

    Public Shared Property LogFileNameDateFormat() As String
        Get
            Return strLogFileNameDateFormat
        End Get
        Set(ByVal value As String)
            strLogFileNameDateFormat = value
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

    Public Shared ReadOnly Property LogFileFullPath() As String
        Get
            'Set the file name date time string
            Dim strFileNameDateTimeString As String = Now.ToString(strLogFileNameDateFormat.Replace("ww", DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.System, FirstWeekOfYear.System).ToString.PadLeft(2, "0")))

            Return strLogFilePath + strLogFileName + "_" + strFileNameDateTimeString + "." + strLogFileExtension
        End Get
    End Property

#End Region

End Class
