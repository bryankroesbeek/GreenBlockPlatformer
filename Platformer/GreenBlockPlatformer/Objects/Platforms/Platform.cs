using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.Platforms {
    public class Platform : IPlatform {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public int Width => this.Texture.Width;
        public int Height => this.Texture.Height;

        public Platform(Texture2D texture, Vector2 position) {
            this.Texture = texture;
            this.Position = position;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }

        public void Update(GameTime gameTime) {
            
        }
    }
}
