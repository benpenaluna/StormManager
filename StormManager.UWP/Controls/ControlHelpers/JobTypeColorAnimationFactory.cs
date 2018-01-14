using System;
using System.Collections.Generic;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public static class JobTypeColorAnimationFactory
    {
        private static Dictionary<ColorAnimationType, Type> AnimationToTypeMapping => new Dictionary<ColorAnimationType, Type>
        {
            {ColorAnimationType.Default, typeof(DefaultColorAnimation) },
            {ColorAnimationType.BuildingDamage, typeof(BuildingDamageColorAnimation) },
            {ColorAnimationType.Flood, typeof(FloodColorAnimation) },
            {ColorAnimationType.TreeDown, typeof(TreeDownColorAnimation) }
        };
        
        public static IMapIconControlHelper Create(ColorAnimationType colorAnimationType)
        {
            AnimationToTypeMapping.TryGetValue(colorAnimationType, out var value);

            if (value == null)
            {
                throw new ArgumentNullException();
            }

            var colorAnimationTypeInstance = (IColorAnimationHelper)Activator.CreateInstance(value);
            return MapIconControlHelper.Create(colorAnimationTypeInstance);
        }
    }
}
