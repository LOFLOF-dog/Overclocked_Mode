using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Reworks
{
    public class EvilOreRework : GlobalTile
    {
        public override void SetDefaults()
        {
            if (Main.tileSolid[TileID.Demonite])
            {
                Main.tileHammer[TileID.Demonite] = false; // Prevent hammering
                Main.tilePick[TileID.Demonite] = true;     // Allow pickaxe mining
            }

            // Change required pickaxe power
            TileID.Sets.Ore[TileID.Demonite] = true;
            TileID.Sets.MinimumPickaxePower[TileID.Demonite] = 65; // Example: require 65% pickaxe power
        }
    }
}
