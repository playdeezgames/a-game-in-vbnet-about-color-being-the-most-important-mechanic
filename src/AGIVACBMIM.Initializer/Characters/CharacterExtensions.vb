Imports System.Runtime.CompilerServices
Public Module CharacterExtensions
    <Extension>
    Public Function Energy(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.Energy)
    End Function
    <Extension>
    Public Function MaximumEnergy(character As ICharacter) As Integer
        Return character.GetStatistic(StatisticTypes.MaximumEnergy)
    End Function
    <Extension>
    Public Function IsDead(character As ICharacter) As Boolean
        Return character.GetStatistic(StatisticTypes.Energy) <= 0
    End Function
End Module
