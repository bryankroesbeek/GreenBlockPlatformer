using System.Collections.Generic;
using GreenBlockPlatformer.Objects.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.Character {
    public interface ICharacter : IComponent{
        Vector2 Speed { get; set; }
        CharacterState State { get; set; }
        Vector2 AirResistance { get; }

        List<Platform> Platforms { get; set; }
    }
}