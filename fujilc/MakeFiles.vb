Imports System.IO
Imports System.IO.Compression

Module MakeFiles
    Public Sub Makefile(ByVal Richtexh As RichTextBox, objinifile As clsIni)

        'Read ini file and copy files to the central location 

        Dim appPath As String = Application.StartupPath()
        Dim startPath As String = appPath & "\Files\"
        Dim zipPath As String = appPath & "\Zipped\" & "errorlog.zip"
        Dim lines As Integer

        lines = IO.File.ReadAllLines(appPath + "\Settings.ini").Length '- 7

        For i = 0 To lines
            Dim filepath As String = objinifile.GetString("FILES", "PATH" & i, "")
            Try
                If filepath <> "" Then
                    File.Copy(filepath, appPath & "\Files\" & Path.GetFileName(filepath), True)
                    UpdateLogTextWhite(Richtexh, Path.GetFileName(filepath) & " " & "has been copied to the central folder.")
                End If
            Catch ex As Exception
                UpdateLogTextRed(Richtexh, ex.Message)
            End Try

        Next

        'Call delete existing zipped log file function

        DeletezipFile(Richtexh, zipPath)

        'zip copied files

        Try
            ZipFile.CreateFromDirectory(startPath, zipPath)
            UpdateLogTextWhite(Richtexh, "Files zipped succesfully to " & zipPath)
        Catch ex As Exception
            UpdateLogTextRed(Richtexh, ex.Message)
        End Try

    End Sub
End Module
