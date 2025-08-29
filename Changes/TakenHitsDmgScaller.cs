using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class TakenHitDmgScaller : ModPlayer
    {
        float DmgMod = 1;
        float DmgScal = ModContent.GetInstance<Config>().TakenHitScal;
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (ModContent.GetInstance<Config>().TakenHitDmgScallerON && ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss && ModContent.GetInstance<MyModSystem>().IsBossAlive()
            || ModContent.GetInstance<Config>().TakenHitDmgScallerON && !ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss)
            {
                modifiers.SourceDamage *= DmgMod;

            }
        }
        int TakenHits;
        bool CodeFixer = false;
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().TakenHitDmgScallerON && ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss
                || ModContent.GetInstance<Config>().TakenHitDmgScallerON && !ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss)
            {
                DmgMod += DmgScal / 100;
            }
        }
        public override void PostUpdate()
        {
            if (!ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().TakenHitDmgScallerON && ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss && CodeFixer == true)
            {
                DmgMod = 1;
                CodeFixer = false;
            }

            if (ModContent.GetInstance<MyModSystem>().IsBossAlive() && ModContent.GetInstance<Config>().TakenHitDmgScallerON && ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss
                || ModContent.GetInstance<Config>().TakenHitDmgScallerON && !ModContent.GetInstance<Config>().TakenHitDmgScallerOnlyWhenBoss)
            {
                CodeFixer = true;
            }
        }
        public override void OnRespawn()
        {
            DmgMod = 1;
        }
    }
}
