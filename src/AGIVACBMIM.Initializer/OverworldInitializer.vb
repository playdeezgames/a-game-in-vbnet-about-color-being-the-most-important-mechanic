Imports SPLORR.Game

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
        For column = 0 To OverworldColumns - 1
            For row = 0 To OverworldRows - 1
                For Each direction In Directions.Cardinal
                    Dim nextColumn = Directions.NextColumn(direction, column, row)
                    Dim nextRow = Directions.NextRow(direction, column, row)
                    If nextColumn < 0 OrElse nextRow < 0 OrElse nextColumn >= OverworldColumns OrElse nextRow >= OverworldRows Then
                        Continue For
                    End If
                    locations(column, row).CreateRoute(direction, locations(nextColumn, nextRow))
                Next
            Next
        Next
    End Sub
End Module
