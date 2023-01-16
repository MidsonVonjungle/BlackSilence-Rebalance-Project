﻿using BigDLL4221.DiceEffects;
using BlackSilence_Rebalance_Project;

namespace TheWhiteNoiseProject.Sprite_Attack_Effects
{
    public class DiceAttackEffect_BSMace_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(BSRebalanceModParameters.Path, 0.54f, 0.23f);
            base.Initialize(self, target, destroyTime);
        }
    }
}