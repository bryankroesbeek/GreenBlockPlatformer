using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.World.Backgrounds {
    class Foreground : IBackground{
        private IWorld World { get; }
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }
        private Vector2 BasePosition { get; }

        public Foreground(IWorld parentWorld, Texture2D texture) {
            this.World = parentWorld;
            this.Texture = texture;
            this.BasePosition = new Vector2(this.Texture.Width / 0.25f, this.Texture.Height / 0.25f);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.Draw(this.Texture, this.Position, null, null, null, 0, new Vector2(8), Color.White);
        }

        public void Update(GameTime gameTime) {
            this.Position = (this.World.Character.Position * -0.75f) - this.BasePosition;
        }
    }
}
