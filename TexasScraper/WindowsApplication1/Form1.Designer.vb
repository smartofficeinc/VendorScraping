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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.browser = New System.Windows.Forms.WebBrowser()
        Me.goButton = New System.Windows.Forms.Button()
        Me.AxWebBrowser1 = New AxSHDocVw.AxWebBrowser()
        CType(Me.AxWebBrowser1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(84, 12)
        Me.browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.browser.Name = "browser"
        Me.browser.Size = New System.Drawing.Size(1115, 609)
        Me.browser.TabIndex = 1
        '
        'goButton
        '
        Me.goButton.AccessibleDescription = ""
        Me.goButton.Location = New System.Drawing.Point(12, 12)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(56, 23)
        Me.goButton.TabIndex = 2
        Me.goButton.Text = "Go"
        Me.goButton.UseVisualStyleBackColor = True
        '
        'AxWebBrowser1
        '
        Me.AxWebBrowser1.Enabled = True
        Me.AxWebBrowser1.Location = New System.Drawing.Point(87, 15)
        Me.AxWebBrowser1.OcxState = CType(resources.GetObject("AxWebBrowser1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWebBrowser1.Size = New System.Drawing.Size(1111, 605)
        Me.AxWebBrowser1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 633)
        Me.Controls.Add(Me.AxWebBrowser1)
        Me.Controls.Add(Me.goButton)
        Me.Controls.Add(Me.browser)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxWebBrowser1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents browser As WebBrowser
    Friend WithEvents goButton As Button
    Friend WithEvents AxWebBrowser1 As AxSHDocVw.AxWebBrowser
End Class
