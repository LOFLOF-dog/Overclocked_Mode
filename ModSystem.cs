using Terraria;
using Terraria.ModLoader;

namespace Overclocked
{
    public class MyModSystem : ModSystem
    {
        public bool IsBossAlive()
        {
            // Check if any NPCs currently active are bosses
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
