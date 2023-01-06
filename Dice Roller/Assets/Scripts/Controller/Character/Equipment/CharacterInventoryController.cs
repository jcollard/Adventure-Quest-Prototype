using AdventureQuest.Equipment;

namespace AdventureQuest.Character.Equipment
{

    public class CharacterInventoryController : InventoryRenderer
    {

        public void Render(ICharacter character) => Render(character.Inventory);
    
    }
}