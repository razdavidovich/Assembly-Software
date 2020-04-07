Imports System.Data.SqlClient
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Assembly.Software.DB
Imports Assembly.Software.Utilities

Public Class frmBaseTables
    Inherits System.Windows.Forms.Form

#Region "Class Private Variables"
    Private dtsTablesRepository As New DataSet
    Private strConnectionString As String

    Private prmOptionalSQLParams As SqlParameter()
    Private objOptionalValues As Object()
    Private intPrevGroupID As Integer 'To store the previous Group ID in case if we shift to new group with out saving the current
    Private strPrevTabID As String 'To store the previous Tab ID in case if we shift to new group with out saving the current

#End Region

#Region " Windows Form Designer generated code "

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents trvTables As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents ulgSpecRev As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ulgSpecType As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ulgPpmCategory As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ulgParamType As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ulgUnitType As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ulgDutParam As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tabBaseTable As Infragistics.Win.UltraWinTabControl.UltraTabStripControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents grdBaseTable As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ultBaseTableToolbar As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _frmBaseTables_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmBaseTables_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmBaseTables_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmBaseTables_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents imgToolbar As System.Windows.Forms.ImageList
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents usbStatus As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaseTables))
        Dim UltraStatusPanel2 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel3 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraStatusPanel4 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel5 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel6 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel7 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel8 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("MainToolbar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Save")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Use Column Click Sorting", "")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("UseRowFiltering", "")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MutliColumnSorting")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SearchTable")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Blank")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SearchTable")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("UseRowFiltering", "")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MutliColumnSorting")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Use Column Click Sorting", "")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("About")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Blank")
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Save")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.trvTables = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.usbStatus = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.imgToolbar = New System.Windows.Forms.ImageList(Me.components)
        Me.ulgSpecRev = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ulgSpecType = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ulgPpmCategory = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ulgParamType = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ulgUnitType = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ulgDutParam = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tabBaseTable = New Infragistics.Win.UltraWinTabControl.UltraTabStripControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.grdBaseTable = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ultBaseTableToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._frmBaseTables_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmBaseTables_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmBaseTables_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.Panel1.SuspendLayout()
        CType(Me.trvTables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.usbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulgSpecRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulgSpecType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulgPpmCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulgParamType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulgUnitType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulgDutParam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabBaseTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBaseTable.SuspendLayout()
        Me.UltraTabSharedControlsPage2.SuspendLayout()
        CType(Me.grdBaseTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultBaseTableToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Verdana", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Purple
        Me.Label2.Location = New System.Drawing.Point(8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(992, 32)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Application Base Tables"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 40)
        Me.Panel1.TabIndex = 8
        '
        'trvTables
        '
        Me.trvTables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trvTables.HideSelection = False
        Me.trvTables.Location = New System.Drawing.Point(0, 80)
        Me.trvTables.Name = "trvTables"
        Me.trvTables.Size = New System.Drawing.Size(128, 574)
        Me.trvTables.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.usbStatus)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 653)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 24)
        Me.Panel2.TabIndex = 10
        '
        'usbStatus
        '
        Me.usbStatus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usbStatus.Location = New System.Drawing.Point(0, 1)
        Me.usbStatus.Name = "usbStatus"
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        UltraStatusPanel1.Appearance = Appearance1
        UltraStatusPanel1.Key = "About"
        UltraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button
        UltraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring
        UltraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.AutoStatusText
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.ForeColor = System.Drawing.Color.Green
        UltraStatusPanel3.Appearance = Appearance2
        UltraStatusPanel3.Key = "Version"
        UltraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.KeyState
        UltraStatusPanel5.KeyStateInfo.Key = Infragistics.Win.UltraWinStatusBar.KeyState.CapsLock
        UltraStatusPanel5.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.KeyState
        UltraStatusPanel6.KeyStateInfo.Key = Infragistics.Win.UltraWinStatusBar.KeyState.InsertMode
        UltraStatusPanel6.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.KeyState
        UltraStatusPanel7.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel7.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.[Date]
        UltraStatusPanel8.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel8.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time
        Me.usbStatus.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1, UltraStatusPanel2, UltraStatusPanel3, UltraStatusPanel4, UltraStatusPanel5, UltraStatusPanel6, UltraStatusPanel7, UltraStatusPanel8})
        Me.usbStatus.Size = New System.Drawing.Size(1008, 23)
        Me.usbStatus.TabIndex = 23
        Me.usbStatus.Text = "UltraStatusBar1"
        '
        'imgToolbar
        '
        Me.imgToolbar.ImageStream = CType(resources.GetObject("imgToolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgToolbar.TransparentColor = System.Drawing.Color.Transparent
        Me.imgToolbar.Images.SetKeyName(0, "")
        Me.imgToolbar.Images.SetKeyName(1, "")
        Me.imgToolbar.Images.SetKeyName(2, "")
        Me.imgToolbar.Images.SetKeyName(3, "")
        Me.imgToolbar.Images.SetKeyName(4, "")
        Me.imgToolbar.Images.SetKeyName(5, "")
        Me.imgToolbar.Images.SetKeyName(6, "")
        '
        'ulgSpecRev
        '
        Me.ulgSpecRev.Cursor = System.Windows.Forms.Cursors.Default
        Me.ulgSpecRev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulgSpecRev.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulgSpecRev.Location = New System.Drawing.Point(0, 0)
        Me.ulgSpecRev.Name = "ulgSpecRev"
        Me.ulgSpecRev.Size = New System.Drawing.Size(737, 345)
        Me.ulgSpecRev.TabIndex = 1
        '
        'ulgSpecType
        '
        Me.ulgSpecType.Cursor = System.Windows.Forms.Cursors.Default
        Me.ulgSpecType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulgSpecType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulgSpecType.Location = New System.Drawing.Point(0, 0)
        Me.ulgSpecType.Name = "ulgSpecType"
        Me.ulgSpecType.Size = New System.Drawing.Size(737, 345)
        Me.ulgSpecType.TabIndex = 2
        '
        'ulgPpmCategory
        '
        Me.ulgPpmCategory.Cursor = System.Windows.Forms.Cursors.Default
        Me.ulgPpmCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulgPpmCategory.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulgPpmCategory.Location = New System.Drawing.Point(0, 0)
        Me.ulgPpmCategory.Name = "ulgPpmCategory"
        Me.ulgPpmCategory.Size = New System.Drawing.Size(737, 345)
        Me.ulgPpmCategory.TabIndex = 8
        '
        'ulgParamType
        '
        Me.ulgParamType.Cursor = System.Windows.Forms.Cursors.Default
        Me.ulgParamType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulgParamType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulgParamType.Location = New System.Drawing.Point(0, 0)
        Me.ulgParamType.Name = "ulgParamType"
        Me.ulgParamType.Size = New System.Drawing.Size(737, 345)
        Me.ulgParamType.TabIndex = 7
        '
        'ulgUnitType
        '
        Me.ulgUnitType.Cursor = System.Windows.Forms.Cursors.Default
        Me.ulgUnitType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulgUnitType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulgUnitType.Location = New System.Drawing.Point(0, 0)
        Me.ulgUnitType.Name = "ulgUnitType"
        Me.ulgUnitType.Size = New System.Drawing.Size(737, 345)
        Me.ulgUnitType.TabIndex = 8
        '
        'ulgDutParam
        '
        Me.ulgDutParam.Cursor = System.Windows.Forms.Cursors.Default
        Me.ulgDutParam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulgDutParam.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulgDutParam.Location = New System.Drawing.Point(0, 0)
        Me.ulgDutParam.Name = "ulgDutParam"
        Me.ulgDutParam.Size = New System.Drawing.Size(737, 345)
        Me.ulgDutParam.TabIndex = 3
        '
        'tabBaseTable
        '
        Me.tabBaseTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabBaseTable.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.tabBaseTable.Location = New System.Drawing.Point(128, 80)
        Me.tabBaseTable.Name = "tabBaseTable"
        Me.tabBaseTable.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.grdBaseTable})
        Me.tabBaseTable.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.tabBaseTable.Size = New System.Drawing.Size(880, 575)
        Me.tabBaseTable.TabIndex = 12
        Me.tabBaseTable.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowSizeToFit
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Controls.Add(Me.grdBaseTable)
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(876, 552)
        '
        'grdBaseTable
        '
        Me.grdBaseTable.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance3.BackColor = System.Drawing.Color.White
        Me.grdBaseTable.DisplayLayout.Appearance = Appearance3
        Me.grdBaseTable.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.grdBaseTable.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 10.0!
        Appearance5.ForeColor = System.Drawing.Color.White
        Appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.grdBaseTable.DisplayLayout.Override.HeaderAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.grdBaseTable.DisplayLayout.Override.RowSelectorAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.grdBaseTable.DisplayLayout.Override.SelectedRowAppearance = Appearance7
        Me.grdBaseTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBaseTable.Location = New System.Drawing.Point(0, 0)
        Me.grdBaseTable.Name = "grdBaseTable"
        Me.grdBaseTable.Size = New System.Drawing.Size(876, 552)
        Me.grdBaseTable.TabIndex = 0
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(737, 358)
        '
        'ultBaseTableToolbar
        '
        Me.ultBaseTableToolbar.AlwaysShowMenusExpanded = Infragistics.Win.DefaultableBoolean.[True]
        Me.ultBaseTableToolbar.DesignerFlags = 1
        Me.ultBaseTableToolbar.DockWithinContainer = Me
        Me.ultBaseTableToolbar.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.ultBaseTableToolbar.ImageListLarge = Me.imgToolbar
        Me.ultBaseTableToolbar.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.IsMainMenuBar = True
        StateButtonTool1.InstanceProps.IsFirstInGroup = True
        LabelTool1.InstanceProps.IsFirstInGroup = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, StateButtonTool1, StateButtonTool2, ButtonTool2, ButtonTool3, LabelTool1, ButtonTool4})
        UltraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.[True]
        UltraToolbar1.Text = "MainToolbar"
        Me.ultBaseTableToolbar.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance8.Image = 0
        ButtonTool5.SharedPropsInternal.AppearancesLarge.Appearance = Appearance8
        ButtonTool5.SharedPropsInternal.Caption = "&Search Table"
        ButtonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool5.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Appearance9.Image = 2
        StateButtonTool3.SharedPropsInternal.AppearancesLarge.Appearance = Appearance9
        StateButtonTool3.SharedPropsInternal.Caption = "&Use Row Filtering"
        StateButtonTool3.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance10.Image = 3
        ButtonTool6.SharedPropsInternal.AppearancesLarge.Appearance = Appearance10
        ButtonTool6.SharedPropsInternal.Caption = "&Mutli Column Sorting"
        ButtonTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance11.Image = 1
        StateButtonTool4.SharedPropsInternal.AppearancesLarge.Appearance = Appearance11
        StateButtonTool4.SharedPropsInternal.Caption = "Use &Column Click Sorting"
        StateButtonTool4.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance12.Image = 5
        ButtonTool7.SharedPropsInternal.AppearancesLarge.Appearance = Appearance12
        ButtonTool7.SharedPropsInternal.Caption = "&About The Software"
        ButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance13.Image = 6
        ButtonTool8.SharedPropsInternal.AppearancesLarge.Appearance = Appearance13
        ButtonTool8.SharedPropsInternal.Caption = "&Exit"
        ButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        LabelTool2.SharedPropsInternal.Spring = True
        Appearance14.Image = 4
        ButtonTool9.SharedPropsInternal.AppearancesLarge.Appearance = Appearance14
        ButtonTool9.SharedPropsInternal.Caption = "Save Data"
        ButtonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.ultBaseTableToolbar.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool5, StateButtonTool3, ButtonTool6, StateButtonTool4, ButtonTool7, ButtonTool8, LabelTool2, ButtonTool9})
        Me.ultBaseTableToolbar.UseLargeImagesOnToolbar = True
        '
        '_frmBaseTables_Toolbars_Dock_Area_Left
        '
        Me._frmBaseTables_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmBaseTables_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
        Me._frmBaseTables_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._frmBaseTables_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmBaseTables_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 43)
        Me._frmBaseTables_Toolbars_Dock_Area_Left.Name = "_frmBaseTables_Toolbars_Dock_Area_Left"
        Me._frmBaseTables_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 634)
        Me._frmBaseTables_Toolbars_Dock_Area_Left.ToolbarsManager = Me.ultBaseTableToolbar
        '
        '_frmBaseTables_Toolbars_Dock_Area_Right
        '
        Me._frmBaseTables_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmBaseTables_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
        Me._frmBaseTables_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._frmBaseTables_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmBaseTables_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(1008, 43)
        Me._frmBaseTables_Toolbars_Dock_Area_Right.Name = "_frmBaseTables_Toolbars_Dock_Area_Right"
        Me._frmBaseTables_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 634)
        Me._frmBaseTables_Toolbars_Dock_Area_Right.ToolbarsManager = Me.ultBaseTableToolbar
        '
        '_frmBaseTables_Toolbars_Dock_Area_Top
        '
        Me._frmBaseTables_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmBaseTables_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
        Me._frmBaseTables_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._frmBaseTables_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmBaseTables_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._frmBaseTables_Toolbars_Dock_Area_Top.Name = "_frmBaseTables_Toolbars_Dock_Area_Top"
        Me._frmBaseTables_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(1008, 43)
        Me._frmBaseTables_Toolbars_Dock_Area_Top.ToolbarsManager = Me.ultBaseTableToolbar
        '
        '_frmBaseTables_Toolbars_Dock_Area_Bottom
        '
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 677)
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.Name = "_frmBaseTables_Toolbars_Dock_Area_Bottom"
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(1008, 0)
        Me._frmBaseTables_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.ultBaseTableToolbar
        '
        'frmBaseTables
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1008, 677)
        Me.Controls.Add(Me.tabBaseTable)
        Me.Controls.Add(Me.trvTables)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me._frmBaseTables_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._frmBaseTables_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._frmBaseTables_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._frmBaseTables_Toolbars_Dock_Area_Top)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBaseTables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add\Edit Base Tables Information"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.trvTables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.usbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulgSpecRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulgSpecType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulgPpmCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulgParamType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulgUnitType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulgDutParam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabBaseTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBaseTable.ResumeLayout(False)
        Me.UltraTabSharedControlsPage2.ResumeLayout(False)
        CType(Me.grdBaseTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultBaseTableToolbar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Overload constructors"

    Public Sub New(ByVal strConnectionString As String, _
                   Optional prmOptionalSQLParams As SqlParameter() = Nothing, Optional objOptionalValues As Object() = Nothing)

        'Call the next constructor in line
        Me.New(strConnectionString, 1, prmOptionalSQLParams, objOptionalValues)

    End Sub

    Public Sub New(ByVal strConnectionString As String, ByVal intGroupID As Integer, _
                   Optional prmOptionalSQLParams As SqlParameter() = Nothing, Optional objOptionalValues As Object() = Nothing)

        'Call the next constructor in line
        Me.New(strConnectionString, intGroupID, 1, prmOptionalSQLParams, objOptionalValues)

    End Sub

    Public Sub New(ByVal strConnectionString As String, ByVal intGroupID As Integer, ByVal intTableID As Integer, _
                   Optional prmOptionalSQLParams As SqlParameter() = Nothing, Optional objOptionalValues As Object() = Nothing)

        MyBase.New()

        'Get the connection string from the config file
        Me.strConnectionString = strConnectionString

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Set the optional parameters and values
        Me.prmOptionalSQLParams = prmOptionalSQLParams
        Me.objOptionalValues = objOptionalValues

        'Load the group tree
        LoadTablesGroups(intGroupID)

        'Load the tables into the Group
        LoadTablesInGroup(intGroupID, intTableID)

    End Sub

#End Region

#Region "Private functions"

    Private Sub LoadTablesGroups(Optional ByVal intDefaultGroupID As Integer = 1)
        '*************************************************************************
        '* Function Name:   LoadTablesGroups
        '* Description:     This sub loads the tables group into the group tree 
        '* Created by:      Raz Davidovich
        '* Created date:    30/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode

        'Get the number of groups from the config file
        Dim intGroupCount As Integer = CType(Config.ReadConfigValue("NoOfGroup", "General", "BaseTables"), Integer)

        'Loop and load the tables group into the group tree
        Dim strTempGroupName As String
        For I As Integer = 1 To intGroupCount
            'Get the group name
            strTempGroupName = Config.ReadConfigValue("Group_Name", "Group_" & I.ToString, "BaseTables")

            'Load the group to the tree
            aNode = trvTables.Nodes.Add("Group_" + I.ToString, strTempGroupName)
        Next

        'Select the default group
        trvTables.Nodes("Group_" & intDefaultGroupID.ToString).Selected = True

    End Sub


    Private Sub LoadTablesInGroup(ByVal intGroupID As Integer, Optional ByVal intDefaultTableID As Integer = 1)
        '*************************************************************************
        '* Function Name:   LoadTablesInGroup
        '* Description:     This sub loads the table into a selected group
        '* Created by:      Raz Davidovich
        '* Created date:    30/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Get the number of groups from the config file
        Dim intTableCount As Integer = CType(Config.ReadConfigValue("NoOfTables", "Group_" & intGroupID.ToString, "BaseTables"), Integer)

        If tabBaseTable.Tabs.Count > 0 Then strPrevTabID = tabBaseTable.ActiveTab.Key
        'Clear all tabs
        tabBaseTable.Tabs.Clear()

        'Loop and load the tables group into the group tree
        Dim strTempTabName As String
        For I As Integer = 1 To intTableCount
            'Get the group name
            strTempTabName = Config.ReadConfigValue("Table_" + I.ToString + "_Text", "Group_" & intGroupID.ToString, "BaseTables")

            'Add a Tab to the Interface
            tabBaseTable.Tabs.Add("Table_" + I.ToString, strTempTabName)

        Next

        'Select the default tab
        tabBaseTable.Tabs("Table_" + intDefaultTableID.ToString).Selected = True

        'Load the data to the defult tab
        SelectTab(tabBaseTable.Tabs("Table_" + intDefaultTableID.ToString).Key)

    End Sub

    Private Function GetTableDataForTableID(ByVal intGroupID As Integer, ByVal intTableID As Integer, _
        Optional ByVal blnReloadTable As Boolean = False) As DataTable
        '*************************************************************************
        '* Function Name:   GetTableDataForTableID
        '* Description:     This sub loads the data for the table from the 
        '*                  database or the dataset if its exists there
        '* Created by:      Raz Davidovich
        '* Created date:    31/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTempTableName As String

        'Get the table name (key in the dataset object)
        strTempTableName = Config.ReadConfigValue("Table_" + intTableID.ToString + "_Name", "Group_" & intGroupID.ToString, "BaseTables")

        'Try to extract the table from the locally cached dataset
        Dim dtlTempDataTable As DataTable = dtsTablesRepository.Tables(strTempTableName)

        If dtlTempDataTable Is Nothing Then
            'Get the table from the database into the cache dataset
            dtsTablesRepository.Tables.Add(GetTableDataFromDB(intGroupID, intTableID))
            dtsTablesRepository.Tables(dtsTablesRepository.Tables.Count - 1).TableName = strTempTableName
            dtlTempDataTable = dtsTablesRepository.Tables(strTempTableName)
        Else
            'If we need to reload the table 
            If blnReloadTable Then
                'Remove the table from the repository
                dtsTablesRepository.Tables.Remove(strTempTableName)

                'Load the table from the database
                'Get the table from the database into the cache dataset
                dtsTablesRepository.Tables.Add(GetTableDataFromDB(intGroupID, intTableID))
                dtsTablesRepository.Tables(dtsTablesRepository.Tables.Count - 1).TableName = strTempTableName
                dtlTempDataTable = dtsTablesRepository.Tables(strTempTableName)

            End If
        End If

        If Not prmOptionalSQLParams Is Nothing Then
            'Set the default value for column names that matches the optional parameters
            For Each prmParam As SqlParameter In prmOptionalSQLParams
                'Get the optional parameter name (same as the column name without the @ charecter) 
                Dim strColumnName As String = prmParam.ParameterName.Replace("@", String.Empty)

                'Try to look the column name in the datatable in case of exception (not such column name) keep looping
                Try
                    dtlTempDataTable.Columns(strColumnName).DefaultValue = objOptionalValues(Array.IndexOf(prmOptionalSQLParams, prmParam))
                Catch ex As Exception

                End Try
            Next
        End If

        'Return the data table
        Return dtlTempDataTable

    End Function

    Private Function GetTableDataFromDB(ByVal intGroupID As Integer, ByVal intTableID As Integer) As DataTable
        '*************************************************************************
        '* Function Name:   GetTableDataFromDB
        '* Description:     This sub loads the data for the table from the 
        '*                  database
        '* Created by:      Raz Davidovich
        '* Created date:    31/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strTempSPName As String = String.Empty
        Dim prmSQLParams As SqlParameter() = {New SqlParameter("@Operation", SqlDbType.Int, 4)}
        Dim objValues As Object() = New Object() {1}
        Dim intIndex As Integer

        Try

            'Create the optional parameters and values (in case they were supplied by the user)
            If (Not Me.prmOptionalSQLParams Is Nothing) Then
                If (Me.prmOptionalSQLParams.Length > 0) Then
                    ReDim Preserve prmSQLParams(prmOptionalSQLParams.Length)
                    ReDim Preserve objValues(prmOptionalSQLParams.Length)

                    'Add the optional parameters & values to the existing arrays
                    For intIndex = 1 To prmOptionalSQLParams.Length
                        prmSQLParams(intIndex) = prmOptionalSQLParams(intIndex - 1)
                        objValues(intIndex) = objOptionalValues(intIndex - 1)
                    Next
                End If
            End If

            Dim objDB As New DBHelper(strConnectionString, DBHelper.Connection_Type.SQL_Server)

            'Get the table stored procedure name
            strTempSPName = Config.ReadConfigValue("Table_" + intTableID.ToString + "_SP", "Group_" & intGroupID.ToString, "BaseTables")

            'Get datatable from the database
            Return objDB.FillDataTableFromSP(strTempSPName, prmSQLParams, objValues)

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
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


    Private Function GetGridComboboxData(ByVal intGridComboID As Integer, Optional ByVal intWhere As Integer = Nothing) As DataTable
        '*************************************************************************
        '* Function Name:   GetGridComboboxData
        '* Description:     This sub loads the data for the table from the 
        '*                  database
        '* Created by:      Raz Davidovich
        '* Created date:    31/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim prmSQLParams As SqlParameter() = {New SqlParameter("@intComboID", SqlDbType.Int, 4), _
                                    New SqlParameter("@WhereParam", SqlDbType.Int, 4)}
        Dim objValues As Object() = New Object() {intGridComboID, intWhere}
        Dim intIndex As Integer

        Try

            'Create the optional parameters and values (in case they were supplied by the user)
            If (Not Me.prmOptionalSQLParams Is Nothing) Then
                If (Me.prmOptionalSQLParams.Length > 0) Then
                    ReDim Preserve prmSQLParams(prmOptionalSQLParams.Length)
                    ReDim Preserve objValues(prmOptionalSQLParams.Length)

                    'Add the optional parameters & values to the existing arrays
                    For intIndex = 1 To prmOptionalSQLParams.Length
                        prmSQLParams(intIndex) = prmOptionalSQLParams(intIndex - 1)
                        objValues(intIndex) = objOptionalValues(intIndex - 1)
                    Next
                End If
            End If

            Dim objDB As New DBHelper(strConnectionString, DBHelper.Connection_Type.SQL_Server)

            'Get datatable from the database
            Return objDB.FillDataTableFromSP("dbo.FillGridCombobox_Sp", prmSQLParams, objValues)

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try

    End Function

    Private Function SaveBaseTableChanges(ByVal dtlBaseTableChangedRows As DataTable) As Boolean
        '*************************************************************************
        '* Function Name:   SaveBaseTableChanges
        '* Description:     This sub loops through the changed rows and save them
        '*                  to the database
        '* Created by:      Raz Davidovich
        '* Created date:    12/10/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim objDB As New DBHelper(strConnectionString, DBHelper.Connection_Type.SQL_Server)
        Dim dtrRow As DataRow
        Dim colKeys() As String = GetTableColumnKeys()
        Dim intNumberOfKeys As Integer = colKeys.GetLength(0)
        Dim intNumberOfColumns As Integer = dtlBaseTableChangedRows.Columns.Count
        Dim intParameterID As Integer = 0
        Dim I As Integer

        'Generate the parameters array
        Dim prmParam(intNumberOfColumns + intNumberOfKeys) As SqlParameter
        Dim objValues(intNumberOfColumns + intNumberOfKeys) As Object
        Try


            '=========================
            'Fill the paarmeters array
            '=========================
            prmParam(intParameterID) = New SqlParameter("@Operation", SqlDbType.Int, 4, ParameterDirection.Input)
            For I = 0 To (intNumberOfColumns - 1)
                intParameterID += 1
                prmParam(intParameterID) = New SqlParameter(GenerateParameter(dtlBaseTableChangedRows.Columns(I).ColumnName), GetSQLParameterType(dtlBaseTableChangedRows.Columns(I).DataType))
            Next

            For I = 0 To (intNumberOfKeys - 1)
                intParameterID += 1
                prmParam(intParameterID) = New SqlParameter("@Key" + (I + 1).ToString, GetSQLParameterType(dtlBaseTableChangedRows.Columns(CType(colKeys(I), Integer)).DataType))
            Next


            'Loop the changed rows
            For Each dtrRow In dtlBaseTableChangedRows.Rows
                'Reset the parameter ID for the row
                intParameterID = 0

                'Create the operation parameter value
                If (dtrRow.RowState = DataRowState.Deleted) Then
                    objValues(intParameterID) = 3
                Else
                    objValues(intParameterID) = 2
                End If

                'Create the rest of the table values
                For I = 0 To (intNumberOfColumns - 1)
                    intParameterID += 1
                    If (dtrRow.RowState = DataRowState.Deleted) Then
                        objValues(intParameterID) = dtrRow(I, DataRowVersion.Original)
                    Else
                        'Prevent null data errors
                        If dtlBaseTableChangedRows.Columns(I).AllowDBNull Then
                            objValues(intParameterID) = dtrRow(I)

                        Else
                            If dtrRow.IsNull(I) Then
                                objValues(intParameterID) = String.Empty
                            Else
                                objValues(intParameterID) = dtrRow(I)

                            End If

                        End If

                    End If

                Next

                'Create the keys values
                For I = 0 To (intNumberOfKeys - 1)
                    intParameterID += 1
                    If (dtrRow.RowState = DataRowState.Added) Then
                        objValues(intParameterID) = dtrRow(CType(colKeys(I), Integer))
                    Else
                        objValues(intParameterID) = dtrRow(CType(colKeys(I), Integer), DataRowVersion.Original)
                    End If

                Next

                'Save\Delete the row data to the database
                If Not objDB.RunSP(GetTableStoredProcedureName(), prmParam, objValues) Then Return False
            Next

            'Clear the all objects
            objDB = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        'ALL OK, return true
        Return True

    End Function

    Private Function GetTableColumnKeys() As String()
        '*************************************************************************
        '* Function Name:   GetTableColumnKeys
        '* Description:     This function returns a string array which contains 
        '*                  column column keys index in the table
        '* Created by:      Raz Davidovich
        '* Created date:    28/03/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Build the group ID and table ID for the keys retrival
        'Get the Group ID
        Dim intGroupID As Integer
        Dim strActiveTab As String
        If intPrevGroupID <> 0 Then 'Checks whether this is being called with in the same group or from different group
            intGroupID = intPrevGroupID
        Else
            intGroupID = CType(trvTables.SelectedNodes(0).Key.Substring(trvTables.SelectedNodes(0).Key.LastIndexOf("_") + 1), Integer)
        End If
        If Not IsNothing(strPrevTabID) Then
            strActiveTab = strPrevTabID
        Else
            strActiveTab = tabBaseTable.ActiveTab.Key.ToString
        End If
        'Get the keys string from the config file
        Dim strKeys As String = Config.ReadConfigValue(strActiveTab + "_Keys", "Group_" + intGroupID.ToString, "BaseTables")

        'Return the splited values
        Return Split(strKeys, ",", , CompareMethod.Text)

    End Function

    Private Function GetTableStoredProcedureName() As String
        '*************************************************************************
        '* Function Name:   GetTableStoredProcedureName
        '* Description:     This function returns the stored procedure used for
        '*                  saving the data into the base table
        '* Created by:      Raz Davidovich
        '* Created date:    29/03/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Build the group ID and table ID for the stored procedure name retrival
        'Get the Group ID
        Dim intGroupID As Integer
        Dim strActiveTab As String

        If intPrevGroupID <> 0 Then 'Checks whether this is from the same group or from the different group
            intGroupID = intPrevGroupID
        Else
            intGroupID = CType(trvTables.SelectedNodes(0).Key.Substring(trvTables.SelectedNodes(0).Key.LastIndexOf("_") + 1), Integer)
        End If
        If IsNothing(tabBaseTable.ActiveTab) Then
            strActiveTab = strPrevTabID
        Else
            strActiveTab = tabBaseTable.ActiveTab.Key.ToString
        End If
        'Return the stored procedure name
        Return Config.ReadConfigValue(strActiveTab + "_SP", "Group_" + intGroupID.ToString, "BaseTables")

    End Function

    Private Function CheckIfNeedToSave() As Boolean
        '*************************************************************************
        '* Function Name:   CheckIfNeedToSave
        '* Description:     This function return true if the current grid data
        '*                  was changed, and some data needs to be saved
        '* Created by:      Raz Davidovich
        '* Created date:    16/02/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        'Get the changed rows for the current base table
        Dim dtlBaseTable As DataTable = grdBaseTable.DataSource.GetChanges()

        'Check if any changes were made
        If dtlBaseTable Is Nothing Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function GetSQLParameterType(ByVal typDataType As System.Type) As System.Data.SqlDbType
        '*************************************************************************
        '* Function Name:   GetSQLParameterType
        '* Description:     This function converts a given system type to SQL DB
        '*                  data type
        '* Created by:      Raz Davidovich
        '* Created date:    01/03/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Select Case typDataType.ToString
            Case "System.String"
                Return SqlDbType.NVarChar
            Case "System.Integer"
                Return SqlDbType.Int
            Case "System.Int64"
                Return SqlDbType.BigInt
            Case "System.Boolean"
                Return SqlDbType.Bit
            Case "System.DateTime"
                Return SqlDbType.DateTime
            Case "System.Decimal"
                Return SqlDbType.Decimal
            Case "System.Double"
                Return SqlDbType.Float
            Case "System.Int32"
                Return SqlDbType.Int
            Case "System.Single"
                Return SqlDbType.Real
            Case "System.Guid"
                Return SqlDbType.UniqueIdentifier
        End Select

    End Function

    Private Sub trvTables_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles trvTables.AfterSelect
        'Get the Group ID
        Dim intGroupID As Integer = CType(trvTables.SelectedNodes(0).Key.Substring(trvTables.SelectedNodes(0).Key.LastIndexOf("_") + 1), Integer)

        'Load the table tabs 
        LoadTablesInGroup(intGroupID)

        intPrevGroupID = intGroupID 'Assigning the previous Group ID so that when they shift to new ones i need to save if the old ones are modified
    End Sub

    Private Sub tabBaseTable_ActiveTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs) Handles tabBaseTable.ActiveTabChanged
        'Select the tab changed by the user
        SelectTab(e.Tab.Key)
    End Sub

    Private Sub grdBaseTable_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdBaseTable.InitializeLayout

        Dim intComboID As Integer
        Dim intMultiColumnComboID As Integer
        Dim strColumnCaption As String
        Dim blnHideColumn As Boolean
        Dim strActiveTab As String

        'Get the Group ID
        Dim intGroupID As Integer = CType(trvTables.SelectedNodes(0).Key.Substring(trvTables.SelectedNodes(0).Key.LastIndexOf("_") + 1), Integer)

        With e.Layout
            'Clear all previous value lists
            .ValueLists.Clear()
            If IsNothing(tabBaseTable.ActiveTab) Then
                strActiveTab = "Table_1"
            Else
                strActiveTab = tabBaseTable.ActiveTab.Key.ToString
            End If

            'Loop the grid columns and load combobox if needed
            For I As Integer = 0 To .Bands(0).Columns.Count - 1

                blnHideColumn = "False"
                'Get the combo ID from the config file
                intComboID = Config.ReadConfigValue(strActiveTab + "_Col_" + I.ToString + "_ComboID", "Group_" + intGroupID.ToString, "BaseTables")
                intMultiColumnComboID = Config.ReadConfigValue(strActiveTab + "_Col_" + I.ToString + "_MultiColumnComboID", "Group_" + intGroupID.ToString, "BaseTables")
                strColumnCaption = Config.ReadConfigValue(strActiveTab + "_Col_" + I.ToString + "_Caption", "Group_" + intGroupID.ToString, "BaseTables")

                'Read the hide column setting for the current column
                blnHideColumn =
                IIf(Config.ReadConfigValue(strActiveTab + "_Col_" + I.ToString + "_Hide", "Group_" + intGroupID.ToString, "BaseTables") = Nothing _
                                    , blnHideColumn,
                                   Config.ReadConfigValue(strActiveTab + "_Col_" + I.ToString + "_Hide", "Group_" + intGroupID.ToString, "BaseTables"))

                'Set the column caption
                If Not (strColumnCaption Is Nothing) Then e.Layout.Bands(0).Columns(I).Header.Caption = strColumnCaption
                e.Layout.Bands(0).Columns(I).Hidden = blnHideColumn

                'If combo Id was found for this column, load the value list to the grid
                If intComboID = 0 Then
                    .Bands(0).Columns(I).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
                    .Bands(0).Columns(I).ValueList = Nothing

                Else

                    'Add a new value list
                    .ValueLists.Add("Column_" + I.ToString)

                    'Get the value list data from the database
                    Dim dtlValuelist As DataTable = GetGridComboboxData(intComboID)

                    'Add the countries to the value list
                    Dim tmpRow As DataRow
                    For Each tmpRow In dtlValuelist.Rows
                        With .ValueLists("Column_" + I.ToString).ValueListItems
                            .Add(tmpRow.Item(0), tmpRow.Item(1))
                        End With
                    Next

                    'Connect the column to the value list and set its type to dropdown list
                    .Bands(0).Columns(I).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                    .Bands(0).Columns(I).ValueList = .ValueLists("Column_" + I.ToString)

                End If

                'If multi column combo Id was found for this column, set it's editor to UltraDropDown
                If intMultiColumnComboID = 0 Then
                    .Bands(0).Columns(I).Editor = Nothing
                Else
                    .Bands(0).Columns(I).Editor = DirectCast(SetMultiColumnCombobox(I, intGroupID, intMultiColumnComboID), EmbeddableEditorBase)
                End If

            Next
        End With

        'Set the Auto column fit property (1 to Autofit) 
        e.Layout.AutoFitStyle = Convert.ToInt32(Config.ReadConfigValue(strActiveTab + "_AutoFitColumns", "Group_" + intGroupID.ToString, "BaseTables"))

    End Sub

    Private Sub ReloadCurrentTable(ByVal strTabKey As String)
        '*************************************************************************
        '* Function Name:   ReloadCurrentTable
        '* Description:     This sub reloads a base table from the database into 
        '*                  the cached dataset
        '* Created by:      Raz Davidovich
        '* Created date:    03/04/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Get the Group ID
        Dim intGroupID As Integer = CType(trvTables.SelectedNodes(0).Key.Substring(trvTables.SelectedNodes(0).Key.LastIndexOf("_") + 1), Integer)

        'Get the table ID
        Dim intTableID As Integer = CType(strTabKey.Substring(strTabKey.LastIndexOf("_") + 1), Integer)

        'Connect the grid to a data table
        grdBaseTable.DataSource = GetTableDataForTableID(intGroupID, intTableID, True)

    End Sub

    Private Sub tabBaseTable_ActiveTabChanging(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventArgs) Handles tabBaseTable.ActiveTabChanging
        'Check if there is data to save
        If CheckIfNeedToSave() Then

            'Ask the user if he wish to save the data
            If General.DisplayMessageBoxLTR(7) = MsgBoxResult.Yes Then
                'Save the data
                If SaveData() Then
                    grdBaseTable.ActiveRow.Update()
                    If IsNothing(tabBaseTable.ActiveTab) Then
                        ReloadCurrentTable("1")
                    Else
                        ReloadCurrentTable(tabBaseTable.ActiveTab.Key)
                    End If


                    'Display a success message
                    General.DisplayMessageBoxLTR(5)
                Else
                    'Display an error  message
                    General.DisplayMessageBoxLTR(6)

                End If
            End If
        End If

    End Sub

    Private Sub ultBaseTableToolbar_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ultBaseTableToolbar.ToolClick
        Select Case e.Tool.Key
            Case "Save"
                'Get the Grid active row
                Dim row As UltraGridRow = Me.grdBaseTable.ActiveRow

                If Not row Is Nothing Then
                    ' Update the row. This will call EndEdit on the underlying data row.
                    row.Update()
                End If

                'Check if any changes were made
                If CheckIfNeedToSave() Then
                    intPrevGroupID = 0 'Clearing the old Group ID 
                    strPrevTabID = Nothing 'Clearing the old Tab ID Active
                    If SaveData() Then
                        'Reload the current table to the tables repository
                        ReloadCurrentTable(tabBaseTable.SelectedTab.Key)

                        'Display a success message
                        General.DisplayMessageBoxLTR(5)
                    Else
                        'Display an error  message
                        General.DisplayMessageBoxLTR(6)
                    End If
                Else
                    'Display a success message
                    General.DisplayMessageBoxLTR(5)
                End If

            Case "SearchTable"    ' ButtonTool
                Dim frm As New frmSearchInfo(Me.grdBaseTable)
                frm.Owner = Me
                frm.Show()

            Case "UseRowFiltering"    ' StateButtonTool
                'Up Cast the tool to StateButtonTool
                Dim stateTool As Infragistics.Win.UltraWinToolbars.StateButtonTool
                stateTool = CType(e.Tool, Infragistics.Win.UltraWinToolbars.StateButtonTool)

                'Check the button new state
                If stateTool.Checked Then
                    Me.grdBaseTable.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
                Else
                    Me.grdBaseTable.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False

                    'Remove any filter if existing
                    grdBaseTable.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
                End If

            Case "MutliColumnSorting"    ' ButtonTool
                'Create a multi column filter form
                Dim frm As New frmSortGrid(grdBaseTable)
                frm.ShowDialog()

            Case "Use Column Click Sorting"    ' StateButtonTool
                'Up Cast the tool to StateButtonTool
                Dim stateTool As Infragistics.Win.UltraWinToolbars.StateButtonTool
                stateTool = CType(e.Tool, Infragistics.Win.UltraWinToolbars.StateButtonTool)

                'Check the button new state
                If stateTool.Checked Then
                    Me.grdBaseTable.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
                Else
                    Me.grdBaseTable.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select
                End If

            Case "About"    ' ButtonTool
                'Show the about form
                Dim frm As New frmAssemblyAbout
                frm.ShowDialog()

            Case "Exit"    ' ButtonTool
                'Exit the base tabel editor
                Me.Close()
        End Select

    End Sub

    Public Function SetMultiColumnCombobox(ByVal intColumnID As Integer, ByVal intGroupID As Integer, ByVal intComboID As Integer) As EmbeddableEditorBase
        '*************************************************************************
        '* Function Name:   SetMultiColumnCombobox
        '* Description:     This sub sets a specific column to be a multi column
        '*                  combobox by setting the column editor to UltraDropdown
        '* Created by:      Raz Davidovich
        '* Created date:    09/06/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim dropDown As UltraDropDown = New UltraDropDown
        Dim editorSettings As DefaultEditorOwnerSettings = New DefaultEditorOwnerSettings
        Dim editor As EmbeddableEditorBase = Nothing
        Dim I As Integer
        Dim intBoundColumn As Integer
        Dim intDisplayColumn As Integer
        Dim blnHideColumn As Boolean

        dropDown.Visible = False
        Me.Controls.Add(dropDown)
        dropDown.DataSource = GetGridComboboxData(intComboID)

        'Get the bound column ID
        intBoundColumn = Config.ReadConfigValue(tabBaseTable.ActiveTab.Key.ToString + "_Col_" + intColumnID.ToString + "_MultiColumnComboBoundColumn", "Group_" + intGroupID.ToString, "BaseTables")

        'Get the display column ID
        intDisplayColumn = Config.ReadConfigValue(tabBaseTable.ActiveTab.Key.ToString + "_Col_" + intColumnID.ToString + "_MultiColumnComboDisplayColumn", "Group_" + intGroupID.ToString, "BaseTables")

        'Set the Value member. Cell values of this column are used as data.
        dropDown.ValueMember = dropDown.DataSource.Columns(intBoundColumn).Caption

        'Set the Data member. Cell values of this column are dispalyed in the cells.
        dropDown.DisplayMember = dropDown.DataSource.Columns(intDisplayColumn).Caption

        'Loop and hide the dropdown columns
        For I = 0 To dropDown.DataSource.Columns.count - 1
            blnHideColumn = Config.ReadConfigValue(tabBaseTable.ActiveTab.Key.ToString + "_Col_" + intColumnID.ToString + "_MultiColumnCombo_Col_" + I.ToString + "_Hide", "Group_" + intGroupID.ToString, "BaseTables")

            dropDown.DisplayLayout.Bands(0).Columns(I).Hidden = blnHideColumn
        Next

        editorSettings.ValueList = dropDown
        editorSettings.DataType = GetType(Integer)
        editor = New EditorWithCombo(New DefaultEditorOwner(editorSettings))

        'Return the drop down object
        Return editor

    End Function

