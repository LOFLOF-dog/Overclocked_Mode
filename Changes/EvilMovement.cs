using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Overclocked.Changes
{
    internal class EvilMovement : ModPlayer
    {
        private static int activationPeriod;
        private static int randomSpread;

        public static int ActivationPeriod 
        {
            get => activationPeriod;
            set  
            {
                activationPeriod = value > 0 ? value : 1;
                if (activationPeriod < randomSpread) 
                {
                    randomSpread = activationPeriod;
                }
            }
        }

        public static int RandomSpread 
        {
            get => randomSpread;
            set 
            {
                randomSpread = value >= 0 ? value : 0;
                if (randomSpread > activationPeriod) 
                {
                    randomSpread = activationPeriod;
                }
            }
        }

        private int tickCounter = 0;
        private enum Dirs { LEFT, UP, RIGHT, DOWN };
        private static Dirs[] currDirs;

        public override void SetStaticDefaults()
        {
            ActivationPeriod = ModContent.GetInstance<Config>().EvilMovementActivationPeriod;
            RandomSpread = ModContent.GetInstance<Config>().EvilMovementRandomSpread;
            //
            currDirs = [Dirs.LEFT, Dirs.UP, Dirs.RIGHT, Dirs.DOWN];
        }
        public override void PreUpdate()
        {
            if (!ModContent.GetInstance<Config>().EvilMovementON) return;
            //
            if (tickCounter <= 0 || --tickCounter <= 0) 
            {
                tickCounter = activationPeriod + (Random.Shared.Next(-randomSpread, randomSpread));
                Random.Shared.Shuffle(currDirs);
            }
        }
        public override void SetControls()
        {
            if (!ModContent.GetInstance<Config>().EvilMovementON) return;
            //
            bool[] oldDirs = [Player.controlLeft, Player.controlUp, Player.controlRight, Player.controlDown];
            //
            Player.controlLeft = oldDirs[(int)currDirs[0]];
            Player.controlUp = oldDirs[(int)currDirs[1]];
            Player.controlRight = oldDirs[(int)currDirs[2]];
            Player.controlDown = oldDirs[(int)currDirs[3]];
        }
    }
}
