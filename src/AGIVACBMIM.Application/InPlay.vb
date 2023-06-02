Friend Module InPlay
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer so playing the game right now!")
            Dim avatar = World.Avatar
            AnsiConsole.MarkupLine($"Location Id: {avatar.Location.Id}")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatTitle}
            If avatar.Location.HasRoutes Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(MainMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case MoveText
                    Move.Run()
                Case MainMenuText
                    Exit Do
                Case Else
                    Throw New NotImplementedException
            End Select
        Loop
    End Sub
End Module
