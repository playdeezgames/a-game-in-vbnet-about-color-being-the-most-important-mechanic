Friend Class Verb
    Implements IVerb
    Private ReadOnly Property Parameters As IReadOnlyDictionary(Of String, Integer)
    ReadOnly Property Name As String Implements IVerb.Name
    ReadOnly Property Executor As Action(Of ICharacter, IItem, ICharacter, IReadOnlyDictionary(Of String, Integer))
    Sub New(name As String, parameters As IReadOnlyDictionary(Of String, Integer), executor As Action(Of ICharacter, IItem, ICharacter, IReadOnlyDictionary(Of String, Integer)))
        Me.Parameters = parameters
        Me.Name = name
        Me.Executor = executor
    End Sub
    Public ReadOnly Property ParameterNames As IEnumerable(Of String) Implements IVerb.ParameterNames
        Get
            Return Parameters.Keys
        End Get
    End Property
    Public ReadOnly Property Parameter(parameterName As String) As Integer Implements IVerb.Parameter
        Get
            Return Parameters(parameterName)
        End Get
    End Property
    Public Sub Execute(Optional character As ICharacter = Nothing, Optional item As IItem = Nothing, Optional otherCharacter As ICharacter = Nothing) Implements IVerb.Execute
        Executor.Invoke(character, item, otherCharacter, Parameters)
    End Sub
End Class
