Friend Class Route
    Inherits RouteDataClient
    Implements IRoute
    Public Sub New(worldData As WorldData, locationId As Integer, direction As String)
        MyBase.New(worldData, locationId, direction)
    End Sub
    Public ReadOnly Property ToLocation As ILocation Implements IRoute.ToLocation
        Get
            Return New Location(WorldData, RouteData.ToLocationId)
        End Get
    End Property
End Class
