using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overclocked.Changes
{
    public class PickupNerf : GlobalItem
    {
        public override bool OnPickup(Item item, Player player)
        {
            if (ModContent.GetInstance<Config>().PickupNerfON)
            {
                if (item.type == ItemID.Heart)
                {
                    // Cancel default healing and apply custom amount
                    player.statLife += ModContent.GetInstance<Config>().HPPickupNerf; // Custom heal amount
                    player.HealEffect(ModContent.GetInstance<Config>().HPPickupNerf); // Show healing effect
                    item.active = false;   // Remove item manually
                    return false;
                }
                else if (item.type == ItemID.Star)
                {
                    player.statMana += ModContent.GetInstance<Config>().ManaPickupNerf; // Custom mana restore
                    player.ManaEffect(ModContent.GetInstance<Config>().ManaPickupNerf);
                    item.active = false;
                    return false;
                }
            }
            return true;
        }
    }
}
