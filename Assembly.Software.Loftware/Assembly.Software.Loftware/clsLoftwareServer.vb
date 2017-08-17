Imports Loftware.LLMControl
Imports System.Collections.Generic

Public Class clsLoftwareServer

    Public Enum ServerStatusType
        OK
        Invalid
    End Enum

    Public ReadOnly Property ServerStatus(ByVal strLoftwareServerIpAddress As String, ByVal intLoftwareServerPort As Integer) As ServerStatusType
        '****************************************************************************************
        '* NAME:		ServerStatus                                                                  
        '* DESCRIPTION: This read only property connects and checks the server status
        '* WRITEN BY:	Raz Davidovich
        '* Revisions:	02/07/2012		Property created
        '****************************************************************************************
        Get

            Dim objLoftwareClient As LoftClient = Nothing
            Try

                objLoftwareClient = Connect(strLoftwareServerIpAddress, intLoftwareServerPort)

                Return ServerStatusType.OK

            Catch ex As Exception

                Return ServerStatusType.Invalid

            Finally

                Cleanup(objLoftwareClient)

            End Try

        End Get
    End Property

    Public Function GetLabelsList(ByVal strLoftwareServerIpAddress As String, ByVal intLoftwareServerPort As Integer, ByVal strFolderLocation As String) As List(Of String)
        '****************************************************************************************
        '* NAME:		GetLabelsList                                                                  
        '* DESCRIPTION: This function will return the complete labels list for a given Loftware Print 
        '*                      Server and a given location
        '* WRITEN BY:	Raz Davidovich
        '* Revisions:	02/07/2012		Function created
        '****************************************************************************************
        Dim objLoftwareClient As LoftClient = Nothing
        Dim objLabelList As String() = Nothing

        Try
            objLoftwareClient = Connect(strLoftwareServerIpAddress, intLoftwareServerPort)

            If objLoftwareClient.GetLabelListExt(strFolderLocation, objLabelList) Then

                Return New List(Of String)(objLabelList)
            Else
                Throw New Exception("Failed to read the label list")
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cleanup(objLoftwareClient)
        End Try

    End Function

    Public Function GetLabelFields(ByVal strLoftwareServerIpAddress As String, ByVal intLoftwareServerPort As Integer, ByVal strFolderName As String, ByVal strLabelName As String) As Dictionary(Of String, Integer)
        '****************************************************************************************
        '* NAME:		GetLabelFields                                                                  
        '* DESCRIPTION: This function will return a given label fields for a given Loftware print server
        '* WRITEN BY:	Raz Davidovich
        '* Revisions:	02/07/2012		Function created
        '****************************************************************************************

        Try
            'Connect to the given loftware print server
            Dim objLoftwareClient As LoftClient = Connect(strLoftwareServerIpAddress, intLoftwareServerPort)
            Dim strRelativeLabelPath As String = strFolderName + IIf(strFolderName.EndsWith("\"), String.Empty, "\") + strLabelName
            Dim dicFieldList As New Dictionary(Of String, Integer)

            'Set the given label as the current label
            If objLoftwareClient.GetLabel(strRelativeLabelPath) Then
                'Loop the current label fields and build the field list
                For i As Integer = 0 To objLoftwareClient.FieldCount - 1
                    'Add the current field to the list
                    dicFieldList.Add(objLoftwareClient.GetFieldName(i), objLoftwareClient.GetFieldMaxLength(i))
                Next

                'Return the dictionary
                Return dicFieldList
            Else
                Throw New Exception("Failed to get the field list for the label in the given path " + strRelativeLabelPath)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function Connect(ByVal strLoftwareServerIpAddress As String, ByVal intLoftwareServerPort As Integer) As LoftClient
        '****************************************************************************************
        '* NAME:		Connect                                                                  
        '* DESCRIPTION: This function attempts to connect to a given loftwrae print server
        '* WRITEN BY:	Raz Davidovich
        '* Revisions:	02/07/2012		Function Creted
        '****************************************************************************************
        Dim objLoftwareClient As LoftClient = Nothing

        Try

            objLoftwareClient = New LoftClient
            If objLoftwareClient.Login(strLoftwareServerIpAddress, intLoftwareServerPort) Then

                Return objLoftwareClient
            Else
                Throw New Exception("Failed to connect to loftware server. IP Address: " + strLoftwareServerIpAddress + ". Port: " + intLoftwareServerPort.ToString())
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub Cleanup(ByRef objLoftwareClient As LoftClient)
        '****************************************************************************************
        '* NAME:		Cleanup                                                                  
        '* DESCRIPTION: Logoff from the Loftware Print Server and dispose any unused objects
        '* WRITEN BY:	Raz Davidovich
        '* Revisions:	02/07/2012		Function created
        '****************************************************************************************
        If objLoftwareClient IsNot Nothing Then
            If objLoftwareClient.LoggedIn Then
                objLoftwareClient.Logout()
            End If

            objLoftwareClient.Dispose()
            objLoftwareClient = Nothing

        End If

    End Sub

    Public Function GetPrintersList(ByVal strLoftwareServerIpAddress As String, ByVal intLoftwareServerPort As Integer) As List(Of clsPrinter)
        '****************************************************************************************
        '* NAME:		GetPrintersList                                                                  
        '* DESCRIPTION: This function will return the printers list from a given Loftware Print Server
        '* WRITEN BY:	Raz Davidovich
        '* Revisions:	02/07/2012		Function created
        '****************************************************************************************

        Try
            'Connect to the given loftware print server
            Dim objLoftwareClient As LoftClient = Connect(strLoftwareServerIpAddress, intLoftwareServerPort)
            Dim clsLPSPrinters As New List(Of clsPrinter)
            Dim arrPrinterNumbers() As Integer = Nothing

            'Set the given label as the current label
            If objLoftwareClient.GetPrinters(arrPrinterNumbers) Then
                Dim strPrinter As String = String.Empty
                Dim strAlias As String = String.Empty
                Dim strPort As String = String.Empty

                'Loop the current label fields and build the field list
                For i As Integer = 0 To arrPrinterNumbers.Length - 1
                    'Add the current field to the list
                    objLoftwareClient.GetPrinterByNumber(arrPrinterNumbers(i), strPrinter, strAlias, strPort)

                    'Add the printer to the list
                    clsLPSPrinters.Add(New clsPrinter(arrPrinterNumbers(i), strPrinter, strAlias, strPort))
                Next

                'Return the dictionary
                Return clsLPSPrinters
            Else
                Throw New Exception("Failed to get printer list for LPS  " + strLoftwareServerIpAddress + " using port number " + intLoftwareServerPort.ToString())
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class