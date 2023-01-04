using BigDLL4221.Utils;

namespace BlackSilence_Rebalance_Project.Passives
{
    public class PassiveAbility_AngelicaDrawPassive_md5488 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            UnitUtil.DrawUntilX(owner, owner.emotionDetail.EmotionLevel);
        }
        //public override void OnWaveStart() => owner.allyCardDetail.DrawCards(2);
    }
}