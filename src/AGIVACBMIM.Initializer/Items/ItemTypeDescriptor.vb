Friend Class ItemTypeDescriptor
    Friend ReadOnly Property Name As String
    Friend ReadOnly Property Verbs As IReadOnlyDictionary(Of String, VerbDescriptor)
    Sub New(name As String, verbs As IReadOnlyDictionary(Of String, VerbDescriptor))
        Me.Name = name
        Me.Verbs = verbs
    End Sub
End Class
