using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class BlockRegenOnHit : ModPlayer 
    {
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<Config>().RegenBlockerON)
            {
                if (ModContent.GetInstance<Config>().RegenBlockerOnlyWhenBoss && !ModContent.GetInstance<MyModSystem>().IsBossAlive()) 
                {
                    return;
                }
                else 
                {
                    if (Main.expertMode) 
                    { Player.AddBuff(ModContent.BuffType<BlockedRegenDebuff>(), ModContent.GetInstance<Config>().RegenBlockedTime * 30); }
                    
                    if (Main.masterMode) 
                    { Player.AddBuff(ModContent.BuffType<BlockedRegenDebuff>(), ModContent.GetInstance<Config>().RegenBlockedTime * 24); }

                    if (!Main.expertMode && !Main.masterMode) 
                    { Player.AddBuff(ModContent.BuffType<BlockedRegenDebuff>(), ModContent.GetInstance<Config>().RegenBlockedTime * 60); }
                    
                }
            }
        }
    }
}