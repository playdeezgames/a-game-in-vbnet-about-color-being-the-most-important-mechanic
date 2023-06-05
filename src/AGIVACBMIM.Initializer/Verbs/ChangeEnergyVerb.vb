Friend Class ChangeEnergyVerb
    Implements IVerb
    Public Sub Execute(Optional character As ICharacter = Nothing, Optional parameters As IVerbParameters = Nothing) Implements IVerb.Execute
        character.SetEnergy(character.Energy + If(parameters?.GetStatistic(StatisticTypes.Energy), 0))
    End Sub
End Class
