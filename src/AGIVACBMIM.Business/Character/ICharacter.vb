﻿Public Interface ICharacter
    ReadOnly Property Id As Integer
    Property Location As ILocation
    Sub Move(direction As String)
End Interface
