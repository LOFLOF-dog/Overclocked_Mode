using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
	public class MaxLifeRework : ModPlayer
	{
        public int MaxLife = ModContent.GetInstance<Config>().BaseMaxLife;
        int ActualMaxLife;
        public override bool CanUseItem(Item item)
        {
            if (ModContent.GetInstance<Config>().MaxHealthReworkON && Player.HeldItem.type == ItemID.LifeCrystal || ModContent.GetInstance<Config>().MaxHealthReworkON && Player.HeldItem.type == ItemID.LifeFruit)
            {
                if (MaxLife == 500)
                {
                    return true;
                }

                if (Player.statLifeMax >= MaxLife)
                {
                    return false;
                }
            }
            return base.CanUseItem(item);
        }

        //TODO: prevent the max hp anouncing text from repeating every time joined world
        public override void PreUpdate()
        {
            if (NPC.downedSlimeKing)
            {   
                MaxLife = ModContent.GetInstance<Config>().MaxLifeKingSlime;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().KingSlimeAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().KingSlimeAnnounced = true;
                }
            }

            if (NPC.downedBoss1)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeEoC;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().EoCAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().EoCAnnounced = true;
                }
            }

            if (NPC.downedBoss2)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeEvilBoss;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().EvilBossAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().EvilBossAnnounced = true;
                }
            }

            if (NPC.downedBoss3)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeSkeletron;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().SkeletronAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().SkeletronAnnounced = true;
                }
            }

            if (NPC.downedQueenBee)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeQueenBee;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().QueenBeeAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().QueenBeeAnnounced = true;
                }
            }

            if (Main.hardMode)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeWoF;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().WoFAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().WoFAnnounced = true;
                }
            }

            if (NPC.downedQueenSlime)
            {
                MaxLife = ModContent.GetInstance<Config>().MaxLifeQueenSlime;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().QueenSlimeAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().QueenSlimeAnnounced = true;
                }
            }

            if (NPC.downedMechBossAny)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMech1;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().Mech1Announced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().Mech1Announced = true;
                }
            }

            if (ModContent.GetInstance<MaxLifeAnnouncementsBloker>().MechsDown == 2)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMech2;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().Mech2Announced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().Mech2Announced = true;
                }
            }

            if (ModContent.GetInstance<MaxLifeAnnouncementsBloker>().MechsDown == 3)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMech3;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().Mech3Announced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().Mech3Announced = true;
                }
            }

            if (NPC.downedFishron)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeFishron;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().FishronAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().FishronAnnounced = true;
                }
            }

            if (NPC.downedEmpressOfLight)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeEmpress;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().EmpressAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().EmpressAnnounced = true;
                }
            }

            if (NPC.downedAncientCultist)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeCultist;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().CultistAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().CultistAnnounced = true;
                }
            }

            if (NPC.downedMoonlord)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMoonLord;
                if (MaxLife > ActualMaxLife && !ModContent.GetInstance<MaxLifeAnnouncementsBloker>().MoonlordAnnounced)
                {
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                    ActualMaxLife = MaxLife;
                    ModContent.GetInstance<MaxLifeAnnouncementsBloker>().MoonlordAnnounced = true;
                }
            }
        }
    }
    public class MaxLifeAnnouncementsBloker : ModSystem
    {
        public bool KingSlimeAnnounced;
        public bool EoCAnnounced;
        public bool EvilBossAnnounced;
        public bool SkeletronAnnounced;
        public bool QueenBeeAnnounced;
        public bool WoFAnnounced;
        public bool QueenSlimeAnnounced;
        public bool Mech1Announced;
        public bool Mech2Announced;
        public bool Mech3Announced;
        public bool PlanteraAnnounced;
        public bool GolemAnnounced;
        public bool FishronAnnounced;
        public bool EmpressAnnounced;
        public bool CultistAnnounced;
        public bool MoonlordAnnounced;
        public int MechsDown = 0;

        public override void PostUpdateEverything()
        {
            if (NPC.downedMechBoss1)
            { MechsDown =+ 1; }
            if (NPC.downedMechBoss2)
            { MechsDown = +1; }
            if (NPC.downedMechBoss3)
            { MechsDown = +1; }
        }

    }
}
