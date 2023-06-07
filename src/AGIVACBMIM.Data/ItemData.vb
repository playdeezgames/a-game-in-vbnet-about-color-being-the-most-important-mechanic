Public Class ItemData
    Public Property ItemType As String
    Public Property Name As String
    Public Property Verbs As New Dictionary(Of String, VerbData)
    Public Property IsDestroyed As Boolean
End Class
