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
                                {StatisticTypes.Energy, 1}
                            })
                        }
                    })
            }
        }
    Friend Const Snax = "Snax"
End Module
