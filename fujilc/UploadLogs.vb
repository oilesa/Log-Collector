Imports System.ComponentModel
Module UploadLogs

    Public Sub Uploadlog(ByVal SendButton As Button, ByVal Richtxt As RichTextBox, ByVal BW1 As BackgroundWorker)

        UpdateLogTextLime(Richtxt, "Connecting to the Server...")
        Try
            Dim objinifile As New clsIni(MainForm.appPath + "\Settings.ini")


            Dim request As System.Net.FtpWebRequest
            Dim Response As System.Net.WebResponse

            Try
                UpdateLogTextLime(Richtxt, "Connected to the server.")
                request = DirectCast(System.Net.WebRequest.Create("ftp://" & objinifile.GetString("SETTINGS", "Address", "") & "/" & Format(DateTime.Now, "yyyy-MM-dd").ToString), System.Net.FtpWebRequest)
                request.Credentials = New System.Net.NetworkCredential(objinifile.GetString("SETTINGS", "Username", ""), Decrypt(objinifile.GetString("SETTINGS", "Password", "")))
                request.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

                Response = request.GetResponse
            Catch ex As Exception
                UpdateLogTextGold(Richtxt, "Date folder already exists. Skipping date folder creation.")
            End Try

            Try
                request = DirectCast(System.Net.WebRequest.Create("ftp://" & objinifile.GetString("SETTINGS", "Address", "") & "/" & Format(DateTime.Now, "yyyy-MM-dd").ToString & "/" & System.Net.Dns.GetHostName), System.Net.FtpWebRequest)
                request.Credentials = New System.Net.NetworkCredential(objinifile.GetString("SETTINGS", "Username", ""), Decrypt(objinifile.GetString("SETTINGS", "Password", "")))
                request.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
                Response = request.GetResponse
            Catch ex As Exception
                UpdateLogTextGold(Richtxt, "Machine folder already exists. Skipping machine folder creation.")
            End Try

            BW1.ReportProgress(35)

            request = DirectCast(System.Net.WebRequest.Create("ftp://" & objinifile.GetString("SETTINGS", "Address", "") & "/" & Format(DateTime.Now, "yyyy-MM-dd").ToString & "/" & System.Net.Dns.GetHostName & "/errorlog-" & System.Net.Dns.GetHostName & "-" & Format(DateTime.Now, "yyyy-MM-dd-hh:mm:ss").ToString & ".zip"), System.Net.FtpWebRequest)

            request.UsePassive = False
            request.UseBinary = True
            request.EnableSsl = True
            request.UsePassive = True
            request.Credentials = New System.Net.NetworkCredential(objinifile.GetString("SETTINGS", "Username", ""), Decrypt(objinifile.GetString("SETTINGS", "Password", "")))

            BW1.ReportProgress(40)

            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile


            BW1.ReportProgress(45)

            Dim fileStream() As Byte = System.IO.File.ReadAllBytes(MainForm.appPath & "\Zipped\" & "errorlog.zip")

            BW1.ReportProgress(50)

            Dim strz As System.IO.Stream = request.GetRequestStream()



            UpdateLogTextLime(Richtxt, "Uploading file to the server...")
            For offset As Integer = 0 To fileStream.Length Step 1024

                If BW1.CancellationPending = True Then
                    BW1.CancelAsync()
                    MainForm.ProgressBar1.Value = 0
                    SendButton.Text = "Send"
                    MainForm.ToolStripStatusLabel1.Text = ""
                    GoTo Canceled
                Else
                    BW1.ReportProgress(CType(offset * MainForm.ProgressBar1.Maximum / fileStream.Length, Integer))
                    Dim chsize As Integer = fileStream.Length - offset
                    If chsize > 1024 Then chsize = 1024
                    strz.Write(fileStream, offset, chsize)
                End If

            Next

Canceled:
            If BW1.CancellationPending Then
                strz.Close()
                strz.Dispose()

                UpdateLogTextRed(Richtxt, "File upload canceled.")
            End If

            If Not BW1.CancellationPending Then
                strz.Close()
                strz.Dispose()

                UpdateLogTextWhite(Richtxt, "File uploaded succesfully.")
                BW1.ReportProgress(100)
                SendButton.Text = "Send"
            End If

        Catch ex As Exception
            UpdateLogTextRed(Richtxt, ex.Message & Environment.NewLine)
            SendButton.Text = "Send"
        End Try

    End Sub
End Module
