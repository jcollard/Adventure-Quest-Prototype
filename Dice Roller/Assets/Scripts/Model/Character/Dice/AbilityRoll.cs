using System.Collections.Generic;
using AdventureQuest.Dice;

namespace AdventureQuest.Character.Dice
{
    [System.Serializable]
    public class AbilityRoll : UnityEngine.ISerializationCallbackReceiver
    {
        [field: UnityEngine.SerializeField]
        private string _diceNotation;
        public AbilityRoll(IRollable baseRoll, RollModifier modifier)
        {
            BaseRoll = baseRoll;
            Modifier = modifier;
        }

        public IRollable BaseRoll { get; private set; }
        public RollModifier Modifier { get; private set; }
        public string DiceNotation { get => ToString(); }

        public int Roll(Abilities abilities) => BaseRoll.Roll() + Modifier.ModifyWith(abilities);

        public static AbilityRoll Parse(string diceNotation)
        {
            string[] tokens = diceNotation.Trim().Split("+");
            List<DiceGroup> diceGroup = new ();
            List<string> rollModiferTokens = new ();
            foreach (string token in tokens)
            {
                if (DiceGroup.IsParseable(token))
                {
                    diceGroup.Add(DiceGroup.Parse(token));
                }
                else
                {
                    rollModiferTokens.Add(token);
                }
            }
            string rollModiferNotation = string.Join("+", rollModiferTokens);
            if (!RollModifier.IsParseable(rollModiferNotation)) { throw new System.FormatException($"Could not parse AbilityRoll from \"{diceNotation}\"."); }
            DicePool dicePool = new (diceGroup);
            RollModifier rollModifier = RollModifier.Parse(rollModiferNotation);
            return new AbilityRoll(dicePool, rollModifier);
        }

        public override string ToString() => $"{BaseRoll} + {Modifier}";

        public void OnBeforeSerialize()
        {
            _diceNotation = this.ToString();
        }

        public void OnAfterDeserialize()
        {
            if (_diceNotation == null) { return; }
            AbilityRoll parsed = AbilityRoll.Parse(_diceNotation);
            BaseRoll = parsed.BaseRoll;
            Modifier = parsed.Modifier;
        }
    }
}