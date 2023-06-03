Public Interface ICharacter
    ReadOnly Property Id As Integer
    Property Location As ILocation
    Sub Move(direction As String)
    ReadOnly Property CharacterType As String
    ReadOnly Property Name As String
    ReadOnly Property CanInteract As Boolean
End Interface
