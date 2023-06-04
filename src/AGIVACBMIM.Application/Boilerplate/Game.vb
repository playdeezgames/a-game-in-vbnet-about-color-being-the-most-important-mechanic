Public Module Game
    Public Sub Run()
        Business.World.Verbs = Verbs.All
        Welcome.Run()
        MainMenu.Run()
    End Sub
End Module
