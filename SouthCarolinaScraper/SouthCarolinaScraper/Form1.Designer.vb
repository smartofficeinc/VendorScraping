<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.stopButton = New System.Windows.Forms.Button()
        Me.countLabel = New System.Windows.Forms.Label()
        Me.goButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.browser = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'stopButton
        '
        Me.stopButton.Location = New System.Drawing.Point(363, 12)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(93, 28)
        Me.stopButton.TabIndex = 0
        Me.stopButton.Text = "Stop"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'countLabel
        '
        Me.countLabel.AutoSize = True
        Me.countLabel.Location = New System.Drawing.Point(590, 20)
        Me.countLabel.Name = "countLabel"
        Me.countLabel.Size = New System.Drawing.Size(35, 13)
        Me.countLabel.TabIndex = 1
        Me.countLabel.Text = "Count"
        '
        'goButton
        '
        Me.goButton.Location = New System.Drawing.Point(255, 12)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(91, 28)
        Me.goButton.TabIndex = 2
        Me.goButton.Text = "Go"
        Me.goButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(474, 12)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(93, 28)
        Me.saveButton.TabIndex = 3
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(12, 46)
        Me.browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.browser.Name = "browser"
        Me.browser.Size = New System.Drawing.Size(895, 390)
        Me.browser.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 448)
        Me.Controls.Add(Me.browser)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.goButton)
        Me.Controls.Add(Me.countLabel)
        Me.Controls.Add(Me.stopButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stopButton As Button
    Friend WithEvents countLabel As Label
    Friend WithEvents goButton As Button
    Friend WithEvents saveButton As Button
    Public WithEvents browser As WebBrowser
End Class
