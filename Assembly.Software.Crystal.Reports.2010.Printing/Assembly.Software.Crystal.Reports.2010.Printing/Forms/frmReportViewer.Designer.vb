<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportViewer
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
        Me.crvCrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvCrystalReportViewer
        '
        Me.crvCrystalReportViewer.ActiveViewIndex = -1
        Me.crvCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvCrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.crvCrystalReportViewer.Name = "crvCrystalReportViewer"
        Me.crvCrystalReportViewer.Size = New System.Drawing.Size(1001, 690)
        Me.crvCrystalReportViewer.TabIndex = 0
        '
        'frmReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 690)
        Me.Controls.Add(Me.crvCrystalReportViewer)
        Me.Name = "frmReportViewer"
        Me.Text = "Crystal Reports Viewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvCrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
