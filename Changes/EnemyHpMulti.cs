
using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class EnemyHpMulti : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (ModContent.GetInstance<Config>().EnemiesHpMultiplierON && !npc.friendly)
            {
                if (!ModContent.GetInstance<Config>().EnemiesHpMultiplierSTACK && !npc.boss)
                {
                    npc.lifeMax *= ModContent.GetInstance<Config>().EnemiesHpMultiplier / 100;
                }
                if (ModContent.GetInstance<Config>().EnemiesHpMultiplierSTACK)
                {
                    npc.lifeMax *= ModContent.GetInstance<Config>().EnemiesHpMultiplier / 100;
                }
            }
        }
    }
}
