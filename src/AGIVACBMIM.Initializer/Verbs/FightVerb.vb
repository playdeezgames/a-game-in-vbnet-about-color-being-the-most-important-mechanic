Imports SPLORR.Game

Friend Module FightVerb
    Friend Sub ExecuteFight(character As ICharacter, item As IItem, target As ICharacter, dictionary As IReadOnlyDictionary(Of String, Integer))
        ExecuteAttack(character, target)
        For Each enemy In character.Location.Enemies(character)
            ExecuteAttack(enemy, character)
        Next
    End Sub
    Friend Sub ExecuteRun(character As ICharacter, item As IItem, target As ICharacter, dictionary As IReadOnlyDictionary(Of String, Integer))
        If RNG.FromRange(0, 1) > 0 Then
            character.AddMessage($"{character.Name} runs!")
            character.Move(RNG.FromEnumerable(character.Location.Routes.Select(Function(x) x.Direction)))
            Return
        End If
        character.AddMessage($"{character.Name} can't get away!")
        For Each enemy In character.Location.Enemies(character)
            ExecuteAttack(enemy, character)
        Next
    End Sub
    Private Sub ExecuteAttack(attacker As ICharacter, defender As ICharacter)
        Dim addMessages = Sub(m As String) MessageAdder(attacker, defender, m)
        If attacker.IsDead OrElse defender.IsDead Then
            Return
        End If
        addMessages($"{attacker.Name} attacks {defender.Name}!")
        Dim attackRoll = attacker.RollAttack()
        addMessages($"{attacker.Name} rolls an attack of {attackRoll}!")
        Dim defendRoll = defender.RollDefend()
        addMessages($"{defender.Name} rolls a defense of {defendRoll}!")
        Dim damage = Math.Max(0, attackRoll - defendRoll)
        If damage > 0 Then
            addMessages($"{attacker.Name} hits for {damage} damage!")
            defender.SetHealth(defender.Health - damage)
            If defender.IsDead Then
                addMessages($"{attacker.Name} kills {defender.Name}!")
                defender.Kill()
            Else
                addMessages($"{defender.Name} has {defender.Health} health remaining.")
            End If
        Else
            addMessages($"{attacker.Name} missed!")
        End If
    End Sub

    Private Sub MessageAdder(attacker As ICharacter, defender As ICharacter, message As String)
        attacker.AddMessage(message)
        defender.AddMessage(message)
    End Sub
End Module
