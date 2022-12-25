using System;
using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Utils;
using UnityEngine;

namespace BlackSilence_Rebalance_Project.Passives
{
    public class PassiveAbility_CardBuffsPassive_md5488 : PassiveAbilityBase
    {
        public override void OnDrawCard()
        {
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
                if (!enemyList.Any()) return;
                var unit = RandomUtil.SelectOne(enemyList);
                enemyList.Remove(unit);
                unit.bufListDetail.AddBuf((BattleUnitBuf)Activator.CreateInstance(buffType));
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(unit, unit.faction, unit.hp, unit.breakDetail.breakGauge);
            }
        }
    }
}