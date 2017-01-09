using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GreenBlockPlatformer.Objects.Character {
    public class Box : IBox{
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public BoxState State { get; set; }

        public Vector2 AirResistance => ((Globals.Gravity / 75) * new Vector2(Math.Abs(this.Speed.X), Math.Abs(this.Speed.Y)));

        public Box(Texture2D texture, Vector2 position) {
            this.Texture = texture;
            this.Position = position;
        }

        public void Update(GameTime gt) {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && this.State == BoxState.Standing) {
                this.Speed += new Vector2(2.5f, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && this.State == BoxState.Standing) {
                this.Speed += new Vector2(-2.5f, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && (this.State == BoxState.Standing)) {
                this.Speed = new Vector2(this.Speed.X, -30);
                this.State = BoxState.Jumping;
            }

            this.Speed += (Globals.Gravity - this.AirResistance);
            this.Position += this.Speed;
            if (this.Speed.Y > 0)
                this.State = BoxState.Falling;

            if (this.Position.Y >= Globals.ScreenHeight - this.Texture.Height && this.State != BoxState.Jumping) {
                this.Position = new Vector2(this.Position.X, Globals.ScreenHeight - this.Texture.Height);
                this.Speed = new Vector2(this.Speed.X, 0);
                this.State = BoxState.Standing;
            }

            if (this.State == BoxState.Standing) {
                if (this.Speed.X > Globals.MaxSpeed) {
                    this.Speed = new Vector2(Globals.MaxSpeed, this.Speed.Y);
                } else if (this.Speed.X < -Globals.MaxSpeed) {
                    this.Speed = new Vector2(-Globals.MaxSpeed, this.Speed.Y);
                }
                if (Math.Abs(this.Speed.X) <= 0.25f) {
                    this.Speed = new Vector2(0, this.Speed.Y);
                } else {
                    if (this.Speed.X < 0) {
                        this.Speed = new Vector2(this.Speed.X + 1f, this.Speed.Y);
                    }
                    if (this.Speed.X > 0) {
                        this.Speed = new Vector2(this.Speed.X - 1f, this.Speed.Y);
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb, GameTime gt) {
           sb.Draw(this.Texture, this.Position, Color.White);
        }
    }

    
}
