using BigDLL4221.Buffs;

namespace BlackSilence_Rebalance_Project.Bufs
{
    public class BattleUnitBuf_BSDurandalBuf_md5488 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_BSDurandalBuf_md5488()
        {
            stack = 0;
        }

        public override string BufName => "Durandal";

        public override string bufActivatedText =>
            "If The Black Silence targets this opponent using Durandal, restore 1 Light and all dice on the page gain 2 Power.";

        //protected override string keywordId => "Crippling_md5488";
        protected override string keywordIconId => "DurandalIcon_md5488";
        public override int paramInBufDesc => 0;
        public override int MaxStack => 0;
    }
}