using MonoMod.Logs;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Overclocked.Reworks
{
    public class EvilBossDropRework : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (!ModContent.GetInstance<Config>().EvilBossMaterialsReworkON) { return; }
            //
            switch (npc.type) 
            {
                case NPCID.Creeper:
                    npcLoot.RemoveWhere(rule => true);
                    break;

                case NPCID.BrainofCthulhu:
                    if (!Main.expertMode && !Main.masterMode)
                    {
                        npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.CrimtaneOre);
                        npcLoot.Add(ItemDropRule.Common(ItemID.TissueSample, 1, 69, 69));
                        npcLoot.Add(ItemDropRule.Common(ItemID.CrimtaneOre, 1, 69, 69));
                    }
                    break;

                default:
                    break;
            }
        }
    }
    public class EvilBossBagsRework : GlobalItem 
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (!ModContent.GetInstance<Config>().EvilBossMaterialsReworkON) { return; }
            //
            if (item.type == ItemID.BrainOfCthulhuBossBag) 
            {
                if (Main.expertMode)
                {
                    itemLoot.RemoveWhere(
                        rule => rule is CommonDrop drop && (drop.itemId == ItemID.CrimtaneOre || drop.itemId == ItemID.TissueSample)
                    );
                    itemLoot.Add(ItemDropRule.Common(ItemID.TissueSample, 1, 69, 69));
                    itemLoot.Add(ItemDropRule.Common(ItemID.CrimtaneOre, 1, 69, 69));
                }
                else
                {
                    itemLoot.RemoveWhere(
                        rule => rule is CommonDrop drop && (drop.itemId == ItemID.CrimtaneOre || drop.itemId == ItemID.TissueSample)
                    );
                    itemLoot.Add(ItemDropRule.Common(ItemID.TissueSample, 1, 69, 69));
                    itemLoot.Add(ItemDropRule.Common(ItemID.CrimtaneOre, 1, 69, 69));
                }       
            }
        }
    }
}
