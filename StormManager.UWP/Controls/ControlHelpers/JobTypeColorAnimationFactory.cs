using System;
using System.Collections.Generic;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public static class JobTypeColorAnimationFactory
    {
        private static Dictionary<ColorAnimationType, Type> AnimationToTypeMapping => new Dictionary<ColorAnimationType, Type>
        {
            {ColorAnimationType.BuildingDamage, typeof(BuildingDamageColorAnimation) },
            {ColorAnimationType.Flood, typeof(FloodColorAnimation) },
            {ColorAnimationType.TreeDown, typeof(TreeDownColorAnimation) }
        };
        
        public static IColorAnimationHelper Create(ColorAnimationType colorAnimationType)
        {
            AnimationToTypeMapping.TryGetValue(colorAnimationType, out var value);

            if (value == null)
            {
                throw new ArgumentNullException();
            }

            return (IColorAnimationHelper)Activator.CreateInstance(value);
        }
    }
}
