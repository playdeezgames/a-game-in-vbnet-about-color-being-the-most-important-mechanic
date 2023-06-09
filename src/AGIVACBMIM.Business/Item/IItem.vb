﻿Public Interface IItem
    ReadOnly Property Id As Integer
    ReadOnly Property ItemType As String
    ReadOnly Property Name As String
    ReadOnly Property VerbNames As IEnumerable(Of String)
    ReadOnly Property Verb(verbName As String) As IVerb
    Sub AddVerb(key As String, name As String, parameters As IReadOnlyDictionary(Of String, Integer))
    Sub Destroy()
End Interface
