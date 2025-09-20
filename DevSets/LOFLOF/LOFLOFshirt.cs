using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LOFLOFdevSet
{
    // This tells tModLoader to look for a texture called MinionBossMask_Head, which is the texture on the player
    // and then registers this item to be accepted in head equip slots
    [AutoloadEquip(EquipType.Body)]
    public class LOFLOFshirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;

            // Common values for every boss mask
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.sellPrice(gold: 5);
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
}