Friend Module Navigation
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        Dim avatar = World.Avatar
        AnsiConsole.MarkupLine($"{avatar.Name}:")
        AnsiConsole.MarkupLine($"    Energy: {avatar.Energy}/{avatar.MaximumEnergy}")
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
        If avatar.HasItems Then
            prompt.AddChoice(InventoryText)
        End If
        prompt.AddChoice(MainMenuText)
        Select Case AnsiConsole.Prompt(prompt)
            Case MoveText
                Move.Run()
            Case MainMenuText
                Return False
            Case InventoryText
                Inventory.Run()
            Case Else
                Throw New NotImplementedException
        End Select
        Return True
    End Function
End Module
