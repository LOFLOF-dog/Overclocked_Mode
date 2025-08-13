using Overclocked.Accs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class AccSlots : ModPlayer
    {
        public int EquipedAccs = 0;
        public override void ResetEffects()
        {
            EquipedAccs = 0;
        }
        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<Config>().LessAccSlotsON && EquipedAccs < ModContent.GetInstance<Config>().BlockedAccesorySlots)
            {
                Player.statLifeMax2 -= Player.statLifeMax - 1;
                Player.GetDamage(DamageClass.Generic) /= 1000;
                //Main.NewText(EquipedAccs.ToString() + ModContent.GetInstance<Config>().BlockedAccesorySlots.ToString() + ModContent.GetInstance<Config>().LessAccSlotsON);
            }
        }
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (ModContent.GetInstance<Config>().BlockedAccesorySlots == 1)
            {
                return new List<Item>()
                { 
                    new Item(ModContent.ItemType<Acc1>())
                };
            }
            if (ModContent.GetInstance<Config>().BlockedAccesorySlots == 2)
            {
                return new List<Item>() 
                { 
                    new Item(ModContent.ItemType<Acc1>()), 
                    new Item(ModContent.ItemType<Acc2>()) 
                };
            }
            if (ModContent.GetInstance<Config>().BlockedAccesorySlots == 3)
            {
                return new List<Item>()
                {
                    new Item(ModContent.ItemType<Acc1>()),
                    new Item(ModContent.ItemType<Acc2>()),
                    new Item(ModContent.ItemType<Acc3>())
                };
            }
            if (ModContent.GetInstance<Config>().BlockedAccesorySlots == 4)
            {
                return new List<Item>()
                {
                    new Item(ModContent.ItemType<Acc1>()),
                    new Item(ModContent.ItemType<Acc2>()),
                    new Item(ModContent.ItemType<Acc3>()),
                    new Item(ModContent.ItemType<Acc4>())
                };
            }
            if (ModContent.GetInstance<Config>().BlockedAccesorySlots == 5)
            {
                return new List<Item>()
                {
                    new Item(ModContent.ItemType<Acc1>()),
                    new Item(ModContent.ItemType<Acc2>()),
                    new Item(ModContent.ItemType<Acc3>()),
                    new Item(ModContent.ItemType<Acc4>()),
                    new Item(ModContent.ItemType<Acc5>())
                };
            }
            if (ModContent.GetInstance<Config>().BlockedAccesorySlots == 6)
            {
                return new List<Item>()
                {
                    new Item(ModContent.ItemType<Acc1>()),
                    new Item(ModContent.ItemType<Acc2>()),
                    new Item(ModContent.ItemType<Acc3>()),
                    new Item(ModContent.ItemType<Acc4>()),
                    new Item(ModContent.ItemType<Acc5>()),
                    new Item(ModContent.ItemType<Acc6>())
                };
            }
            return base.AddStartingItems(mediumCoreDeath);
            
        }
        public override bool CanUseItem(Item item)
        {
            if (ModContent.GetInstance<Config>().NoDemonHeart && Player.HeldItem.type == ItemID.DemonHeart)
            {
                return false;
            }
            return base.CanUseItem(item);
        }
    }
}
