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
End Module
