Friend Module Buy
    Friend Sub Run()
        Dim avatar = World.Avatar
        Dim sellers = avatar.Location.OtherCharacters(avatar).Where(Function(x) x.HasPrices)
        Select Case sellers.Count
            Case 0
                Return
            Case 1
                RunSeller(avatar, sellers.Single)
            Case Else
                Dim prompt As New SelectionPrompt(Of String) With {.Title = BuyFromTitle}
                prompt.AddChoice(NeverMindText)
                Dim table = sellers.ToDictionary(Function(x) x.Name, Function(x) x)
                prompt.AddChoices(table.Keys)
                Dim answer = AnsiConsole.Prompt(prompt)
                Select Case answer
                    Case NeverMindText
                        Return
                    Case Else
                        RunSeller(avatar, table(answer))
                End Select
        End Select
    End Sub

    Private Sub RunSeller(avatar As ICharacter, seller As ICharacter)
        Dim prices = seller.Prices
        Dim prompt As New SelectionPrompt(Of String) With {.Title = BuyWhatTitle}
        prompt.AddChoice(NeverMindText)
        Dim table = prices.ToDictionary(Of String, String)(Function(x) $"{x.Key}({x.Value} jools each)", Function(x) x.Key)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                RunSale(avatar, table(answer), prices(table(answer)))
        End Select
    End Sub
    Private Sub RunSale(avatar As ICharacter, itemType As String, itemPriceEach As Integer)
        Dim maximumItems = avatar.Jools \ itemPriceEach
        If maximumItems = 0 Then
            avatar.AddMessage($"{avatar.Name} can't afford any!")
            Return
        End If
        Dim quantity = Math.Clamp(AnsiConsole.Ask(Of Integer)(HowManyTitle, maximumItems), 0, maximumItems)
        If quantity > 0 Then
            avatar.Buy(itemType, quantity, itemPriceEach)
        End If
    End Sub
End Module
