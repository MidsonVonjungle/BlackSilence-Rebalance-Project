using System;
using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Utils;

namespace BlackSilence_Rebalance_Project.Passives
{
    public class PassiveAbility_CardBuffsPassive_md5488 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            var buffUsed = new List<Type>();
            var buffToGive = new List<Type>();
            foreach (var buff in BSRebalanceModParameters.CardsBuff)
                if (owner.allyCardDetail.GetHand()
                    .Exists(x => x.GetID() == new LorId(BSRebalanceModParameters.PackageId, buff.Key)))
                    buffToGive.Add(buff.Value);
            if (!buffToGive.Any()) return;
            foreach (var unit in BattleObjectManager.instance.GetAliveList(
                         UnitUtil.ReturnOtherSideFaction(owner.faction)))
            {
                if (buffToGive.Count == buffUsed.Count) break;
                var buff = RandomUtil.SelectOne(buffToGive);
                while (buffUsed.Contains(buff))
                    buff = RandomUtil.SelectOne(buffToGive);
                buffUsed.Add(buff);
                unit.bufListDetail.AddBuf((BattleUnitBuf)Activator.CreateInstance(buff));
            }
        }
    }
}