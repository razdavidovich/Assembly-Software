Imports Loftware.LLMControl

Public Class clsPrintLabel
  
    Public Function PrintLabel(ByVal strLoftwareServerIPAddress As String, _
                                        ByVal intLoftwareServerPort As Integer, _
                                        ByVal intPrinterID As Integer, _
                                        ByVal strLabelName As String, _
                                        ByVal intSerializedLabels As Integer, _
                                        ByVal intNumberOfCopies As Integer, _
                                        ByVal htlParams As Hashtable, _
                                        Optional ByRef lngErrorNumber As Long = 0, _
                                        Optional ByRef strErrorDescription As String = vbNullString) As List(Of clsRowPrintStatus)

        '****************************************************************************
        '* NAME:            PrintLabelFromDataTable                                 *
        '* DESCRIPTION:     Print Label From Given Data Table                       *
        '*                                                                          *
        '* WRITTEN BY:      Raz Davidovich                                          *
        '* DATE:            29/04/2010                                              *
        '* UPDATED BY:      Raz Davidovich                                          *
        '* UPDATE DATE:     29/04/2010                                              *
        '****************************************************************************

        'Generate a datatable from the given hashtable
        Dim dtlDatatable As DataTable = GenerateDatatableFromHashtable(htlParams)

        'Call the overloading function
        Return PrintLabel(strLoftwareServerIPAddress, intLoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, _
                dtlDatatable, lngErrorNumber, strErrorDescription)

    End Function

    Public Function PrintLabel(ByVal strLoftwareServerIPAddress As String, _
                                            ByVal intLoftwareServerPort As Integer, _
                                            ByVal intPrinterID As Integer, _
                                            ByVal strLabelName As String, _
                                            ByVal intSerializedLabels As Integer, _
                                            ByVal intNumberOfCopies As Integer, _
                                            ByVal dtlParams As DataTable, _
                                            Optional ByRef lngErrorNumber As Long = 0, _
                                            Optional ByRef strErrorDescription As String = vbNullString) As List(Of clsRowPrintStatus)
        '****************************************************************************
        '* NAME:            PrintLabelFromDataTable                                 *
        '* DESCRIPTION:     Print Label From Given Data Table                       *
        '*                                                                          *
        '* WRITTEN BY:      Raz Davidovich                                          *
        '* DATE:            29/04/2010                                              *
        '* UPDATED BY:      Raz Davidovich                                          *
        '* UPDATE DATE:     29/04/2010                                              *
        '****************************************************************************

        Dim LlmClient As New LoftClient()
        Dim clsListOfPrintStatuses As New List(Of clsRowPrintStatus)

        'Check if the client is already login
        If LlmClient.LoggedIn() Then
            LlmClient.Logout()
        End If

        Try
            ' Exits Sub If There Is no Rows To Print
            If (dtlParams.Rows.Count > 0) Then

                'Login to the LPS
                LlmClient.Login(strLoftwareServerIPAddress, intLoftwareServerPort)

                'Load the label
                LlmClient.GetLabel(strLabelName)

                'Set the printer to print to
                LlmClient.PrinterNumber = intPrinterID

                'Declare the job status object
                Dim llmPrintJobResponse As PrintJobResponse = Nothing

                'Loop and print every row in the datatable
                For Each row As DataRow In dtlParams.Rows
                    Dim clsPrintStatus As clsRowPrintStatus = PrintLabelFromDataRow(LlmClient, intSerializedLabels, intNumberOfCopies, row, lngErrorNumber, strErrorDescription, llmPrintJobResponse)
                    clsListOfPrintStatuses.Add(clsPrintStatus)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("Exception at: " + System.Reflection.MethodBase.GetCurrentMethod.Name + " Please check the inner exception or details", ex)

        Finally
            LlmClient.Logout()
            LlmClient = Nothing
        End Try

        'Return the list of print statuses
        Return clsListOfPrintStatuses

    End Function

    Public Function PrintLabel(ByVal strLoftwareServerIPAddress As String, _
                                      ByVal intLoftwareServerPort As Integer, _
                                      ByVal intPrinterID As Integer, _
                                      ByVal strLabelName As String, _
                                      ByVal intSerializedLabels As Integer, _
                                      ByVal intNumberOfCopies As Integer, _
                                      ByVal dictParams As Dictionary(Of String, String), _
                                      Optional ByRef lngErrorNumber As Long = 0, _
                                      Optional ByRef strErrorDescription As String = vbNullString) As List(Of clsRowPrintStatus)
        '****************************************************************************
        '* NAME:            PrintLabelFromDictionary                                *
        '* DESCRIPTION:     Print Label From Given Dictionary                       *
        '* WRITTEN BY:      Sivachandran                                            *
        '* DATE:            16/06/2014                                              *
        '****************************************************************************

        'Generate a datatable from the given Dictionary
        Dim dtlDatatable As DataTable = GenerateDatatableFromDictionary(dictParams)

        'Call the overloading function
        Return PrintLabel(strLoftwareServerIPAddress, intLoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, _
                dtlDatatable, lngErrorNumber, strErrorDescription)

    End Function

    Private Function PrintLabelFromDataRow(ByVal LlmClient As LoftClient, _
                                    ByVal intSerializedLabels As Integer, _
                                    ByVal intNumberOfCopies As Integer, _
                                    ByVal drParams As DataRow, _
                                    ByRef lngErrorNumber As Long, _
                                    ByRef strErrorDescription As String, _
                                    Optional ByRef llmPrintJobResponse As PrintJobResponse = Nothing) As clsRowPrintStatus
        '****************************************************************************
        '* NAME:            PrintLabel                                              *
        '* DESCRIPTION:     Printing a single label using LPS based on a single     *
        '*                  data row                                                *
        '*                                                                          *
        '* WRITTEN BY:      Raz Davidovich                                          *
        '* DATE:            01/05/2010                                              *
        '****************************************************************************
        Dim strValue As String = String.Empty

        Try
            'Loop the datarow and set the label parameters
            For intCount As Integer = 0 To drParams.Table.Columns.Count - 1
                Try
                    LlmClient.SetData(drParams.Table.Columns(intCount).Caption, drParams(intCount).ToString)
                Catch ex As Exception

                End Try
            Next

            LlmClient.Duplicates = intNumberOfCopies
            LlmClient.Quantity = intSerializedLabels

            'Set the job name
            LlmClient.JobName = "Job_" + Now.ToString("dd-MM-yyyy_HH-mm-ss")

            'Print out the Label
            LlmClient.PrintJob(llmPrintJobResponse)

            'Build and return the row print status
            Dim clsPrintStatus As New clsRowPrintStatus(llmPrintJobResponse.StatusCode, llmPrintJobResponse.XmlData, drParams.ItemArray)

            'Return the job status
            Return clsPrintStatus

        Catch ex As Exception
            Throw New Exception("Exception at: " + System.Reflection.MethodBase.GetCurrentMethod.Name + " Please check the inner exception or details", ex)

        End Try

    End Function

    Private Function GenerateDatatableFromHashtable(ByVal htlSourceHashtable As Hashtable) As DataTable
        '****************************************************************************
        '* NAME:            GenerateDatatableFromHashtable                          *
        '* DESCRIPTION:     Generating a datatable from a given hashtable           *
        '*                                                                          *
        '* WRITTEN BY:      Raz Davidovich                                          *
        '* DATE:            01/05/2010                                              *
        '****************************************************************************

        Dim dtlDatatable As New DataTable

        'Loop and add the columns based on the keys in the hashtable
        For Each objKey As Object In htlSourceHashtable.Keys
            ' Create columns
            dtlDatatable.Columns.Add(objKey.ToString, Type.GetType("System.String"))
        Next

        'Declare row
        Dim dtrRow As DataRow

        'Create new row
        dtrRow = dtlDatatable.NewRow

        'Loop and add the values to the datarow based on the keys in the hashtable
        For Each objKey As Object In htlSourceHashtable.Keys
            'Set column value
            dtrRow(objKey.ToString) = htlSourceHashtable.Item(objKey)
        Next

        'Add the row to the datatable
        dtlDatatable.Rows.Add(dtrRow)

        Return dtlDatatable
    End Function

    Private Function GenerateDatatableFromDictionary(ByVal dictSourceDictionary As Dictionary(Of String, String)) As DataTable
        '****************************************************************************
        '* NAME:            GenerateDatatableFromHashtable                          *
        '* DESCRIPTION:     Generating a datatable from a given dictionary          *
        '* WRITTEN BY:      Sivachandran                                            *
        '* DATE:            16/06/2014                                              *
        '****************************************************************************

        Dim dtlDatatable As New DataTable

        'Loop and add the columns based on the keys in the hashtable
        For Each objKey As Object In dictSourceDictionary.Keys
            ' Create columns
            dtlDatatable.Columns.Add(objKey.ToString, Type.GetType("System.String"))
        Next

        'Declare row
        Dim dtrRow As DataRow

        'Create new row
        dtrRow = dtlDatatable.NewRow

        'Loop and add the values to the datarow based on the keys in the hashtable
        For Each objKey As Object In dictSourceDictionary.Keys
            'Set column value
            dtrRow(objKey.ToString) = dictSourceDictionary.Item(objKey)
        Next

        'Add the row to the datatable
        dtlDatatable.Rows.Add(dtrRow)

        Return dtlDatatable
    End Function

End Class