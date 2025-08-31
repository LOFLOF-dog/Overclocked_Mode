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
            RecipeGroup EvilBossMaterial = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}",ItemID.ShadowScale, ItemID.TissueSample);
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowScale), EvilBossMaterial);
        }
        public override void AddRecipes()
        {
            for (int i = 0; i < Main.recipe.Length; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.createItem.type == ItemID.BundleofBalloons || recipe.createItem.type == ItemID.HorseshoeBundle)
                {
                    recipe.DisableRecipe();
                }
            }
            Recipe BundleofBalloons = Recipe.Create(ItemID.BundleofBalloons);
            BundleofBalloons.AddIngredient(ItemID.CloudinaBalloon);
            BundleofBalloons.AddIngredient(ItemID.BlizzardinaBalloon);
            BundleofBalloons.AddIngredient(ItemID.SandstorminaBalloon);
            BundleofBalloons.AddRecipeGroup(nameof(ItemID.ShadowScale), 5);
            BundleofBalloons.AddTile(TileID.TinkerersWorkbench);
            BundleofBalloons.Register();
            Recipe HorseshoeBundleBundle = Recipe.Create(ItemID.HorseshoeBundle);
            HorseshoeBundleBundle.AddIngredient(ItemID.BundleofBalloons);
            HorseshoeBundleBundle.AddIngredient(ItemID.LuckyHorseshoe);
            HorseshoeBundleBundle.AddTile(TileID.TinkerersWorkbench);
            HorseshoeBundleBundle.Register();
            Recipe HorseshoeBundleAll = Recipe.Create(ItemID.HorseshoeBundle);
            HorseshoeBundleAll.AddIngredient(ItemID.CloudinaBalloon);
            HorseshoeBundleAll.AddIngredient(ItemID.BlizzardinaBalloon);
            HorseshoeBundleAll.AddIngredient(ItemID.SandstorminaBalloon);
            HorseshoeBundleAll.AddIngredient(ItemID.LuckyHorseshoe);
            HorseshoeBundleAll.AddRecipeGroup(nameof(ItemID.ShadowScale), 5);
            HorseshoeBundleAll.AddTile(TileID.TinkerersWorkbench);
            HorseshoeBundleAll.Register();
            Recipe HorseshoeBundleCloud = Recipe.Create(ItemID.HorseshoeBundle);
            HorseshoeBundleCloud.AddIngredient(ItemID.BlueHorseshoeBalloon);
            HorseshoeBundleCloud.AddRecipeGroup(RecipeGroupID.BlizzardBalloons);
            HorseshoeBundleCloud.AddRecipeGroup(RecipeGroupID.SandstormBalloons);
            HorseshoeBundleCloud.AddRecipeGroup(nameof(ItemID.ShadowScale), 5);
            HorseshoeBundleCloud.AddTile(TileID.TinkerersWorkbench);
            HorseshoeBundleCloud.Register();
            Recipe HorseshoeBundleBlizzard = Recipe.Create(ItemID.HorseshoeBundle);
            HorseshoeBundleBlizzard.AddIngredient(ItemID.WhiteHorseshoeBalloon);
            HorseshoeBundleBlizzard.AddRecipeGroup(RecipeGroupID.CloudBalloons);
            HorseshoeBundleBlizzard.AddRecipeGroup(RecipeGroupID.SandstormBalloons);
            HorseshoeBundleBlizzard.AddRecipeGroup(nameof(ItemID.ShadowScale), 5);
            HorseshoeBundleBlizzard.AddTile(TileID.TinkerersWorkbench);
            HorseshoeBundleBlizzard.Register();
            Recipe HorseshoeBundleSandstorm = Recipe.Create(ItemID.HorseshoeBundle);
            HorseshoeBundleSandstorm.AddIngredient(ItemID.YellowHorseshoeBalloon);
            HorseshoeBundleSandstorm.AddRecipeGroup(RecipeGroupID.BlizzardBalloons);
            HorseshoeBundleSandstorm.AddRecipeGroup(RecipeGroupID.CloudBalloons);
            HorseshoeBundleSandstorm.AddRecipeGroup(nameof(ItemID.ShadowScale), 5);
            HorseshoeBundleSandstorm.AddTile(TileID.TinkerersWorkbench);
            HorseshoeBundleSandstorm.Register();
            // Removing Recipes.
            //   List<Recipe> rec = Main.recipe.ToList();
            //   int numberRecipesRemoved = 0;
            // The Recipes to remove.
            //numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.AlphabetStatueU);
            //Change AlphabetStatueT's recipe to create 10 clentaminator from 10 wood
            //   rec.Where(x => x.createItem.type == ItemID.HorseshoeBundle  /*|| x.createItem.type == ItemID.HorseshoeBundle*//* || x.requiredItem == ItemID.HorseshoeBundle*/).ToList().ForEach(s =>
            //   {
            //for (int i = 0; i < s.requiredItem.Length; i++)
            //{
            //    s.requiredItem[i] = new Item();
            //}
            //if (rec.requiredItem == ItemID.HorseshoeBundle) { }
            //       s.AddRecipeGroup(nameof(ItemID.ShadowScale), 1);
            //s.requiredItem[12].SetDefaults("Overclocked:ShadowScale", false);
            //s.requiredItem[12].stack = 10;

            //s.createItem.SetDefaults(ItemID.Clentaminator, false);
            //s.createItem.stack = 10;
            /*foreach (Recipe recipe in Main.recipe)
            {
                foreach (Item item in recipe.requiredItem)
                {
                    if (item.type != ItemID.BundleofBalloons) // Check for Bundle of Balloons
                    {
                        // Do something, like logging or modifying the recipe
                        s.AddRecipeGroup(nameof(ItemID.ShadowScale), 1);
                    }
                }
            }*/
            //  });
            //  Main.recipe = rec.ToArray();
            //  Array.Resize(ref Main.recipe, Recipe.maxRecipes);
            //  Recipe.numRecipes -= numberRecipesRemoved;

            /*Recipe recipe = Recipe.Create(ItemID.BundleofBalloons);
            recipe.AddIngredient(ItemID.CloudinaBalloon);
            recipe.AddIngredient(ItemID.BlizzardinaBalloon);
            recipe.AddIngredient(ItemID.SandstorminaBalloon);
            recipe.AddIngredient(ItemID.SandstorminaBalloon);
            recipe.AddRecipeGroup(RecipeGroupID.);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();*/
        }
    }
}
