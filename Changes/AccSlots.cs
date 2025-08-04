using Overclocked.Accs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class AccSlots : ModPlayer
	{
        public bool AccOn;
        public override void ResetEffects()
        {
            AccOn = false;
        }
        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<Config>().LessAccSlotsON)
            {
                if (AccOn != true)
                {
                    Player.statLifeMax2 -= Player.statLifeMax - 1;
                    Player.GetDamage(DamageClass.Generic) /= 1000;
                }
            }
        }
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new List<Item>() { new Item(ModContent.ItemType<Acc>()) };
        }
    }
}
