using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Models;
using BigDLL4221.Utils;

namespace BlackSilence_Rebalance_Project
{
    public class BSRebalanceInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(BSRebalanceModParameters.Path + "/ArtWork"));
            ArtUtil.GetSpeedDieArtWorks(new DirectoryInfo(BSRebalanceModParameters.Path + "/CustomDiceArtWork"));
            ArtUtil.PreLoadBufIcons();
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, BSRebalanceModParameters.PackageId);
            KeypageUtil.ChangeKeypageItem(BookXmlList.Instance, BSRebalanceModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(BSRebalanceModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(BSRebalanceModParameters.PackageId);
            ArtUtil.MakeCustomBook(BSRebalanceModParameters.PackageId);
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());

        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(BSRebalanceModParameters.PackageId);
            BSRebalanceModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(BSRebalanceModParameters.PackageId, BSRebalanceModParameters.Path);
            ModParameters.Assemblies.Add(Assembly.GetExecutingAssembly());
        }
    }
}