#End Region

#Region "Public functions"

    Public Sub SelectTab(ByVal strTabKey As String)
        '*************************************************************************
        '* Function Name:   SelectTab
        '* Description:     This function selects and loads a table into a tab
        '*                  based on given tab key string
        '* Created by:      Raz Davidovich
        '* Created date:    31/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Get the Group ID
        Dim intGroupID As Integer = CType(trvTables.SelectedNodes(0).Key.Substring(trvTables.SelectedNodes(0).Key.LastIndexOf("_") + 1), Integer)

        'Get the table ID
        Dim intTableID As Integer = CType(strTabKey.Substring(strTabKey.LastIndexOf("_") + 1), Integer)

        Dim strAllowEdit As String

        'Connect the grid to a data table
        grdBaseTable.DataSource = GetTableDataForTableID(intGroupID, intTableID)

        strAllowEdit = Config.ReadConfigValue("Table_" + intTableID.ToString + "_AllowEdit", "Group_" & intGroupID.ToString, "BaseTables")

        'Set the table to be either editable or non-editable
        Select Case strAllowEdit
            Case Nothing
                grdBaseTable.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
            Case "False"
                grdBaseTable.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            Case "True"
                grdBaseTable.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True

        End Select


    End Sub

    Public Sub SelectTab(ByVal intTabIndex As Integer)
        '*************************************************************************
        '* Function Name:   SelectTab
        '* Description:     This function selects and loads a table into a tab
        '*                  based on given tab index
        '* Created by:      Raz Davidovich
        '* Created date:    31/01/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Call the overload function
        SelectTab(tabBaseTable.Tabs(intTabIndex).Key())

    End Sub

    Public Function SaveData() As Boolean
        '*************************************************************************
        '* Function Name:   SaveData
        '* Description:     This function saves the selected base table data 
        '* Created by:      Raz Davidovich
        '* Created date:    05/02/2005
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Get the changed rows for the current base table
        Dim dtlBaseTable As DataTable = grdBaseTable.DataSource.GetChanges()

        Return SaveBaseTableChanges(dtlBaseTable)

    End Function

#End Region

    Private Sub frmBaseTables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objAppInfo As New Assembly.Software.Utilities.clsApplicationAttributes
        usbStatus.Panels("Version").Text = "Version: " + objAppInfo.AppMajorVersion.ToString + "." + objAppInfo.AppMinorVersion.ToString + "." + objAppInfo.AppRevisionVersion.ToString

    End Sub

    Private Sub usbStatus_ButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinStatusBar.PanelEventArgs) Handles usbStatus.ButtonClick
        Select Case e.Panel.Key
            Case "About"
                'Show the about form
                Dim frm As New frmAssemblyAbout
                frm.ShowDialog()
        End Select

    End Sub

End Class
