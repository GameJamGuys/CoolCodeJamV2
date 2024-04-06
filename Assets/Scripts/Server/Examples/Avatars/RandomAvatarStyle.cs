using Unity.VisualScripting;
using UnityEngine;

namespace Server.Examples
{
   public class RandomAvatarStyle
    {
        private bool Flip { get; set;} = false;
        private int Rotate { get; set;} = 0;
        private int Scale { get; set;} = 100;
        private int Radius { get; set;} = 0;
        private int Size { get; set;} = 96;
        private Color BackgroundColor { get; set;} = Color.clear;

        public override string ToString()
        {
            return $"&flip={Flip.ToString().ToLower()}&rotate={Rotate}&scale={Scale}&radius={Radius}&size={Size}&" +
                   $"backgroundColor={(BackgroundColor.a == 0 ? "transparent" : BackgroundColor.ToHexString()[..6])}";
        }

        ///If true then horizontally mirrored
        public RandomAvatarStyle SetFlip(bool isFlipped)
        {
            Flip = isFlipped;
            return this;
        }
        
        ///Percentage of result scale
        /// <param name="scale">Min = 0, Max = 200</param>
        public RandomAvatarStyle SetScale(int scale)
        {
            if (scale < 0)
                scale = 0;
            if (scale > 200)
                scale = 200;
            
            Scale = scale;
            return this;
        }
        
        ///Corners radius
        /// <param name="radius">Min = 0, Max = 50</param>
        public RandomAvatarStyle SetRadius(int radius)
        {
            if (radius < 0)
                radius = 0;
            if (radius > 50)
                radius = 50;
            
            Radius = radius;
            return this;
        }
        
        ///Result angle in degrees
        /// <param name="rotate">Min = 0, Max = 360</param>
        public RandomAvatarStyle SetRotate(int rotate)
        {
            if (rotate < 0)
                rotate = 0;
            if (rotate > 360)
                rotate = 360;
            
            Rotate = rotate;
            return this;
        }
        
        ///Set size in pixels for generated picture
        /// <param name="size">Min = 1</param>
        public RandomAvatarStyle SetSize(int size)
        {
            if (size < 1)
                size = 1;
            
            Size = size;
            return this;
        }
        
        ///Background color
        public RandomAvatarStyle SetBackgroundColor(Color color)
        {
            BackgroundColor = color;
            return this;
        }
    }
}