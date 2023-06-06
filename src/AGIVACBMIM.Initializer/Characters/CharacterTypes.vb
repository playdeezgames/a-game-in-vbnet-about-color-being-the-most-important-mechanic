Friend Module CharacterTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, CharacterTypeDescriptor) =
        New Dictionary(Of String, CharacterTypeDescriptor) From
        {
            {
                N00b,
                New CharacterTypeDescriptor(
                    "N00b",
                    New Dictionary(Of String, VerbDescriptor) From
                    {
                        {VerbTypes.Movement, New VerbDescriptor("Move", New Dictionary(Of String, Integer))}
                    },
                    spawnCount:=1,
                    statistics:=New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.MaximumEnergy, 100},
                        {StatisticTypes.Energy, 100}
                    },
                    canSpawn:=AddressOf OverworldOnly,
                    provisioner:=AddressOf N00bProvisioning)},
            {
                Color,
                New CharacterTypeDescriptor(
                    "Color, the most important mechanic",
                    New Dictionary(Of String, VerbDescriptor),
                    spawnCount:=1,
                    canSpawn:=AddressOf TownOnly)
            },
            {
                Hue,
                New CharacterTypeDescriptor(
                    "Hue, the mechanic",
                    New Dictionary(Of String, VerbDescriptor),
                    spawnCount:=1,
                    canSpawn:=AddressOf TownOnly)
            },
            {
                Shade,
                New CharacterTypeDescriptor(
                    "Shade, the mechanic",
                    New Dictionary(Of String, VerbDescriptor),
                    spawnCount:=1,
                    canSpawn:=AddressOf TownOnly)
            },
            {
                Tint,
                New CharacterTypeDescriptor(
                    "Tint, the mechanic",
                    New Dictionary(Of String, VerbDescriptor),
                    spawnCount:=1,
                    canSpawn:=AddressOf TownOnly)
            },
            {
                Tone,
                New CharacterTypeDescriptor(
                    "Tone, the mechanic",
                    New Dictionary(Of String, VerbDescriptor),
                    spawnCount:=1,
                    canSpawn:=AddressOf TownOnly)
            },
            {
                Pigment,
                New CharacterTypeDescriptor(
                    "Pigment, the mechanic",
                    New Dictionary(Of String, VerbDescriptor),
                    spawnCount:=1,
                    canSpawn:=AddressOf TownOnly)
            }
        }

    Private Function TownOnly(location As ILocation) As Boolean
        Return location.LocationType = LocationTypes.Town
    End Function

    Private Function OverworldOnly(location As ILocation) As Boolean
        Return location.LocationType = LocationTypes.Overworld
    End Function

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
