Friend Class RouteDataClient
    Inherits LocationDataClient
    Protected ReadOnly Direction As String
    Public Sub New(worldData As WorldData, locationId As Integer, direction As String)
        MyBase.New(worldData, locationId)
    End Sub
    Protected ReadOnly Property RouteData As RouteData
        Get
            Return LocationData.Routes(Direction)
        End Get
    End Property
End Class
