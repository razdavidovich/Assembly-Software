Public Class ComboItem
    '***************************************************************************
    '* This Class is used to generate a combo box item that has a code and 
    '* description, this class acts as a single item
    '***************************************************************************

    'Private class variables declarations
    Private strText As String
    Private intValue As Integer

    Sub New(ByVal Text As String, ByVal Value As Integer)
        '*************************************************************************
        '* Function Name:   New
        '* Description:     Public class constructor
        '* Created by:      Raz Davidovich
        '* Created date:    10/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        MyBase.New()

        'Save the values to the class 
        strText = Text
        intValue = Value

    End Sub

    Public ReadOnly Property DisplayText() As String
        Get
            Return strText
        End Get
    End Property

    Public ReadOnly Property Value() As Integer
        Get
            Return intValue
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return strText
    End Function

End Class
