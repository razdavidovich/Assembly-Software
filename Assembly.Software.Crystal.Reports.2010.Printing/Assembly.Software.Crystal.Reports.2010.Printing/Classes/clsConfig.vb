''' <summary>
''' A class for reading the settings from the app.config file
''' </summary>
''' <remarks></remarks>
Public Class clsConfig

#Region "Class Constructor"

    Shared Sub New()

    End Sub

#End Region

#Region "Class Methos"

    Public Shared Sub SaveConfigValue(ByVal ItemName As String, ByVal ConfigSection As String, ByVal ConfigGroup As String, ByVal strValue As String)
        'Create the profile manager object
        Dim cfg As [Assembly].Software.Profile.Config = New [Assembly].Software.Profile.Config

        'Set the configuration group
        cfg.GroupName = ConfigGroup

        'Read the value from the configuration
        cfg.SetValue(ConfigSection, ItemName, strValue)

    End Sub

#End Region

#Region "Class Properties"

    Public Shared ReadOnly Property ReadConfigValue(ByVal ItemName As String, ByVal ConfigSection As String, ByVal ConfigGroup As String, Optional ByVal strConfigFile As String = "") As String
        Get
            Dim cfg As [Assembly].Software.Profile.Config
            If strConfigFile = String.Empty Then

                'Create the profile manager object
                cfg = New [Assembly].Software.Profile.Config()
            Else
                cfg = New [Assembly].Software.Profile.Config(strConfigFile)
            End If

            'Set the configuration group
            cfg.GroupName = ConfigGroup

            'Read the value from the configuration
            Return cfg.GetValue(ConfigSection, ItemName)
        End Get
    End Property

#End Region

End Class
