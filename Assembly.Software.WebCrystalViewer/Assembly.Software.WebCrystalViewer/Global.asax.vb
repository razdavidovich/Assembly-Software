Imports System.Web.SessionState
Imports Assembly.Software.Utilities

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Private ReadOnly Property LogFileName() As String
        Get
            Dim strConn As String = String.Empty
            Dim sb As StringBuilder

            Try
                sb = New StringBuilder()
                sb.Append(Config.ReadASPConfigValue("LogFileName", "appSettings").ToString())
                strConn = sb.ToString()
            Catch ex As Exception
                '  Loger.writeToLog(System.Reflection.MethodBase.GetCurrentMethod.Name, "Error Description", ex.Message)
            Finally
                sb = Nothing
            End Try
            Return strConn
        End Get
    End Property

    Private ReadOnly Property LogFilePath() As String
        Get
            Dim strConn As String = String.Empty
            Dim sb As StringBuilder

            Try
                sb = New StringBuilder()
                sb.Append(Config.ReadASPConfigValue("LogFilePath", "appSettings").ToString())
                strConn = sb.ToString()
            Catch ex As Exception
                '  Loger.writeToLog(System.Reflection.MethodBase.GetCurrentMethod.Name, "Error Description", ex.Message)
            Finally
                sb = Nothing
            End Try
            Return strConn
        End Get
    End Property

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        clsApplicationLogFile.LogFileName = LogFileName()
        clsApplicationLogFile.LogFilePath = LogFilePath()
        clsApplicationLogFile.WriteLog("Application Start")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class