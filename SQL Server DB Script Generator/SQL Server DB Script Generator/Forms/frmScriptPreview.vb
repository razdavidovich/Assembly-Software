Public Class frmScriptPreview
    Inherits System.Windows.Forms.Form

#Region " Class private declarations"
    Private Const LANGUAGE_NAME = "SQL"
#End Region

#Region " Class Constructor"

    Public Sub New(ByVal strSQLScript As String, ByVal strConfigScript As String)
        'Call the base constructor
        Me.New()

        'Load the SQL Script to the preview area
        rtfScriptPreview.Text = strSQLScript
        rtfConfigPreview.Text = strConfigScript

    End Sub

    Public Sub New(ByVal strSQLScript As String)
        'Call the base constructor
        Me.New(strSQLScript, String.Empty)

    End Sub

#End Region

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
    Friend WithEvents utcScriptTabControl As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents rtfScriptPreview As System.Windows.Forms.RichTextBox
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents rtfConfigPreview As System.Windows.Forms.RichTextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdCopyToClipboard As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScriptPreview))
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.cmdCopyToClipboard = New Infragistics.Win.Misc.UltraButton
        Me.utcScriptTabControl = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.rtfScriptPreview = New System.Windows.Forms.RichTextBox
        Me.rtfConfigPreview = New System.Windows.Forms.RichTextBox
        CType(Me.utcScriptTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utcScriptTabControl.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCopyToClipboard
        '
        Me.cmdCopyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.cmdCopyToClipboard.Appearance = Appearance1
        Me.cmdCopyToClipboard.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cmdCopyToClipboard.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCopyToClipboard.Location = New System.Drawing.Point(608, 524)
        Me.cmdCopyToClipboard.Name = "cmdCopyToClipboard"
        Me.cmdCopyToClipboard.Size = New System.Drawing.Size(184, 64)
        Me.cmdCopyToClipboard.TabIndex = 4
        Me.cmdCopyToClipboard.Text = "&Copy To Clipboard"
        '
        'utcScriptTabControl
        '
        Me.utcScriptTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.utcScriptTabControl.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utcScriptTabControl.Controls.Add(Me.UltraTabPageControl1)
        Me.utcScriptTabControl.Controls.Add(Me.UltraTabPageControl2)
        Me.utcScriptTabControl.Location = New System.Drawing.Point(12, 8)
        Me.utcScriptTabControl.Name = "utcScriptTabControl"
        Me.utcScriptTabControl.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utcScriptTabControl.Size = New System.Drawing.Size(780, 510)
        Me.utcScriptTabControl.TabIndex = 6
        Me.utcScriptTabControl.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "SP"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Base Tables Stored Procedures"
        UltraTab2.Key = "Config"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Windows Configuration For Base Tables (Config File)"
        Me.utcScriptTabControl.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(776, 479)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.rtfScriptPreview)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 29)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(776, 479)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.rtfConfigPreview)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(776, 479)
        '
        'rtfScriptPreview
        '
        Me.rtfScriptPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfScriptPreview.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.rtfScriptPreview.Location = New System.Drawing.Point(0, 0)
        Me.rtfScriptPreview.Name = "rtfScriptPreview"
        Me.rtfScriptPreview.Size = New System.Drawing.Size(776, 479)
        Me.rtfScriptPreview.TabIndex = 6
        Me.rtfScriptPreview.Text = ""
        Me.rtfScriptPreview.WordWrap = False
        '
        'rtfConfigPreview
        '
        Me.rtfConfigPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfConfigPreview.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.rtfConfigPreview.Location = New System.Drawing.Point(0, 0)
        Me.rtfConfigPreview.Name = "rtfConfigPreview"
        Me.rtfConfigPreview.Size = New System.Drawing.Size(776, 479)
        Me.rtfConfigPreview.TabIndex = 7
        Me.rtfConfigPreview.Text = ""
        Me.rtfConfigPreview.WordWrap = False
        '
        'frmScriptPreview
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(808, 601)
        Me.Controls.Add(Me.utcScriptTabControl)
        Me.Controls.Add(Me.cmdCopyToClipboard)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScriptPreview"
        Me.Text = "Script Preview"
        CType(Me.utcScriptTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utcScriptTabControl.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents RTBWrapper As New clsRTBWrapper

    Private Sub frmScriptPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intNumberOfSyntaxItems As Integer
        Dim strRegularExpression As String
        Dim strHighlightColor As String

        With RTBWrapper
            .bind(rtfScriptPreview)

            'Get the number of syntax Items to read from the config
            intNumberOfSyntaxItems = Integer.Parse(Config.ReadConfigValue("NumberOfKeyWords", LANGUAGE_NAME, "Language_Syntax"))

            'Loop and Add the language syntax to the wrapper class
            For Index As Integer = 1 To intNumberOfSyntaxItems
                strRegularExpression = Config.ReadConfigValue("RegularExpresstion_" + Index.ToString, LANGUAGE_NAME, "Language_Syntax")
                strHighlightColor = Config.ReadConfigValue("HighlightColor_" + Index.ToString, LANGUAGE_NAME, "Language_Syntax")
                .rtfSyntax.add(strRegularExpression, True, True, Color.FromName(strHighlightColor).ToArgb)
            Next

        End With

        'Paint the SQL Script
        RTBWrapper.colorDocument()

        'Select All text
        rtfScriptPreview.SelectAll()

    End Sub

    Private Sub cmdCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyToClipboard.Click
        'If no text was selected by the user, select all text for the copy process
        If rtfScriptPreview.SelectedText.Length = 0 Then
            rtfScriptPreview.SelectAll()
        End If

        If rtfConfigPreview.SelectedText.Length = 0 Then
            rtfConfigPreview.SelectAll()
        End If

        'Copy the data from the rich textbox to the clipboard
        If utcScriptTabControl.Tabs("SP").Active Then
            rtfScriptPreview.Copy()
        Else
            rtfConfigPreview.Copy()
        End If

        'Display a message to the user
        MessageBox.Show("The script was copied to the clipboard", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
