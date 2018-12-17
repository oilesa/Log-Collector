Public Class Settings
    Dim objinifile As New clsIni(MainForm.appPath + "\Settings.ini")

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtftpaddress.Text = objinifile.GetString("SETTINGS", "Address", "")
        txtusername.Text = objinifile.GetString("SETTINGS", "Username", "")
        txtpassword.Text = Decrypt(objinifile.GetString("SETTINGS", "Password", ""))

        txtupdaterep.Text = objinifile.GetString("SETTINGS", "UpdateRepository", "")
        cbupdate.Checked = CBool(objinifile.GetString("SETTINGS", "CheckUpdate", ""))
        cbgetkiosklog.Checked = CBool(objinifile.GetString("SETTINGS", "GetKioskLogs", ""))
        cbgetfiles.Checked = CBool(objinifile.GetString("SETTINGS", "GetFiles", ""))

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Writeini()
        Close()
    End Sub

    Private Sub Writeini()
        System.IO.File.WriteAllText(MainForm.appPath + "\Settings.ini", "")
        objinifile.WriteString("SETTINGS", "Address", txtftpaddress.Text)
        objinifile.WriteString("SETTINGS", "Username", txtusername.Text)
        objinifile.WriteString("SETTINGS", "Password", Encrypt(txtpassword.Text))

        objinifile.WriteString("SETTINGS", "UpdateRepository", txtupdaterep.Text)
        objinifile.WriteString("SETTINGS", "CheckUpdate", cbupdate.Checked)

        objinifile.WriteString("SETTINGS", "GetKioskLogs", cbgetkiosklog.Checked)
        objinifile.WriteString("SETTINGS", "GetFiles", cbgetfiles.Checked)

        Dim lines As Integer = rtpath.Lines.Length - 1
        For i = 0 To lines
            Try
                objinifile.WriteString("FILES", "PATH" & i, rtpath.Lines(i))
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        LoadInRt()
    End Sub
    Private Sub Settings_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadInRt()
    End Sub

    Private Sub LoadInRt()
        rtpath.Clear()
        Dim lines As Integer
        lines = IO.File.ReadAllLines(MainForm.appPath + "\Settings.ini").Length
        For i = 0 To lines
            Dim filepath As String = objinifile.GetString("FILES", "PATH" & i, "")
            Try
                If filepath <> "" Then
                    rtpath.AppendText(filepath & Environment.NewLine)
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

End Class