Friend Module InPlay
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer so playing the game right now!")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatTitle}
            prompt.AddChoice(MainMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case MainMenuText
                    Exit Do
                Case Else
                    Throw New NotImplementedException
            End Select
        Loop
    End Sub
End Module
