Module DeleteZipFiles
    Public Sub DeletezipFile(ByVal Richtexh As RichTextBox, ByVal zipPath As String)
        'Delete existing zip file
        Try
            If System.IO.File.Exists(zipPath) Then
                System.IO.File.Delete(zipPath)
                UpdateLogTextWhite(Richtexh, "Existing zip file has been deleted.")
            End If
        Catch ex As Exception
            UpdateLogTextRed(Richtexh, ex.Message)
        End Try
    End Sub
End Module
