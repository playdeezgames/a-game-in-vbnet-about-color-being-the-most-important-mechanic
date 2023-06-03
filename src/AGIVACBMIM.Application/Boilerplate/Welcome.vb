Friend Module Welcome
    Friend Sub Run()
        Console.Title = Constants.GameTitle
        Dim figlet As New FigletText(Constants.GameTitle) With {.Color = Color.Aqua, .Justification = Justify.Center}
        AnsiConsole.Write(figlet)
        OkPrompt()
    End Sub
End Module
