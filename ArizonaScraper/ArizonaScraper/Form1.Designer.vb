<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.textBox = New System.Windows.Forms.TextBox()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.goButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'textBox
        '
        Me.textBox.Location = New System.Drawing.Point(50, 89)
        Me.textBox.Name = "textBox"
        Me.textBox.Size = New System.Drawing.Size(75, 20)
        Me.textBox.TabIndex = 9
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(50, 60)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 8
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'goButton
        '
        Me.goButton.Location = New System.Drawing.Point(50, 31)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(75, 23)
        Me.goButton.TabIndex = 7
        Me.goButton.Text = "Go"
        Me.goButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(180, 135)
        Me.Controls.Add(Me.textBox)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.goButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textBox As TextBox
    Friend WithEvents saveButton As Button
    Friend WithEvents goButton As Button
End Class
