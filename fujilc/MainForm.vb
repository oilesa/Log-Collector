
Public Class MainForm
    Public Shared appPath As String = Application.StartupPath()
    Dim objinifile As New clsIni(appPath + "\Settings.ini")
    Dim thread01 As System.Threading.Thread
    Dim thread02 As System.Threading.Thread
    Dim thread03 As System.Threading.Thread

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.Size = New System.Drawing.Size(600, 180)
        lbver.Text = "v" & Application.ProductVersion
        LogText.Visible = False
        Me.Size = New System.Drawing.Size(600, 180)
        NotifyIcon1.Visible = False
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If objinifile.GetString("SETTINGS", "CheckUpdate", "") Then
            thread03 = New System.Threading.Thread(AddressOf CheckUpdate)
            thread03.Start()
        End If
    End Sub

    Private Sub CheckUpdate()
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(objinifile.GetString("SETTINGS", "UpdateRepository", "") & "/ver.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newstrversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newstrversion.Contains(currentversion) Then
                ToolStripStatusLabel1.Text = "Checked for update. You have the latest version."
            Else
                Process.Start(appPath + "\updater.exe")
                Application.Exit()

            End If
        Catch ex As Exception
            MessageBox.Show("Couldn't check for update. Please check you inetrnet connection.")
        End Try
    End Sub

    Private Sub slbtn_Click(sender As Object, e As EventArgs) Handles btnsl.Click
        If Not BackgroundWorker1.IsBusy And btnsl.Text = "Send" Then
            Me.BackgroundWorker1.WorkerReportsProgress = True
            Me.BackgroundWorker1.WorkerSupportsCancellation = True
            btnsl.Text = "Cancel"
            BackgroundWorker1.RunWorkerAsync()
        ElseIf BackgroundWorker1.IsBusy AndAlso BackgroundWorker1.WorkerSupportsCancellation Then
            Me.BackgroundWorker1.CancelAsync()
            btnsl.Text = "Send"
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If Me.BackgroundWorker1.CancellationPending = True Then
            Me.BackgroundWorker1.CancelAsync()
            ProgressBar1.Value = 0
            btnsl.Text = "Send"
            ToolStripStatusLabel1.Text = ""
        Else
            ProgressBar1.Value = e.ProgressPercentage
            ToolStripStatusLabel1.Text = "Progress %" & e.ProgressPercentage.ToString
            SaveLogs()
            If ToolStripStatusLabel1.Text = "Progress %100" Then
                ToolStripStatusLabel1.Text = "All Done. Check the log for details."
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If BackgroundWorker1.CancellationPending = True Then
            BackgroundWorker1.CancelAsync()
            ProgressBar1.Value = 0
            btnsl.Text = "Send"
            ToolStripStatusLabel1.Text = ""
        Else

            CleanupFile(LogText, appPath & "\Files\")

        End If

        BackgroundWorker1.ReportProgress(5)

        If BackgroundWorker1.CancellationPending = True Then
            BackgroundWorker1.CancelAsync()
            ProgressBar1.Value = 0
            btnsl.Text = "Send"
            ToolStripStatusLabel1.Text = ""
        Else
            If objinifile.GetString("SETTINGS", "GetFiles", "") Then
                Makefile(LogText, objinifile)
            End If
        End If


        BackgroundWorker1.ReportProgress(20)

        If BackgroundWorker1.CancellationPending = True Then
            BackgroundWorker1.CancelAsync()
            ProgressBar1.Value = 0
            btnsl.Text = "Send"
            ToolStripStatusLabel1.Text = ""
        Else
            If objinifile.GetString("SETTINGS", "GetKioskLogs", "") Then
                MakeKioskLog(LogText)
            End If
        End If


        BackgroundWorker1.ReportProgress(30)

        If BackgroundWorker1.CancellationPending = True Then
            BackgroundWorker1.CancelAsync()
            ProgressBar1.Value = 0
            btnsl.Text = "Send"
            ToolStripStatusLabel1.Text = ""
        Else
            If CBool(objinifile.GetString("SETTINGS", "GetFiles", "")) Or CBool(objinifile.GetString("SETTINGS", "GetKioskLogs", "")) Then

                Uploadlog(btnsl, LogText, BackgroundWorker1)
            Else
                LogText.AppendText("No files to upload." & Environment.NewLine)
                BackgroundWorker1.ReportProgress(100)
            End If
        End If

    End Sub

    Private Sub Main_Minimize(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            NotifyIcon1.ShowBalloonTip(2000, "FUJIFILM Log Collector", "FUJIFILM Log Collector minimized to notification area.", ToolTipIcon.Info)
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        NotifyIcon1.Visible = False
        btnsl.PerformClick()
    End Sub

    Private Sub llshowlog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llshowlog.LinkClicked
        thread01 = New System.Threading.Thread(AddressOf ShLogText)
        thread01.Start()
    End Sub
    Private Sub ShLogText()
        If LogText.Visible Then
            LogText.Visible = False
            llshowlog.Text = "Show Logs"
            Me.Size = New System.Drawing.Size(600, 180)
        Else
            llshowlog.Text = "Hide Logs"
            Me.Size = New System.Drawing.Size(600, 300)
            LogText.Visible = True
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        NotifyIcon1.Visible = False
        Application.Exit()
    End Sub

    Private Sub ShowAbout(Sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        About.ShowDialog()
    End Sub

    Private Sub SaveLogs()
        LogText.SaveFile(appPath & "\Log.txt", RichTextBoxStreamType.UnicodePlainText)
    End Sub

    Private Sub SendToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToolStripMenuItem.Click
        btnsl.PerformClick()
    End Sub

    Private Sub ExitLogCollectorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitLogCollectorToolStripMenuItem.Click
        btnexit.PerformClick()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        NotifyIcon1.Visible = False
    End Sub

    Private Sub ViewLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLogsToolStripMenuItem.Click
        ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        NotifyIcon1.Visible = False
        LogText.Visible = False
        thread01 = New System.Threading.Thread(AddressOf ShLogText)
        thread01.Start()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        NotifyIcon1.Visible = False
        Application.Exit()
    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click
        Settings.ShowDialog()
        Settings.rtpath.Clear()
    End Sub
End Class
