using BigDLL4221.DiceEffects;
using BlackSilence_Rebalance_Project;

namespace TheWhiteNoiseProject.Sprite_Attack_Effects
{
    public class DiceAttackEffect_BSAxe_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(BSRebalanceModParameters.Path, 0.54f, 0.23f);
            base.Initialize(self, target, destroyTime);
        }
    }
    //The normal Roland EffectRes doesn't match with a custom sprite like mine, so I need to create my own
    //And yes, its indeed a painful process to do so because the only way to check if an EffectRes is in the
    //right place is through opening and closing the game
    //...at least that's the only way I know how
}