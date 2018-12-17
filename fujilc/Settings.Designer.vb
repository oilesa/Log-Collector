<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ftpsettings = New System.Windows.Forms.TabPage()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtftpaddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Paths = New System.Windows.Forms.TabPage()
        Me.cbgetfiles = New System.Windows.Forms.CheckBox()
        Me.cbgetkiosklog = New System.Windows.Forms.CheckBox()
        Me.rtpath = New System.Windows.Forms.RichTextBox()
        Me.Update = New System.Windows.Forms.TabPage()
        Me.lblupdatepath = New System.Windows.Forms.Label()
        Me.txtupdaterep = New System.Windows.Forms.TextBox()
        Me.cbupdate = New System.Windows.Forms.CheckBox()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.ftpsettings.SuspendLayout()
        Me.Paths.SuspendLayout()
        Me.Update.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.ftpsettings)
        Me.TabControl1.Controls.Add(Me.Paths)
        Me.TabControl1.Controls.Add(Me.Update)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(314, 369)
        Me.TabControl1.TabIndex = 0
        '
        'ftpsettings
        '
        Me.ftpsettings.Controls.Add(Me.txtusername)
        Me.ftpsettings.Controls.Add(Me.txtpassword)
        Me.ftpsettings.Controls.Add(Me.txtftpaddress)
        Me.ftpsettings.Controls.Add(Me.Label3)
        Me.ftpsettings.Controls.Add(Me.Label2)
        Me.ftpsettings.Controls.Add(Me.Label1)
        Me.ftpsettings.Location = New System.Drawing.Point(4, 22)
        Me.ftpsettings.Name = "ftpsettings"
        Me.ftpsettings.Padding = New System.Windows.Forms.Padding(3)
        Me.ftpsettings.Size = New System.Drawing.Size(306, 343)
        Me.ftpsettings.TabIndex = 0
        Me.ftpsettings.Text = "FTP"
        Me.ftpsettings.UseVisualStyleBackColor = True
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(19, 72)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(190, 20)
        Me.txtusername.TabIndex = 5
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(19, 111)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(190, 20)
        Me.txtpassword.TabIndex = 4
        '
        'txtftpaddress
        '
        Me.txtftpaddress.Location = New System.Drawing.Point(19, 33)
        Me.txtftpaddress.Name = "txtftpaddress"
        Me.txtftpaddress.Size = New System.Drawing.Size(190, 20)
        Me.txtftpaddress.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FTP Address"
        '
        'Paths
        '
        Me.Paths.Controls.Add(Me.cbgetfiles)
        Me.Paths.Controls.Add(Me.cbgetkiosklog)
        Me.Paths.Controls.Add(Me.rtpath)
        Me.Paths.Location = New System.Drawing.Point(4, 22)
        Me.Paths.Name = "Paths"
        Me.Paths.Padding = New System.Windows.Forms.Padding(3)
        Me.Paths.Size = New System.Drawing.Size(306, 343)
        Me.Paths.TabIndex = 1
        Me.Paths.Text = "Paths"
        Me.Paths.UseVisualStyleBackColor = True
        '
        'cbgetfiles
        '
        Me.cbgetfiles.AutoSize = True
        Me.cbgetfiles.Location = New System.Drawing.Point(8, 29)
        Me.cbgetfiles.Name = "cbgetfiles"
        Me.cbgetfiles.Size = New System.Drawing.Size(67, 17)
        Me.cbgetfiles.TabIndex = 2
        Me.cbgetfiles.Text = "Get Files"
        Me.cbgetfiles.UseVisualStyleBackColor = True
        '
        'cbgetkiosklog
        '
        Me.cbgetkiosklog.AutoSize = True
        Me.cbgetkiosklog.Location = New System.Drawing.Point(8, 6)
        Me.cbgetkiosklog.Name = "cbgetkiosklog"
        Me.cbgetkiosklog.Size = New System.Drawing.Size(98, 17)
        Me.cbgetkiosklog.TabIndex = 1
        Me.cbgetkiosklog.Text = "Get Kiosk Logs"
        Me.cbgetkiosklog.UseVisualStyleBackColor = True
        '
        'rtpath
        '
        Me.rtpath.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rtpath.Location = New System.Drawing.Point(3, 52)
        Me.rtpath.Name = "rtpath"
        Me.rtpath.Size = New System.Drawing.Size(300, 288)
        Me.rtpath.TabIndex = 0
        Me.rtpath.Text = ""
        '
        'Update
        '
        Me.Update.Controls.Add(Me.lblupdatepath)
        Me.Update.Controls.Add(Me.txtupdaterep)
        Me.Update.Controls.Add(Me.cbupdate)
        Me.Update.Location = New System.Drawing.Point(4, 22)
        Me.Update.Name = "Update"
        Me.Update.Padding = New System.Windows.Forms.Padding(3)
        Me.Update.Size = New System.Drawing.Size(306, 343)
        Me.Update.TabIndex = 2
        Me.Update.Text = "Update"
        Me.Update.UseVisualStyleBackColor = True
        '
        'lblupdatepath
        '
        Me.lblupdatepath.AutoSize = True
        Me.lblupdatepath.Location = New System.Drawing.Point(8, 9)
        Me.lblupdatepath.Name = "lblupdatepath"
        Me.lblupdatepath.Size = New System.Drawing.Size(90, 13)
        Me.lblupdatepath.TabIndex = 2
        Me.lblupdatepath.Text = "Update repository"
        '
        'txtupdaterep
        '
        Me.txtupdaterep.Location = New System.Drawing.Point(8, 25)
        Me.txtupdaterep.Name = "txtupdaterep"
        Me.txtupdaterep.Size = New System.Drawing.Size(287, 20)
        Me.txtupdaterep.TabIndex = 1
        '
        'cbupdate
        '
        Me.cbupdate.AutoSize = True
        Me.cbupdate.Location = New System.Drawing.Point(8, 51)
        Me.cbupdate.Name = "cbupdate"
        Me.cbupdate.Size = New System.Drawing.Size(158, 17)
        Me.cbupdate.TabIndex = 0
        Me.cbupdate.Text = "Check for update on startup"
        Me.cbupdate.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(231, 372)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 7
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 403)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.ftpsettings.ResumeLayout(False)
        Me.ftpsettings.PerformLayout()
        Me.Paths.ResumeLayout(False)
        Me.Paths.PerformLayout()
        Me.Update.ResumeLayout(False)
        Me.Update.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents ftpsettings As TabPage
    Friend WithEvents Paths As TabPage
    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents txtftpaddress As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Update As TabPage
    Friend WithEvents lblupdatepath As Label
    Friend WithEvents txtupdaterep As TextBox
    Friend WithEvents cbupdate As CheckBox
    Friend WithEvents btnsave As Button
    Friend WithEvents rtpath As RichTextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbgetfiles As CheckBox
    Friend WithEvents cbgetkiosklog As CheckBox
End Class
