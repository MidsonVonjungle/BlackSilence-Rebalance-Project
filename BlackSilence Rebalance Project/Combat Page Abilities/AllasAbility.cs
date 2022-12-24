using BlackSilence_Rebalance_Project.Bufs;
using System.Linq;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_Rebalance_AllasWorkshop_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 2";
        private const int Check = 1;

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.TargetDice == null)
                return;
            behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = -2
            });
        }
        public override void OnUseCard()
        {
            var enemybuff = card.target?.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_BSAllasBuf_md5488);
            if (enemybuff != null && enemybuff.stack >= Check)
            {
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 2
                });
                owner.cardSlotDetail.RecoverPlayPointByCard(1);
            }
        }
    }
}