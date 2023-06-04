Imports SPLORR.Game

Friend Module OverworldInitializer
    Private Const OverworldColumns = 8
    Private Const OverworldRows = 8
    Friend Sub Run(world As IWorld)
        Dim townColumn = RNG.FromRange(0, OverworldColumns - 1)
        Dim townRow = RNG.FromRange(0, OverworldRows - 1)
        Dim locations(OverworldColumns, OverworldRows) As ILocation
        For column = 0 To OverworldColumns - 1
            For row = 0 To OverworldRows - 1
                locations(column, row) = world.CreateLocation(
                    If(column = townColumn AndAlso row = townRow, LocationTypes.TownEntrance, LocationTypes.Overworld),
                    $"Zone {ChrW(column + 65)}{row + 1}")
            Next
        Next
        For column = 0 To OverworldColumns - 1
            For row = 0 To OverworldRows - 1
                For Each direction In Directions.Cardinal
                    Dim nextColumn = Directions.NextColumn(direction, column, row)
                    Dim nextRow = Directions.NextRow(direction, column, row)
                    nextColumn = If(nextColumn < 0, nextColumn + OverworldColumns, If(nextColumn >= OverworldColumns, nextColumn - OverworldColumns, nextColumn))
                    nextRow = If(nextRow < 0, nextRow + OverworldRows, If(nextRow >= OverworldRows, nextRow - OverworldRows, nextRow))
                    locations(column, row).CreateRoute(direction, locations(nextColumn, nextRow))
                Next
            Next
        Next
    End Sub
End Module
