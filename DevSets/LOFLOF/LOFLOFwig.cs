using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.DevSets.LOFLOF
{
    // This tells tModLoader to look for a texture called MinionBossMask_Head, which is the texture on the player
    // and then registers this item to be accepted in head equip slots
    [AutoloadEquip(EquipType.Head)]
    public class LOFLOFwig : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 18;

            // Common values for every boss mask
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.sellPrice(gold: 5);
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
}