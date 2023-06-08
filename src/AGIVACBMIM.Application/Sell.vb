Friend Module Sell
    Friend Sub Run()
        Dim avatar = World.Avatar
        Dim buyers = avatar.Location.OtherCharacters(avatar).Where(Function(x) x.HasOffers)
        Select Case buyers.Count
            Case 0
                Return
            Case 1
                RunBuyer(avatar, buyers.Single)
            Case Else
                Dim prompt As New SelectionPrompt(Of String) With {.Title = SellToTitle}
                prompt.AddChoice(NeverMindText)
                Dim table = buyers.ToDictionary(Function(x) x.Name, Function(x) x)
                prompt.AddChoices(table.Keys)
                Dim answer = AnsiConsole.Prompt(prompt)
                Select Case answer
                    Case NeverMindText
                        Return
                    Case Else
                        RunBuyer(avatar, table(answer))
                End Select
        End Select
    End Sub
    Private Sub RunBuyer(avatar As ICharacter, buyer As ICharacter)
        Dim offers = buyer.Offers
        Dim prompt As New SelectionPrompt(Of String) With {.Title = SellWhatTitle}
        prompt.AddChoice(NeverMindText)
        Dim table = offers.ToDictionary(Of String, String)(Function(x) $"{x.Key}({x.Value} jools each)", Function(x) x.Key)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                RunOffer(avatar, table(answer), offers(table(answer)))
        End Select
    End Sub
    Private Sub RunOffer(avatar As ICharacter, itemType As String, itemOfferEach As Integer)
        Dim maximumItems = avatar.Items.Count(Function(x) x.ItemType = itemType)
        If maximumItems = 0 Then
            avatar.AddMessage($"{avatar.Name} doesn't have any!")
            Return
        End If
        Dim quantity = Math.Clamp(AnsiConsole.Ask(Of Integer)(HowManyTitle, maximumItems), 0, maximumItems)
        If quantity > 0 Then
            avatar.Sell(itemType, quantity, itemOfferEach)
        End If
    End Sub
End Module
