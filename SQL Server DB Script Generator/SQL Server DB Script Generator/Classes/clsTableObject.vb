
'**************************************************************************
'*
'* A class for Table script object, implements the IScriptObject interface
'*
'**************************************************************************

Public Class clsTableObject
    Implements IScriptObject

#Region "Class declaration object"
    'Shared class delaration
    Private Shared intFileNameID As Integer

    'Private class declaration
    Friend strObjectType As String
    Friend strObjectName As String
    Friend strObjectOwner As String
    Friend strSystemObjectType As String
    Friend objSystemArgs As Object(,)
    Friend blnGenerateHeader As Boolean
    Friend blnGenerateDropCommand As Boolean
    Friend blnGenerateTableKeys As Boolean
    Friend strObjectScriptHeader As String
    Friend strObjectScript As String
    Friend intFieldID As Integer = 0
    Friend strCollation As String
    Friend strTableName As String

    Friend Const DEFAULT_VARCHAR_LENGTH = 50
    Friend Const DEFAULT_FIELD_NAME = "NO_NAME_FIELD"

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
        Me.New(strObjectType, "Table_Name_" & intFileNameID.ToString & "_Ta", objSystemArgs)
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

        'Set the object type to the local variable
        Me.strObjectType = strObjectType
        Me.strObjectName = strObjectName
        Me.strObjectOwner = strObjectOwner
        Me.blnGenerateHeader = blnGenerateHeader
        Me.blnGenerateDropCommand = blnGenerateDropCommand
        Me.blnGenerateTableKeys = blnGenerateTableKeys
        Me.strSystemObjectType = "IsUserTable"
        Me.strTableName = strObjectName

        'Save the system arguments to the local variable
        Me.objSystemArgs = objSystemArgs

    End Sub
#End Region

#Region "Class Properties"
    Public ReadOnly Property ObjectType() As String Implements IScriptObject.ObjectType
        Get
            'Returns the object type
            Return strObjectType
        End Get
    End Property

    Public ReadOnly Property ScriptDescriptiveHeader() As String Implements IScriptObject.ScriptDescriptiveHeader
        Get
            'Return the Script Header
            Return GenerateDescriptiveHeader()
        End Get
    End Property

    Public ReadOnly Property ObjectName() As String Implements IScriptObject.ObjectName
        Get
            'Return the object name
            Return strObjectName
        End Get
    End Property

    Public Property ObjectOwner() As String Implements IScriptObject.ObjectOwner
        Get
            Return strObjectOwner
        End Get
        Set(ByVal Value As String)
            strObjectOwner = Value
        End Set
    End Property

    Public Property GenerateDescriptiveHeader() As Boolean Implements IScriptObject.GenerateDescriptiveHeader
        Get
            Return blnGenerateHeader
        End Get
        Set(ByVal Value As Boolean)
            blnGenerateHeader = Value
        End Set
    End Property

    Public Property GenerateDropCommand() As Boolean Implements IScriptObject.GenerateDropCommand
        Get
            Return blnGenerateDropCommand
        End Get
        Set(ByVal Value As Boolean)
            blnGenerateDropCommand = Value
        End Set
    End Property

    Public ReadOnly Property SystemObjectType() As String Implements IScriptObject.SystemObjectType
        Get
            Return strSystemObjectType
        End Get
    End Property

    Public Property UseCollation() As String
        Get
            Return strCollation
        End Get
        Set(ByVal Value As String)
            'Set the collation to the private variable
            strCollation = "COLLATE " + Value
        End Set
    End Property

#End Region

#Region "Class methods"

    Public Overridable Function GenerateObjectScript() As String Implements IScriptObject.GenerateObjectScript
        '*************************************************************************
        '* Function Name:   GenerateObjectScript
        '* Description:     This class method generates the SQL Script
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
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
            strTemp += "CREATE TABLE [" + strObjectOwner + "].[" + strObjectName + "] ("
            strTemp += vbCrLf
            'Generate the key fields command
            strTemp += GenerateFields()
            strTemp += vbCrLf
            strTemp += ") ON [PRIMARY]"
            strTemp += vbCrLf
            strTemp += "GO"
        End If
        strTemp += vbCrLf
        strTemp += vbCrLf

        'Generate primery keys for the this table (if needed)
        If blnGenerateTableKeys Then
            strTemp += GenerateTableKeysScript()
        End If

        'Return the complete script
        Return strTemp

    End Function

    Public Function GenerateHeader() As String
        '*************************************************************************
        '* Function Name:   GenerateHeader
        '* Description:     Private function that generates the SQL descriptive
        '*                  header
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String

        strTemp = "/*===== Object: " & strObjectType & " [" & strObjectOwner & "].[" & strObjectName & "]"
        strTemp += "    Script Date: " & Now.ToString("dd/MM/yyyy HH:mm:ss") & " =====*/"
        strTemp += vbCrLf

        Return strTemp

    End Function

    Public Function GenerateDrop() As String
        '*************************************************************************
        '* Function Name:   GenerateDrop
        '* Description:     Private function that generates the SQL drop command
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String

        strTemp = "if exists (select * from dbo.sysobjects where id = object_id(N'"
        strTemp += "[" & strObjectOwner & "].[" & strObjectName
        strTemp += "]') and OBJECTPROPERTY(id, N'" & strSystemObjectType & "') = 1)"
        strTemp += vbCrLf
        strTemp += "drop " + strObjectType + " [" & strObjectOwner & "].[" & strObjectName & "]"
        strTemp += vbCrLf
        strTemp += "GO"
        strTemp += vbCrLf
        strTemp += vbCrLf

        Return strTemp

    End Function

