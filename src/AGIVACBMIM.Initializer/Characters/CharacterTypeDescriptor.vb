Friend Class CharacterTypeDescriptor
    Friend ReadOnly Property Name As String
    Friend ReadOnly Property SpawnCount As Integer
    Friend Sub New(
                  name As String,
                  Optional statistics As IReadOnlyDictionary(Of String, Integer) = Nothing,
                  Optional spawnCount As Integer = 0,
                  Optional canSpawn As Func(Of ILocation, Boolean) = Nothing)
        Me.Name = name
        Me.SpawnCount = spawnCount
        Me.Statistics = If(statistics, New Dictionary(Of String, Integer))
        Me.CanSpawn = canSpawn
    End Sub
    Friend ReadOnly Property Statistics As IReadOnlyDictionary(Of String, Integer)
    Friend ReadOnly Property CanSpawn As Func(Of ILocation, Boolean)
End Class
