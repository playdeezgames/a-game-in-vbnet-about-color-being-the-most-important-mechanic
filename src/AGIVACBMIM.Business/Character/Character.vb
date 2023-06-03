Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter
    Public Sub New(worldData As WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property
    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, CharacterData.LocationId)
        End Get
        Set(value As ILocation)
            Location.RemoveCharacter(Me)
            CharacterData.LocationId = value.Id
            Location.AddCharacter(Me)
        End Set
    End Property
    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return CharacterData.CharacterType
        End Get
    End Property
    Public Sub Move(direction As String) Implements ICharacter.Move
        If Location.HasRoute(direction) Then
            Location = Location.Route(direction).ToLocation
        End If
    End Sub
End Class
