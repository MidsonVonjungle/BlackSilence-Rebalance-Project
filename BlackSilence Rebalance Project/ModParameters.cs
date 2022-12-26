using System;
using System.Collections.Generic;
using BlackSilence_Rebalance_Project.Bufs;

namespace BlackSilence_Rebalance_Project
{
    public static class BSRebalanceModParameters
    {
        public static string PackageId = "MidsonBSRebalance.md5488";

        public static string Path;
        public static LorId BSFuriosoCard = new LorId(PackageId, 10);

        public static List<int> BlackSilenceOriginalCards = new List<int>
            { 702001, 702002, 702003, 702004, 702005, 702006, 702007, 702008, 702009 };

        public static List<int> BSRebalanceCards = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static Dictionary<int, Type> CardsBuff = new Dictionary<int, Type>
        {
            { 5, typeof(BattleUnitBuf_BSAllasBuf_md5488) },
            { 7, typeof(BattleUnitBuf_BSCrystalBuf_md5488) },
            { 4, typeof(BattleUnitBuf_BSDurandalBuf_md5488) },
            { 6, typeof(BattleUnitBuf_BSLogicBuf_md5488) },
            { 9, typeof(BattleUnitBuf_BSMookBuf_md5488) },
            { 3, typeof(BattleUnitBuf_BSOldBoysBuf_md5488) },
            { 1, typeof(BattleUnitBuf_BSRangaBuf_md5488) },
            { 8, typeof(BattleUnitBuf_BSWheelsBuf_md5488) },
            { 2, typeof(BattleUnitBuf_BSZelkovaBuf_md5488) }
        };
    }
}