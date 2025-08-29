using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class TakenHitLimit : ModPlayer
    {
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (ModContent.GetInstance<Config>().TakenHitLimitON && ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss && ModContent.GetInstance<MyModSystem>().IsBossAlive() && TakenHits >= ModContent.GetInstance<Config>().TakenHitLimit - 1
            || ModContent.GetInstance<Config>().TakenHitLimitON && !ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss && TakenHits >= ModContent.GetInstance<Config>().TakenHitLimit - 1)
            {
                modifiers.FinalDamage *= 2137;
                
            }
        }
        int TakenHits;
        bool CodeFixer = false;
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().TakenHitLimitON && ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss
                || ModContent.GetInstance<Config>().TakenHitLimitON && !ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss)
            {
                TakenHits++;
            }
        }
        public override void PostUpdate()
        {
            if (!ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().TakenHitLimitON && ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss && CodeFixer == true)
            {
                TakenHits = 0;
                CodeFixer = false;
            }

            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().TakenHitLimitON && ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss
                || ModContent.GetInstance<Config>().TakenHitLimitON && !ModContent.GetInstance<Config>().TakenHitLimitOnlyWhenBoss)
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
