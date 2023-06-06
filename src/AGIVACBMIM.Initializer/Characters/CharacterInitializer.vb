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
    Private Sub SpawnCharacter(
            world As IWorld,
            characterType As String,
            descriptor As CharacterTypeDescriptor)
        Dim character = world.CreateCharacter(
            characterType,
            descriptor.Name,
            RNG.FromEnumerable(world.Locations.Where(Function(x) descriptor.CanSpawn(x))),
            statistics:=descriptor.Statistics)
        For Each verb In descriptor.Verbs
            character.AddVerb(verb.Key, verb.Value.Name, verb.Value.Parameters)
        Next
        descriptor.Provisioner.Invoke(character)
    End Sub
End Module
