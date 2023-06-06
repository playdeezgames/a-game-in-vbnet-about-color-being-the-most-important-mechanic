Public Class ItemVerbDataClient
    Inherits ItemDataClient
    Protected ReadOnly Property VerbName As String
    Public Sub New(worldData As WorldData, itemId As Integer, verbName As String)
        MyBase.New(worldData, itemId)
        Me.VerbName = verbName
    End Sub
    Protected ReadOnly Property ItemVerbData As VerbData
        Get
            Return ItemData.Verbs(VerbName)
        End Get
    End Property
End Class
