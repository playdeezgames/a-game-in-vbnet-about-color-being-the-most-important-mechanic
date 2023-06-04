Imports SPLORR.Game

Friend Module CharacterInitializer
    Friend Sub Run(world As IWorld)
        For Each characterType In CharacterTypes.All
            Dim descriptor = CharacterTypes.Descriptors(characterType)
            Dim spawnCount = descriptor.SpawnCount
            While spawnCount > 0
                SpawnCharacter(world, characterType, descriptor)
                spawnCount -= 1
            End While
        Next
    End Sub
    Private Sub SpawnCharacter(world As IWorld, characterType As String, descriptor As CharacterTypeDescriptor)
        world.CreateCharacter(
            characterType,
            descriptor.Name,
            RNG.FromEnumerable(world.Locations),
            statistics:=descriptor.Statistics)
    End Sub
End Module
