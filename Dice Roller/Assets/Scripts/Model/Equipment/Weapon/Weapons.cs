using AdventureQuest.Character.Dice;

namespace AdventureQuest.Equipment
{
    public static class Weapons
    {
        public static readonly Weapon Dagger = new Builder()
            .Name("Dagger")
            .Description("A dagger is a fighting knife with a very sharp point and usually two sharp edges, typically designed or capable of being used as a thrusting or stabbing weapon.")
            .Cost(2)
            .Damage("1d4")
            .Build();
        
        public static readonly Weapon ShortSword = new Builder()
            .Name("Short sword")
            .Description("Short sword, as the name suggests, is a relatively smaller sword than an original sword. It is a single-handed sword with a handle that just features a grip with a single hand.")
            .Cost(10)
            .Damage("1d6")
            .Build();

        public static readonly Weapon Longsword = new Builder()
            .Name("Longsword")
            .Description("The longsword is a one-handed military melee weapon in the heavy blade group.")
            .Cost(25)
            .Damage("2d4")
            .Build();
        
        public static readonly Weapon BattleAxe = new Builder()
            .Name("Battle-axe")
            .Description("A battle axe is an axe specifically designed for combat.")
            .Cost(75)
            .Damage("1d12")
            .Build();

        private class Builder
        {
            private string _name = string.Empty;
            private string _description = string.Empty;
            private int _cost = -1;
            private AbilityRoll _damage = null;

            public Builder Name(string value) => SetRef(ref _name, value); 
            public Builder Cost(int value) => SetRef(ref _cost, value); 
            public Builder Description(string value) => SetRef(ref _description, value); 
            public Builder Damage(string value) => SetRef(ref _damage, AbilityRoll.Parse(value)); 

            private Builder SetRef<T>(ref T field, T value)
            {
                field = value;
                return this;
            }

            public Weapon Build()
            {
                if (_name == null || _description == null || _cost == -1 || _damage == null)
                {
                    throw new System.InvalidOperationException($"Could not construct weapon with missing fields.");
                }
                return new Weapon(_name, _description, _cost, _damage);
            }
            
        }
    }

    
}