#End Region

#Region "Class private functions"

    Private Function GenerateFields() As String
        '*************************************************************************
        '* Function Name:   GenerateFields
        '* Description:     This function loops the fields collection and generate
        '*                  the list of fields for the script
        '* Created by:      Raz Davidovich
        '* Created date:    23/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String = String.Empty
        Dim blnDefaultValueUsed As Boolean

        'Loop the fields collection and generate script
        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            'Reset the default values flag
            blnDefaultValueUsed = False

            'Start generate the SQL
            strTemp += vbTab
            strTemp += "["
            If (objSystemArgs(1, I).ToString.Trim = vbNullString) Then
                strTemp += DEFAULT_FIELD_NAME + "] [" + objSystemArgs(2, I) + "] "
                blnDefaultValueUsed = True
            Else
                strTemp += objSystemArgs(1, I) + "] [" + objSystemArgs(2, I) + "] "
            End If

            If LCase(objSystemArgs(2, I)) = "nvarchar" Then
                strTemp += "("
                If (objSystemArgs(3, I).ToString = vbNullString) Or Not IsNumeric(objSystemArgs(3, I)) Then
                    strTemp += DEFAULT_VARCHAR_LENGTH.ToString
                    blnDefaultValueUsed = True
                Else
                    strTemp += objSystemArgs(3, I)
                End If
                strTemp += ") " + strCollation
            End If

            'If the current field is not a key, allow the field to accept null values
            strTemp += IIf(objSystemArgs(4, I).ToString.Trim.ToUpper = "Y", " NOT ", String.Empty) + " NULL "

            'Add comma if this is not the last field
            If I <> objSystemArgs.Length Then strTemp += ", "
            strTemp += IIf(blnDefaultValueUsed, " -- DEFAULT VALUES USED FOR THIS FIELD", String.Empty)
            strTemp += vbCrLf
        Next

        Return strTemp

    End Function

    Private Function GenerateTableKeysScript() As String
        '*************************************************************************
        '* Function Name:   GenerateTableKeysScript
        '* Description:     This function generates the table keys script
        '* Created by:      Raz Davidovich
        '* Created date:    23/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTemp As String
        Dim blnFoundKeys As Boolean = True

        'Start key definition
        strTemp = "ALTER TABLE [" + strObjectOwner + "].[" + strObjectName + "] ADD " + vbCrLf
        strTemp += "CONSTRAINT [PK_" + strObjectName + "] PRIMARY KEY  CLUSTERED " + vbCrLf
        strTemp += "(" + vbCrLf

        'Loop and add the primery key fields
        For I As Integer = 0 To objSystemArgs.GetUpperBound(1)
            If (objSystemArgs(4, I).ToString.Trim = "Y") Then
                strTemp += vbTab
                strTemp += "["
                If (objSystemArgs(1, I).ToString.Trim = vbNullString) Then
                    strTemp += DEFAULT_FIELD_NAME + "] ," + vbCrLf
                Else
                    strTemp += objSystemArgs(1, I) + "] ," + vbCrLf
                End If

                'Set the found keys flag
                blnFoundKeys = True
            End If

        Next

        'If keys were found return the script, otherwise return comment
        If blnFoundKeys Then
            'Remove the last comma from the script
            strTemp = strTemp.Remove(strTemp.LastIndexOf(","), 1)

            'End the key definition
            strTemp += ")  ON [PRIMARY] " + vbCrLf
            strTemp += "GO" + vbCrLf + vbCrLf

            Return strTemp
        Else
            Return "/*=====  PLEASE NOTE THAT NO KEY FIELDS WERE FOUND FOR '" + strObjectName + "' TABLE =====*/"
        End If

    End Function

    Protected Function GenerateParameter(ByVal strFieldName As String) As String
        '*************************************************************************
        '* Function Name:   GenerateParameter
        '* Description:     This function returns the parameter name after removing 
        '*                  forbiden characters from the field name
        '* Created by:      Raz Davidovich
        '* Created date:    13/01/2008
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Remove illegal characters
        strFieldName = strFieldName.Replace("-", "_")
        strFieldName = strFieldName.Replace("/", "_")
        strFieldName = strFieldName.Replace("\", "_")
        strFieldName = strFieldName.Replace("(", "_")
        strFieldName = strFieldName.Replace(")", "_")
        strFieldName = strFieldName.Replace(" ", "_")
        Return "@" + strFieldName

    End Function

#End Region

End Class
