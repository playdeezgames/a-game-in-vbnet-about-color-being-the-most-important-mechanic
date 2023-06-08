Friend Module Neutral
    Friend Function Run() As Boolean
        Dim avatar = World.Avatar
        If World.HasMessages Then
            Dim messageCounter = 0
            For Each message In World.Messages
                AnsiConsole.MarkupLine(message)
                messageCounter += 1
                If messageCounter Mod 10 = 0 Then
                    OkPrompt()
                End If
            Next
            World.ClearMessages()
            If messageCounter > 5 AndAlso Not messageCounter Mod 10 = 0 Then
                OkPrompt()
                AnsiConsole.Clear()
            End If
        End If
        If avatar.IsDead Then
            GameOver.Run()
            Return False
        End If
        Return Navigation.Run()
    End Function
End Module
