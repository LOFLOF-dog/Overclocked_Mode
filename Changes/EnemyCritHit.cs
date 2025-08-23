using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    internal class EnemyCritHit : ModPlayer
    {
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            float CritChance = ModContent.GetInstance<Config>().CritTakenDamageChance;
            if (Main.rand.NextFloat() < CritChance / 100 && ModContent.GetInstance<Config>().CritTakenDamageON)
            {

                modifiers.FinalDamage *= ModContent.GetInstance<Config>().CritTakenDamageMultiplier / 100;

                Microsoft.Xna.Framework.Color Critcolor = new Microsoft.Xna.Framework.Color(255, 100, 70, 255);
                CombatText.NewText(Player.Hitbox, Critcolor, "Critical Damage!");

            }
        }
    }
}
