Friend Module Load
    Friend Sub Run()
        Dim filename = AnsiConsole.Ask(Of String)("[olive]Load From Filename:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(filename) Then
            AnsiConsole.MarkupLine("[red]Load canceled.[/]")
            OkPrompt()
            Return
        End If
        Context.World = Business.World.Load(filename)
        If Context.World Is Nothing Then
            AnsiConsole.MarkupLine("[red]Load failed.[/]")
            OkPrompt()
            Return
        End If
        AnsiConsole.MarkupLine("[lime]Load successful.[/]")
        OkPrompt()
        InPlay.Run()
    End Sub
End Module
