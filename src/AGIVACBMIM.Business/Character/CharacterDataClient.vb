Friend MustInherit Class CharacterDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property CharacterId As Integer
    Protected Sub New(worldData As WorldData, characterId As Integer)
        MyBase.New(worldData)
        Me.CharacterId = characterId
    End Sub
    Protected ReadOnly Property CharacterData As CharacterData
        Get
            Return WorldData.Characters(CharacterId)
        End Get
    End Property
End Class
