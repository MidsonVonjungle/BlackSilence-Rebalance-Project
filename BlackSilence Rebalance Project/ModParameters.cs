using System.Collections.Generic;
using BigDLL4221.BaseClass;
using BigDLL4221.Models;
using LOR_XML;

namespace BlackSilence_Rebalance_Project
{
    public static class BSRebalanceModParameters
    {
        public static string PackageId = "BSRebalnce.md5488";
        public static string Path;
        //public static LorId FuriosoCard = new LorId(PackageId, 10);
        //There's no furioso yet

        public static List<int> BlackSilenceOriginalCards = new List<int>
            { 702001, 702002, 702003, 702004, 702005, 702006, 702007, 702008, 702009 };

        public static List<int> BSRebalanceCards = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
}