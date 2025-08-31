using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Reworks
{
    public class EvilOreRework : GlobalTile
    {
        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            if (type == TileID.Demonite && ModContent.GetInstance<Config>().EvilOresReworkON || type == TileID.Crimtane && ModContent.GetInstance<Config>().EvilOresReworkON)
            {
                Player player = Main.LocalPlayer;
                if (player.HeldItem.pick < 65) // Example threshold
                {
                    return false; // Prevent mining
                }
            }
            return base.CanKillTile(i, j, type, ref blockDamaged);
        }
    }
}
