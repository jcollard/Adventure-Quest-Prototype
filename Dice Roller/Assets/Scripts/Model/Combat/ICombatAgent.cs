
using System.Threading.Tasks;

namespace AdventureQuest.Combat
{
    public interface ICombatAgent
    {
        public ICombatAction SelectAction(CombatManager manager);
    }
}