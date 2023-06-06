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
    Sub AddVerb(key As String, name As String, parameters As IReadOnlyDictionary(Of String, Integer))
    ReadOnly Property HasItems As Boolean
    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of String, IEnumerable(Of IItem))
    ReadOnly Property Items As IEnumerable(Of IItem)
    ReadOnly Property Verbs(verbName As String) As IVerb
End Interface
