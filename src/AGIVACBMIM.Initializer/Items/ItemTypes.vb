Friend Module ItemTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {
                Snax,
                New ItemTypeDescriptor("Snax")
            }
        }
    Friend Const Snax = "Snax"
End Module
