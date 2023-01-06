using AdventureQuest.Equipment;

namespace AdventureQuest.Character.Equipment
{

    public class CharacterInventoryController : InventoryController
    {

        public void Render(ICharacter character) => Render(character.Inventory);
    
    }
}