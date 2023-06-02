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
    Public Function CreateRoute(direction As String, toLocation As ILocation) As IRoute Implements ILocation.CreateRoute
        LocationData.Routes(direction) = New RouteData With {
            .ToLocationId = toLocation.Id}
        Return New Route(WorldData, LocationId, direction)
    End Function
End Class
