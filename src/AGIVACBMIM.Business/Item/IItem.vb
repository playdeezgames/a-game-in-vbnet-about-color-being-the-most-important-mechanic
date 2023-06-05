Public Interface IItem
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    ReadOnly Property VerbNames As IEnumerable(Of String)
End Interface
