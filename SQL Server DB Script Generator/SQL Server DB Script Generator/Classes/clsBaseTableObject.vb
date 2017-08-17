
'**************************************************************************
'*
'* A class for Base Table script object, inherits clsBaseTableObject
'*
'**************************************************************************

Public Class clsBaseTableObject
    Inherits clsTableObject

#Region "Class declaration object"
    'Shared class delaration
    Private Shared intFileNameID As Integer

#End Region

#Region "Class constructors"
    Public Sub New(ByVal strObjectType As String, ByVal objSystemArgs As Object(,))
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Call the oveloaded constructor
        Me.New(strObjectType, "Base_Table_Name_" & intFileNameID.ToString & "_Ta", objSystemArgs)
        intFileNameID += 1

    End Sub

    Public Sub New(ByVal strObjectType As String, ByVal strObjectName As String, _
        ByVal objSystemArgs As Object(,))
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Call the oveloaded constructor
        Me.New(strObjectType, strObjectName, "dbo", objSystemArgs)

    End Sub

    Public Sub New(ByVal strObjectType As String, ByVal strObjectName As String, _
    ByVal strObjectOwner As String, ByVal objSystemArgs As Object(,))
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Call the oveloaded constructor
        Me.New(strObjectType, strObjectName, "dbo", True, True, objSystemArgs)

    End Sub

    Public Sub New(ByVal strObjectType As String, ByVal strObjectName As String, _
        ByVal strObjectOwner As String, ByVal blnGenerateHeader As Boolean, ByVal objSystemArgs As Object(,))
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Call the oveloaded constructor
        Me.New(strObjectType, strObjectName, strObjectOwner, blnGenerateHeader, True, objSystemArgs)

    End Sub

    Public Sub New(ByVal strObjectType As String, ByVal strObjectName As String, _
        ByVal strObjectOwner As String, ByVal blnGenerateHeader As Boolean, _
        ByVal blnGenerateDropCommand As Boolean, ByVal objSystemArgs As Object(,))
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Call the oveloaded constructor
        Me.New(strObjectType, strObjectName, strObjectOwner, blnGenerateHeader, blnGenerateDropCommand, True, objSystemArgs)

    End Sub

    Public Sub New(ByVal strObjectType As String, ByVal strObjectName As String, _
        ByVal strObjectOwner As String, ByVal blnGenerateHeader As Boolean, _
        ByVal blnGenerateDropCommand As Boolean, ByVal blnGenerateTableKeys As Boolean, _
        ByVal objSystemArgs As Object(,))
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    30/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        MyBase.New(strObjectType, strObjectName, strObjectOwner, blnGenerateHeader, blnGenerateDropCommand, blnGenerateTableKeys, objSystemArgs)

        Me.strSystemObjectType = "IsProcedure"
        Me.strObjectName = "BT_" + Replace(strObjectName, "_Ta", "_Sp", , , CompareMethod.Text)

    End Sub

#End Region

