using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Accs
{
    public class Acc5 : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = ItemRarityID.Expert;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<Changes.AccSlots>().AccOn = true;
        }
        public override bool AllowPrefix(int pre)
        {
            return false;
        }
        public override void AddRecipes()
        {
            if (ModContent.GetInstance<Config>().LessAccSlotsON)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.DirtBlock)
                    .Register();
            }
        }

    }
}
