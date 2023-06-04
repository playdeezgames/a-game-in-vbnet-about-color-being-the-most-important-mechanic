﻿Public Class World
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

    Public Sub Save(filename As String) Implements IWorld.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(WorldData))
    End Sub

    Public Function CreateLocation(name As String) As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData With {.Name = name})
        Return New Location(WorldData, locationId)
    End Function

    Public Function CreateCharacter(
                            characterType As String,
                            name As String,
                            location As ILocation,
                            Optional statistics As IReadOnlyDictionary(Of String, Integer) = Nothing) As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = WorldData.Characters.Count
        WorldData.Characters.Add(New CharacterData With {
                                 .CharacterType = characterType,
                                 .LocationId = location.Id,
                                 .Name = name,
                                 .Statistics = statistics.ToDictionary(Function(x) x.Key, Function(x) x.Value)})
        Return New Character(WorldData, characterId) With {
            .Location = location
        }
    End Function
    Public Shared Function Load(filename As String) As IWorld
        Try
            Return New World(JsonSerializer.Deserialize(Of WorldData)(File.ReadAllText(filename)))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
