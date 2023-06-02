Public Interface ILocation
    Function CreateRoute(direction As String, toLocation As ILocation) As IRoute
    ReadOnly Property Id As Integer
End Interface
