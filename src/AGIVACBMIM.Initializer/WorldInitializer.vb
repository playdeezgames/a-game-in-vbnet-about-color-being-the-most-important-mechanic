Public Module WorldInitializer
    Sub Run(world As IWorld)
        OverworldInitializer.Run(world)
        TownInitializer.Run(world)
        CharacterInitializer.Run(world)
        AvatarInitializer.Run(world)
    End Sub
End Module
