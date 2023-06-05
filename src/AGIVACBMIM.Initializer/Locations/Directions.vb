Friend Module Directions
    Friend Const North = "North"
    Friend Const East = "East"
    Friend Const South = "South"
    Friend Const West = "West"
    Friend Const Inward = "In"
    Friend Const Outward = "Out"
    Friend ReadOnly Cardinal As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            North,
            East,
            South,
            West
        }
    Private ReadOnly columnDeltas As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {North, 0},
            {East, 1},
            {South, 0},
            {West, -1}
        }
    Private ReadOnly rowDeltas As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {North, -1},
            {East, 0},
            {South, 1},
            {West, 0}
        }
    Friend Function NextColumn(direction As String, column As Integer, row As Integer) As Integer
        Return column + columnDeltas(direction)
    End Function

    Friend Function NextRow(direction As String, column As Integer, row As Integer) As Integer
        Return row + rowDeltas(direction)
    End Function
End Module
