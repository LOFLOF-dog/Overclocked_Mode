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
            if (npc.type == NPCID.Creeper)
            {
                npcLoot.RemoveWhere(rule => true);
            }
            if (!Main.expertMode && !Main.masterMode && npc.type == NPCID.BrainofCthulhu) 
            {
                npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.CrimtaneOre);
                npcLoot.Add(ItemDropRule.Common(ItemID.TissueSample, 1, 69, 69));
                npcLoot.Add(ItemDropRule.Common(ItemID.CrimtaneOre, 1, 69, 69));
            }
        }
    }
}
