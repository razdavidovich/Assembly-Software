Imports [Assembly].Software.Profile
Imports Microsoft.Win32
Imports System.Collections.Specialized

'*******************************************************************
'*
'* A class for reading the settings from the app.config file
'*
'*******************************************************************

Public Class Config

#Region "Class Declarations"

    Public Enum enuRegistryRootItem
        HKEY_CLASES_ROOT
        HKEY_CURRENT_USER
        HKEY_LOCAL_MACHINE
        HKEY_USERS
        HKEY_CURRENT_CONFIG
    End Enum

#End Region

#Region "Class Properties"

    Public Shared ReadOnly Property ReadConfigValue(ByVal ItemName As String, ByVal ConfigSection As String, _
                        ByVal ConfigGroup As String, Optional ByVal blnWinConfig As Boolean = True) As String
        Get
            'Get the current running assembly
            Dim strRunningAssembly As String = System.Reflection.Assembly.GetExecutingAssembly().Location + ".config"

            'Create the profile manager object
            Dim cfg As [Assembly].Software.Profile.Config
            If blnWinConfig Then
                cfg = New [Assembly].Software.Profile.Config
            Else
                cfg = New [Assembly].Software.Profile.Config(strRunningAssembly)
            End If

            'Set the configuration group
            cfg.GroupName = ConfigGroup

            'Read the value from the configuration
            Return cfg.GetValue(ConfigSection, ItemName)
        End Get
    End Property

    Public Shared ReadOnly Property ReadASPConfigValue(ByVal ItemName As String, ByVal ConfigSection As String)
        Get
            Dim nvc As NameValueCollection
            Try
                nvc = System.Configuration.ConfigurationManager.GetSection(ConfigSection)
                Return nvc(ItemName)
            Catch ex As Exception
                Return Nothing
            End Try


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

    ''' <summary>
    ''' This function returns the registry value of a given key, based on the user specification
    ''' </summary>
    ''' <param name="enuRegistryRootKey">The users selections of the root registry key</param>
    ''' <param name="strRegistrySection">The users selection of the path to the registry key, for example: SOFTWARE\Microsoft\Windows\CurrentVersion</param>
    ''' <param name="strItemName">The users selections of the item that needs to be read, for example: CommonFilesDir</param>
    ''' <returns>The vaue of the item from the registry</returns>
    ''' <remarks>
    ''' Written By: Raz Davidovich
    ''' Write Date: 29/04/2008
    ''' </remarks>
    Public Shared Function ReadRegistryValue(ByVal enuRegistryRootKey As enuRegistryRootItem, ByVal strRegistrySection As String, ByVal strItemName As String) As String
        'Crete the registry key
        Dim regKey As Microsoft.Win32.RegistryKey

        'Try to open the selected root key
        Try
            Select Case enuRegistryRootKey
                Case enuRegistryRootItem.HKEY_CLASES_ROOT
                    regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_CURRENT_CONFIG
                    regKey = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_CURRENT_USER
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_LOCAL_MACHINE
                    regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_USERS
                    regKey = Microsoft.Win32.Registry.Users.OpenSubKey(strRegistrySection, True)

                Case Else
                    regKey = Nothing
            End Select

            'Try to read the value from the requested item
            If regKey Is Nothing Then
                Return vbNullString
            Else
                Return regKey.GetValue(strItemName).ToString()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="enuRegistryRootKey">The users selections of the root registry key</param>
    ''' <param name="strRegistrySection">The users selection of the path to the registry key, for example: SOFTWARE\Microsoft\Windows\CurrentVersion</param>
    ''' <param name="strItemName">The users selections of the item that needs to be read, for example: CommonFilesDir</param>
    ''' <param name="strValueToWrite">The value to write to the registry item</param>
    ''' <remarks>
    ''' Written By: Raz Davidovich
    ''' Write Date: 29/04/2008
    ''' </remarks>
    Public Shared Sub WriteRegistryValue(ByVal enuRegistryRootKey As enuRegistryRootItem, ByVal strRegistrySection As String, _
                    ByVal strItemName As String, ByVal strValueToWrite As String)

        'Crete the registry key
        Dim regKey As Microsoft.Win32.RegistryKey

        'Try to open the selected root key
        Try
            Select Case enuRegistryRootKey
                Case enuRegistryRootItem.HKEY_CLASES_ROOT
                    regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_CURRENT_CONFIG
                    regKey = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_CURRENT_USER
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_LOCAL_MACHINE
                    regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strRegistrySection, True)

                Case enuRegistryRootItem.HKEY_USERS
                    regKey = Microsoft.Win32.Registry.Users.OpenSubKey(strRegistrySection, True)

                Case Else
                    regKey = Nothing
            End Select

            'Try to read the value from the requested item
            If regKey Is Nothing Then
                Throw New ArgumentNullException("Could not locate the registry key")
            Else
                regKey.SetValue(strItemName, strValueToWrite)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class
