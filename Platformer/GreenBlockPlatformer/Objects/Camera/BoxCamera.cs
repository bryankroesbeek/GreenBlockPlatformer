using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBlockPlatformer.Objects.Character;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.Camera {
    public class BoxCamera : ICamera{
        public Texture2D Texture {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Vector2 Position { get; set; }

        private Vector2 Origin { get; set; }

        private IBox Target { get; set; }
        private Viewport Viewport { get; set; }
        private float Rotation { get; set; }
        private float Zoom { get; set; }

        public Matrix ViewMatrix {
            get {
                return
                    Matrix.CreateTranslation(new Vector3(-this.Position, 0.0f)) *
                    Matrix.CreateRotationZ(this.Rotation) *
                    Matrix.CreateScale(this.Zoom, this.Zoom, 1.0f)*
                    Matrix.CreateTranslation(new Vector3(this.Origin, 0.0f));
            }
        }

        public BoxCamera(IBox target, Viewport viewport) {
            this.Target = target;
            this.Viewport = viewport;

            this.Rotation = 0.0f;
            this.Zoom = 1.0f;

            this.Position = target.Position;
            this.Origin = new Vector2(this.Viewport.Width / 2.0f, this.Viewport.Height / 2.0f);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime) {
            this.Position = this.Target.Position;
        }
    }
}
