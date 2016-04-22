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
        Me.browser = New System.Windows.Forms.WebBrowser()
        Me.linksList = New System.Windows.Forms.ListBox()
        Me.goButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.textBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(12, 129)
        Me.browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.browser.Name = "browser"
        Me.browser.Size = New System.Drawing.Size(831, 343)
        Me.browser.TabIndex = 0
        '
        'linksList
        '
        Me.linksList.FormattingEnabled = True
        Me.linksList.Location = New System.Drawing.Point(12, 12)
        Me.linksList.Name = "linksList"
        Me.linksList.Size = New System.Drawing.Size(728, 108)
        Me.linksList.TabIndex = 1
        '
        'goButton
        '
        Me.goButton.Location = New System.Drawing.Point(758, 24)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(75, 23)
        Me.goButton.TabIndex = 2
        Me.goButton.Text = "Go"
        Me.goButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(758, 53)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 3
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'textBox
        '
        Me.textBox.Location = New System.Drawing.Point(769, 91)
        Me.textBox.Name = "textBox"
        Me.textBox.Size = New System.Drawing.Size(52, 20)
        Me.textBox.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 487)
        Me.Controls.Add(Me.textBox)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.goButton)
        Me.Controls.Add(Me.linksList)
        Me.Controls.Add(Me.browser)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents browser As WebBrowser
    Friend WithEvents linksList As ListBox
    Friend WithEvents goButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents textBox As TextBox
End Class
