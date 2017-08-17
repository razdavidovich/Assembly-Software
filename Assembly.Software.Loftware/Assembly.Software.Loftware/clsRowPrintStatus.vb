Imports System.Runtime.Serialization
Imports Loftware.Common

''' <summary>
''' Public class to hold the a single print row status including the printed row information (SubmitedData and SubmitedXML properties)
''' </summary>
''' <remarks></remarks>
<System.Runtime.Serialization.DataContract()> _
Public Class clsRowPrintStatus

    Private objSubmitedData As Object()
    Private strSubmitedXML As String
    Private intPrintedJobStatus As Global.Loftware.Common.LLMStatusCodes

    Sub New(ByVal intPrintedJobStatus As Global.Loftware.Common.LLMStatusCodes, ByVal strSubmitedXml As String, ByVal objSubmitedData As Object())
        Me.intPrintedJobStatus = intPrintedJobStatus
        Me.strSubmitedXML = strSubmitedXml
        Me.objSubmitedData = objSubmitedData

        'Replace DBNull value with null value in the submitted values object array
        Dim index As Integer = 0
        For Each Item As Object In Me.objSubmitedData
            If IsDBNull(Item) Then
                Me.objSubmitedData(index) = String.Empty
            End If
            index += 1
        Next

    End Sub

    <DataMember()> _
    Public Property PrintedJobStatus() As Global.Loftware.Common.LLMStatusCodes
        Get
            Return intPrintedJobStatus
        End Get
        Private Set(ByVal value As LLMStatusCodes)  'Cheat to create a readonly datamember attribute
            intPrintedJobStatus = value
        End Set
    End Property

    <DataMember()> _
    Public Property SubmitedXml() As String
        Get
            Return strSubmitedXML
        End Get
        Private Set(ByVal value As String)  'Cheat to create a readonly datamember attribute
            strSubmitedXML = value
        End Set
    End Property

    <DataMember()> _
    Public Property SubmitedData() As Object()
        Get
            Return objSubmitedData
        End Get
        Private Set(ByVal value As Object())  'Cheat to create a readonly datamember attribute
            objSubmitedData = value
        End Set
    End Property

End Class