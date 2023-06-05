Friend Module CharacterProvisioner
    Friend Sub NoProvisioning(character As ICharacter)
        'nothing!
    End Sub
    Friend Sub N00bProvisioning(character As ICharacter)
        Dim itemType = ItemTypes.Snax
        Dim itemDescriptor = ItemTypes.Descriptors(itemType)
        Dim item = character.World.CreateItem(itemType, itemDescriptor.Name)
        character.AddItem(item)
    End Sub
End Module
