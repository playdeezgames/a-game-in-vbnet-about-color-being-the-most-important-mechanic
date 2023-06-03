Friend Module MainMenu
    Sub Run()
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = MainMenuTitle}
            If Context.World IsNot Nothing Then
                prompt.AddChoice(ContinueText)
                prompt.AddChoice(SaveText)
                prompt.AddChoice(AbandonText)
            Else
                prompt.AddChoice(EmbarkText)
                prompt.AddChoice(LoadText)
                prompt.AddChoice(QuitText)
            End If
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonText
                    If ConfirmPrompt(AbandonGameTitle) Then
                        Context.Abandon()
                    End If
                Case ContinueText
                    InPlay.Run()
                Case EmbarkText
                    Embark.Run()
                Case QuitText
                    If ConfirmPrompt(ConfirmQuitTitle) Then
                        Exit Do
                    End If
                Case SaveText
                    Save.Run()
                Case LoadText
                    Load.Run()
                Case Else
                    Throw New NotImplementedException
            End Select
        Loop
    End Sub
End Module
