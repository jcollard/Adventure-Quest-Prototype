# TODO List

Current Prime Goal: Implement Status Screen

* Need IEquipmentManifest to return IResults rather than bools
* IRequirement needs to have better serialization information to be able to deserialize to the correct type.

1. Shop needs to be Serializable
2. Consider CharacterEquipmentManifest becoming EquipmentManifest and removing the character argument in the constructor
3. IEquippable needs a better deserialization method. Potentially could write a
   "InterfaceSerializationWrapper" which stores information about deserializing
   the associated interface.
4. Consider generalizing the CharacterInspectorEditor to work for anything that
   implements an "AsJson" / "IObservable"
   * a UnityEditor drawer for ICharacter / IEquipment / IInventory
5. Scene Transition Manager for moving between scenes. Currently everytime, we
   save the character manually on the button click.
6. Create Character "Status" screen which allows equipping and unequipping equipment
7. Add in Hitpoints / other stats to character
8. Create "combat" system
9. Add "forest" to the town hub
10. Add an armor Shop
11. Add "healer" to town?
12. Add Potions? / Useable items?

# Potential Abstractions (Code Smells)

## ObservableComponent
Consider rewriting `ObservableComponent` to only allow observing
`IObservable<T>` rather than just `<T>`. See `ObservableCharacter` for possible
implementation details.

Consider renaming `ObservableComponent` to not have the word `Observable`
perhaps `Changeable` / `Watchable` / `ObservableContainer`?

## Dialogs share copy / paste code
See `MessageDialog`, `SellDialog`, and `PurchaseDialog`. Should likely have a parent type `Dialog<Renderable<T>>`

# Known Bugs

1. Bug in Character Creator / Ability Score Label. If Modifier is greater than 1
   character, does not display properly.
