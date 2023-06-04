Friend Module CharacterTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, CharacterTypeDescriptor) =
        New Dictionary(Of String, CharacterTypeDescriptor) From
        {
            {
                N00b,
                New CharacterTypeDescriptor(
                    "N00b",
                    spawnCount:=1,
                    statistics:=New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.MaximumEnergy, 100},
                        {StatisticTypes.Energy, 10}
                    })},
            {Color, New CharacterTypeDescriptor("Color, the most important mechanic", spawnCount:=1)},
            {Hue, New CharacterTypeDescriptor("Hue, the mechanic", spawnCount:=1)},
            {Shade, New CharacterTypeDescriptor("Shade, the mechanic", spawnCount:=1)},
            {Tint, New CharacterTypeDescriptor("Tint, the mechanic", spawnCount:=1)},
            {Tone, New CharacterTypeDescriptor("Tone, the mechanic", spawnCount:=1)},
            {Pigment, New CharacterTypeDescriptor("Pigment, the mechanic", spawnCount:=1)}
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    Friend Const N00b = "N00b"
    Friend Const Color = "Color"
    Friend Const Hue = "Hue"
    Friend Const Shade = "Shade"
    Friend Const Tint = "Tint"
    Friend Const Tone = "Tone"
    Friend Const Pigment = "Pigment"
End Module
