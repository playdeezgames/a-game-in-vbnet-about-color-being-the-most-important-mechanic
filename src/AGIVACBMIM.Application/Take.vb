Friend Module Take
    Friend Sub Run()
        Dim avatar = World.Avatar
        Dim location = avatar.Location
        Dim itemStacks = location.Items.GroupBy(Function(x) x.Name)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = TakeTitle}
        prompt.AddChoice(NeverMindText)
        Dim table As New Dictionary(Of String, IEnumerable(Of IItem))
        For Each itemStack In itemStacks
            table($"{itemStack.Key}(x{itemStack.Count})") = itemStack
        Next
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                RunItemStack(avatar, location, table(answer))
        End Select
    End Sub

    Private Sub RunItemStack(character As ICharacter, location As ILocation, items As IEnumerable(Of IItem))
        Dim itemCount = Math.Clamp(AnsiConsole.Ask(HowManyTitle, items.Count), 0, items.Count)
        items = items.Take(itemCount)
        For Each item In items
            location.RemoveItem(item)
            character.AddItem(item)
        Next
    End Sub
End Module
