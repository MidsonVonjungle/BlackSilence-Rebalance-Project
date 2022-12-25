using System.Linq;
using BlackSilence_Rebalance_Project.Bufs;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_Rebalance_AllasWorkshop_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 2";

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.TargetDice?.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = -2
            });
        }

        public override void OnUseCard()
        {
            var enemybuff = card.target?.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_BSAllasBuf_md5488);
            if (enemybuff == null) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 2
            });
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}