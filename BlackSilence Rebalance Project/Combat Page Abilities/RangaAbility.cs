using System.Linq;
using BlackSilence_Rebalance_Project.Bufs;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_Rebalance_RangaWorkshop_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "The Cost of this page cannot be changed";

        public override void OnUseCard()
        {
            var enemybuff = card.target?.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_BSRangaBuf_md5488);
            if (enemybuff == null) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 2
            });
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
            RevampUtil.PrepareCounterDie(owner, card);
        }

        public override bool IsFixedCost()
        {
            return true;
        }
    }
}