using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class EnemyDmgMultiMode : ModPlayer
    {
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (ModContent.GetInstance<Config>().EnemiesDmgMultiplierON && ModContent.GetInstance<Config>().EnemiesDmgMultiplierSTACK)
            {
                modifiers.SourceDamage *= ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100;
            }
            if (ModContent.GetInstance<Config>().EnemiesDmgMultiplierON && !ModContent.GetInstance<Config>().EnemiesDmgMultiplierSTACK)
            {
                base.ModifyHurt(ref modifiers);
            }
        }
    }

    /*public class EnemyDmgMulti : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (ModContent.GetInstance<Config>().EnemiesDmgMultiplierON)
            {
                if (!ModContent.GetInstance<Config>().EnemiesDmgMultiplierSTACK && !npc.boss)
                {
                    npc.damage *= ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100;
                }
                else
                {
                    npc.damage *= ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100;
                }
            }
        }
    }
    public class ProjDmgMulti : GlobalProjectile
    {
        public override bool InstancePerEntity => true; // ensures per-projectile data

        public override void AI(Projectile projectile)
        {
            if (ModContent.GetInstance<Config>().EnemiesDmgMultiplierON && !ModContent.GetInstance<Config>().EnemiesDmgMultiplierSTACK && Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Only apply once
                if (projectile.localAI[0] == 0f)
                {
                    int npcIndex = (int)projectile.ai[0]; // assumes ai[0] stores NPC index

                    if (npcIndex >= 0 && npcIndex < Main.maxNPCs)
                    {
                        NPC npc = Main.npc[npcIndex];

                        if (npc.active && !npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); 
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

                        if (npc.active && !npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); 
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

                        if (npc.active && !npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); 
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

                        if (npc.active && !npc.boss)
                        {
                            projectile.damage = (int)(projectile.damage * ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100); 
                            projectile.localAI[0] = 1f; // flag to prevent repeated boosting
                        }
                    }
                }
            }
        }
        public override void SetDefaults(Projectile projectile)
        {
            if (ModContent.GetInstance<Config>().EnemiesDmgMultiplierON && ModContent.GetInstance<Config>().EnemiesDmgMultiplierSTACK && Main.netMode != NetmodeID.MultiplayerClient)
            {
                projectile.damage *= ModContent.GetInstance<Config>().EnemiesDmgMultiplier / 100;
            }
        }
    }*/
}
