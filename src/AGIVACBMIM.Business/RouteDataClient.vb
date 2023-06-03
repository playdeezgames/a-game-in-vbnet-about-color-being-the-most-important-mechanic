Friend Class RouteDataClient
    Inherits LocationDataClient
    Protected ReadOnly DirectionId As String
    Public Sub New(worldData As WorldData, locationId As Integer, directionId As String)
        MyBase.New(worldData, locationId)
        Me.DirectionId = directionId
    End Sub
    Protected ReadOnly Property RouteData As RouteData
        Get
            Return LocationData.Routes(DirectionId)
        End Get
    End Property
End Class
