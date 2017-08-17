<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu")
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("File")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SelectAll")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ClearSelection")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("ScriptOptions")
        Dim PopupMenuTool3 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Help")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit_App")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim PopupMenuTool4 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("File")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit_App")
        Dim PopupMenuTool5 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Help")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("About")
        Dim PopupMenuTool6 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("ScriptOptions")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("GenKeysInfo", "")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("IncludeDescriptive", "")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("GenerateDROP", "")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("About")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("IncludeDescriptive", "")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("GenerateDROP", "")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SelectAll")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ClearSelection")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim StateButtonTool6 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("GenKeysInfo", "")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbDatabases = New System.Windows.Forms.ComboBox
        Me.lvwObjectsToScript = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.mglListViewImages = New System.Windows.Forms.ImageList(Me.components)
        Me.chkGenerateConfig = New System.Windows.Forms.CheckBox
        Me.btnGenerateToFile = New Infragistics.Win.Misc.UltraButton
        Me.imgGraphics = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGenerateToClipboard = New Infragistics.Win.Misc.UltraButton
        Me.btnConnectToServer = New Infragistics.Win.Misc.UltraButton
        Me.erpFormErrors = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkWindowsAuthentication = New System.Windows.Forms.CheckBox
        Me.frmMainForm_Fill_Panel = New System.Windows.Forms.Panel
        Me._frmMainForm_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.tlbUltraToolbarManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._frmMainForm_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._frmMainForm_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._frmMainForm_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        CType(Me.erpFormErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmMainForm_Fill_Panel.SuspendLayout()
        CType(Me.tlbUltraToolbarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Name (or IP)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 83)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SQL Server User Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 120)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "SQL Server Password"
        '
        'txtServerName
        '
        Me.txtServerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServerName.Location = New System.Drawing.Point(306, 13)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(257, 26)
        Me.txtServerName.TabIndex = 0
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.Location = New System.Drawing.Point(306, 83)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(257, 26)
        Me.txtUserName.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(306, 120)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(257, 26)
        Me.txtPassword.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 221)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Database Selection"
        '
        'cmbDatabases
        '
        Me.cmbDatabases.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDatabases.Enabled = False
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(306, 219)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(256, 28)
        Me.cmbDatabases.TabIndex = 5
        '
        'lvwObjectsToScript
        '
        Me.lvwObjectsToScript.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwObjectsToScript.CheckBoxes = True
        Me.lvwObjectsToScript.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvwObjectsToScript.Location = New System.Drawing.Point(78, 258)
        Me.lvwObjectsToScript.Name = "lvwObjectsToScript"
        Me.lvwObjectsToScript.Size = New System.Drawing.Size(484, 402)
        Me.lvwObjectsToScript.SmallImageList = Me.mglListViewImages
        Me.lvwObjectsToScript.TabIndex = 9
        Me.lvwObjectsToScript.UseCompatibleStateImageBehavior = False
        Me.lvwObjectsToScript.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Script Object Name"
        Me.ColumnHeader1.Width = 1000
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Table ID"
        Me.ColumnHeader2.Width = 0
        '
        'mglListViewImages
        '
        Me.mglListViewImages.ImageStream = CType(resources.GetObject("mglListViewImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.mglListViewImages.TransparentColor = System.Drawing.Color.Transparent
        Me.mglListViewImages.Images.SetKeyName(0, "Tables.ico")
        Me.mglListViewImages.Images.SetKeyName(1, "Views.ico")
        '
        'chkGenerateConfig
        '
        Me.chkGenerateConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkGenerateConfig.AutoSize = True
        Me.chkGenerateConfig.Checked = True
        Me.chkGenerateConfig.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGenerateConfig.Location = New System.Drawing.Point(78, 666)
        Me.chkGenerateConfig.Name = "chkGenerateConfig"
        Me.chkGenerateConfig.Size = New System.Drawing.Size(281, 24)
        Me.chkGenerateConfig.TabIndex = 6
        Me.chkGenerateConfig.Text = "Generate base tables config entries"
        Me.chkGenerateConfig.UseVisualStyleBackColor = True
        '
        'btnGenerateToFile
        '
        Me.btnGenerateToFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.Image = "Save.ico"
        Me.btnGenerateToFile.Appearance = Appearance1
        Me.btnGenerateToFile.Enabled = False
        Me.btnGenerateToFile.ImageList = Me.imgGraphics
        Me.btnGenerateToFile.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnGenerateToFile.Location = New System.Drawing.Point(79, 703)
        Me.btnGenerateToFile.Name = "btnGenerateToFile"
        Me.btnGenerateToFile.Size = New System.Drawing.Size(170, 53)
        Me.btnGenerateToFile.TabIndex = 7
        Me.btnGenerateToFile.Text = "&Save to File"
        '
        'imgGraphics
        '
        Me.imgGraphics.ImageStream = CType(resources.GetObject("imgGraphics.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgGraphics.TransparentColor = System.Drawing.Color.Transparent
        Me.imgGraphics.Images.SetKeyName(0, "Save.ico")
        Me.imgGraphics.Images.SetKeyName(1, "StorageSearch.ico")
        Me.imgGraphics.Images.SetKeyName(2, "Database.ico")
        '
        'btnGenerateToClipboard
        '
        Me.btnGenerateToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.Image = "StorageSearch.ico"
        Me.btnGenerateToClipboard.Appearance = Appearance2
        Me.btnGenerateToClipboard.Enabled = False
        Me.btnGenerateToClipboard.ImageList = Me.imgGraphics
        Me.btnGenerateToClipboard.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnGenerateToClipboard.Location = New System.Drawing.Point(392, 703)
        Me.btnGenerateToClipboard.Name = "btnGenerateToClipboard"
        Me.btnGenerateToClipboard.Size = New System.Drawing.Size(170, 53)
        Me.btnGenerateToClipboard.TabIndex = 8
        Me.btnGenerateToClipboard.Text = "&Preview Script"
        '
        'btnConnectToServer
        '
        Me.btnConnectToServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.Image = "Database.ico"
        Me.btnConnectToServer.Appearance = Appearance13
        Me.btnConnectToServer.ImageList = Me.imgGraphics
        Me.btnConnectToServer.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnConnectToServer.Location = New System.Drawing.Point(306, 161)
        Me.btnConnectToServer.Name = "btnConnectToServer"
        Me.btnConnectToServer.Size = New System.Drawing.Size(257, 43)
        Me.btnConnectToServer.TabIndex = 4
        Me.btnConnectToServer.Text = "&Connect to Server"
        '
        'erpFormErrors
        '
        Me.erpFormErrors.ContainerControl = Me
        '
        'chkWindowsAuthentication
        '
        Me.chkWindowsAuthentication.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkWindowsAuthentication.AutoSize = True
        Me.chkWindowsAuthentication.Location = New System.Drawing.Point(306, 48)
        Me.chkWindowsAuthentication.Name = "chkWindowsAuthentication"
        Me.chkWindowsAuthentication.Size = New System.Drawing.Size(232, 24)
        Me.chkWindowsAuthentication.TabIndex = 1
        Me.chkWindowsAuthentication.Text = "Use Windows Authentication"
        Me.chkWindowsAuthentication.UseVisualStyleBackColor = True
        '
        'frmMainForm_Fill_Panel
        '
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.chkWindowsAuthentication)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.btnConnectToServer)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.btnGenerateToClipboard)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.btnGenerateToFile)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.chkGenerateConfig)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.lvwObjectsToScript)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.cmbDatabases)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.Label4)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.txtPassword)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.txtUserName)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.txtServerName)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.Label3)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.Label2)
        Me.frmMainForm_Fill_Panel.Controls.Add(Me.Label1)
        Me.frmMainForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.frmMainForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmMainForm_Fill_Panel.Location = New System.Drawing.Point(0, 21)
        Me.frmMainForm_Fill_Panel.Name = "frmMainForm_Fill_Panel"
        Me.frmMainForm_Fill_Panel.Size = New System.Drawing.Size(642, 769)
        Me.frmMainForm_Fill_Panel.TabIndex = 0
        '
        '_frmMainForm_Toolbars_Dock_Area_Left
        '
        Me._frmMainForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMainForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
        Me._frmMainForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._frmMainForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMainForm_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 21)
        Me._frmMainForm_Toolbars_Dock_Area_Left.Name = "_frmMainForm_Toolbars_Dock_Area_Left"
        Me._frmMainForm_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 769)
        Me._frmMainForm_Toolbars_Dock_Area_Left.ToolbarsManager = Me.tlbUltraToolbarManager
        '
        'tlbUltraToolbarManager
        '
        Me.tlbUltraToolbarManager.DesignerFlags = 1
        Me.tlbUltraToolbarManager.DockWithinContainer = Me
        Me.tlbUltraToolbarManager.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.tlbUltraToolbarManager.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.IsMainMenuBar = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool1, ButtonTool1, ButtonTool2, PopupMenuTool2, PopupMenuTool3})
        UltraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Text = "MainMenu"
        Me.tlbUltraToolbarManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance25.Image = CType(resources.GetObject("Appearance25.Image"), Object)
        ButtonTool3.SharedProps.AppearancesSmall.Appearance = Appearance25
        ButtonTool3.SharedProps.Caption = "&Exit Application"
        PopupMenuTool4.SharedProps.Caption = "&File"
        PopupMenuTool4.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4})
        PopupMenuTool5.SharedProps.Caption = "&Help"
        PopupMenuTool5.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool5})
        PopupMenuTool6.SharedProps.Caption = "&Script Options"
        StateButtonTool1.Checked = True
        StateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool2.Checked = True
        StateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool3.Checked = True
        StateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool6.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool1, StateButtonTool2, StateButtonTool3})
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        ButtonTool6.SharedProps.AppearancesSmall.Appearance = Appearance26
        ButtonTool6.SharedProps.Caption = "&About This Software"
        StateButtonTool4.Checked = True
        StateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        Appearance28.Image = CType(resources.GetObject("Appearance28.Image"), Object)
        StateButtonTool4.SharedProps.AppearancesSmall.Appearance = Appearance28
        StateButtonTool4.SharedProps.Caption = "Include Descriptive Header"
        StateButtonTool5.Checked = True
        StateButtonTool5.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        Appearance29.Image = CType(resources.GetObject("Appearance29.Image"), Object)
        StateButtonTool5.SharedProps.AppearancesSmall.Appearance = Appearance29
        StateButtonTool5.SharedProps.Caption = "Generate the DROP <Object> command"
        Appearance23.Image = CType(resources.GetObject("Appearance23.Image"), Object)
        ButtonTool7.SharedProps.AppearancesSmall.Appearance = Appearance23
        ButtonTool7.SharedProps.Caption = "Select &All"
        ButtonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool7.SharedProps.Visible = False
        Appearance24.Image = CType(resources.GetObject("Appearance24.Image"), Object)
        ButtonTool8.SharedProps.AppearancesSmall.Appearance = Appearance24
        ButtonTool8.SharedProps.Caption = "&Clear All"
        ButtonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool8.SharedProps.Visible = False
        StateButtonTool6.Checked = True
        StateButtonTool6.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        StateButtonTool6.SharedProps.AppearancesSmall.Appearance = Appearance27
        StateButtonTool6.SharedProps.Caption = "Generate Keys Information"
        Me.tlbUltraToolbarManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool3, PopupMenuTool4, PopupMenuTool5, PopupMenuTool6, ButtonTool6, StateButtonTool4, StateButtonTool5, ButtonTool7, ButtonTool8, StateButtonTool6})
        '
        '_frmMainForm_Toolbars_Dock_Area_Right
        '
        Me._frmMainForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMainForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
        Me._frmMainForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._frmMainForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMainForm_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(642, 21)
        Me._frmMainForm_Toolbars_Dock_Area_Right.Name = "_frmMainForm_Toolbars_Dock_Area_Right"
        Me._frmMainForm_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 769)
        Me._frmMainForm_Toolbars_Dock_Area_Right.ToolbarsManager = Me.tlbUltraToolbarManager
        '
        '_frmMainForm_Toolbars_Dock_Area_Top
        '
        Me._frmMainForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMainForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
        Me._frmMainForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._frmMainForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMainForm_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._frmMainForm_Toolbars_Dock_Area_Top.Name = "_frmMainForm_Toolbars_Dock_Area_Top"
        Me._frmMainForm_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(642, 21)
        Me._frmMainForm_Toolbars_Dock_Area_Top.ToolbarsManager = Me.tlbUltraToolbarManager
        '
        '_frmMainForm_Toolbars_Dock_Area_Bottom
        '
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 790)
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.Name = "_frmMainForm_Toolbars_Dock_Area_Bottom"
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(642, 0)
        Me._frmMainForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.tlbUltraToolbarManager
        '
        'frmMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 790)
        Me.Controls.Add(Me.frmMainForm_Fill_Panel)
        Me.Controls.Add(Me._frmMainForm_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._frmMainForm_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._frmMainForm_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._frmMainForm_Toolbars_Dock_Area_Bottom)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQL Server Stored Procedure Script Generator"
        CType(Me.erpFormErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmMainForm_Fill_Panel.ResumeLayout(False)
        Me.frmMainForm_Fill_Panel.PerformLayout()
        CType(Me.tlbUltraToolbarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbDatabases As System.Windows.Forms.ComboBox
    Friend WithEvents lvwObjectsToScript As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkGenerateConfig As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerateToFile As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGenerateToClipboard As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnConnectToServer As Infragistics.Win.Misc.UltraButton
    Friend WithEvents erpFormErrors As System.Windows.Forms.ErrorProvider
    Friend WithEvents imgGraphics As System.Windows.Forms.ImageList
    Friend WithEvents chkWindowsAuthentication As System.Windows.Forms.CheckBox
    Friend WithEvents mglListViewImages As System.Windows.Forms.ImageList
    Friend WithEvents tlbUltraToolbarManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents frmMainForm_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _frmMainForm_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmMainForm_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmMainForm_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmMainForm_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea

End Class
