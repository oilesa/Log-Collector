Imports System.Net

Public Class Updater

    Dim WithEvents WC As New WebClient
    Dim appPath As String = Application.StartupPath()
    Dim objinifile As New clsIni(appPath + "\Settings.ini")
    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WC.DownloadFileAsync(New Uri(objinifile.GetString("SETTINGS", "UpdateRepository", "") + "fujilc.exe"), "fujilc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        lblupdating.Text = "Updating..." & "%" & CType(ProgressBar1.Value, String)
        AddHandler WC.DownloadFileCompleted, AddressOf ExitApplication
    End Sub

    Private Sub ExitApplication()
        'Process.Start(appPath + "\fujilc.exe")
        MessageBox.Show("Log-Collector has been updated. Please run the application again.")
        Application.Exit()
    End Sub
End Class
