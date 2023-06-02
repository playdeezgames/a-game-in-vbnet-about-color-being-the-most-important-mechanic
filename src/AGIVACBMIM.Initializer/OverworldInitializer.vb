Friend Module OverworldInitializer
    Private Const OverworldColumns = 8
    Private Const OverworldRows = 8
    Friend Sub Run(world As IWorld)
        Dim locations(OverworldColumns, OverworldRows) As ILocation
        For column = 0 To OverworldColumns - 1
            For row = 0 To OverworldRows - 1
                locations(column, row) = world.CreateLocation()
            Next
        Next
    End Sub
End Module
