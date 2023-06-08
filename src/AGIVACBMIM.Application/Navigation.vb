Friend Module Navigation
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        Dim avatar = World.Avatar
        AnsiConsole.MarkupLine($"{avatar.Name}:")
        AnsiConsole.MarkupLine($"    Energy: {avatar.Energy}/{avatar.MaximumEnergy}")
        AnsiConsole.MarkupLine($"    Health: {avatar.Health}/{avatar.MaximumHealth}")
        AnsiConsole.MarkupLine($"    Jools: {avatar.Jools}")
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

        If location.HasItems Then
            Dim items = location.Items.GroupBy(Function(x) x.Name)
            AnsiConsole.WriteLine()
            AnsiConsole.MarkupLine($"On the Ground:")
            For Each item In items
                AnsiConsole.MarkupLine($"    {item.Key}(x{item.Count})")
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
            prompt.AddChoice(RunText)
        Else
            If location.HasItems Then
                prompt.AddChoice(TakeText)
            End If
            If location.HasRoutes Then
                prompt.AddChoice(MoveText)
            End If
        End If
        If otherCharacters.Any(Function(x) x.CanInteract) Then
            prompt.AddChoice(InteractText)
        End If
        If avatar.HasItems Then
            prompt.AddChoice(InventoryText)
        End If
        If otherCharacters.Any(Function(x) x.HasOffers) Then
            prompt.AddChoice(SellText)
        End If
        If otherCharacters.Any(Function(x) x.HasPrices) Then
            prompt.AddChoice(BuyText)
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
            Case TakeText
                Take.Run()
            Case RunText
                Application.Run.Run()
            Case SellText
                Sell.Run()
            Case BuyText
                Buy.Run()
            Case Else
                Throw New NotImplementedException
        End Select
        Return True
    End Function
End Module
