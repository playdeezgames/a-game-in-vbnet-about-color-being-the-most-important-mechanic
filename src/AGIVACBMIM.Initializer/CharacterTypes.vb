Friend Module CharacterTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, CharacterTypeDescriptor) =
        New Dictionary(Of String, CharacterTypeDescriptor) From
        {
            {N00b, New CharacterTypeDescriptor("N00b", spawnCount:=1)},
            {Color, New CharacterTypeDescriptor("Color, the most important mechanic", spawnCount:=1)}
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    Friend Const N00b = "N00b"
    Friend Const Color = "Color"
End Module