#Region "Class methods"

    Public Overrides Function GenerateObjectScript() As String
        '*************************************************************************
        '* Function Name:   GenerateObjectScript
        '* Description:     This class method generates the SQL Script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String = String.Empty

        'Generate the Object script header (if needed)
        If blnGenerateHeader Then
            strTemp += GenerateHeader()
        End If

        'Generate the Object drop script (if needed)
        If blnGenerateDropCommand Then
            strTemp += GenerateDrop()
        End If

        If objSystemArgs Is Nothing Then
            strTemp += "/*===================================================================*/"
            strTemp += vbCrLf
            strTemp += "/*=== NO TABLE FIELDS WERE DEFINED OR BAD TABLE FIELDS DEFINITION ===*/"
            strTemp += vbCrLf
            strTemp += "/*===================================================================*/"
        Else
            strTemp += "CREATE PROCEDURE [" + strObjectOwner + "].[" + strObjectName + "] "
            strTemp += vbCrLf
            strTemp += vbTab + "@Operation		INT," + vbCrLf
            'Generate the parameters
            strTemp += GenerateParameters()
            strTemp += vbCrLf + "AS" + vbCrLf

            'Generate the select part
            strTemp += vbTab + "IF (@Operation = 1)" + vbCrLf
            strTemp += vbTab + vbTab + "BEGIN" + vbCrLf
            strTemp += vbTab + vbTab + vbTab + GenerateSelect() + vbCrLf
            strTemp += vbTab + vbTab + "END" + vbCrLf

            'Generate the Insert/Update part
            strTemp += vbTab + "IF (@Operation = 2)" + vbCrLf
            strTemp += vbTab + vbTab + "BEGIN" + vbCrLf
            strTemp += vbTab + vbTab + vbTab + "IF EXISTS(" + GenerateSelect() + Space(1) + GenerateWhere() + ")" + vbCrLf
            'Update the existing row
            strTemp += vbTab + vbTab + vbTab + "BEGIN" + vbCrLf
            strTemp += GenerateUpdate(vbTab + vbTab + vbTab + vbTab) + vbCrLf
            strTemp += vbTab + vbTab + vbTab + "END" + vbCrLf
            strTemp += vbTab + vbTab + "ELSE" + vbCrLf
            'Insert a new row
            strTemp += vbTab + vbTab + vbTab + "BEGIN" + vbCrLf
            strTemp += GenerateInsert(vbTab + vbTab + vbTab + vbTab) + vbCrLf
            strTemp += vbTab + vbTab + vbTab + "END" + vbCrLf
            strTemp += vbTab + vbTab + "END" + vbCrLf

            'Generate the Delete part
            strTemp += vbTab + "IF(@Operation = 3)" + vbCrLf
            strTemp += vbTab + vbTab + "BEGIN" + vbCrLf
            strTemp += vbTab + vbTab + vbTab + GenerateDelete() + vbCrLf
            strTemp += vbTab + vbTab + vbTab + GenerateWhere() + vbCrLf
            strTemp += vbTab + vbTab + "END" + vbCrLf

            strTemp += "GO"
            strTemp += vbCrLf
            strTemp += vbCrLf

        End If

        'Return the complete script
        Return strTemp

    End Function

    Public Function GenerateConfigScript() As String
        '*************************************************************************
        '* Function Name:   GenerateConfigScript
        '* Description:     This function generates a complete templete for the
        '*                  base table config values (needs editing)
        '* Created by:      Raz Davidovich
        '* Created date:    10/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim sbrConfig As New System.Text.StringBuilder
        Dim clsAppAttribute As New clsApplicationAttributes


        With sbrConfig
            .AppendLine("<!-- The following table settings has been generated by " + clsAppAttribute.ApplicationTitle + " Version: " + clsAppAttribute.ApplicationVersion)
            .AppendLine("<add key=""Table_" + objSystemArgs(1, 0).ToString + "_Text"" value=""" + strTableName + """ />")
        End With

        Return sbrConfig.ToString

    End Function

#End Region

#Region "Class private functions"

    Private Function GenerateSelect() As String
        '*************************************************************************
        '* Function Name:   GenerateSelect
        '* Description:     This function generate a select statement for the 
        '*                  script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Generate the Select
        Return "SELECT * FROM " + strObjectOwner + "." + strTableName

    End Function

    Private Function GenerateInsert(Optional ByVal strTabShift As String = vbNullString) As String
        '*************************************************************************
        '* Function Name:   GenerateInsert
        '* Description:     This function generate a Insert statement for the 
        '*                  script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String
        Dim strTempFields As String
        Dim strTempParameters As String
        Dim blnDefaultValueUsed As Boolean

        strTempParameters = "("
        strTempFields = "("

        'Loop the fields collection and generate script
        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            'Generate field if it is not an identity field (Auto generated number)
            If (objSystemArgs(5, I).ToString <> "Y") Then

                'Reset the default values flag
                blnDefaultValueUsed = False

                'Start generate the SQL
                If (objSystemArgs(1, I).ToString.Trim = vbNullString) Then
                    strTempParameters += "@" + DEFAULT_FIELD_NAME + "_" + I.ToString + ""
                    strTempFields += DEFAULT_FIELD_NAME + "_" + I.ToString + ""
                    blnDefaultValueUsed = True
                Else
                    strTempParameters += GenerateParameter(objSystemArgs(1, I))
                    strTempFields += "[" + objSystemArgs(1, I) + "]"
                End If

                'Add comma if this is not the last field
                If I <> objSystemArgs.GetUpperBound(1) Then
                    strTempParameters += ", "
                    strTempFields += ", "
                End If

            End If
        Next

        strTempParameters += ")"
        strTempFields += ")"

        'Combine the Insert
        strTemp = strTabShift + "INSERT INTO " + strObjectOwner + "." + strTableName + vbCrLf
        strTemp += strTabShift + vbTab + strTempFields + vbCrLf
        strTemp += strTabShift + "VALUES" + vbCrLf
        strTemp += strTabShift + vbTab + strTempParameters + vbCrLf

        Return strTemp

    End Function

    Private Function GenerateUpdate(Optional ByVal strTabShift As String = vbNullString) As String
        '*************************************************************************
        '* Function Name:   GenerateUpdate
        '* Description:     This function generate a Update statement for the 
        '*                  script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String

        'Generate the opening update clause
        strTemp = strTabShift + "UPDATE " + strObjectOwner + "." + strTableName + " SET" + vbCrLf

        'Generate the field list update
        'Loop the fields collection and generate script
        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            'Generate field if it is not an identity field (Auto generated number)
            If (objSystemArgs(5, I).ToString <> "Y") Then
                'Start generate the SQL
                strTemp += strTabShift + vbTab + "[" + objSystemArgs(1, I) + "]" + " = " + GenerateParameter(objSystemArgs(1, I))

                'Add comma if this is not the last field
                If I <> objSystemArgs.GetUpperBound(1) Then strTemp += ", "
                strTemp += vbCrLf
            End If
        Next

        strTemp += strTabShift + GenerateWhere()

        Return strTemp

    End Function

    Private Function GenerateDelete() As String
        '*************************************************************************
        '* Function Name:   GenerateDelete
        '* Description:     This function generate a delete statement for the 
        '*                  script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Generate the Select
        Return "DELETE FROM " + strObjectOwner + "." + strTableName

    End Function

    Private Function GenerateWhere() As String
        '*************************************************************************
        '* Function Name:   GenerateWhere
        '* Description:     This function generate a where clause for the script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String
        Dim intKeyID As Integer = 1

        'Generate the Select
        strTemp = "WHERE "

        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            If (objSystemArgs(4, I).ToString.Trim = "Y") Then
                strTemp += "([" + objSystemArgs(1, I) + "] = " + "@Key" + intKeyID.ToString + ") AND "
                intKeyID += 1
            End If
        Next

        If strTemp.Trim.Length > 0 Then strTemp = strTemp.Remove(strTemp.Length - 5, 5)

        Return strTemp

    End Function

    Private Function GenerateParameters() As String
        '*************************************************************************
        '* Function Name:   GenerateParameters
        '* Description:     This function loops the fields collection and generate
        '*                  the list of SP parameters for the script
        '* Created by:      Raz Davidovich
        '* Created date:    23/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String = String.Empty
        Dim intKeyID As Integer = 1
        Dim blnDefaultValueUsed As Boolean

        '=====================================
        '= Step 1 - Generate fields parameters
        '=====================================
        'Loop the fields collection and generate script
        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            'Reset the default values flag
            blnDefaultValueUsed = False

            'Start generate the SQL
            If (objSystemArgs(1, I).ToString.Trim = vbNullString) Then
                objSystemArgs(1, I) = DEFAULT_FIELD_NAME + "_" + I.ToString
                strTemp += vbTab + "@" + DEFAULT_FIELD_NAME + "_" + I.ToString + vbTab + objSystemArgs(2, I)
                blnDefaultValueUsed = True
            Else
                strTemp += vbTab + GenerateParameter(objSystemArgs(1, I)) + vbTab + objSystemArgs(2, I)

            End If

            If (LCase(objSystemArgs(2, I)) = "varchar") Or (LCase(objSystemArgs(2, I)) = "nvarchar") Then
                strTemp += "("
                If (objSystemArgs(3, I).ToString = vbNullString) Or Not IsNumeric(objSystemArgs(3, I)) Then
                    strTemp += DEFAULT_VARCHAR_LENGTH.ToString
                    blnDefaultValueUsed = True
                Else
                    strTemp += objSystemArgs(3, I).ToString
                End If
                strTemp += ")"
            End If

            'If the current field is not a key, allow the field to accept null values
            strTemp += " = NULL, "

            'Add comma if this is not the last field
            strTemp += IIf(blnDefaultValueUsed, " -- DEFAULT VALUES USED FOR THIS FIELD", String.Empty)
            strTemp += vbCrLf
        Next

        '===========================================
        '= Step 2 - Generate keys fields parameters
        '===========================================
        'Loop and add the primery key fields
        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            If (objSystemArgs(4, I).ToString.Trim = "Y") Then
                strTemp += vbTab + "@Key" + intKeyID.ToString + vbTab + objSystemArgs(2, I)
                intKeyID += 1

                If (LCase(objSystemArgs(2, I)) = "varchar") Or (LCase(objSystemArgs(2, I)) = "nvarchar") Then
                    strTemp += "("
                    If (objSystemArgs(3, I).ToString = vbNullString) Or Not IsNumeric(objSystemArgs(3, I)) Then
                        strTemp += DEFAULT_VARCHAR_LENGTH.ToString
                        blnDefaultValueUsed = True
                    Else
                        strTemp += objSystemArgs(3, I).ToString
                    End If
                    strTemp += ")"
                End If

                'If the current field is not a key, allow the field to accept null values
                strTemp += " = NULL, "

                'Add comma if this is not the last field
                strTemp += IIf(blnDefaultValueUsed, " -- DEFAULT VALUES USED FOR THIS PARAMETER", String.Empty)
                strTemp += vbCrLf

            End If

        Next

        If strTemp.Trim.Length > 0 Then strTemp = strTemp.Remove(strTemp.Length - 4, 4) + vbCrLf

        Return strTemp

    End Function

#End Region

End Class
