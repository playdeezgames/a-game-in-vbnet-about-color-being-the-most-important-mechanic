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

    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return CharacterData.Name
        End Get
    End Property

    Public ReadOnly Property CanInteract As Boolean Implements ICharacter.CanInteract
        Get
            Return False
        End Get
    End Property

    Public Sub Move(direction As String) Implements ICharacter.Move
        If Location.HasRoute(direction) Then
            Location = Location.Route(direction).ToLocation
            World.Verbs(VerbTypes.Movement).Execute(character:=Me)
        End If
    End Sub

    Public Sub SetStatistic(statisticType As String, statisticValue As Integer) Implements ICharacter.SetStatistic
        CharacterData.Statistics(statisticType) = statisticValue
    End Sub

    Public Function GetStatistic(statisticType As String) As Integer Implements ICharacter.GetStatistic
        Return CharacterData.Statistics(statisticType)
    End Function
End Class
