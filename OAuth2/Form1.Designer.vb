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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFacebook = New System.Windows.Forms.Button()
        Me.btnGoogle = New System.Windows.Forms.Button()
        Me.btnLinkedIn = New System.Windows.Forms.Button()
        Me.btnSalesForce = New System.Windows.Forms.Button()
        Me.btnGitHub = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtListenPort = New System.Windows.Forms.TextBox()
        Me.txtAccessToken = New System.Windows.Forms.TextBox()
        Me.txtRefreshToken = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(477, 52)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'btnFacebook
        '
        Me.btnFacebook.Location = New System.Drawing.Point(26, 93)
        Me.btnFacebook.Name = "btnFacebook"
        Me.btnFacebook.Size = New System.Drawing.Size(91, 38)
        Me.btnFacebook.TabIndex = 1
        Me.btnFacebook.Text = "Facebook"
        Me.btnFacebook.UseVisualStyleBackColor = True
        '
        'btnGoogle
        '
        Me.btnGoogle.Location = New System.Drawing.Point(151, 93)
        Me.btnGoogle.Name = "btnGoogle"
        Me.btnGoogle.Size = New System.Drawing.Size(91, 38)
        Me.btnGoogle.TabIndex = 2
        Me.btnGoogle.Text = "Google"
        Me.btnGoogle.UseVisualStyleBackColor = True
        '
        'btnLinkedIn
        '
        Me.btnLinkedIn.Location = New System.Drawing.Point(276, 93)
        Me.btnLinkedIn.Name = "btnLinkedIn"
        Me.btnLinkedIn.Size = New System.Drawing.Size(91, 38)
        Me.btnLinkedIn.TabIndex = 3
        Me.btnLinkedIn.Text = "LinkedIn"
        Me.btnLinkedIn.UseVisualStyleBackColor = True
        '
        'btnSalesForce
        '
        Me.btnSalesForce.Location = New System.Drawing.Point(401, 93)
        Me.btnSalesForce.Name = "btnSalesForce"
        Me.btnSalesForce.Size = New System.Drawing.Size(91, 38)
        Me.btnSalesForce.TabIndex = 4
        Me.btnSalesForce.Text = "Salesforce"
        Me.btnSalesForce.UseVisualStyleBackColor = True
        '
        'btnGitHub
        '
        Me.btnGitHub.Location = New System.Drawing.Point(526, 93)
        Me.btnGitHub.Name = "btnGitHub"
        Me.btnGitHub.Size = New System.Drawing.Size(91, 38)
        Me.btnGitHub.TabIndex = 5
        Me.btnGitHub.Text = "GitHub"
        Me.btnGitHub.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(640, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Listen Port:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Access Token:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Refresh Token:"
        '
        'txtListenPort
        '
        Me.txtListenPort.Location = New System.Drawing.Point(706, 103)
        Me.txtListenPort.Name = "txtListenPort"
        Me.txtListenPort.Size = New System.Drawing.Size(73, 20)
        Me.txtListenPort.TabIndex = 9
        Me.txtListenPort.Text = "3017"
        '
        'txtAccessToken
        '
        Me.txtAccessToken.Location = New System.Drawing.Point(130, 157)
        Me.txtAccessToken.Name = "txtAccessToken"
        Me.txtAccessToken.Size = New System.Drawing.Size(534, 20)
        Me.txtAccessToken.TabIndex = 10
        '
        'txtRefreshToken
        '
        Me.txtRefreshToken.Location = New System.Drawing.Point(130, 188)
        Me.txtRefreshToken.Name = "txtRefreshToken"
        Me.txtRefreshToken.Size = New System.Drawing.Size(534, 20)
        Me.txtRefreshToken.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Error / Info Log"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(26, 267)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(870, 261)
        Me.TextBox1.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(683, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(213, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "* Some providers to not give refresh tokens."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 544)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRefreshToken)
        Me.Controls.Add(Me.txtAccessToken)
        Me.Controls.Add(Me.txtListenPort)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGitHub)
        Me.Controls.Add(Me.btnSalesForce)
        Me.Controls.Add(Me.btnLinkedIn)
        Me.Controls.Add(Me.btnGoogle)
        Me.Controls.Add(Me.btnFacebook)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "OAuth2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFacebook As System.Windows.Forms.Button
    Friend WithEvents btnGoogle As System.Windows.Forms.Button
    Friend WithEvents btnLinkedIn As System.Windows.Forms.Button
    Friend WithEvents btnSalesForce As System.Windows.Forms.Button
    Friend WithEvents btnGitHub As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtListenPort As System.Windows.Forms.TextBox
    Friend WithEvents txtAccessToken As System.Windows.Forms.TextBox
    Friend WithEvents txtRefreshToken As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
