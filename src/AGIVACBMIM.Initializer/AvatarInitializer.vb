Imports SPLORR.Game

Friend Module AvatarInitializer
    Friend Sub Run(world As IWorld)
        world.Avatar = world.Characters.Single(Function(x) x.CharacterType = CharacterTypes.N00b)
    End Sub
End Module
