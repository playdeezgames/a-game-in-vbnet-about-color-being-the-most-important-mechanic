Friend Module InPlay
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer so playing the game right now!")
            Dim avatar = World.Avatar
            Dim location = avatar.Location
            AnsiConsole.MarkupLine($"Location Id: {location.Id}")

            If location.HasRoutes Then
                Dim routes = location.Routes
                AnsiConsole.WriteLine()
                AnsiConsole.MarkupLine($"Exits:")
                For Each route In routes
                    AnsiConsole.MarkupLine($"    {route.Direction}")
                Next
            End If

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
