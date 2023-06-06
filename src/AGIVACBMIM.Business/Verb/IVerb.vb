Public Interface IVerb
    ReadOnly Property Name As String
    Sub Execute(character As ICharacter)
    ReadOnly Property ParameterNames As IEnumerable(Of String)
    ReadOnly Property Parameter(parameterName As String) As Integer
End Interface
