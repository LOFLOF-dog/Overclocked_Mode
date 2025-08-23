using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Overclocked
{
    public class Config : ModConfig
    {
        // TODO: add Astolfoless textures for accs
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Boss Health Multiplier
        [Header("BossHpMulti")]

        [DefaultValue(true)]
        public bool BossHpMultiplierON;

        [DefaultValue(200)]
        [Range(1, 10000)]
        public int BossHpMultiplier;

        #endregion

        #region Multiplayer Boss Health Multiplier
        [Header("MultiplayerBossHpMulti")]

        [DefaultValue(true)]
        public bool MultiplayerBossHpMultiplierON;

        [DefaultValue(100)]
        [Range(0, 10000)]
        public int MultiplayerBossHpMultiplier;

        #endregion

        #region No Nurse Healing
        [Header("NoNurseHealing")]

        [DefaultValue(true)]
        public bool NoNurseHealingON;

        [DefaultValue("I can't heal you right now")]
        public string NurseText;

        #endregion

        #region Max Health Rework
        [Header("MaxHpRework")]

        [DefaultValue(true)]
        public bool MaxHealthReworkON;

        [DefaultValue(200)]
        [Range(100, 500)]
        public int BaseMaxLife;

        [DefaultValue(200)]
        [Range(100, 500)]
        public int MaxLifeKingSlime;

        [DefaultValue(240)]
        [Range(100, 500)]
        public int MaxLifeEoC;

        [DefaultValue(300)]
        [Range(100, 500)]
        public int MaxLifeEvilBoss;

        [DefaultValue(400)]
        [Range(100, 500)]
        public int MaxLifeSkeletron;

        [DefaultValue(400)]
        [Range(100, 500)]
        public int MaxLifeQueenBee;

        [DefaultValue(400)]
        [Range(100, 500)]
        public int MaxLifeWoF;

        [DefaultValue(400)]
        [Range(100, 500)]
        public int MaxLifeQueenSlime;

        [DefaultValue(400)]
        [Range(100, 500)]
        public int MaxLifeMech1;

        [DefaultValue(400)]
        [Range(100, 500)]
        public int MaxLifeMech2;

        [DefaultValue(450)]
        [Range(100, 500)]
        public int MaxLifeMech3;

        [DefaultValue(500)]
        [Range(100, 500)]
        public int MaxLifePlantera;

        [DefaultValue(500)]
        [Range(100, 500)]
        public int MaxLifeGolem;

        [DefaultValue(500)]
        [Range(100, 500)]
        public int MaxLifeFishron;

        [DefaultValue(500)]
        [Range(100, 500)]
        public int MaxLifeEmpress;

        [DefaultValue(500)]
        [Range(100, 500)]
        public int MaxLifeCultist;

        [DefaultValue(500)]
        [Range(100, 500)]
        public int MaxLifeMoonLord;

        #endregion

        #region Less Accessory Slots
        [Header("LessAccSlots")]

        [DefaultValue(true)]
        public bool LessAccSlotsON;

        [DefaultValue(1)]
        [Range(1, 6)]
        public int BlockedAccesorySlots;

        [DefaultValue(false)]
        public bool NoDemonHeart;

        #endregion

        #region Crit Taken Damage
        [Header("CritTakedDamage")]

        [DefaultValue(true)]
        public bool CritTakenDamageON;

        [DefaultValue(4)]
        [Range(1, 100)]
        public int CritTakenDamageChance;

        [DefaultValue(200)]
        [Range(1, 10000)]
        public int CritTakenDamageMultiplier;

        #endregion
    }
}