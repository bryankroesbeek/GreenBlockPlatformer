using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.World.Backgrounds {
    class Background : IBackground{
        private IWorld World { get; }
        public Texture2D Texture { get; set; }

        private Vector2 BaseLocation { get; set; }
        public Vector2 Position { get; set; }

        public Background(IWorld parentWorld, Texture2D texture) {
            this.World = parentWorld;
            this.Texture = texture;
            this.BaseLocation = new Vector2(this.Texture.Width / 2f, this.Texture.Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }

        public void Update(GameTime gameTime) {
            this.Position = (this.World.Character.Position * 0.75f) - this.BaseLocation;
        }
    }
}
