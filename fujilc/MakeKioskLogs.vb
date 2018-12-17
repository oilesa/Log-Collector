Imports System.IO
Imports System.IO.Compression

Module MakeKioskLogs
    Public Sub MakeKioskLog(ByVal Richtxt As RichTextBox)

        Dim appPath As String = Application.StartupPath()
        Dim startPath As String = appPath & "\Files\"
        Dim zipPath As String = appPath & "\Zipped\" & "errorlog.zip"

        'Delete existing zip file

        DeletezipFile(Richtxt, zipPath)

        Dim Filepath As String = "C:\ImagineKiosk\IKT\ImagineKioskTray_" + String.Format("{0:yyyyMMdd}", DateTime.Now) + ".log"
        Try
            File.Copy(Filepath, appPath & "\Files\" & Path.GetFileName(Filepath), True)
            UpdateLogTextWhite(Richtxt, Path.GetFileName(Filepath) & " " & "has been copied to the central folder.")
        Catch ex As Exception
            UpdateLogTextRed(Richtxt, ex.Message)
        End Try

        Filepath = "C:\Users\FRONTIER\AppData\Roaming\imaginekiosk\Local Store\IKLogs\" + String.Format("{0:yyyyMMdd}", DateTime.Now) + "-archive.zip"
        Try
            File.Copy(Filepath, appPath & "\Files\" & Path.GetFileName(Filepath), True)
            UpdateLogTextWhite(Richtxt, Path.GetFileName(Filepath) & " " & "has been copied to the central folder.")
        Catch ex As Exception
            UpdateLogTextRed(Richtxt, ex.Message)
        End Try


        Filepath = "C:\Users\FRONTIER\AppData\Roaming\imaginekiosk\Local Store\IKLogs\"
        Try
            For Each logfile In Directory.GetFiles(Filepath, "*.log", SearchOption.AllDirectories)
                If File.Exists(logfile) Then
                    File.Copy(logfile, Path.Combine(appPath & "\Files\", Path.GetFileName(logfile)), True)
                    UpdateLogTextWhite(Richtxt, Path.GetFileName(logfile) & " " & "has been copied to the central folder.")
                End If
            Next
        Catch ex As Exception
            UpdateLogTextRed(Richtxt, ex.Message)
        End Try

        If Directory.GetFiles(startPath).Length > 0 Then
            Try
                ZipFile.CreateFromDirectory(startPath, zipPath)
                UpdateLogTextWhite(Richtxt, "Kiosk Log Files zipped succesfully to " & zipPath)
            Catch ex As Exception
                UpdateLogTextRed(Richtxt, ex.Message)
            End Try
        End If

    End Sub
End Module
