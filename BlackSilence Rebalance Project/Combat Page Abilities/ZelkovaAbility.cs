using System.Linq;
using BlackSilence_Rebalance_Project.Bufs;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_Rebalance_ZelkovaWorkshop_md5488 : DiceCardSelfAbilityBase
    {
        private const int Check = 1;
        public static string Desc = "The Cost of this page cannot be changed [On Use] Draw 1 Page";

        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            base.OnUseCard();

            var enemybuff = card.target?.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_BSZelkovaBuf_md5488);
            if (enemybuff == null || enemybuff.stack < Check) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 2
            });
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }

        public override bool IsFixedCost()
        {
            return true;
        }
    }
}