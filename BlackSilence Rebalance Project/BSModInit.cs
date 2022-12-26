using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using UnityEngine;

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
            OnInitRewards();
            OnInitCards();
            OnInitKeypages();
            OnInitSprites();
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(
                keypages: new List<LorId> { new LorId(BSRebalanceModParameters.PackageId, 10000001) }
            ));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(BSRebalanceModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(1, CardOption.NoInventory),
                new CardOptions(2, CardOption.NoInventory),
                new CardOptions(3, CardOption.NoInventory),
                new CardOptions(4, CardOption.NoInventory),
                new CardOptions(5, CardOption.NoInventory),
                new CardOptions(6, CardOption.NoInventory),
                new CardOptions(7, CardOption.NoInventory),
                new CardOptions(8, CardOption.NoInventory),
                new CardOptions(9, CardOption.NoInventory),
                new CardOptions(10, CardOption.Personal)
            });
        }
        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(BSRebalanceModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001, isDeckFixed: true, everyoneCanEquip: true,
                    bookCustomOptions: new BookCustomOptions(name: "Angelica")),

                new KeypageOptions(10000002, isDeckFixed: true, everyoneCanEquip: true, bookCustomOptions: new BookCustomOptions())
            });
        }
        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(BSRebalanceModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "Angelica_Thumbnail_md5488"),
            });
        }

    }
}