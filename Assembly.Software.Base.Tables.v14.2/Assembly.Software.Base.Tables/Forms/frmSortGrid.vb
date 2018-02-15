Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing

'Imports System.Data.DataRow

Public Class frmSortGrid

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Private grdGrid As UltraGrid

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

    End Sub
    Public Sub New(ByRef grdSample As UltraGrid)

        Me.New()
        'Add any initialization after the InitializeComponent() call

        Me.grdGrid = grdSample

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
    Friend WithEvents grbParam As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmbParam1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbStyleSort1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbParam2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbParam3 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbParam4 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbParam5 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbStyleSort2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbStyleSort3 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbStyleSort4 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbStyleSort5 As Infragistics.Win.UltraWinGrid.UltraCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSortGrid))
        Me.grbParam = New System.Windows.Forms.GroupBox
        Me.cmbStyleSort5 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbStyleSort4 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbStyleSort3 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbStyleSort2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbParam5 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbParam4 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbParam3 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbParam2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbStyleSort1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbParam1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnOk = New Infragistics.Win.Misc.UltraButton
        Me.grbParam.SuspendLayout()
        CType(Me.cmbStyleSort5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStyleSort4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStyleSort3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStyleSort2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbParam5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbParam4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbParam3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbParam2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStyleSort1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbParam1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbParam
        '
        Me.grbParam.Controls.Add(Me.cmbStyleSort5)
        Me.grbParam.Controls.Add(Me.cmbStyleSort4)
        Me.grbParam.Controls.Add(Me.cmbStyleSort3)
        Me.grbParam.Controls.Add(Me.cmbStyleSort2)
        Me.grbParam.Controls.Add(Me.cmbParam5)
        Me.grbParam.Controls.Add(Me.cmbParam4)
        Me.grbParam.Controls.Add(Me.cmbParam3)
        Me.grbParam.Controls.Add(Me.cmbParam2)
        Me.grbParam.Controls.Add(Me.cmbStyleSort1)
        Me.grbParam.Controls.Add(Me.cmbParam1)
        Me.grbParam.Location = New System.Drawing.Point(16, 12)
        Me.grbParam.Name = "grbParam"
        Me.grbParam.Size = New System.Drawing.Size(480, 295)
        Me.grbParam.TabIndex = 0
        Me.grbParam.TabStop = False
        Me.grbParam.Text = "Parameters for sorting"
        '
        'cmbStyleSort5
        '
        Me.cmbStyleSort5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbStyleSort5.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStyleSort5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbStyleSort5.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbStyleSort5.Enabled = False
        Me.cmbStyleSort5.Location = New System.Drawing.Point(264, 232)
        Me.cmbStyleSort5.Name = "cmbStyleSort5"
        Me.cmbStyleSort5.Size = New System.Drawing.Size(190, 26)
        Me.cmbStyleSort5.TabIndex = 30
        '
        'cmbStyleSort4
        '
        Me.cmbStyleSort4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbStyleSort4.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStyleSort4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbStyleSort4.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbStyleSort4.Enabled = False
        Me.cmbStyleSort4.Location = New System.Drawing.Point(264, 184)
        Me.cmbStyleSort4.Name = "cmbStyleSort4"
        Me.cmbStyleSort4.Size = New System.Drawing.Size(190, 26)
        Me.cmbStyleSort4.TabIndex = 29
        '
        'cmbStyleSort3
        '
        Me.cmbStyleSort3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbStyleSort3.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStyleSort3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbStyleSort3.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbStyleSort3.Enabled = False
        Me.cmbStyleSort3.Location = New System.Drawing.Point(264, 136)
        Me.cmbStyleSort3.Name = "cmbStyleSort3"
        Me.cmbStyleSort3.Size = New System.Drawing.Size(190, 26)
        Me.cmbStyleSort3.TabIndex = 28
        '
        'cmbStyleSort2
        '
        Me.cmbStyleSort2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbStyleSort2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStyleSort2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbStyleSort2.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbStyleSort2.Enabled = False
        Me.cmbStyleSort2.Location = New System.Drawing.Point(264, 88)
        Me.cmbStyleSort2.Name = "cmbStyleSort2"
        Me.cmbStyleSort2.Size = New System.Drawing.Size(190, 26)
        Me.cmbStyleSort2.TabIndex = 27
        '
        'cmbParam5
        '
        Me.cmbParam5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbParam5.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbParam5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbParam5.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbParam5.Enabled = False
        Me.cmbParam5.Location = New System.Drawing.Point(23, 232)
        Me.cmbParam5.Name = "cmbParam5"
        Me.cmbParam5.Size = New System.Drawing.Size(205, 26)
        Me.cmbParam5.TabIndex = 26
        '
        'cmbParam4
        '
        Me.cmbParam4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbParam4.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbParam4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbParam4.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbParam4.Enabled = False
        Me.cmbParam4.Location = New System.Drawing.Point(23, 184)
        Me.cmbParam4.Name = "cmbParam4"
        Me.cmbParam4.Size = New System.Drawing.Size(205, 26)
        Me.cmbParam4.TabIndex = 25
        '
        'cmbParam3
        '
        Me.cmbParam3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbParam3.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbParam3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbParam3.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbParam3.Enabled = False
        Me.cmbParam3.Location = New System.Drawing.Point(23, 136)
        Me.cmbParam3.Name = "cmbParam3"
        Me.cmbParam3.Size = New System.Drawing.Size(205, 26)
        Me.cmbParam3.TabIndex = 24
        '
        'cmbParam2
        '
        Me.cmbParam2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbParam2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbParam2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbParam2.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbParam2.Enabled = False
        Me.cmbParam2.Location = New System.Drawing.Point(23, 88)
        Me.cmbParam2.Name = "cmbParam2"
        Me.cmbParam2.Size = New System.Drawing.Size(205, 26)
        Me.cmbParam2.TabIndex = 23
        '
        'cmbStyleSort1
        '
        Me.cmbStyleSort1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbStyleSort1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStyleSort1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbStyleSort1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbStyleSort1.Location = New System.Drawing.Point(264, 40)
        Me.cmbStyleSort1.Name = "cmbStyleSort1"
        Me.cmbStyleSort1.Size = New System.Drawing.Size(190, 26)
        Me.cmbStyleSort1.TabIndex = 22
        '
        'cmbParam1
        '
        Me.cmbParam1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbParam1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbParam1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbParam1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbParam1.Location = New System.Drawing.Point(23, 40)
        Me.cmbParam1.Name = "cmbParam1"
        Me.cmbParam1.Size = New System.Drawing.Size(205, 26)
        Me.cmbParam1.TabIndex = 21
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(363, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(16, 328)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(135, 40)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "&OK"
        '
        'frmSortGrid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(510, 381)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbParam)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSortGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parameters for sorting"
        Me.grbParam.ResumeLayout(False)
        Me.grbParam.PerformLayout()
        CType(Me.cmbStyleSort5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStyleSort4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStyleSort3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStyleSort2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbParam5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbParam4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbParam3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbParam2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStyleSort1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbParam1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSortParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadComboParam()
        LoadComboTypeSort()
    End Sub

    Private Sub LoadComboParam()
        FillComboParamSort(cmbParam1)
        FillComboParamSort(cmbParam2)
        FillComboParamSort(cmbParam3)
        FillComboParamSort(cmbParam4)
        FillComboParamSort(cmbParam5)
    End Sub

    Private Sub LoadComboTypeSort()
        FillComboStyleSort(cmbStyleSort1)
        FillComboStyleSort(cmbStyleSort2)
        FillComboStyleSort(cmbStyleSort3)
        FillComboStyleSort(cmbStyleSort4)
        FillComboStyleSort(cmbStyleSort5)
    End Sub

    Private Sub FillComboStyleSort(ByRef cmbComboBoxStyleSort As UltraCombo)
        '*************************************************************************
        '* Function Name:   FillComboStyleSort
        '* Description:     This sub  fill  combobox(Style Sort) 
        '* Created by:      Olga Lebedeva
        '* Created date:    01/03/2005
        '*************************************************************************.
        Dim dtComboData As New DataTable
        Dim row As DataRow = dtComboData.NewRow

        dtComboData.Columns.Add("Value")
        dtComboData.Columns.Add("TypeSort")

        row = dtComboData.NewRow
        row(0) = 1
        row(1) = "Ascending"
        dtComboData.Rows.InsertAt(row, 0)

        row = dtComboData.NewRow
        row(0) = 2
        row(1) = "Descending"
        dtComboData.Rows.InsertAt(row, 1)

        cmbComboBoxStyleSort.DataSource = dtComboData
        cmbComboBoxStyleSort.ValueMember = dtComboData.Columns(0).ColumnName
        cmbComboBoxStyleSort.DisplayMember = dtComboData.Columns(1).ColumnName
        cmbComboBoxStyleSort.DataBind()
        Dim column As DataColumn

        'hide all the Id in the table
        For Each column In dtComboData.Columns
            If column.ColumnName.EndsWith("Value") Then
                cmbComboBoxStyleSort.DisplayLayout.Bands(0).Columns(0).Hidden = True
            End If
        Next

        SetFontCombo(cmbComboBoxStyleSort)

    End Sub

    Private Sub SetFontCombo(ByRef cmbComboBox As UltraCombo)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

        cmbComboBox.Rows(0).Selected = True
        cmbComboBox.DisplayLayout.Bands(0).Columns(1).Width = cmbComboBox.Width
        cmbComboBox.Font = New Font("verdana", 10, FontStyle.Regular, GraphicsUnit.Point, 1)
        Appearance2.FontData.Name = "Verdana"
        Appearance2.FontData.SizeInPoints = 10.0!
        cmbComboBox.DisplayLayout.Appearance = Appearance2
        cmbComboBox.DisplayLayout.Bands(0).ColHeadersVisible = False
    End Sub

    Private Sub FillComboParamSort(ByRef cmbComboBoxParamSort As UltraCombo)
        '*************************************************************************
        '* Sub Name:   FillComboParamSort
        '* Description:     fill combobox used all columns from grid, if column 
        '*                  is not hidden 
        '* Created by:      Olga Lebedeva
        '* Created date:    23/02/2005
        '*************************************************************************

        Dim dtComboData As New DataTable
        Dim row As DataRow = dtComboData.NewRow

        dtComboData.Columns.Add("Value")
        dtComboData.Columns.Add("ParamSort")
        row(0) = -1
        row(1) = "<- Select ->"
        dtComboData.Rows.Add(row)

        For i As Integer = 0 To grdGrid.DisplayLayout.Bands(0).Columns.Count - 1
            'if column is not hide insert to the combobox
            If grdGrid.DisplayLayout.Bands(0).Columns.Item(i).Hidden = False Then
                row = dtComboData.NewRow
                row(0) = grdGrid.DisplayLayout.Bands(0).Columns.Item(i).Index
                row(1) = grdGrid.DisplayLayout.Bands(0).Columns.Item(i).Header.Caption()
                dtComboData.Rows.Add(row)
            End If
        Next

        cmbComboBoxParamSort.DataSource = dtComboData
        cmbComboBoxParamSort.ValueMember = dtComboData.Columns(0).ColumnName
        cmbComboBoxParamSort.DisplayMember = dtComboData.Columns(1).ColumnName
        cmbComboBoxParamSort.DataBind()

        Dim column As DataColumn
        'hide all the Id in the table
        For Each column In dtComboData.Columns
            If column.ColumnName.EndsWith("Value") Then
                cmbComboBoxParamSort.DisplayLayout.Bands(0).Columns(0).Hidden = True
            End If
        Next

        SetFontCombo(cmbComboBoxParamSort)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim blnStyleSort As Boolean = False

        'remove all columns from SortedColumnsCollection
        grdGrid.DisplayLayout.Bands(0).SortedColumns.Clear()

        If cmbParam1.SelectedRow.Cells(0).Value <> -1 Then
            'user select column for sort
            If cmbStyleSort1.SelectedRow.Cells(0).Value = 2 Then
                'Ascending=False,Descending=True
                blnStyleSort = True
            End If
            'add column to SortedColumnsCollection
            grdGrid.DisplayLayout.Bands(0).SortedColumns.Add(grdGrid.DisplayLayout.Bands(0).Columns(CInt(cmbParam1.SelectedRow.Cells(0).Text)), blnStyleSort, False)
        End If

        If cmbParam2.SelectedRow.Cells(0).Value <> -1 Then
            'user select column for sort
            If cmbStyleSort2.SelectedRow.Cells(0).Value = 2 Then
                'Ascending=False,Descending=True
                blnStyleSort = True
            End If
            'add column to SortedColumnsCollection
            grdGrid.DisplayLayout.Bands(0).SortedColumns.Add(grdGrid.DisplayLayout.Bands(0).Columns(CInt(cmbParam2.SelectedRow.Cells(0).Text)), blnStyleSort, False)
        End If

        If cmbParam3.SelectedRow.Cells(0).Value <> -1 Then
            'user select column for sort
            If cmbStyleSort3.SelectedRow.Cells(0).Value = 2 Then
                'Ascending=False,Descending=True
                blnStyleSort = True
            End If
            'add column to SortedColumnsCollection
            grdGrid.DisplayLayout.Bands(0).SortedColumns.Add(grdGrid.DisplayLayout.Bands(0).Columns(CInt(cmbParam3.SelectedRow.Cells(0).Text)), blnStyleSort, False)
        End If

        If cmbParam4.SelectedRow.Cells(0).Value <> -1 Then
            'user select column for sort
            If cmbStyleSort4.SelectedRow.Cells(0).Value = 2 Then
                'Ascending=False,Descending=True
                blnStyleSort = True
            End If
            'add column to SortedColumnsCollection
            grdGrid.DisplayLayout.Bands(0).SortedColumns.Add(grdGrid.DisplayLayout.Bands(0).Columns(CInt(cmbParam4.SelectedRow.Cells(0).Text)), blnStyleSort, False)
        End If

        If cmbParam5.SelectedRow.Cells(0).Value <> -1 Then
            'user select column for sort
            If cmbStyleSort5.SelectedRow.Cells(0).Value = 2 Then
                'Ascending=False,Descending=True
                blnStyleSort = True
            End If
            'add column to SortedColumnsCollection
            grdGrid.DisplayLayout.Bands(0).SortedColumns.Add(grdGrid.DisplayLayout.Bands(0).Columns(CInt(cmbParam5.SelectedRow.Cells(0).Text)), blnStyleSort, False)
        End If

        Me.Close()

    End Sub

    Private Sub Check(ByRef cmbParam As UltraCombo, ByRef cmbStyle As UltraCombo, ByVal blnEnable As Boolean)
        cmbParam.Enabled = blnEnable
        cmbStyle.Enabled = blnEnable
    End Sub

    Private Sub cmbParam1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbParam1.ValueChanged
        If cmbParam1.SelectedRow.Cells(0).Value <> -1 Then
            Check(cmbParam2, cmbStyleSort2, True)
        Else
            Check(cmbParam2, cmbStyleSort2, False)
        End If
    End Sub

    Private Sub cmbParam2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbParam2.ValueChanged
        If cmbParam2.SelectedRow.Cells(0).Value <> -1 Then
            Check(cmbParam3, cmbStyleSort3, True)
        Else
            Check(cmbParam3, cmbStyleSort3, False)
        End If
    End Sub

    Private Sub cmbParam3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbParam3.ValueChanged
        If cmbParam3.SelectedRow.Cells(0).Value <> -1 Then
            Check(cmbParam4, cmbStyleSort4, True)
        Else
            Check(cmbParam4, cmbStyleSort4, False)
        End If
    End Sub

    Private Sub cmbParam4_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbParam4.ValueChanged
        If cmbParam4.SelectedRow.Cells(0).Value <> -1 Then
            Check(cmbParam5, cmbStyleSort5, True)
        Else
            Check(cmbParam5, cmbStyleSort5, False)
        End If
    End Sub

End Class
