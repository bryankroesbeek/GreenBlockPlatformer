using System.Collections.Generic;
using GreenBlockPlatformer.Objects.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.Character {
    public interface IBox : IComponent{
        Vector2 Speed { get; set; }
        BoxState State { get; set; }
        Vector2 AirResistance { get; }

        List<Platform> Platforms { get; set; }
    }
}