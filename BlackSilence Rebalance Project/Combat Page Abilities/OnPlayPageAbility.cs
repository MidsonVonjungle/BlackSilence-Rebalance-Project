using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackSilence_Rebalance_Project.Combat_Page_Abilities
{
    public class DiceCardSelfAbility_OnPlayPage_md5488 : DiceCardSelfAbilityBase
    {
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit,unit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit,BattleUnitModel self)
        {
            var buffToGive = new List<Type>();
            foreach (var card in self.allyCardDetail.GetHand())
            {
                if (card.GetID().packageId != BSRebalanceModParameters.PackageId ||
                    !BSRebalanceModParameters.CardsBuff.TryGetValue(card.GetID().id, out var buffType)) continue;
                buffToGive.Add(buffType);
            }
            if (!buffToGive.Any()) return;
            buffToGive.RemoveAll(x => unit.bufListDetail.GetActivatedBufList().Exists(y => y.GetType() == x));
            if (!buffToGive.Any()) return;
            unit.bufListDetail.AddBuf((BattleUnitBuf)Activator.CreateInstance(RandomUtil.SelectOne(buffToGive)));
        }
    }
}
