using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects {
    public interface IComponent : IDrawableComponent{
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
    }

    public interface IDrawableComponent {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
