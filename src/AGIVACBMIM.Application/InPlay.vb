Friend Module InPlay
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer so playing the game right now!")
            Dim avatar = World.Avatar
            Dim location = avatar.Location
            AnsiConsole.MarkupLine($"
Location: 
    {location.Name}")

            If location.HasRoutes Then
                Dim routes = location.Routes
                AnsiConsole.WriteLine()
                AnsiConsole.MarkupLine($"Exits:")
                For Each route In routes
                    AnsiConsole.MarkupLine($"    {route.Direction}")
                Next
            End If

            Dim otherCharacters = location.OtherCharacters(avatar)
            If otherCharacters.Any Then
                AnsiConsole.WriteLine()
                AnsiConsole.MarkupLine("Other Characters:")
                For Each character In otherCharacters
                    AnsiConsole.MarkupLine($"    {character.Name}")
                Next
            End If

            AnsiConsole.WriteLine()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatTitle}
            If location.HasRoutes Then
                prompt.AddChoice(MoveText)
            End If
            If otherCharacters.Any(Function(x) x.CanInteract) Then
                prompt.AddChoice(InteractText)
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
