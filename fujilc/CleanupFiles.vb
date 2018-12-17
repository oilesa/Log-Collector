Imports System.IO
Module CleanupFiles
    Public Sub CleanupFile(ByVal Richtxt As RichTextBox, ByVal startPath As String)
        UpdateLogTextLime(Richtxt, "Starting logs collection process...")
        Try
            For Each D In Directory.GetDirectories(startPath)
                Directory.Delete(D, True)
            Next
            UpdateLogTextWhite(Richtxt, "Directory Cleanup is complete.")
        Catch ex As Exception
            UpdateLogTextRed(Richtxt, ex.Message)
        End Try

        Try
            For Each F In Directory.GetFiles(startPath)
                File.Delete(F)
            Next
            UpdateLogTextWhite(Richtxt, "File Cleanup is complete.")
        Catch ex As Exception
            UpdateLogTextRed(Richtxt, ex.Message)
        End Try
    End Sub
End Module
