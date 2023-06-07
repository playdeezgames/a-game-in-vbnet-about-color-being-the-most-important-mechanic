Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter
    Public Sub New(worldData As WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property
    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, CharacterData.LocationId)
        End Get
        Set(value As ILocation)
            Location.RemoveCharacter(Me)
            CharacterData.LocationId = value.Id
            Location.AddCharacter(Me)
        End Set
    End Property
    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return CharacterData.CharacterType
        End Get
    End Property
    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return CharacterData.Name
        End Get
    End Property
    Public ReadOnly Property CanInteract As Boolean Implements ICharacter.CanInteract
        Get
            Return False
        End Get
    End Property
    Public ReadOnly Property World As IWorld Implements ICharacter.World
        Get
            Return New World(WorldData)
        End Get
    End Property
    Public ReadOnly Property HasItems As Boolean Implements ICharacter.HasItems
        Get
            Return CharacterData.ItemIds.Any
        End Get
    End Property
    Public ReadOnly Property ItemStacks As IReadOnlyDictionary(Of String, IEnumerable(Of IItem)) Implements ICharacter.ItemStacks
        Get
            Return Items.GroupBy(Function(x) x.Name).ToDictionary(Function(x) x.Key, Function(x) x.AsEnumerable)
        End Get
    End Property
    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements ICharacter.Items
        Get
            Return CharacterData.ItemIds.Select(Function(x) New Item(WorldData, x))
        End Get
    End Property
    Public ReadOnly Property Verbs(verbName As String) As IVerb Implements ICharacter.Verbs
        Get
            Dim verbData = CharacterData.Verbs(verbName)
            Return New Verb(verbData.Name, verbData.Parameters, Business.World.VerbExecutors(verbName))
        End Get
    End Property
    Public Sub Move(direction As String) Implements ICharacter.Move
        If Location.HasRoute(direction) Then
            Location = Location.Route(direction).ToLocation
            Verbs(VerbTypes.Movement).Execute(character:=Me)
        End If
    End Sub
    Public Sub SetStatistic(statisticType As String, statisticValue As Integer) Implements ICharacter.SetStatistic
        CharacterData.Statistics(statisticType) = statisticValue
    End Sub
    Public Sub AddItem(item As IItem) Implements ICharacter.AddItem
        CharacterData.ItemIds.Add(item.Id)
    End Sub
    Public Sub AddVerb(key As String, name As String, parameters As IReadOnlyDictionary(Of String, Integer)) Implements ICharacter.AddVerb
        CharacterData.Verbs.Add(
            key,
            New VerbData With
            {
                .Name = name,
                .Parameters = parameters.ToDictionary(Function(x) x.Key, Function(x) x.Value)
            })
    End Sub

    Public Sub RemoveItem(item As IItem) Implements ICharacter.RemoveItem
        CharacterData.ItemIds.Remove(item.Id)
    End Sub

    Public Sub AddMessage(text As String) Implements ICharacter.AddMessage
        If WorldData.AvatarCharacterId.HasValue AndAlso WorldData.AvatarCharacterId.Value = Id Then
            WorldData.Messages.Add(text)
        End If
    End Sub

    Public Function GetStatistic(statisticType As String) As Integer Implements ICharacter.GetStatistic
        Return CharacterData.Statistics(statisticType)
    End Function
End Class
