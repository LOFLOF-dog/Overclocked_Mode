using LOFLOFdevSet;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.DevSets
{
    public class LootBagDrop : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            // In addition to this code, we also do similar code in Common/GlobalNPCs/ExampleNPCLoot.cs to edit the boss loot for non-expert drops. Remember to do both if your edits should affect non-expert drops as well.
            if (item.type == ItemID.DestroyerBossBag || item.type == ItemID.TwinsBossBag || item.type == ItemID.SkeletronPrimeBossBag
                || item.type == ItemID.PlanteraBossBag || item.type == ItemID.GolemBossBag || item.type == ItemID.FishronBossBag
                || item.type == ItemID.FairyQueenBossBag || item.type == ItemID.BossBagBetsy || item.type == ItemID.CultistBossBag || item.type == ItemID.MoonLordBossBag)
            {
                // The following code is attempting to retrieve the ItemDropRule found in the ItemDropDatabase.RegisterBossBags method:
                // RegisterToItem(item, ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.BeeGun, ItemID.BeeKeeper, ItemID.BeesKnees));
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is OneFromOptionsNotScaledWithLuckDropRule oneFromOptionsDrop)
                    {
                        var original = oneFromOptionsDrop.dropIds.ToList();
                        if (Main.rand.NextFloat() > 5)
                        {
                            original.Add(ModContent.ItemType<LOFLOFwig>());
                            original.Add(ModContent.ItemType<LOFLOFshirt>());
                            original.Add(ModContent.ItemType<LOFLOFboots>());
                            original.Add(ItemID.DogTail);
                        }
                        if (Main.rand.NextFloat() > 5)
                        {
                            original.Add(ModContent.ItemType<LOFLOFwig>());
                            original.Add(ModContent.ItemType<LOFLOFshirt>());
                            original.Add(ModContent.ItemType<LOFLOFboots>());
                            original.Add(ItemID.DogTail);
                        }
                        oneFromOptionsDrop.dropIds = original.ToArray();
                    }
                }
            }
        }
    }
}