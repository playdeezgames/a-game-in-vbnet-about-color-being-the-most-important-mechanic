Friend Class CharacterTypeDescriptor
    Friend ReadOnly Property Name As String
    Friend ReadOnly Property SpawnCount As Integer
    Friend ReadOnly Property Provisioner As Action(Of ICharacter)
    Friend ReadOnly Property IsEnemy As Boolean
    Friend Sub New(
                  name As String,
                  verbs As IReadOnlyDictionary(Of String, VerbDescriptor),
                  Optional isEnemy As Boolean = True,
                  Optional statistics As IReadOnlyDictionary(Of String, Integer) = Nothing,
                  Optional spawnCount As Integer = 0,
                  Optional canSpawn As Func(Of ILocation, Boolean) = Nothing,
                  Optional provisioner As Action(Of ICharacter) = Nothing)
        Me.Name = name
        Me.SpawnCount = spawnCount
        Me.Statistics = If(statistics, New Dictionary(Of String, Integer))
        Me.CanSpawn = canSpawn
        Me.Provisioner = If(provisioner, AddressOf NoProvisioning)
        Me.Verbs = verbs
        Me.IsEnemy = isEnemy
    End Sub
    Friend ReadOnly Property Statistics As IReadOnlyDictionary(Of String, Integer)
    Friend ReadOnly Property CanSpawn As Func(Of ILocation, Boolean)
    Friend ReadOnly Property Verbs As IReadOnlyDictionary(Of String, VerbDescriptor)
End Class
