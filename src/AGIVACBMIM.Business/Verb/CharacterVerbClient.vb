Friend Class CharacterVerbClient
    Inherits CharacterDataClient
    Protected ReadOnly Property VerbName As String
    Public Sub New(worldData As WorldData, characterId As Integer, verbName As String)
        MyBase.New(worldData, characterId)
        Me.VerbName = verbName
    End Sub
    Protected ReadOnly Property ItemVerbData As VerbData
        Get
            Return CharacterData.Verbs(VerbName)
        End Get
    End Property
End Class
