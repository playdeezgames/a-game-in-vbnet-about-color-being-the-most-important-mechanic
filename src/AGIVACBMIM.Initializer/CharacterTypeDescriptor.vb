Friend Class CharacterTypeDescriptor
    Friend ReadOnly Property Name As String
    Friend ReadOnly Property SpawnCount As Integer
    Friend Sub New(name As String, Optional spawnCount As Integer = 0)
        Me.Name = name
        Me.SpawnCount = spawnCount
    End Sub
End Class
