Public Interface ICharacter
    ReadOnly Property Id As Integer
    Property Location As ILocation
    Sub Move(direction As String)
    ReadOnly Property CharacterType As String
    ReadOnly Property Name As String
    ReadOnly Property CanInteract As Boolean
    Function GetStatistic(statisticType As String) As Integer
    Sub SetStatistic(statisticType As String, statisticValue As Integer)
    ReadOnly Property World As IWorld
    Sub AddItem(item As IItem)
End Interface
