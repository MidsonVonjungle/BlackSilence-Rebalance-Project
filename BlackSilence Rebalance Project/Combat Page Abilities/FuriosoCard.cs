using BigDLL4221.Utils;
using BlackSilence_Rebalance_Project.Passives;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_BSRebalanceFuriosoCard_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc =
            "This page can be used after using all 9 Combat Pages of the [Black Silence]. [On Use] Restore 3 Light and Draw until 6 pages are in hand.";

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_CardBuffsPassive_md5488) is
                PassiveAbility_CardBuffsPassive_md5488 passiveAbility)
                return passiveAbility.IsActivatedSpecialCard();
            return false;
        }

        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPointByCard(3);
            UnitUtil.DrawUntilX(owner, 6);
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_CardBuffsPassive_md5488) is
                PassiveAbility_CardBuffsPassive_md5488 passiveAbility)
                passiveAbility.ResetUsedCount();
        }
    }
}