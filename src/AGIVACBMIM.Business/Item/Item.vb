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
End Class
