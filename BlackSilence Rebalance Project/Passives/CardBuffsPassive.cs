using System;
using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Utils;

namespace BlackSilence_Rebalance_Project.Passives
{
    public class PassiveAbility_CardBuffsPassive_md5488 : PassiveAbilityBase
    {
        public override void OnRoundStartAfter()
        {
            var givedBuffUnits = new List<BattleUnitModel>();
            var buffToGive = new List<Type>();
            foreach (var card in owner.allyCardDetail.GetHand())
            {
                if (card.GetID().packageId != BSRebalanceModParameters.PackageId || !BSRebalanceModParameters.CardsBuff.TryGetValue(card.GetID().id, out var buffType)) continue;
                buffToGive.Add(buffType);
            }
            var enemyList = BattleObjectManager.instance.GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction));
            if (!buffToGive.Any() || !enemyList.Any()) return;
            foreach (var buffType in buffToGive)
            {
                if (givedBuffUnits.Count == enemyList.Count) return;
                var unit = RandomUtil.SelectOne(enemyList);
                while (givedBuffUnits.Contains(unit))
                    unit = RandomUtil.SelectOne(enemyList);
                givedBuffUnits.Add(unit);
                unit.bufListDetail.AddBuf((BattleUnitBuf)Activator.CreateInstance(buffType));
            }
        }
    }
}