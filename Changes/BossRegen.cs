using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Overclocked.Changes
{
    /// <summary>
    /// ModBuff class that enables boss's regeneration
    /// </summary>
    internal class BossRegenBuff : ModBuff 
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BossRegen>().isBossRegenON = true;
        }
    }
    /// <summary>
    /// Global NPC class that provides boss regeneration
    /// when there are no player interactions with it
    /// </summary>
    internal class BossRegen : GlobalNPC 
    {
        static private int healPercent;
        static private int healActivationTime;
        static private int noHitActivationTime;

        private int hpTickCounter;
        public bool isBossRegenON;

        static public int HealPercent 
        { 
            get => healPercent; 
            set 
            { 
                if (value > 0 && value <= 100) 
                    healPercent = 2 * value; 
            } 
        }
        static public int HealActivationTime 
        {
            get => healActivationTime;
            set
            { 
                if (value > 0 && value <= 216000)
                    healActivationTime = value * 2; 
            } 
        }
        static public int NoHitActivationTime 
        { 
            get => noHitActivationTime; 
            set 
            { 
                if (value > 0 && value <= 3600) 
                    noHitActivationTime = value * 60 * 2;
            } 
        }

        public override bool InstancePerEntity => true;
        public override void ResetEffects(NPC npc)
        {
            isBossRegenON = false;
        }
        /// <summary>
        /// Sets HP regeneration defaults and adds regeneration buff to bosses
        /// </summary>
        /// <param name="entity">Entity object on spawn</param>
        public override void SetDefaults(NPC entity)
        {
            hpTickCounter = 0;
            isBossRegenON = false;

            if (ModContent.GetInstance<Config>().BossRegenON && entity.boss) 
            {
                entity.AddBuff(ModContent.BuffType<BossRegenBuff>(), int.MaxValue);
            }
        }
        /// <summary>
        /// Applies boss regeneration on target NPC when there are no player interactions 
        /// </summary>
        /// <param name="npc">Buff target NPC (boss)</param>
        /// <param name="damage">Unused</param>
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (isBossRegenON) 
            {
                if (hpTickCounter == 0 || --hpTickCounter == 0)
                {
                    npc.lifeRegen += npc.lifeMax * healPercent;
                    hpTickCounter = healActivationTime;
                }
            }
        }
        /// <summary>
        /// Disables healing for NoHitActivationTime when a boss gets a melee hit
        /// </summary>
        /// <param name="npc">Unused</param>
        /// <param name="player">Unused</param>
        /// <param name="item">Unused</param>
        /// <param name="hit">Unused</param>
        /// <param name="damageDone">Unused</param>
        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            hpTickCounter = noHitActivationTime;
        }
        /// <summary>
        /// Disables healing for NoHitActivationTime when a boss gets a projectile hit
        /// </summary>
        /// <param name="npc">Unused</param>
        /// <param name="projectile">Unused</param>
        /// <param name="hit">Unused</param>
        /// <param name="damageDone">Unused</param>
        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            hpTickCounter = noHitActivationTime;
        }
    }
}
