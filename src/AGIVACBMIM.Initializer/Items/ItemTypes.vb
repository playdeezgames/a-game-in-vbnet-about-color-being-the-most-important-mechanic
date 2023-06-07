Friend Module ItemTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {
                Snax,
                New ItemTypeDescriptor(
                    "Snax",
                    New Dictionary(Of String, VerbDescriptor) From
                    {
                        {
                            VerbTypes.ChangeEnergy,
                            New VerbDescriptor("Eat", New Dictionary(Of String, Integer) From
                            {
                                {StatisticTypes.Energy, 10}
                            })
                        }
                    })
            },
            {
                Goo,
                New ItemTypeDescriptor(
                    "Goo",
                    New Dictionary(Of String, VerbDescriptor))
            }
        }
    Friend Const Goo = "Goo"
    Friend Const Snax = "Snax"
End Module
