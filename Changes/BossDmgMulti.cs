using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class BossDmgMultiMode : ModPlayer
    {
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (ModContent.GetInstance<Config>().BossDmgMultiplierON && ModContent.GetInstance<MyModSystem>().IsBossAlive())
            {
                modifiers.SourceDamage *= ModContent.GetInstance<Config>().BossDmgMultiplier / 100;
            }
        }
    }
    /*public class BossDmgMulti : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (ModContent.GetInstance<Config>().BossDmgMultiplierON && !ModContent.GetInstance<Config>().BossDmgMultiplierMode && npc.boss)
            {
                npc.damage *= ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100;
            }
        }
    }
    public class BossProjectileDmgMulti : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            if (ModContent.GetInstance<Config>().EnemiesDmgMultiplierON && !ModContent.GetInstance<Config>().BossDmgMultiplierMode && Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Only apply once
                if (projectile.localAI[0] == 0f)
                {
                    int npcIndex = (int)projectile.ai[0]; // assumes ai[0] stores NPC index

                    if (npcIndex >= 0 && npcIndex < Main.maxNPCs)
                    {
                        NPC npc = Main.npc[npcIndex];

                        if (npc.active && npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); // 50% boost
                            projectile.localAI[0] = 1f; // flag to prevent repeated boosting
                        }
                    }
                }

                if (projectile.localAI[0] == 0f)
                {
                    int npcIndex = (int)projectile.ai[1]; // assumes ai[0] stores NPC index

                    if (npcIndex >= 0 && npcIndex < Main.maxNPCs)
                    {
                        NPC npc = Main.npc[npcIndex];

                        if (npc.active && npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); // 50% boost
                            projectile.localAI[0] = 1f; // flag to prevent repeated boosting
                        }
                    }
                }

                if (projectile.localAI[0] == 0f)
                {
                    int npcIndex = (int)projectile.ai[2]; // assumes ai[0] stores NPC index

                    if (npcIndex >= 0 && npcIndex < Main.maxNPCs)
                    {
                        NPC npc = Main.npc[npcIndex];

                        if (npc.active && npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); // 50% boost
                            projectile.localAI[0] = 1f; // flag to prevent repeated boosting
                        }
                    }
                }

                if (projectile.localAI[0] == 0f)
                {
                    int npcIndex = (int)projectile.ai[3]; // assumes ai[0] stores NPC index

                    if (npcIndex >= 0 && npcIndex < Main.maxNPCs)
                    {
                        NPC npc = Main.npc[npcIndex];

                        if (npc.active && npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); // 50% boost
                            projectile.localAI[0] = 1f; // flag to prevent repeated boosting
                        }
                    }
                }
            }
        }
    }*/
}
