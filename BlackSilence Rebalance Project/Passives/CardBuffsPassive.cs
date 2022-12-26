﻿using System;
using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Utils;
using BlackSilence_Rebalance_Project.Bufs;
using LOR_DiceSystem;

namespace BlackSilence_Rebalance_Project.Passives
{
    public class PassiveAbility_CardBuffsPassive_md5488 : PassiveAbilityBase
    {
        private readonly DiceCardXmlInfo _counterCard =
            new DiceCardXmlInfo(new LorId(BSRebalanceModParameters.PackageId,
                10)); //TODO Card on the inv maker without any Combat Dice

        private readonly List<BattleDiceBehavior> _counterDice = new List<BattleDiceBehavior>();
        private readonly List<LorId> _usedCount = new List<LorId>();

        public override void OnDrawCard()
        {
            var buffToGive = new List<Type>();
            foreach (var card in owner.allyCardDetail.GetHand())
            {
                if (card.GetID().packageId != BSRebalanceModParameters.PackageId ||
                    !BSRebalanceModParameters.CardsBuff.TryGetValue(card.GetID().id, out var buffType)) continue;
                buffToGive.Add(buffType);
            }

            var enemyList = BattleObjectManager.instance.GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction));
            if (!buffToGive.Any() || !enemyList.Any()) return;
            foreach (var buffType in buffToGive)
            {
                if (!enemyList.Any()) return;
                var unit = RandomUtil.SelectOne(enemyList);
                enemyList.Remove(unit);
                unit.bufListDetail.AddBuf((BattleUnitBuf)Activator.CreateInstance(buffType));
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(unit,
                    unit.faction, unit.hp, unit.breakDetail.breakGauge);
            }
        }

        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            var lorId = curCard.card.GetID();
            if (lorId.packageId != BSRebalanceModParameters.PackageId) return;
            if (!_usedCount.Contains(lorId) && BSRebalanceModParameters.BSRebalanceCards.Contains(lorId.id))
                _usedCount.Add(lorId);
        }

        public override void OnWaveStart()
        {
            owner.personalEgoDetail.AddCard(BSRebalanceModParameters.BSFuriosoCard);
        }

        public override void OnRoundStart()
        {
            foreach (var battleDiceCardModel in owner.allyCardDetail.GetAllDeck())
            {
                battleDiceCardModel.RemoveBuf<BattleDiceCardBuf_BSRebalanceEgoCount_md5488>();
                var lorId = battleDiceCardModel.GetID();
                if (lorId.packageId != BSRebalanceModParameters.PackageId) continue;
                if (!_usedCount.Contains(lorId) && BSRebalanceModParameters.BSRebalanceCards.Contains(lorId.id))
                    battleDiceCardModel.AddBuf(new BattleDiceCardBuf_BSRebalanceEgoCount_md5488());
            }

            owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_BSRebalanceSpecialCount_md5488));
            owner.bufListDetail.AddBuf(new BattleUnitBuf_BSRebalanceSpecialCount_md5488
            {
                stack = _usedCount.Count
            });
        }

        public bool IsActivatedSpecialCard()
        {
            return _usedCount.Count >= 9;
        }

        public void ResetUsedCount()
        {
            _usedCount.Clear();
        }

        public override void OnStartBattle()
        {
            if (!_counterDice.Any()) return;
            owner.cardSlotDetail.keepCard.AddBehaviours(_counterCard, _counterDice);
            _counterDice.Clear();
        }

        public void AddDie(BattleDiceBehavior die)
        {
            _counterDice.Add(die);
        }
    }
}