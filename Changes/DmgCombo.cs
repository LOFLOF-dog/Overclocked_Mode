using Terraria;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class DmgCombo : ModPlayer
    {
        public float DamageCombo = 1f;
        int WaitTime = 0;
        float DmgIncrease = ModContent.GetInstance<Config>().DmgComboIncrease;
        float DmgComboDecrease = ModContent.GetInstance<Config>().DmgComboDecrease;
        float DmgComboCapDown = ModContent.GetInstance<Config>().DmgComboCapDown;
        float DmgComboCapUp = ModContent.GetInstance<Config>().DmgComboCapUp;
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<Config>().DmgComboON)
            {
                //when player get hit set wait time till damage combo start to decrease 
                WaitTime = ModContent.GetInstance<Config>().DmgComboWaitTime * 60;
                //increase the damage combo
                DamageCombo += (DmgIncrease / 100) * (1 - (DamageCombo - 1) / ModContent.GetInstance<Config>().DmgComboDispower);
                //cap the damage combo if needed
                if (DmgComboCapUp / 100 != 0 && DamageCombo > DmgComboCapUp / 100)
                { DamageCombo = DmgComboCapUp / 100; }
            }
        }
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (ModContent.GetInstance<Config>().DmgComboON)
            {
                //multiply taken damage by damagge combo
                modifiers.SourceDamage *= DamageCombo;
            }
        }
        public override void PreUpdate()
        {
            //Main.NewText(WaitTime.ToString());
            if (ModContent.GetInstance<Config>().DmgComboON)
            {
                //decrease wait time till it's 0
                //when 0, decrease damage combo
                if (WaitTime > 0)
                { WaitTime -= 1; }
                if (WaitTime <= 0 && DamageCombo > DmgComboCapDown / 100)
                {
                    DamageCombo -= DmgComboDecrease /100 / 60;
                }
            }
        }
        //reset damage combo when player die
        public override void OnRespawn()
        {
            DamageCombo = 1;
        }
    }
}