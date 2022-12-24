using BlackSilence_Rebalance_Project.Bufs;
using System.Linq;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_Rebalance_Logic_md5488 : DiceCardSelfAbilityBase
    {

        private const int Check = 1;
        public override void OnUseCard()
        {
            var enemybuff = card.target?.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_BSLogicBuf_md5488);
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