Public Interface ILocation
    Function CreateRoute(direction As String, toLocation As ILocation) As IRoute
    ReadOnly Property Id As Integer
    ReadOnly Property HasRoutes As Boolean
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    Function HasRoute(direction As String) As Boolean
    ReadOnly Property Route(direction As String) As IRoute
    ReadOnly Property OtherCharacters(character As ICharacter) As IEnumerable(Of ICharacter)
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    ReadOnly Property Name As String
End Interface
