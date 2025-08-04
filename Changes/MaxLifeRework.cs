using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
	public class MaxLifeRework : ModPlayer
	{

        int MaxLife = ModContent.GetInstance<Config>().BaseMaxLife;
        int ActualMaxLife;
        public override bool CanUseItem(Item item)
        {
            if (ModContent.GetInstance<Config>().MaxHealthReworkON && Player.HeldItem.type == ItemID.LifeCrystal || Player.HeldItem.type == ItemID.LifeFruit)
            {
                if (Player.statLifeMax >= MaxLife /*&& MaxLife != 500*/)
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
            }
            if (NPC.downedBoss1 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeEoC)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeEoC;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedBoss2 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeEvilBoss)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeEvilBoss;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedBoss3 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeSkeletron)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeSkeletron;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedQueenBee && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeQueenBee)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeQueenBee;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (Main.hardMode && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeWoF)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeWoF;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedQueenSlime && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeQueenSlime)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeQueenSlime;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedMechBossAny && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeMech1)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMech1;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeMech2 || NPC.downedMechBoss1 && NPC.downedMechBoss3 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeMech2 || NPC.downedMechBoss3 && NPC.downedMechBoss2 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeMech2)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMech2;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeMech3)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMech3;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedFishron && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeFishron)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeFishron;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedEmpressOfLight && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeEmpress)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeEmpress;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedAncientCultist && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeCultist)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeCultist;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
            if (NPC.downedMoonlord && MaxLife !>= ModContent.GetInstance<Config>().MaxLifeMoonLord)
            { 
                MaxLife = ModContent.GetInstance<Config>().MaxLifeMoonLord;
                if (MaxLife > ActualMaxLife)
                {
                    ActualMaxLife = MaxLife;
                    Main.NewText("[c/FF2682:You can now have " + MaxLife.ToString() + " max life.]");
                }
            }
        }
    }
}
