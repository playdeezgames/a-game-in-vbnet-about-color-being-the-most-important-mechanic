﻿Public Class LocationData
    Public Property Routes As New Dictionary(Of String, RouteData)
    Public Property CharacterIds As New HashSet(Of Integer)
    Public Property ItemIds As New HashSet(Of Integer)
    Public Property Name As String
    Public Property LocationType As String
End Class
