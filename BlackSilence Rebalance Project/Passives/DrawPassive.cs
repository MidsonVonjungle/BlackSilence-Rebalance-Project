using BigDLL4221.Utils;
using MsLocal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return;
            this.owner.allyCardDetail.DrawCards(1);
        }
        public override void OnWaveStart() => this.owner.allyCardDetail.DrawCards(2);
    }
}