using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Overclocked.Changes
{
    public class NurseHealBlocker : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void GetChat(NPC npc, ref string chat)
        {
            if (ModContent.GetInstance<Config>().NoNurseHealingON)
            {
                if (npc.type == NPCID.Nurse)
                {
                    // Change the chat message depending on whether a boss is alive
                    if (ModContent.GetInstance<MyModSystem>().IsBossAlive())
                    {
                        chat = ModContent.GetInstance<Config>().NurseText;
                    }
                }
            }
        }

        /*public override bool PreChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type == NPCID.Nurse && firstButton)
            {
                // Check if a boss is alive
                if (IsBossAlive())
                {
                    // Prevent the default healing behavior if a boss is alive
                    Main.NewText("Git Gud Sucker!!1!");
                    return false; // Returning false prevents the default action
                }
            }
            return true;
        }*/
    }
}
