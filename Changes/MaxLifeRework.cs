using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Overclocked.Changes
{
    public class MaxLifeRework : ModPlayer
    {
        public override bool CanUseItem(Item item)
        {
            if (ModContent.GetInstance<Config>().MaxHealthReworkON && Player.HeldItem.type == ItemID.LifeCrystal || ModContent.GetInstance<Config>().MaxHealthReworkON && Player.HeldItem.type == ItemID.LifeFruit)
            {
                if (ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife == 500)
                {
                    return true;
                }

                if (Player.statLifeMax >= ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife)
                {
                    return false;
                }
            }
            return base.CanUseItem(item);
        }
        private void Announce()
        {
            if (ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife > ModContent.GetInstance<MaxLifeReworkSystem>().ActualMaxLife)
            {
                Main.NewText("[c/FF2682:You can now have " + ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife.ToString() + " max life.]");
                ModContent.GetInstance<MaxLifeReworkSystem>().ActualMaxLife = ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife;
            }
        }
        //TODO: prevent the max hp anouncing text from repeating every time joined world
        public override void PreUpdate()
        {
            /*Player player = ModContent.GetInstance<Player>();
            if (player.statLifeMax > ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife)
            { 
                player.statLifeMax2 = ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife;
            }*/
                //Main.NewText(ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife.ToString());
                //Main.NewText(ModContent.GetInstance<MaxLifeReworkSystem>().ActualMaxLife.ToString());
            if (NPC.downedSlimeKing)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeKingSlime;
                Announce();
            }
            if (NPC.downedBoss1)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeEoC;
                Announce();
            }
            if (NPC.downedBoss2)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeEvilBoss;
                Announce();
            }
            if (NPC.downedBoss3)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeEvilBoss;
                Announce();
            }
            if (NPC.downedQueenBee)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeQueenBee;
                Announce();
            }
            if (Main.hardMode)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeWoF;
                Announce();
            }
            if (NPC.downedQueenSlime)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeQueenSlime;
                Announce();
            }
            if (NPC.downedMechBossAny)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeMech1;
                Announce();
            }
            if (ModContent.GetInstance<MaxLifeReworkSystem>().MechsDown == 2)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeMech2;
                Announce();
            }
            if (ModContent.GetInstance<MaxLifeReworkSystem>().MechsDown == 3)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeMech3;
                Announce();
            }
            if (NPC.downedFishron)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeFishron;
                Announce();
            }
            if (NPC.downedEmpressOfLight)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeEmpress;
                Announce();
            }
            if (NPC.downedAncientCultist)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeCultist;
                Announce();
            }
            if (NPC.downedMoonlord)
            {
                ModContent.GetInstance<MaxLifeReworkSystem>().MaxLife = ModContent.GetInstance<Config>().MaxLifeMoonLord;
                Announce();
            }
        }
    }
    public class MaxLifeReworkSystem : ModSystem
    {
        public int MaxLife = ModContent.GetInstance<Config>().BaseMaxLife;
        public int ActualMaxLife;
        public override void SaveWorldData(TagCompound tag)
        {
            tag["MaxLife"] = MaxLife;
            tag["ActualMaxLife"] = ActualMaxLife;
            tag["MechsDown"] = MechsDown;
        }
        public override void LoadWorldData(TagCompound tag)
        {
            MaxLife = tag.GetInt("MaxLife");
            ActualMaxLife = tag.GetInt("ActualMaxLife");
            MechsDown = tag.GetInt("MechsDown");
        }
        public int MechsDown = 0;
        public override void PostUpdateEverything()
        {
            if (NPC.downedMechBoss1)
            { MechsDown = +1; }
            if (NPC.downedMechBoss2)
            { MechsDown = +1; }
            if (NPC.downedMechBoss3)
            { MechsDown = +1; }
        }
    }
}

