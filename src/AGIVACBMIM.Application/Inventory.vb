﻿Friend Module Inventory
    Friend Sub Run()
        Dim avatar = World.Avatar
        Dim itemStacks = avatar.ItemStacks
        Dim table = itemStacks.ToDictionary(Function(x) $"{x.Key}(x{x.Value.Count})", Function(x) x.Value)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{avatar.Name}'s Inventory:[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                RunItemStack(avatar, table(answer))
        End Select
    End Sub
    Private Sub RunItemStack(avatar As ICharacter, items As IEnumerable(Of IItem))
        If items.Count = 1 Then
            RunItem(items.Single)
            Return
        End If
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]Which {items.First.Name}?[/]"}
        prompt.AddChoice(NeverMindText)
        Dim suffix = ""
        Dim table As New Dictionary(Of String, IItem)
        For Each item In items
            table($"{item.Name}{suffix}") = item
            suffix &= " " + ChrW(8)
        Next
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                RunItem(table(answer))
        End Select
    End Sub
    Private Sub RunItem(item As IItem)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{item.Name}[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table As New Dictionary(Of String, String)
        For Each verbName In item.VerbNames
            Dim verb = item.Verb(verbName)
            table(verb.Name) = verbName
        Next
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return
            Case Else
                item.Verb(table(answer)).Execute(World.Avatar, item)
        End Select
    End Sub
End Module
