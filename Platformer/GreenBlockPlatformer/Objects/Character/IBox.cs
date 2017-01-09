using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.Character {
    public interface IBox : IComponent{
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
        Vector2 Speed { get; set; }
        BoxState State { get; set; }

        Vector2 AirResistance { get; }
    }
}