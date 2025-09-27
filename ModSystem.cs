using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overclocked.Changes;
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
        public override void OnWorldLoad()
        {
            if (ModContent.GetInstance<Config>().ForceGetGoodWorld)
            {
                Main.getGoodWorld = true;
            }
            if (ModContent.GetInstance<Config>().RemoveGetGoodWorld)
            {
                Main.getGoodWorld = false;
            }
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (ModContent.GetInstance<Config>().DmgComboShow && ModContent.GetInstance<Config>().DmgComboON)
            {
                Player player = Main.LocalPlayer;
                var modPlayer = player.GetModPlayer<DmgCombo>();

                // Convert world position to screen position
                Vector2 screenPos = player.Center - Main.screenPosition;
                screenPos.Y += 3 * Main.GameViewMatrix.Zoom.Y * 5; // Offset below the player3
                screenPos.X -= 75;

                string text = modPlayer.DamageCombo.ToString("F2"); // Format to 2 decimal places
                Color textColor = Color.White;

                // Draw the text
                Utils.DrawBorderString(spriteBatch, text, screenPos, textColor);
            }
        }
    }
    public class TakenHitsCount : ModPlayer
    {
        public int TakenHits;
        public int TakenHitsBoss;
        bool CodeFixer = false;
        Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 255, 255);
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<Config>().ShowHitNumber && ModContent.GetInstance<MyModSystem>().IsBossAlive() 
                || ModContent.GetInstance<Config>().ShowHitNumberAlways)
            {
                TakenHits++;
                // Spawn the combat text
                // Position: slightly below the player
                Vector2 textPosition = new Vector2(Player.Center.X, Player.Center.Y - 20);

                // Create a rectangle for the text spawn
                Microsoft.Xna.Framework.Rectangle rect = new Microsoft.Xna.Framework.Rectangle((int)textPosition.X, (int)textPosition.Y, 0, 0);

                // Spawn combat text
                CombatText.NewText(rect, color, TakenHits.ToString(), true, false);
            }
            if (ModContent.GetInstance<Config>().ShowHitNumberAfterFight && ModContent.GetInstance<MyModSystem>().IsBossAlive())
            {
                TakenHitsBoss++;
            }
        }
        public override void PostUpdate()
        {
            if (!ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().ShowHitNumber && CodeFixer == true && !ModContent.GetInstance<Config>().ShowHitNumberAlways)
            {
                TakenHits = 0;
            }
            if (!ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().ShowHitNumberAfterFight && CodeFixer == true)
            {
                //Player player = ModContent.GetInstance<Player>();
                if (TakenHitsBoss > 0)
                {
                    Main.NewText("[c/24FF9B:" + this.Player.name + " got hit " + TakenHitsBoss.ToString() + " times.]");
                }
                else
                {
                    Main.NewText("[c/24FF9B:" + this.Player.name + " did a no-hit.]");
                }
                TakenHitsBoss = 0;
            }

            if (!ModContent.GetInstance<MyModSystem>().IsBossAlive() && CodeFixer == true)
            { CodeFixer = false; }

            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().ShowHitNumber
                || ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().ShowHitNumberAfterFight)
            {
                CodeFixer = true;
            }
        }
        public override void OnRespawn()
        {if (ModContent.GetInstance<Config>().ShowHitNumber || ModContent.GetInstance<Config>().ShowHitNumberAfterFight)
            TakenHits = 0;
        }
    }
}
