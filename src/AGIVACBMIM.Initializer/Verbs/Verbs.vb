Public Module Verbs
    Public ReadOnly Property All As IReadOnlyDictionary(Of String, IVerb) =
        New Dictionary(Of String, IVerb) From
        {
            {VerbTypes.Movement, New MovementVerb()}
        }
End Module
