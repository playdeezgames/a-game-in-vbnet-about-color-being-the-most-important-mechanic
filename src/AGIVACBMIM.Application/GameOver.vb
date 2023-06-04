Friend Module GameOver
    Friend Sub Run()
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("[red]Yer dead![/]")
        OkPrompt()
        Context.Abandon()
    End Sub
End Module
