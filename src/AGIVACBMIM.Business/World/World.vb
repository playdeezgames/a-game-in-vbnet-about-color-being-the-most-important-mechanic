Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Public Sub New(worldData As WorldData)
        MyBase.New(worldData)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            If WorldData.AvatarCharacterId.HasValue Then
                Return New Character(WorldData, WorldData.AvatarCharacterId.Value)
            End If
            Return Nothing
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                WorldData.AvatarCharacterId = Nothing
                Return
            End If
            WorldData.AvatarCharacterId = value.Id
        End Set
    End Property

    Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IWorld.Locations
        Get
            Dim result = New List(Of ILocation)
            For index = 0 To WorldData.Locations.Count - 1
                result.Add(New Location(WorldData, index))
            Next
            Return result
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements IWorld.Characters
        Get
            Dim result = New List(Of ICharacter)
            For index = 0 To WorldData.Characters.Count - 1
                result.Add(New Character(WorldData, index))
            Next
            Return result
        End Get
    End Property

    Public Function CreateLocation(name As String) As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData With {.Name = name})
        Return New Location(WorldData, locationId)
    End Function

    Public Function CreateCharacter(characterType As String, name As String, location As ILocation) As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = WorldData.Characters.Count
        WorldData.Characters.Add(New CharacterData With {
                                 .CharacterType = characterType,
                                 .LocationId = location.Id,
                                 .Name = name})
        Dim result = New Character(WorldData, characterId)
        result.Location = location
        Return result
    End Function
End Class
