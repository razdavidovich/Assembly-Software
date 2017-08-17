Public Class clsExcelExport
    '*************************************************************************
    '* This class allows to export a dataset & datatable to an excel workbook
    '* the file created by this class will only be recognized by Excel 2000
    '* and above since the underlying data in this file is XML
    '*************************************************************************

#Region "Class Declarations"

#End Region

#Region "Class Overloads Constructors"

#End Region

#Region "Class Private Functions"

#End Region

#Region "Class Properties"

#End Region

#Region "Class Methods"

    Public Shared Sub ExportDataTableToExcel(ByVal dtlDataTable As DataTable, ByVal strFileName As String _
        , Optional ByVal strTableName As String = Nothing)
        '*************************************************************************
        '* Function Name:   ExportDataTableToExcel
        '* Description:     This function exports a given data tables 
        '*                  into an excel worksbook. 
        '* Created by:      Raz Davidovich
        '* Created date:    23/12/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim dtsDataset As New DataSet

        'Add the datatable to the new dataset object
        dtsDataset.Tables.Add(dtlDataTable)

        'Set the table name (if supplied by the user)
        If Not (strTableName Is Nothing) Then
            dtsDataset.Tables(0).TableName = strTableName
        End If

        'Export the table to excel
        ExportDatasetToExcel(dtsDataset, strFileName)

        'Clear the temporary dataset object
        dtsDataset.Dispose()

    End Sub

    Public Shared Sub ExportDataTableToExcel(ByVal dtsDataset As DataSet, ByVal strTableName As String, _
        ByVal strFileName As String)
        '*************************************************************************
        '* Function Name:   ExportDataTableToExcel
        '* Description:     This function exports a given data tables 
        '*                  into an excel worksbook. 
        '* Created by:      Raz Davidovich
        '* Created date:    23/12/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim dtlTemp As New DataTable

        'Remove all other data tables from the source dataset
        For Each dtlTemp In dtsDataset.Tables
            If dtlTemp.TableName <> strTableName Then dtsDataset.Tables.Remove(strTableName)
        Next

        'Export the table to excel, if table exists
        If dtsDataset.Tables.Count > 0 Then
            ExportDatasetToExcel(dtsDataset, strFileName)
        Else
            Throw New DataException("The table name deos not reside in the given dataset")
        End If

        'Clear the temporary datatable object
        dtlTemp.Dispose()

    End Sub

    Public Shared Sub ExportDataTableToExcel(ByVal dtsDataset As DataSet, ByVal intTableIndex As Integer, _
        ByVal strFileName As String)
        '*************************************************************************
        '* Function Name:   ExportDataTableToExcel
        '* Description:     This function exports a given data tables 
        '*                  into an excel worksbook. 
        '* Created by:      Raz Davidovich
        '* Created date:    23/12/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim dtsTemp As New DataSet

        'Check for a valid table index
        If intTableIndex < dtsDataset.Tables.Count Then
            'Get the table into the new dataset
            dtsTemp.Tables.Add(dtsDataset.Tables(intTableIndex))

            'Export the table to excel
            ExportDatasetToExcel(dtsTemp, strFileName)
        Else
            Throw New DataException("Invalid tabel index, the given dataset contains only " + dtsDataset.Tables.Count.ToString + " tables")
        End If

        'Clear the temporary datatable object
        dtsTemp.Dispose()

    End Sub

    Public Shared Sub ExportDatasetToExcel(ByVal source As DataSet, ByVal fileName As String)
        '*************************************************************************
        '* Function Name:   ExportDatasetToExcel
        '* Description:     This function exports all tables in a given dataset
        '*                  into an excel worksbook. each table is exported into
        '*                  into seperate worksheet that is named after the table
        '*                  name in the dataset.
        '* Created by:      Raz Davidovich
        '* Created date:    23/12/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        Dim excelDoc As System.IO.StreamWriter

        'Try to open the stream writer for the file
        Try
            excelDoc = New System.IO.StreamWriter(fileName)
        Catch ex As Exception
            'Display the error message and exit
            Throw ex
        End Try

        Const startExcelXML = "<?xml version=""1.0"" ?>" + vbCrLf + _
            "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""" + vbCrLf + _
            "xmlns:o=""urn:schemas-microsoft-com:office:office""" + vbCrLf + _
            "xmlns:x=""urn:schemas-microsoft-com:office:excel""" + vbCrLf + _
            "xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">" + vbCrLf + _
            "<Styles>" + vbCrLf + _
            "<Style ss:ID=""Default"" ss:Name=""Normal"">" + vbCrLf + _
            "<Alignment ss:Vertical=""Bottom""/>" + vbCrLf + _
            "<Borders/>" + vbCrLf + _
            "<Font/>" + vbCrLf + _
            "<Interior/>" + vbCrLf + _
            "<NumberFormat/>" + vbCrLf + _
            "<Protection/>" + vbCrLf + _
            "</Style>" + vbCrLf + _
            "<Style ss:ID=""BoldColumn"">" + vbCrLf + _
            "<Font x:Family=""Swiss"" ss:Bold=""1""/>" + vbCrLf + _
            "</Style>" + vbCrLf + _
            "<Style ss:ID=""StringLiteral"">" + vbCrLf + _
            "<NumberFormat ss:Format=""@""/>" + vbCrLf + _
            "</Style>" + vbCrLf + _
            "<Style ss:ID=""Decimal"">" + vbCrLf + _
            "<NumberFormat ss:Format=""0.0000""/>" + vbCrLf + _
            "</Style>" + vbCrLf + _
            "<Style ss:ID=""Integer"">" + vbCrLf + _
            "<NumberFormat ss:Format=""0""/>" + vbCrLf + _
            "</Style>" + vbCrLf + _
            "<Style ss:ID=""DateLiteral"">" + vbCrLf + _
            "<NumberFormat ss:Format=""mm/dd/yyyy;@""/>" + vbCrLf + _
            "</Style>" + vbCrLf + _
            "</Styles>" + vbCrLf

        Const endExcelXML = "</Workbook>" + vbCrLf

        Dim rowCount As Integer = 0
        Dim sheetCount As Integer = 1

        'Write the excel header
        excelDoc.Write(startExcelXML)

        '==================================================================
        'Loop through the tables in the dataset and generate the worksheets
        '==================================================================
        For Each dtl As DataTable In source.Tables
            'Generate a new worksheet
            excelDoc.Write("<Worksheet ss:Name=""" + dtl.TableName + """>" + vbCrLf)
            excelDoc.Write("<Table>" + vbCrLf)

            '=============================
            'Generate the worksheet header
            '=============================
            excelDoc.Write("<Row>" + vbCrLf)

            'Loop through the columns header
            For x As Integer = 0 To dtl.Columns.Count - 1
                excelDoc.Write("<Cell ss:StyleID=""BoldColumn""><Data ss:Type=""String"">")
                excelDoc.Write(dtl.Columns(x).ColumnName)
                excelDoc.Write("</Data></Cell>" + vbCrLf)
            Next

            excelDoc.Write("</Row>" + vbCrLf)

            '=======================================================================
            'Loop through the the rows in the table and save them into the worksheet
            '=======================================================================
            For Each x As DataRow In dtl.Rows

                rowCount += 1
                'if the number of rows is > 64000 create a new page to continue output
                If rowCount = 64000 Then

                    rowCount = 0
                    sheetCount += 1
                    excelDoc.Write("</Table>" + vbCrLf)
                    excelDoc.Write(" </Worksheet>" + vbCrLf)
                    excelDoc.Write("<Worksheet ss:Name=""Sheet""" + sheetCount + """>" + vbCrLf)
                    excelDoc.Write("<Table>" + vbCrLf)
                End If

                excelDoc.Write("<Row>" + vbCrLf) 'ID=" + rowCount + "
                For y As Integer = 0 To dtl.Columns.Count - 1

                    Dim rowType As System.Type
                    rowType = x(y).GetType()
                    Select Case (rowType.ToString())

                        Case "System.String"
                            Dim XMLstring As String = x(y).ToString()
                            XMLstring = XMLstring.Trim()
                            XMLstring = XMLstring.Replace("&", "&amp;")
                            XMLstring = XMLstring.Replace(">", "&gt;")
                            XMLstring = XMLstring.Replace("<", "&lt;")
                            excelDoc.Write("<Cell ss:StyleID=""StringLiteral"">" + _
                                        "<Data ss:Type=""String"">")
                            excelDoc.Write(XMLstring)
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.DateTime"
                            'Excel has a specific Date Format of YYYY-MM-DD followed by  
                            'the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            'The Following Code puts the date stored in XMLDate 
                            'to the format above
                            Dim XMLDate As DateTime = CType(x(y), DateTime)
                            Dim XMLDatetoString As String = "" 'Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() + _
                                "-" + _
                                (IIf(XMLDate.Month < 10, "0" + _
                                XMLDate.Month.ToString(), XMLDate.Month.ToString()) + _
                                "-" + _
                                IIf(XMLDate.Day < 10, "0" + _
                                XMLDate.Day.ToString(), XMLDate.Day.ToString()) + _
                                "T" + _
                                IIf(XMLDate.Hour < 10, "0" + _
                                XMLDate.Hour.ToString(), XMLDate.Hour.ToString()) + _
                                ":" + _
                                IIf(XMLDate.Minute < 10, "0" + _
                                XMLDate.Minute.ToString(), XMLDate.Minute.ToString()) + _
                                ":" + _
                                IIf(XMLDate.Second < 10, "0" + _
                                XMLDate.Second.ToString(), XMLDate.Second.ToString()) + _
                                ".000")
                            excelDoc.Write("<Cell ss:StyleID=""DateLiteral"">" + _
                                "<Data ss:Type=""DateTime"">")
                            excelDoc.Write(XMLDatetoString)
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.Boolean"
                            excelDoc.Write("<Cell ss:StyleID=""StringLiteral"">" + _
                                        "<Data ss:Type=""String"">")
                            excelDoc.Write(x(y).ToString())
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.Byte[]"
                            excelDoc.Write("<Cell ss:StyleID=""StringLiteral"">" + _
                            "<Data ss:Type=""String"">")
                            excelDoc.Write("")
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.Int16", "System.Int32", "System.Int64", "System.Byte"
                            excelDoc.Write("<Cell ss:StyleID=""Integer"">" + _
                                    "<Data ss:Type=""Number"">")
                            excelDoc.Write(x(y).ToString())
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.Decimal", "System.Double"
                            excelDoc.Write("<Cell ss:StyleID=""Decimal"">" + _
                                "<Data ss:Type=""Number"">")
                            excelDoc.Write(x(y).ToString())
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.Single", "System.Double"
                            excelDoc.Write("<Cell ss:StyleID=""Decimal"">" + _
                                "<Data ss:Type=""Number"">")
                            excelDoc.Write(x(y).ToString())
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case "System.DBNull"
                            excelDoc.Write("<Cell ss:StyleID=""StringLiteral"">" + _
                            "<Data ss:Type=""String"">")
                            excelDoc.Write("")
                            excelDoc.Write("</Data></Cell>" + vbCrLf)

                        Case Else
                            Throw (New Exception(rowType.ToString() + " not handled."))
                    End Select
                Next
                excelDoc.Write("</Row>" + vbCrLf)
            Next

            excelDoc.Write("</Table>" + vbCrLf)
            excelDoc.Write(" </Worksheet>" + vbCrLf)
        Next
        excelDoc.Write(endExcelXML)
        excelDoc.Close()

    End Sub

#End Region


End Class
