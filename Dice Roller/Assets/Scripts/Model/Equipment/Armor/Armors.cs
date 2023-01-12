using AdventureQuest.Character.Dice;

namespace AdventureQuest.Equipment.Armor
{
    public static class Armors
    {
        public static readonly Armor LeatherArmor = new Builder()
            .Name("Leather Armor")
            .SpriteId("leather_armor")
            .Description("Leather Armor Description")
            .Defense(5)
            .Cost(25)
            .Slot(EquipmentSlot.Torso)
            .Build();

        public static readonly Armor LeatherBoots = new Builder()
            .Name("Leather Boots")
            .SpriteId("leather_boots")
            .Description("Leather Boots Description")
            .Defense(2)
            .Cost(10)
            .Slot(EquipmentSlot.Feet)
            .Build();
        
        public static readonly Armor ClothPants = new Builder()
            .Name("Cloth Pants")
            .SpriteId("cloth_pants")
            .Description("Cloth Pants Description")
            .Defense(1)
            .Cost(2)
            .Slot(EquipmentSlot.Legs)
            .Build();
        
        public static readonly Armor ChainHelmet = new Builder()
            .Name("Chain Helmet")
            .SpriteId("chain_helm")
            .Description("Chain Helmet Description")
            .Defense(3)
            .Cost(50)
            .Slot(EquipmentSlot.Head)
            .Build();

        private class Builder
        {
            private string _spriteId = string.Empty;
            private string _name = string.Empty;
            private string _description = string.Empty;
            private int _cost = -1;
            private int _defense = -1;
            private EquipmentSlot? _slot = null;

            public Builder SpriteId(string value) => SetRef(ref _spriteId, value); 
            public Builder Name(string value) => SetRef(ref _name, value); 
            public Builder Cost(int value) => SetRef(ref _cost, value); 
            public Builder Description(string value) => SetRef(ref _description, value); 
            public Builder Defense(int value) => SetRef(ref _defense, value); 
            public Builder Slot(EquipmentSlot value) => SetRef(ref _slot, value); 

            private Builder SetRef<T>(ref T field, T value)
            {
                field = value;
                return this;
            }

            public Armor Build()
            {
                if (_name == null || _description == null || _cost == -1 || _defense == -1 || _slot == null || _spriteId == null)
                {
                    throw new System.InvalidOperationException($"Could not construct armor  with missing fields.");
                }
                return new Armor(_name, _spriteId, _description, _cost, _defense, _slot.Value);
            }
            
        }
    }

    
}

