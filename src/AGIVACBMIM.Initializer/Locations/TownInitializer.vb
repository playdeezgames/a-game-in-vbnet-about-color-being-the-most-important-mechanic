Imports SPLORR.Game

Friend Module TownInitializer
    Private Const TownColumns = 4
    Private Const TownRows = 4
    Friend Sub Run(world As IWorld)
        Dim locations(TownColumns, TownRows) As ILocation
        For column = 0 To TownColumns - 1
            For row = 0 To TownRows - 1
                locations(column, row) = world.CreateLocation(
                    LocationTypes.Town,
                    $"District {column + 1}-{row + 1}")
            Next
        Next
        For column = 0 To TownColumns - 1
            For row = 0 To TownRows - 1
                For Each direction In Directions.Cardinal
                    Dim nextColumn = Directions.NextColumn(direction, column, row)
                    Dim nextRow = Directions.NextRow(direction, column, row)
                    nextColumn = If(nextColumn < 0, nextColumn + TownColumns, If(nextColumn >= TownColumns, nextColumn - TownColumns, nextColumn))
                    nextRow = If(nextRow < 0, nextRow + TownRows, If(nextRow >= TownRows, nextRow - TownRows, nextRow))
                    locations(column, row).CreateRoute(direction, locations(nextColumn, nextRow))
                Next
            Next
        Next
        Dim overworldEntrance = world.Locations.Single(Function(x) x.LocationType = LocationTypes.TownEntrance)
        overworldEntrance.Name = $"{overworldEntrance.Name}(Town Entrance)"
        Dim townExit = locations(RNG.FromRange(0, TownColumns - 1), RNG.FromRange(0, TownRows - 1))
        townExit.Name = $"{townExit.Name}(Town Exit)"
        overworldEntrance.CreateRoute(Directions.Inward, townExit)
        townExit.CreateRoute(Directions.Outward, overworldEntrance)
    End Sub
End Module
