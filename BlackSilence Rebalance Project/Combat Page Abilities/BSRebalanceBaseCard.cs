using BlackSilence_Rebalance_Project.Bufs;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_BSRebalanceBaseCard_md5488 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            var target = card.target;
            if (!card.card.HasBuf<BattleDiceCardBuf_BSRebalanceEgoCount_md5488>() || target == null) return;
        }
    }
}