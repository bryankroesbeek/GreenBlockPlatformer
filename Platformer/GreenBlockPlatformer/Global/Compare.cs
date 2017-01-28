using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GreenBlockPlatformer.Global {
    public static class Compare {
        public static bool IsBetween(this Vector2 point, Vector2 lowerBound, Vector2 upperBound) {
            bool c1 = (point.X > lowerBound.X && point.Y > lowerBound.Y);
            bool c2 = (point.X < upperBound.X && point.Y < upperBound.Y);

            return c1 && c2;
        }

        public static bool IsBetween(this Vector2 point, Vector2 comparePoint, float offset) {
            bool c1 = (point.X > comparePoint.X - offset && point.Y > comparePoint.Y - offset);
            bool c2 = (point.X < comparePoint.X + offset && point.Y < comparePoint.Y + offset);

            return c1 && c2;
        }

        public static bool IsBetween(this Vector2 point, Vector2 comparePoint, float offsetX, float offsetY) {
            bool c1 = (point.X > comparePoint.X - offsetX && point.Y > comparePoint.Y - offsetY);
            bool c2 = (point.X < comparePoint.X + offsetX && point.Y < comparePoint.Y + offsetY);

            return c1 && c2;
        }
    }
}
