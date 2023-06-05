Friend Module Inventory
    Friend Sub Run()
        Dim avatar = World.Avatar
        Dim itemStacks = avatar.ItemStacks
        Dim table = itemStacks.ToDictionary(Function(x) $"{x.Key}(x{x.Value.Count})", Function(x) x.Value)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{avatar.Name}'s Inventory:[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
End Module
