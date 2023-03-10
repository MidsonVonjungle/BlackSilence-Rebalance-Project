using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using CustomMapUtility;
using LOR_DiceSystem;
using MonoMod.Utils;
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
            CustomMapHandler.GetCMU(BSRebalanceModParameters.PackageId);
            //CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
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
            OnInitSkins();
            OnInitPassives();
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
                new CardOptions(10, CardOption.Personal),
                new CardOptions(11, CardOption.Personal),
                new CardOptions(12, CardOption.Personal),
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(BSRebalanceModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001, isDeckFixed: true, everyoneCanEquip: true,
                    bookCustomOptions: new BookCustomOptions("Angelica")),
            });
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(BSRebalanceModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "Angelica_Thumbnail_md5488")
            });
        }
        private static void OnInitSkins()
        {
            ModParameters.SkinOptions.AddRange(new Dictionary<string, SkinOptions>
            {
                {
                    "Angelica", new SkinOptions(BSRebalanceModParameters.PackageId,
                        motionSounds: new Dictionary<MotionDetail, MotionSound>
                        {
                            { MotionDetail.J, new MotionSound("Roland_DuelSword.wav") },
                            { MotionDetail.H, new MotionSound("Roland_Hammer.wav") },
                            { MotionDetail.Z, new MotionSound("Roland_Spear.wav") },
                            { MotionDetail.E, new MotionSound("Roland_Evasion.wav") },
                            { MotionDetail.G, new MotionSound("Roland_Guard.wav") },
                            { MotionDetail.S1, new MotionSound("Roland_Revolver.wav") },
                            { MotionDetail.S2, new MotionSound("Roland_Revolver.wav") },
                            { MotionDetail.S3, new MotionSound("Roland_LongSword_Start.wav") },
                            { MotionDetail.S5, new MotionSound("Roland_Gauntlet1.wav") },
                            { MotionDetail.S6, new MotionSound("Roland_Gauntlet1.wav") },
                            { MotionDetail.S7, new MotionSound("Roland_ShortSword", isBaseSoundWin: true) },
                            { MotionDetail.S8, new MotionSound("Roland_Axe.wav") },
                            { MotionDetail.S9, new MotionSound("Roland_Mace.wav") },
                            { MotionDetail.S10, new MotionSound("Roland_GreatSword.wav") },
                            { MotionDetail.S11, new MotionSound("Roland_Shotgun.wav") },
                            { MotionDetail.S12, new MotionSound("Roland_Duralandal_Down.wav") },
                            { MotionDetail.S13, new MotionSound("Roland_Duralandal_Up.wav") },
                            { MotionDetail.S14, new MotionSound("Roland_Duralandal_Strong", isBaseSoundWin: true) },
                        })
                    //I could have the code use sounds directly from the game, however, what I wasn't expecting was for the exported sounds
                    //to not work at all, so I told the code to use the base game ones... fuck me, why does this even happen?
                }
            });
        }
        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(BSRebalanceModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(1, false),
                new PassiveOptions(2, cannotBeUsedWithPassives: new List<LorId> { 
                    new LorId(260004),
                    new LorId("WhiteRoland.md588", 4),
                }),
            });
            //This will prevent Twelve Fixers from being used together with 'Ill Colore de Charlesmagne', having both at once
            //would have been too strong
            //And it includes Paladin from my White Noise, I like to think if all Twelve Fixers were present in the game, all their
            //min reducing passives would have a tiny extra flavor to accompany it, or at least Roland would, he's the leader of the Charles'
            //Office after all
        }
    }
}