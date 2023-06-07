Friend Module Fight
    Friend Sub Run()
        Dim avatar = World.Avatar
        Dim enemies = avatar.Location.Enemies(avatar)
        If enemies.Count = 1 Then
            RunEnemy(avatar, enemies.Single)
            Return
        End If
        Dim table As New Dictionary(Of String, ICharacter)
        Dim suffix = ""
        For Each enemy In enemies
            table($"{enemy.Name}({enemy.Health}/{enemy.MaximumHealth}){suffix}") = enemy
            suffix &= " " + ChrW(8)
        Next
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ChooseEnemyTitle}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                RunEnemy(avatar, table(answer))
        End Select
    End Sub

    Private Sub RunEnemy(avatar As ICharacter, enemy As ICharacter)
        avatar.Verbs(VerbTypes.Fight).Execute(avatar, otherCharacter:=enemy)
    End Sub
End Module
