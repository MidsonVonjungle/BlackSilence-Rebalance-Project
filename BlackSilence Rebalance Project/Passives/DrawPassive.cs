using BigDLL4221.Utils;

namespace BlackSilence_Rebalance_Project.Passives
{
    public class PassiveAbility_AngelicaDrawPassive_md5488 : PassiveAbilityBase
    {
        //public override void OnRoundStart()
        //{
        //    UnitUtil.DrawUntilX(owner, owner.emotionDetail.EmotionLevel);
        //}
        //This is the older version passive
        public override void OnRoundEnd()
        {
            if (this.owner.allyCardDetail.GetHand().Count <= 3)
                this.owner.allyCardDetail.DrawCards(1);
        }
        //public override void OnWaveStart() => this.owner.allyCardDetail.DrawCards(2);
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {

            if (this.owner.emotionDetail.EmotionLevel >= 3)
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                min = 2
            });
        }

        //I had to come up with something to deal with the card draw, truth be told, this just makes
        //the Black Silence an Arbiter in draw, you'll only run out of cards if you're retarded
    }
}