using BlackSilence_Rebalance_Project.Passives;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_BSRebalanceFuriosoCard_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc =
            "This page can be used after using all 9 Combat Pages of the [Black Silence].";

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_CardBuffsPassive_md5488) is
                PassiveAbility_CardBuffsPassive_md5488 passiveAbility)
                return passiveAbility.IsActivatedSpecialCard();
            return false;
        }

        public override void OnUseCard()
        {
            //owner.allyCardDetail.DrawCards(3);
            //owner.cardSlotDetail.RecoverPlayPointByCard(5);
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_CardBuffsPassive_md5488) is
                PassiveAbility_CardBuffsPassive_md5488 passiveAbility)
                passiveAbility.ResetUsedCount();
        }
    }
}