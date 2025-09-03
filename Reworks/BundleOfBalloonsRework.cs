using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Overclocked.Reworks
{
    public class BundleOfBalloonsRework : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup EvilBossMaterial = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.ShadowScale, ItemID.TissueSample);
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowScale), EvilBossMaterial);
        }
        public override void AddRecipes()
        {
            // Removing Recipes.
            List<Recipe> rec = Main.recipe.ToList();
            //
            //Change AlphabetStatueT's recipe to create 10 clentaminator from 10 wood
            rec.Where(x => 
                (x.createItem.type == ItemID.HorseshoeBundle || 
                x.createItem.type == ItemID.BundleofBalloons) &&
                !x.requiredItem.Any(x => x.type == ItemID.BundleofBalloons)
            ).ToList().ForEach(s =>
            {
                s.AddRecipeGroup(nameof(ItemID.ShadowScale), 1);
            });
            //
            Main.recipe = rec.ToArray();
            //Array.Resize(ref Main.recipe, Recipe.maxRecipes);
        }
    }
}
