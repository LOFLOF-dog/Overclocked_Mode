using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class BossHpMulti : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            float MultiplayerFactor;

            int playerCount = 0;
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                if (Main.player[i].active)
                {
                    playerCount++;
                }
            }

            if (ModContent.GetInstance<Config>().MultiplayerBossHpMultiplierON && Main.expertMode && playerCount > 1)
            {
                float multiplayerFactor = 1f;
                float healthAdded = 0.35f;

                // Start from player 2
                for (int i = 2; i <= playerCount; i++)
                {
                    multiplayerFactor += healthAdded;
                    healthAdded += (1f - healthAdded) / 3f;
                }

                // Apply adjustment for 10 or more players
                if (playerCount >= 10)
                {
                    multiplayerFactor = (multiplayerFactor * 2f + 8f) / 3f;
                }
                MultiplayerFactor = multiplayerFactor;
            }
            else
            {
                MultiplayerFactor = 0;
            }

            float OverclockedBossHpMulti = ModContent.GetInstance<Config>().BossHpMultiplier / 100;
            float OverclockedMultiplayerBossHpMulti = ModContent.GetInstance<Config>().MultiplayerBossHpMultiplier / 100;
            float FinalMultiplayerMulti = (OverclockedMultiplayerBossHpMulti * (playerCount - 1) ) - MultiplayerFactor + 1;

            if (!ModContent.GetInstance<Config>().BossHpMultiplierON) { OverclockedBossHpMulti = 1; }
            if (!ModContent.GetInstance<Config>().MultiplayerBossHpMultiplierON) { FinalMultiplayerMulti = 1; }

            if (npc.boss)
            {
                float BossHp = npc.lifeMax * OverclockedBossHpMulti * FinalMultiplayerMulti;
                int BossHpInt = (int)BossHp;
                npc.lifeMax = BossHpInt;
            }
        }
    }
}
