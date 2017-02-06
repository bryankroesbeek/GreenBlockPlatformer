using System;
using System.Linq;
using System.Collections.Generic;
using GreenBlockPlatformer.Global;
using GreenBlockPlatformer.Objects.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GreenBlockPlatformer.Objects.Character {
    public class Character : ICharacter {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public CharacterState State { get; set; }
        public Vector2 AirResistance => ((Globals.Gravity / 75) * new Vector2(Math.Abs(this.Speed.X), Math.Abs(this.Speed.Y)));
        public List<Platform> Platforms { get; set; }

        private Platform UnderlyingPlatform => Platforms
            .Where(x => 
                this.Position.X > x.Position.X && this.Position.X < (x.Position.X + x.Width) || 
                this.Position.X + this.Texture.Width > x.Position.X && this.Position.X + this.Texture.Width < (x.Position.X + x.Width)
            )
            .Where(y => y.Position.Y > this.Position.Y)
            .OrderBy(y => y.Position.Y)
            .ToList().FirstOrDefault();

        public Character(Texture2D texture, Vector2 position, List<Platform> platforms = null) {
            this.Texture = texture;
            this.Position = position;

            this.Platforms = platforms;
        }

        public void Update(GameTime gt) {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && this.State == CharacterState.Standing) {
                this.Speed += new Vector2(2.5f, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && this.State == CharacterState.Standing) {
                this.Speed += new Vector2(-2.5f, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && (this.State == CharacterState.Standing)) {
                this.Speed = new Vector2(this.Speed.X, -30);
                this.State = CharacterState.Jumping;
            }

            this.Speed += (Globals.Gravity - this.AirResistance);
            this.Position += this.Speed;
            if (this.Speed.Y > 0)
                this.State = CharacterState.Falling;

            if (this.Position.Y >= this.UnderlyingPlatform?.Position.Y - this.Texture.Height && this.State != CharacterState.Jumping) {
                this.Position = new Vector2(this.Position.X, this.UnderlyingPlatform.Position.Y - this.Texture.Height);
                this.Speed = new Vector2(this.Speed.X, 0);
                this.State = CharacterState.Standing;
            }

            if (this.State == CharacterState.Standing) {
                if (this.Speed.X > Globals.MaxSpeed) {
                    this.Speed = new Vector2(Globals.MaxSpeed, this.Speed.Y);
                } else if (this.Speed.X < -Globals.MaxSpeed) {
                    this.Speed = new Vector2(-Globals.MaxSpeed, this.Speed.Y);
                }
                if (Math.Abs(this.Speed.X) <= 0.25f) {
                    this.Speed = new Vector2(0, this.Speed.Y);
                } else {
                    if (this.Speed.X < 0) {
                        this.Speed = new Vector2(this.Speed.X + 0.5f, this.Speed.Y);
                    }
                    if (this.Speed.X > 0) {
                        this.Speed = new Vector2(this.Speed.X - 0.5f, this.Speed.Y);
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb, GameTime gt) {
            sb.Draw(this.Texture, this.Position, Color.White);
        }
    }
}