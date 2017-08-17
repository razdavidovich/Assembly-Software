
'*******************************************************************
'*
'* An interface for general script object
'*
'*******************************************************************

Public Interface IScriptObject

    'Properties declaration
    ReadOnly Property ScriptDescriptiveHeader() As String
    ReadOnly Property ObjectType() As String
    ReadOnly Property ObjectName() As String
    ReadOnly Property SystemObjectType() As String
    Property ObjectOwner() As String
    Property GenerateDescriptiveHeader() As Boolean
    Property GenerateDropCommand() As Boolean

    'Functions declaration
    Function GenerateObjectScript() As String


End Interface
