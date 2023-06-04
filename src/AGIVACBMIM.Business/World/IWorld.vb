Public Interface IWorld
    Function CreateLocation(name As String) As ILocation
    Function CreateCharacter(
                            characterType As String,
                            name As String,
                            location As ILocation,
                            Optional statistics As IReadOnlyDictionary(Of String, Integer) = Nothing) As ICharacter
    Property Avatar As ICharacter
    ReadOnly Property Locations As IEnumerable(Of ILocation)
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    Sub Save(filename As String)
End Interface
