Friend Class VerbDescriptor
    ReadOnly Property Name As String
    ReadOnly Property Parameters As IReadOnlyDictionary(Of String, Integer)
    Sub New(name As String, parameters As IReadOnlyDictionary(Of String, Integer))
        Me.Name = name
        Me.Parameters = parameters
    End Sub
End Class
