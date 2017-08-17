Imports System.Runtime.Serialization

''' <summary>
''' A class to hold a single Loftware print server printer information
''' </summary>
''' <remarks></remarks>
<System.Runtime.Serialization.DataContract()> _
Public Class clsPrinter

    Private intPrinterNumber As Integer
    Private strPrinterName As String
    Private strPrinterAlias As String
    Private strPort As String

    Sub New(ByVal intPrinterNumber As Integer, ByVal strPrinterName As String, ByVal strPrinterAlias As String, ByVal strPort As String)
        Me.intPrinterNumber = intPrinterNumber
        Me.strPrinterName = strPrinterName
        Me.strPrinterAlias = strPrinterAlias
        Me.strPort = strPort
    End Sub

    <DataMember()> _
    Public Property PrinterPort() As String
        Get
            Return strPort
        End Get
        Private Set(ByVal value As String)  'Cheat to create a readonly datamember attribute
            strPort = value
        End Set
    End Property

    <DataMember()> _
    Public Property PrinterAlias() As String
        Get
            Return strPrinterAlias
        End Get
        Private Set(ByVal value As String)  'Cheat to create a readonly datamember attribute
            strPrinterAlias = value
        End Set
    End Property

    <DataMember()> _
    Public Property PrinterName() As String
        Get
            Return strPrinterName
        End Get
        Private Set(ByVal value As String)  'Cheat to create a readonly datamember attribute
            strPrinterName = value
        End Set
    End Property

    <DataMember()> _
    Public Property PrinterNumber() As Integer
        Get
            Return intPrinterNumber
        End Get
        Private Set(ByVal value As Integer)  'Cheat to create a readonly datamember attribute
            intPrinterNumber = value
        End Set
    End Property

End Class