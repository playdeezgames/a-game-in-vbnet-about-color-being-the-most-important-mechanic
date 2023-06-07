Public Module Verbs
    Public ReadOnly Property All As IReadOnlyDictionary(Of String, Action(Of ICharacter, IItem, ICharacter, IReadOnlyDictionary(Of String, Integer))) =
        New Dictionary(Of String, Action(Of ICharacter, IItem, ICharacter, IReadOnlyDictionary(Of String, Integer))) From
        {
            {VerbTypes.Movement, AddressOf ExecuteMovement},
            {VerbTypes.ChangeEnergy, AddressOf ExecuteChangeEnergy},
            {VerbTypes.Fight, AddressOf ExecuteFight}
        }

    Private Sub ExecuteChangeEnergy(character As ICharacter, item As IItem, otherCharacter As ICharacter, parameters As IReadOnlyDictionary(Of String, Integer))
        Dim delta = parameters(StatisticTypes.Energy)
        character.SetEnergy(character.Energy + delta)
        character.AddMessage($"{character.Name} gains {delta} energy, and now has {character.Energy}/{character.MaximumEnergy}.")
        If item IsNot Nothing Then
            character.RemoveItem(item)
            item.Destroy()
        End If
    End Sub

    Private Sub ExecuteMovement(character As ICharacter, item As IItem, otherCharacter As ICharacter, parameters As IReadOnlyDictionary(Of String, Integer))
        character.SetEnergy(character.Energy - 1)
    End Sub
End Module
