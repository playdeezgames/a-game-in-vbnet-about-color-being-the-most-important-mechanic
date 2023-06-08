Friend Module Run
    Friend Sub Run()
        Dim avatar = World.Avatar
        avatar.Verbs(VerbTypes.Run).Execute(avatar)
    End Sub
End Module
