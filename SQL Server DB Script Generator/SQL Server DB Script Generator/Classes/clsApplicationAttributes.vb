Imports System.Reflection
Imports System.Runtime.InteropServices

'**********************************************************************
'* This class is the Assembly Software standard way of access an      *
'* application information that is stored inside the AssemblyInfo     *
'* file and the Assembly file itself                                  *
'*                                                                    *
'* WRITEN BY:   Raz Davidovich                                        *
'* DATE:        25/06/2004                                              *
'**********************************************************************

Public Class clsApplicationAttributes
    Private strAppMajorVersion As String
    Private strAppMinorVersion As String
    Private strAppRevisionVersion As String
    Private strAppBuildVersion As String
    Private strCompany As String
    Private strTitle As String
    Private strProduct As String
    Private strVersion As String
    Private strDescription As String
    Private strCopyright As String
    Private strTrademark As String
    Private strExecutablePath As String
    Private strStartupPath As String
    Private strGUID As String
    Private blnCLSCompliant As Boolean

    'Class constructor
    Public Sub New()
        '**********************************************************************
        '* NAME:        New                                                   *
        '* DESCRIPTION: This Sub is the class constructor for                 *
        '*              ApplicationAttributes class                           *
        '* WRITEN BY:   Raz Davidovich                                        *
        '* DATE:        4/3/2003                                              *
        '**********************************************************************

        Dim objCopyright As AssemblyCopyrightAttribute = CType(AssemblyCopyrightAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(AssemblyCopyrightAttribute)), AssemblyCopyrightAttribute)
        Dim objDescription As AssemblyDescriptionAttribute = CType(AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(AssemblyDescriptionAttribute)), AssemblyDescriptionAttribute)
        Dim objCompany As AssemblyCompanyAttribute = CType(AssemblyCompanyAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(AssemblyCompanyAttribute)), AssemblyCompanyAttribute)
        Dim objTrademark As AssemblyTrademarkAttribute = CType(AssemblyTrademarkAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(AssemblyTrademarkAttribute)), AssemblyTrademarkAttribute)
        Dim objProduct As AssemblyProductAttribute = CType(AssemblyProductAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(AssemblyProductAttribute)), AssemblyProductAttribute)
        Dim objTitle As AssemblyTitleAttribute = CType(AssemblyTitleAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(AssemblyTitleAttribute)), AssemblyTitleAttribute)
        Dim objGuid As GuidAttribute = CType(GuidAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(GuidAttribute)), GuidAttribute)
        Dim verApplication As System.Version

        'Get the system version
        verApplication = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version()

        'Set the application information to the class private variables
        strAppMajorVersion = verApplication.Major.ToString
        strAppMinorVersion = verApplication.Minor.ToString
        strAppRevisionVersion = verApplication.Revision.ToString
        strAppBuildVersion = verApplication.Build.ToString
        strCompany = objCompany.Company
        strTitle = objTitle.Title
        strProduct = objProduct.Product
        strVersion = Application.ProductVersion
        strDescription = objDescription.Description
        strCopyright = objCopyright.Copyright
        strTrademark = objTrademark.Trademark
        strExecutablePath = Application.ExecutablePath
        strStartupPath = Application.StartupPath
        strGUID = objGuid.Value
    End Sub

    Public ReadOnly Property CompanyName() As String
        Get
            Return strCompany
        End Get
    End Property

    Public ReadOnly Property ApplicationTitle() As String
        Get
            Return strTitle
        End Get
    End Property

    Public ReadOnly Property ProductName() As String
        Get
            Return strProduct
        End Get
    End Property

    Public ReadOnly Property ApplicationVersion() As String
        Get
            Return strVersion
        End Get
    End Property

    Public ReadOnly Property ApplicationDescription() As String
        Get
            Return strDescription
        End Get
    End Property

    Public ReadOnly Property ApplicationCopyright() As String
        Get
            Return strCopyright
        End Get
    End Property

    Public ReadOnly Property ApplicationTrademark() As String
        Get
            Return strTrademark
        End Get
    End Property

    Public ReadOnly Property ExecutablePath() As String
        Get
            Return strExecutablePath
        End Get
    End Property

    Public ReadOnly Property StartupPath() As String
        Get
            Return strStartupPath
        End Get
    End Property

    Public ReadOnly Property GUID() As String
        Get
            Return strGUID
        End Get
    End Property

    Public ReadOnly Property CLSCompliant() As Boolean
        Get
            Return blnCLSCompliant
        End Get
    End Property

    Public ReadOnly Property AppMajorVersion() As String
        Get
            Return strAppMajorVersion
        End Get
    End Property

    Public ReadOnly Property AppMinorVersion() As String
        Get
            Return strAppMinorVersion
        End Get
    End Property

    Public ReadOnly Property AppRevisionVersion() As String
        Get
            Return strAppRevisionVersion
        End Get
    End Property

    Public ReadOnly Property AppBuildVersion() As String
        Get
            Return strAppBuildVersion
        End Get
    End Property

End Class
