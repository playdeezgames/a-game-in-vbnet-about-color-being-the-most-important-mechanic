Imports System.Runtime.CompilerServices
Imports SPLORR.Game

Public Module CharacterExtensions
    <Extension>
    Public Function Energy(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.Energy)
    End Function
    <Extension>
    Public Sub SetEnergy(character As ICharacter, energy As Integer)
        character.SetStatistic(StatisticTypes.Energy, Math.Clamp(energy, 0, character.MaximumEnergy))
    End Sub
    <Extension>
    Public Function MaximumEnergy(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.MaximumEnergy)
    End Function
    <Extension>
    Public Function IsDead(character As ICharacter) As Boolean
        Return character.GetStatistic(StatisticTypes.Energy) <= 0 OrElse character.GetStatistic(StatisticTypes.Health) <= 0
    End Function
    <Extension>
    Public Function Health(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.Health)
    End Function
    <Extension>
    Public Sub SetHealth(character As ICharacter, health As Integer)
        character.SetStatistic(StatisticTypes.Health, Math.Clamp(health, 0, character.MaximumHealth))
    End Sub
    <Extension>
    Public Sub Kill(character As ICharacter)
        Dim location = character.Location
        For Each item In character.Items
            character.RemoveItem(item)
            location.AddItem(item)
        Next
        character.Location.RemoveCharacter(character)
        'TODO: drop items
    End Sub
    <Extension>
    Public Function MaximumHealth(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.MaximumHealth)
    End Function
    <Extension>
    Public Function RollAttack(character As ICharacter) As Integer
        Return RNG.FromRange(1, character.GetStatistic(StatisticTypes.Attack))
    End Function
    <Extension>
    Public Function RollDefend(character As ICharacter) As Integer
        Return RNG.FromRange(1, character.GetStatistic(StatisticTypes.Defend))
    End Function
    <Extension>
    Public Function Jools(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.Jools)
    End Function
    <Extension>
    Public Sub SetJools(character As ICharacter, jools As Integer)
        character.SetStatistic(StatisticTypes.Jools, jools)
    End Sub
    <Extension>
    Public Function HasOffers(character As ICharacter) As Boolean
        Return character.CharacterType = CharacterTypes.Color
    End Function
    Private ReadOnly pricesTable As IReadOnlyDictionary(Of String, IReadOnlyDictionary(Of String, Integer)) =
        New Dictionary(Of String, IReadOnlyDictionary(Of String, Integer)) From
        {
            {
                CharacterTypes.Hue,
                New Dictionary(Of String, Integer) From
                {
                    {ItemTypes.Snax, 2}
                }
            },
            {
                CharacterTypes.Tint,
                New Dictionary(Of String, Integer) From
                {
                    {ItemTypes.Snax, 2}
                }
            },
            {
                CharacterTypes.Tone,
                New Dictionary(Of String, Integer) From
                {
                    {ItemTypes.Snax, 2}
                }
            },
            {
                CharacterTypes.Shade,
                New Dictionary(Of String, Integer) From
                {
                    {ItemTypes.Snax, 2}
                }
            },
            {
                CharacterTypes.Pigment,
                New Dictionary(Of String, Integer) From
                {
                    {ItemTypes.Snax, 2}
                }
            }
        }
    <Extension>
    Public Function Prices(character As ICharacter) As IReadOnlyDictionary(Of String, Integer)
        If pricesTable.ContainsKey(character.CharacterType) Then
            Return pricesTable(character.CharacterType)
        End If
        Return New Dictionary(Of String, Integer)
    End Function
    <Extension>
    Public Function Offers(character As ICharacter) As IReadOnlyDictionary(Of String, Integer)
        If character.CharacterType <> CharacterTypes.Color Then
            Return New Dictionary(Of String, Integer)
        End If
        Return New Dictionary(Of String, Integer) From
            {
                {ItemTypes.Goo, 1}
            }
    End Function
    <Extension>
    Sub Sell(character As ICharacter, itemType As String, quantity As Integer, itemOfferEach As Integer)
        Dim soldItems = character.Items.Where(Function(x) x.ItemType = itemType).Take(quantity)
        For Each soldItem In soldItems
            character.RemoveItem(soldItem)
            soldItem.Destroy()
            character.SetJools(character.Jools + itemOfferEach)
        Next
        character.AddMessage($"{character.Name} sold {quantity} {itemType} for {quantity * itemOfferEach} jools.")
    End Sub
    <Extension>
    Sub Buy(character As ICharacter, itemType As String, quantity As Integer, itemPriceEach As Integer)
        character.AddMessage($"{character.Name} buys {quantity} {itemType} for {quantity * itemPriceEach} jools.")
        While quantity > 0
            character.SetJools(character.Jools - itemPriceEach)
            SpawnItemInCharacterInventory(character, itemType, ItemTypes.Descriptors(itemType))
            quantity -= 1
        End While
    End Sub
    <Extension>
    Public Function HasPrices(character As ICharacter) As Boolean
        Select Case character.CharacterType
            Case CharacterTypes.Shade,
                 CharacterTypes.Pigment,
                 CharacterTypes.Hue,
                 CharacterTypes.Tone,
                 CharacterTypes.Tint
                Return True
            Case Else
                Return False
        End Select
    End Function
End Module
