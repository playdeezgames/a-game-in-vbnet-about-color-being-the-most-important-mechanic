Friend Module Navigation
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        Dim avatar = World.Avatar
        If World.HasMessages Then
            Dim messageCounter = 0
            For Each message In World.Messages
                AnsiConsole.MarkupLine(message)
                messageCounter += 1
                If messageCounter Mod 10 = 0 Then
                    OkPrompt()
                End If
            Next
            World.ClearMessages()
            If messageCounter > 5 AndAlso Not messageCounter Mod 10 = 0 Then
                OkPrompt()
                AnsiConsole.Clear()
            End If
        End If
        AnsiConsole.MarkupLine($"{avatar.Name}:")
        AnsiConsole.MarkupLine($"    Energy: {avatar.Energy}/{avatar.MaximumEnergy}")
        AnsiConsole.MarkupLine($"    Health: {avatar.Health}/{avatar.MaximumHealth}")
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
            For Each group In otherCharacters.GroupBy(Function(x) x.Name)
                AnsiConsole.MarkupLine($"    {group.Key}(x{group.Count})")
            Next
        End If

        AnsiConsole.WriteLine()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatTitle}
        If location.CanFight(avatar) Then
            prompt.AddChoice(FightText)
        ElseIf location.HasRoutes Then
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
            Case FightText
                Fight.Run()
            Case Else
                Throw New NotImplementedException
        End Select
        Return True
    End Function
End Module
