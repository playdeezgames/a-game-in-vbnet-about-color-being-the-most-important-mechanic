Friend Module Move
    Friend Sub Run()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = MoveTitle}
        prompt.AddChoices(NeverMindText)
        prompt.AddChoices(World.Avatar.Location.Routes.Select(Function(x) x.Direction))
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                World.Avatar.Move(answer)
        End Select
    End Sub
End Module
