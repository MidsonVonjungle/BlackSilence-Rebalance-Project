using BigDLL4221.Buffs;

namespace BlackSilence_Rebalance_Project.Bufs
{
    public class BattleDiceCardBuf_BSRebalanceEgoCount_md5488 : BattleDiceCardBuf
    {
        protected override string keywordIconId => "FuriosoIcon_md5488";
    }

    //Buff that count the used cards
    public class BattleUnitBuf_BSRebalanceSpecialCount_md5488 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_BSRebalanceSpecialCount_md5488() : base(infinite: true, lastOneScene: false)
        {

        }

          public override string BufName => "Furioso";
          public override string bufActivatedText => $"Number of the Black Silence's Combat Pages used : {stack}";
        //protected override string keywordIconId => "WhiteNoiseCard_md5488";
        // protected override string keywordId => "SpecialCount_md5488";
    }
}
