Friend Class Item
    Inherits ItemDataClient
    Implements IItem
    Public Sub New(worldData As WorldData, itemId As Integer)
        MyBase.New(worldData, itemId)
    End Sub
    Public ReadOnly Property Id As Integer Implements IItem.Id
        Get
            Return ItemId
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IItem.Name
        Get
            Return ItemData.Name
        End Get
    End Property

    Public ReadOnly Property VerbNames As IEnumerable(Of String) Implements IItem.VerbNames
        Get
            Return ItemData.Verbs.Keys
        End Get
    End Property

    Public ReadOnly Property Verb(verbName As String) As IVerb Implements IItem.Verb
        Get
            Dim verbData = ItemData.Verbs(verbName)
            Return New Verb(verbData.Name, verbData.Parameters, Business.World.VerbExecutors(verbName))
        End Get
    End Property

    Public Sub AddVerb(key As String, name As String, parameters As IReadOnlyDictionary(Of String, Integer)) Implements IItem.AddVerb
        ItemData.Verbs.Add(
            key,
            New VerbData With
            {
                .Name = name,
                .Parameters = parameters.ToDictionary(Function(x) x.Key, Function(x) x.Value)
            })
    End Sub
End Class
