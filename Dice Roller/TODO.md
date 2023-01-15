# TODO List

Primary Goal:  Implement a Combat System

* Combatant portrait / portrait render
* Add combat info output to Combat scene
* Implement an Enemy type that implements the ICombat-ant interface
* Implement a Combat Rounds / Timing system
* Victory / Defeat conditions?
* Implement Flee
* Implement Defend
* Implement Inventory view / Useable items
* Code Smell: CombatantRenderer and TraitManifestRenderer both have lazy loaded
  sub properties using Property. Code is identical / copy and paste. We should
  consider how to abstract this.


1. Add Health / Stamina to Status screen
2. Shop needs to be Serializable (Not sure if this is true anymore)
3. Consider CharacterEquipmentManifest becoming EquipmentManifest and removing the character argument in the constructor
   * CharacterEquipmentManifest should not take a character, should just have
     the character attached. Too easy to "equip" using another characters stats.
4. IEquippable needs a better deserialization method. Potentially could write a
   "InterfaceSerializationWrapper" which stores information about deserializing
   the associated interface.
5. Consider generalizing the CharacterInspectorEditor to work for anything that
   implements an "AsJson" / "IObservable"
   * a UnityEditor drawer for ICharacter / IEquipment / IInventory
6. Add in Hitpoints / other stats to character
7. Create "combat" system
8.  Add "forest" to the town hub
9.  Add an armor Shop
10. Add "healer" to town?
11. Add Potions? / Useable items?
12. Need IEquipmentManifest to return IResults rather than bool
13. Add drag and drop buy and sell to shop
14. Add Item information to Status / Inventory. When clicking on item, should
    get information about that item. Similar to shop.
15. If possible, we would like to "fail fast" on scene load if a Location is not
    available in the Build settings

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
