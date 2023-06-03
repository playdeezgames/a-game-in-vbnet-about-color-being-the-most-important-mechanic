Friend Module Save
    Friend Sub Run()
        Dim filename = AnsiConsole.Ask(Of String)("[olive]Save To Filename:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(filename) Then
            AnsiConsole.MarkupLine("[red]Save canceled.[/]")
            OkPrompt()
            Return
        End If
        Context.World.Save(filename)
        AnsiConsole.MarkupLine("[lime]Save successful.[/]")
        OkPrompt()
    End Sub
End Module
