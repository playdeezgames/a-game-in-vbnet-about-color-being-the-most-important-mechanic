﻿Public Class ItemDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property ItemId As Integer
    Public Sub New(worldData As WorldData, itemId As Integer)
        MyBase.New(worldData)
        Me.ItemId = itemId
    End Sub
    Protected ReadOnly Property ItemData As ItemData
        Get
            Return WorldData.Items(ItemId)
        End Get
    End Property
End Class
