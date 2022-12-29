using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackSilence_Rebalance_Project.Dice_Effects
{
    public class DiceCardAbility_BSRebalanceFurioso_md5488 : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Destroy all of opponent's dice.";
        public override void OnWinParrying()
        {
            if (card?.target?.currentDiceAction?.cardBehaviorQueue.Count > 0)
                card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice);
        }
    }
}
