using System.Linq;
using BigDLL4221.Extensions;
using BlackSilence_Rebalance_Project.Passives;
using LOR_DiceSystem;

namespace BlackSilence_Rebalance_Project
{
    public static class RevampUtil
    {
        public static void PrepareCounterDie(BattleUnitModel owner, BattlePlayingCardDataInUnitModel card)
        {
            if (!owner.HasPassive(typeof(PassiveAbility_CardBuffsPassive_md5488), out var passive)) return;
            if (!(passive is PassiveAbility_CardBuffsPassive_md5488 typedPassive)) return;
            var die = card.card.CreateDiceCardBehaviorList().LastOrDefault(x => x.Type == BehaviourType.Atk);
            if (die == null) return;
            die.behaviourInCard.Copy();
            die.behaviourInCard.Type = BehaviourType.Standby;
            die.behaviourInCard.Min = 3;
            die.behaviourInCard.Dice = 7;
            typedPassive.AddDie(die);
        }
    }
}