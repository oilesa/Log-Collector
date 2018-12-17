Module UpdateLogText

    Public Sub UpdateLogTextLime(ByVal Richtxt As RichTextBox, ByVal Message As String)
        Richtxt.SelectionColor = Color.Lime
        Richtxt.AppendText(Message & Environment.NewLine)
        Richtxt.ScrollToCaret()
    End Sub
    Public Sub UpdateLogTextRed(ByVal Richtxt As RichTextBox, ByVal Message As String)
        Richtxt.SelectionColor = Color.Red
        Richtxt.AppendText(Message & Environment.NewLine)
        Richtxt.ScrollToCaret()
    End Sub
    Public Sub UpdateLogTextGold(ByVal Richtxt As RichTextBox, ByVal Message As String)
        Richtxt.SelectionColor = Color.Gold
        Richtxt.AppendText(Message & Environment.NewLine)
        Richtxt.ScrollToCaret()
    End Sub
    Public Sub UpdateLogTextWhite(ByVal Richtxt As RichTextBox, ByVal Message As String)
        Richtxt.AppendText(Message & Environment.NewLine)
        Richtxt.ScrollToCaret()
    End Sub
End Module
