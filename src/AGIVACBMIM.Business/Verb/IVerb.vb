Public Interface IVerb
    ReadOnly Property Name As String
    Sub Execute(Optional character As ICharacter = Nothing, Optional item As IItem = Nothing)
    ReadOnly Property ParameterNames As IEnumerable(Of String)
    ReadOnly Property Parameter(parameterName As String) As Integer
End Interface
