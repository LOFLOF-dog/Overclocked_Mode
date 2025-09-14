
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
    /// <summary>
    /// Template class to imitate reference to data fields
    /// </summary>
    /// <typeparam name="_Ty">Type of data</typeparam>
    class TypeRef<_Ty> 
    {
        /// <summary>
        /// Constuctor, which saves lambda functions
        /// </summary>
        /// <param name="g">Source value getter</param>
        /// <param name="s">Source value setter</param>
        public TypeRef(Func<_Ty> g, Action<_Ty> s)
        {
            getter = g;
            setter = s;
        }

        /// <summary>
        /// Value property allows to have access to data field reference like
        /// </summary>
        public _Ty Value { get => getter(); set => setter(value); }

        public override string ToString() => Value.ToString();

        private object target;
        private Func<_Ty>   getter;
        private Action<_Ty> setter;
    }
    
    /// <summary>
    /// Modifying "Player" entity. Shuffles controls time to time
    /// </summary>
    internal class EvilMovement : ModPlayer
    {
        private static int activationPeriod; 
        private static int randomSpread;

        /// <summary>
        /// Set of references on player's controls (see <see cref="TypeRef{_Ty}"/>)
        /// </summary>
        private TypeRef<bool>[] controls;

        /// <summary>
        /// Set of shuffled references on player's controls (see <see cref="TypeRef{_Ty}"/>)
        /// </summary>
        private TypeRef<bool>[] shuffledControls;

        /// <summary>
        /// Tick counter. Lol
        /// </summary>
        private int tickCounter = 0;

        /// <summary>
        /// ActivationPeriod is amount of tick needs to shuffle controls again
        /// </summary>
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

        /// <summary>
        /// RandomSpread randomizes <see cref="ActivationPeriod"/>
        /// </summary>
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

        /// <summary>
        /// Sets <see cref="ActivationPeriod"/> and <see cref="RandomSpread"/>
        /// </summary>
        public override void SetStaticDefaults()
        {
            ActivationPeriod = ModContent.GetInstance<Config>().EvilMovementActivationPeriod;
            RandomSpread = ModContent.GetInstance<Config>().EvilMovementRandomSpread;
        }
        /// <summary>
        /// Initializes player's control set to shuffle
        /// </summary>
        public override void Initialize()
        {
            controls =
            [
                new TypeRef<bool>( () => Player.controlLeft,  (bool value) => Player.controlLeft  = value ),
                new TypeRef<bool>( () => Player.controlUp,    (bool value) => Player.controlUp    = value ),
                new TypeRef<bool>( () => Player.controlRight, (bool value) => Player.controlRight = value ),
                new TypeRef<bool>( () => Player.controlDown,  (bool value) => Player.controlDown  = value ),
                new TypeRef<bool>( () => Player.controlHook,  (bool value) => Player.controlHook  = value ),
                new TypeRef<bool>( () => Player.controlJump,  (bool value) => Player.controlJump  = value )
            ];
            shuffledControls = (TypeRef<bool>[])controls.Clone();
        }
        /// <summary>
        /// Decrements tick counter, sets random count of ticks on it on zero value
        /// and shuffles player's control set
        /// </summary>
        public override void PreUpdate()
        {
            if (!ModContent.GetInstance<Config>().EvilMovementON) return;
            //
            if (tickCounter <= 0 || --tickCounter <= 0) 
            {
                tickCounter = activationPeriod + (Random.Shared.Next(-randomSpread, randomSpread));
                Random.Shared.Shuffle(shuffledControls);

                CombatText.NewText(Player.getRect(), Color.Cyan, "GET CONFUSED LOL");
            }
        }

        /// <summary>
        /// Applies shuffled player's control set
        /// </summary>
        public override void SetControls()
        {
            if (!ModContent.GetInstance<Config>().EvilMovementON) return;
            
            bool[] oldControls = new bool[controls.Count()];

            // Copying values before editing to swap values, not to overwrite them
            for (int i = 0; i < oldControls.Count(); ++i)
            {
                oldControls[i] = controls[i].Value;
            }
            
            // Set's copied values to current player's control set through references (see TypeRef<_Ty>)
            for (int i = 0; i < oldControls.Count(); ++i) 
            {
                shuffledControls[i].Value = oldControls[i];
            }
        }
    }
}
