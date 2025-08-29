using Microsoft.Xna.Framework;
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
    public class TakenHitsCount : ModPlayer
    {
        private bool IsCounterActive()
        {
            if (ModContent.GetInstance<Config>().ShowHitNumberAfterFight || ModContent.GetInstance<Config>().ShowHitNumber)
            { return true; }
            return false;
        }
        public int TakenHits;
        bool CodeFixer = false;
        Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 255, 255);
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && IsCounterActive()
                || ModContent.GetInstance<Config>().ShowHitNumberAlways && IsCounterActive())
            {
                // Spawn the combat text
                TakenHits++;
                if (ModContent.GetInstance<Config>().ShowHitNumber)
                {
                    // Position: slightly below the player
                    Vector2 textPosition = new Vector2(Player.Center.X, Player.Center.Y - 20);

                    // Create a rectangle for the text spawn
                    Microsoft.Xna.Framework.Rectangle rect = new Microsoft.Xna.Framework.Rectangle((int)textPosition.X, (int)textPosition.Y, 0, 0);

                    // Spawn combat text
                    CombatText.NewText(rect, color, TakenHits.ToString(), true, false);
                }
            }
        }
        public override void PostUpdate()
        {
            if (!ModContent.GetInstance<MyModSystem>().IsBossAlive() && IsCounterActive() && CodeFixer == true 
                || !ModContent.GetInstance<MyModSystem>().IsBossAlive() && IsCounterActive() && ModContent.GetInstance<Config>().ShowHitNumberAlways && CodeFixer == true)
            {
                if (ModContent.GetInstance<Config>().ShowHitNumberAfterFight)
                {
                    //Player player = ModContent.GetInstance<Player>();
                    if (TakenHits > 0)
                    {
                        Main.NewText("[c/24FF9B:" + this.Player.name + " got hit " + TakenHits.ToString() + " times.]");
                    }
                    else
                    {
                        Main.NewText("[c/24FF9B:" + this.Player.name + " did a no-hit.]");
                    }
                }
                if (!ModContent.GetInstance<Config>().ShowHitNumberAlways)
                {
                    TakenHits = 0;
                }
                CodeFixer = false;
            }

            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && IsCounterActive())
            {
                CodeFixer = true;
            }
        }
        public override void OnRespawn()
        {
            TakenHits = 0;
        }
    }
}
