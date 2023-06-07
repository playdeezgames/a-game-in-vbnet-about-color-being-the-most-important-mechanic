Friend Module CharacterProvisioner
    Friend Sub NoProvisioning(character As ICharacter)
        'nothing!
    End Sub
    Friend Sub N00bProvisioning(character As ICharacter)
        Dim itemType = ItemTypes.Snax
        Dim itemDescriptor = ItemTypes.Descriptors(itemType)
        SpawnItemInCharacterInventory(character, itemType, itemDescriptor)
        SpawnItemInCharacterInventory(character, itemType, itemDescriptor)
    End Sub
    Friend Sub SlimeProvisioning(character As ICharacter)
        Dim itemType = ItemTypes.Goo
        Dim itemDescriptor = ItemTypes.Descriptors(itemType)
        SpawnItemInCharacterInventory(character, itemType, itemDescriptor)
    End Sub

    Private Sub SpawnItemInCharacterInventory(character As ICharacter, itemType As String, itemDescriptor As ItemTypeDescriptor)
        Dim item = character.World.CreateItem(itemType, itemDescriptor.Name)
        For Each verb In itemDescriptor.Verbs
            item.AddVerb(verb.Key, verb.Value.Name, verb.Value.Parameters)
        Next
        character.AddItem(item)
    End Sub
End Module
