Friend Class MovementVerb
    Implements IVerb
    Public Sub Execute(Optional character As ICharacter = Nothing) Implements IVerb.Execute
        Dim newEnergy = character.GetStatistic(StatisticTypes.Energy) - 1
        character.SetStatistic(StatisticTypes.Energy, newEnergy)
    End Sub
End Class
