Imports [Assembly].Software.Profile

'*******************************************************************
'*
'* A class for reading the settings from the app.config file
'*
'*******************************************************************

Public Class Config

#Region "Class Properties"

    Public Shared ReadOnly Property ReadConfigValue(ByVal ItemName As String, ByVal ConfigSection As String, ByVal ConfigGroup As String) As String
        Get
            'Create the profile manager object
            Dim cfg As [Assembly].Software.Profile.Config = New [Assembly].Software.Profile.Config

            'Set the configuration group
            cfg.GroupName = ConfigGroup

            'Read the value from the configuration
            Return cfg.GetValue(ConfigSection, ItemName)
        End Get
    End Property

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

End Class
