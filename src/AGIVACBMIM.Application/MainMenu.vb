Imports System.ComponentModel

Friend Module MainMenu
    Sub Run()
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = MainMenuTitle}
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    If ConfirmPrompt(ConfirmQuitTitle) Then
                        Exit Do
                    End If
                Case Else
                    Throw New NotImplementedException
            End Select
        Loop
    End Sub
End Module
