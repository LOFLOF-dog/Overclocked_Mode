using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Reworks
{
    public class EvilBossDropRework : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Creeper)
            {
                Main.NewText("GOWNO");
                npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.TissueSample); //Add(ItemDropRule.Common(ModContent.ItemType<MyModItem>(), 10));
            }
        }
    }
}
