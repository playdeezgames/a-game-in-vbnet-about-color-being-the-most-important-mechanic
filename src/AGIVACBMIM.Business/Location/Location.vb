Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Public Sub New(worldData As WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub
    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return LocationId
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements ILocation.HasRoutes
        Get
            Return LocationData.Routes.Any
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return LocationData.Routes.Select(Function(x) New Route(WorldData, LocationId, x.Key))
        End Get
    End Property

    Public ReadOnly Property Route(direction As String) As IRoute Implements ILocation.Route
        Get
            If HasRoute(direction) Then
                Return New Route(WorldData, LocationId, direction)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property OtherCharacters(character As ICharacter) As IEnumerable(Of ICharacter) Implements ILocation.OtherCharacters
        Get
            Return Characters.Where(Function(x) x.Id <> character.Id)
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements ILocation.Characters
        Get
            Return LocationData.CharacterIds.Select(Function(x) New Character(WorldData, x))
        End Get
    End Property

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        LocationData.CharacterIds.Add(character.Id)
    End Sub

    Public Sub RemoveCharacter(character As ICharacter) Implements ILocation.RemoveCharacter
        LocationData.CharacterIds.Remove(character.Id)
    End Sub

    Public Function CreateRoute(direction As String, toLocation As ILocation) As IRoute Implements ILocation.CreateRoute
        LocationData.Routes(direction) = New RouteData With {
            .ToLocationId = toLocation.Id}
        Return New Route(WorldData, LocationId, direction)
    End Function

    Public Function HasRoute(direction As String) As Boolean Implements ILocation.HasRoute
        Return LocationData.Routes.ContainsKey(direction)
    End Function
End Class
