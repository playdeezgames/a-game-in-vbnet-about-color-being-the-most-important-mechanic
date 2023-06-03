Friend Module Context
    Friend Property World As IWorld

    Friend Sub Start()
        World = New World(New WorldData)
        WorldInitializer.Run(World)
    End Sub

    Friend Sub Abandon()
        World = Nothing
    End Sub
End Module
