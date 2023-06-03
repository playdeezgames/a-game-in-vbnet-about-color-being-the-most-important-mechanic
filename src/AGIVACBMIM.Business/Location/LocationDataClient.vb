Friend MustInherit Class LocationDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property LocationId As Integer
    Protected Sub New(worldData As WorldData, locationId As Integer)
        MyBase.New(worldData)
        Me.LocationId = locationId
    End Sub
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(LocationId)
        End Get
    End Property
End Class
