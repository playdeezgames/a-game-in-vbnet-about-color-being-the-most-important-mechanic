Friend Class ItemTypeDescriptor
    Friend ReadOnly Property Name As String
    Friend ReadOnly Property Verbs As IReadOnlyDictionary(Of String, IEnumerable(Of IReadOnlyDictionary(Of String, Integer)))
    Sub New(name As String, verbs As IReadOnlyDictionary(Of String, IEnumerable(Of IReadOnlyDictionary(Of String, Integer))))
        Me.Name = name
        Me.Verbs = verbs
    End Sub
End Class
