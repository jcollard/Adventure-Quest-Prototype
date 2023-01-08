# TODO List

1. Equipment / related classes should be Serializable
2. Shop needs to be Serializable
3. Consider CharacterEquipmentManifest becoming EquipmentManifest and removing the character argument in the constructor
4. IEquippable needs a better deserialization method. Potentially could write a
   "InterfaceSerializationWrapper" which stores information about deserializing
   the associated interface.

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
