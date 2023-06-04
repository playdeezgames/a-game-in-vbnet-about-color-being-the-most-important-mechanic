Friend Module Neutral
    Friend Function Run() As Boolean
        Dim avatar = World.Avatar
        If avatar.IsDead Then
            GameOver.Run()
            Return False
        End If
        Return Navigation.Run()
    End Function
End Module
