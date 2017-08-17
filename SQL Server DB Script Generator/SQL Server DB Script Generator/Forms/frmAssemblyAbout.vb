Imports System.IO 'for File.Exists function
Imports Microsoft.Win32   'for registry functions
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class frmAssemblyAbout
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnSysInfo As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents pBoxMagma As System.Windows.Forms.PictureBox
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblDeveloper As System.Windows.Forms.Label
    Friend WithEvents lblVersionText As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lnkEmail As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkWebSite As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblBuild As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAssemblyAbout))
        Me.lblProduct = New System.Windows.Forms.Label
        Me.pBoxMagma = New System.Windows.Forms.PictureBox
        Me.lblVersionText = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.lblDeveloper = New System.Windows.Forms.Label
        Me.btnSysInfo = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lnkEmail = New System.Windows.Forms.LinkLabel
        Me.lnkWebSite = New System.Windows.Forms.LinkLabel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblBuild = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblProduct
        '
        Me.lblProduct.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblProduct.ForeColor = System.Drawing.Color.Blue
        Me.lblProduct.Location = New System.Drawing.Point(197, 8)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(275, 23)
        Me.lblProduct.TabIndex = 0
        Me.lblProduct.Text = "Product Information"
        Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pBoxMagma
        '
        Me.pBoxMagma.Image = CType(resources.GetObject("pBoxMagma.Image"), System.Drawing.Image)
        Me.pBoxMagma.Location = New System.Drawing.Point(14, 8)
        Me.pBoxMagma.Name = "pBoxMagma"
        Me.pBoxMagma.Size = New System.Drawing.Size(180, 104)
        Me.pBoxMagma.TabIndex = 1
        Me.pBoxMagma.TabStop = False
        '
        'lblVersionText
        '
        Me.lblVersionText.Location = New System.Drawing.Point(197, 77)
        Me.lblVersionText.Name = "lblVersionText"
        Me.lblVersionText.Size = New System.Drawing.Size(56, 23)
        Me.lblVersionText.TabIndex = 2
        Me.lblVersionText.Text = "Version:"
        Me.lblVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCopyright
        '
        Me.lblCopyright.Location = New System.Drawing.Point(197, 29)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(292, 24)
        Me.lblCopyright.TabIndex = 3
        Me.lblCopyright.Text = "Copyright © 2001-2004, Assembly Software LTD."
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDeveloper
        '
        Me.lblDeveloper.Location = New System.Drawing.Point(16, 240)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(424, 40)
        Me.lblDeveloper.TabIndex = 4
        Me.lblDeveloper.Text = "Warning: This computer program is protected by copyright law and international tr" & _
        "eaties."
        Me.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSysInfo
        '
        Me.btnSysInfo.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnSysInfo.Location = New System.Drawing.Point(352, 288)
        Me.btnSysInfo.Name = "btnSysInfo"
        Me.btnSysInfo.Size = New System.Drawing.Size(120, 24)
        Me.btnSysInfo.TabIndex = 5
        Me.btnSysInfo.Text = "System Info"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnOK.Location = New System.Drawing.Point(352, 320)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(197, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "All Rights Reserved"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 288)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(328, 64)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Unauthorized reproduction or distribution of this program, or any portion of it, " & _
        "may result in severe civil and criminal penalties, and will be prosecuted to the" & _
        " maximum extent possible under the law."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.ForeColor = System.Drawing.Color.Green
        Me.lblVersion.Location = New System.Drawing.Point(261, 77)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(64, 23)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "1.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkEmail)
        Me.GroupBox1.Controls.Add(Me.lnkWebSite)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(16, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 120)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contact Information"
        '
        'lnkEmail
        '
        Me.lnkEmail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkEmail.Location = New System.Drawing.Point(128, 96)
        Me.lnkEmail.Name = "lnkEmail"
        Me.lnkEmail.Size = New System.Drawing.Size(216, 16)
        Me.lnkEmail.TabIndex = 9
        Me.lnkEmail.TabStop = True
        Me.lnkEmail.Text = "info@Assembly.co.il"
        '
        'lnkWebSite
        '
        Me.lnkWebSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkWebSite.Location = New System.Drawing.Point(128, 72)
        Me.lnkWebSite.Name = "lnkWebSite"
        Me.lnkWebSite.Size = New System.Drawing.Size(216, 16)
        Me.lnkWebSite.TabIndex = 8
        Me.lnkWebSite.TabStop = True
        Me.lnkWebSite.Text = "http://www.Assembly.co.il"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Email:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Web Site:"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(128, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(216, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "972-(0)8-9461114"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(128, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "972-(0)8-9474108"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Office Fax:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Office Phone:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(349, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 23)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Build:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBuild
        '
        Me.lblBuild.ForeColor = System.Drawing.Color.Green
        Me.lblBuild.Location = New System.Drawing.Point(397, 77)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(104, 23)
        Me.lblBuild.TabIndex = 7
        Me.lblBuild.Text = "1.0"
        Me.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAssemblyAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(490, 367)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblBuild)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSysInfo)
        Me.Controls.Add(Me.lblDeveloper)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblVersionText)
        Me.Controls.Add(Me.pBoxMagma)
        Me.Controls.Add(Me.lblProduct)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblVersion)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssemblyAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objAppInfo As clsApplicationAttributes = New clsApplicationAttributes

        'Set the web site link data
        lnkWebSite.Links.Add(0, 30, lnkWebSite.Text)

        'Set the Email link data
        lnkEmail.Links.Add(0, 30, "mailto:" & lnkEmail.Text)

        'Load the application name information
        lblProduct.Text = objAppInfo.ProductName

        'Load the application vertion information
        lblVersion.Text = objAppInfo.AppMajorVersion.ToString + "." + objAppInfo.AppMinorVersion.ToString + "." + objAppInfo.AppRevisionVersion.ToString
        lblBuild.Text = objAppInfo.AppBuildVersion.ToString

        'Set the copyrights text
        lblCopyright.Text = "Copyright © 2001-" & Now.Year.ToString & ", Assembly Software LTD."

        'Clear the objects
        objAppInfo = Nothing

    End Sub

    'close AboutBox
    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSysInfo.Click
        ShowSysInfo()
    End Sub

    Public Sub ShowSysInfo()
        '**********************************************************************
        '* NAME:        ShowSysInfo                                           *
        '* DESCRIPTION: This Sub Opens the system info screen                 *
        '* WRITEN BY:   Adir Saharabi                                         *
        '* DATE:        4/3/2003                                              *
        '**********************************************************************
        Dim sSysInfoPath As String = String.Empty
        Dim sRegPath As String
        'Reg key paths
        Const REGKEYSYSINFOLOC As String = "SOFTWARE\Microsoft\Shared Tools Location"
        Const REGVALSYSINFOLOC As String = "MSINFO"
        Const REGKEYSYSINFO As String = "SOFTWARE\Microsoft\Shared Tools\MSINFO"
        Const REGVALSYSINFO As String = "PATH"
        Const MSINFOEXE As String = "\MSINFO32.EXE"

        'get location of MSInfo.exe and launch it
        Try
            If GetHKLMValue(REGKEYSYSINFO, REGVALSYSINFO, sSysInfoPath) Then
                sRegPath = "Reg path: HKLM\" & REGKEYSYSINFO & "\" & REGVALSYSINFO

            ElseIf GetHKLMValue(REGKEYSYSINFOLOC, REGVALSYSINFOLOC, sSysInfoPath) Then
                sSysInfoPath = sSysInfoPath & MSINFOEXE
                sRegPath = "Reg path: HKLM\" & REGKEYSYSINFOLOC & "\" & REGVALSYSINFOLOC

            Else
                sRegPath = "MSInfo Registry Entries not found"
            End If

            If sSysInfoPath.Length > 0 Then
                ' Validate Existance Of Known 32 Bit File Version
                If File.Exists(sSysInfoPath) Then
                    'launch MSInfo
                    Shell(sSysInfoPath, AppWinStyle.NormalFocus)
                    Exit Sub
                Else
                    sRegPath = "MSInfo path not found"
                End If
            End If
            MessageBox.Show("System Information is unavailable at this time (" & sRegPath & ").", "AboutBox", MessageBoxButtons.OK)

        Catch e As Exception
            Console.WriteLine("ShowSysInfo - Error: " & e.Message.ToString)
            MessageBox.Show("System Information is unavailable at this time (error reading registry).", "AboutBox", MessageBoxButtons.OK)
        End Try
    End Sub


    Private Function GetHKLMValue(ByVal KeyName As String, ByVal SubKeyRef As String, ByRef KeyVal As String) As Boolean
        '**********************************************************************
        '* NAME:        GetHKLMValue                                          *
        '* DESCRIPTION: This Sub reads an HKLM Registry key value             *
        '* WRITEN BY:   Adir Saharabi                                         *
        '* DATE:        4/3/2003                                              *
        '**********************************************************************
        Dim regHKLM As RegistryKey = Registry.LocalMachine
        Dim regSubKey As RegistryKey

        Try
            'Open KeyName Under HKEY_LOCAL_MACHINE
            regSubKey = regHKLM.OpenSubKey(KeyName)
            KeyVal = regSubKey.GetValue(SubKeyRef, ControlChars.NullChar).ToString

        Catch e As Exception
            Console.WriteLine("GetKeyValue - Error: " & e.Message.ToString)
        End Try

        If KeyVal.Length > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub lnkWebSite_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkWebSite.LinkClicked
        'Open the magma group web site
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub lnkEmail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEmail.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class
