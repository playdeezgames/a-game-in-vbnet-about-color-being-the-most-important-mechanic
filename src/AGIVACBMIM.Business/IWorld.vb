Public Interface IWorld
    Function CreateLocation() As ILocation
    Function CreateCharacter(location As ILocation) As ICharacter
    Property Avatar As ICharacter
End Interface
