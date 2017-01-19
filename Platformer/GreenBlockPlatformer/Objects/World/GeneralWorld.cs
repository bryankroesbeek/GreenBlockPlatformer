using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBlockPlatformer.Global;
using GreenBlockPlatformer.Objects.Character;
using GreenBlockPlatformer.Objects.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.World {
    class GeneralWorld : IWorld {
        public Box Character { get; set; }
        public List<Platform> Platforms { get; set; }

        public GeneralWorld(Box character, GraphicsDevice gd) {
            this.Character = character;

            this.Platforms = new List<Platform> {
                new Platform(gd.CreateMonoTexture(200, 50, new Color(56, 56, 56)), new Vector2(-10, 100)),
                new Platform(gd.CreateMonoTexture(200, 50, new Color(56, 56, 56)), new Vector2(300, 300)),
                new Platform(gd.CreateMonoTexture(200, 50, new Color(56, 56, 56)), new Vector2(600, 500)),
                new Platform(gd.CreateMonoTexture(1400, 50, new Color(56, 56, 56)), new Vector2(-20, 700))
            };
        }

        public GeneralWorld(Box character, List<Platform> platforms) {
            this.Character = character;
            this.Platforms = platforms;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            this.Character.Draw(spriteBatch, gameTime);

            foreach (Platform p in this.Platforms) {
                p.Draw(spriteBatch, gameTime);
            }
        }

        public void Update(GameTime gameTime) {
            this.Character.Platforms = this.Platforms;
            this.Character.Update(gameTime);

            foreach (Platform p in this.Platforms) {
                p.Update(gameTime);
            }
        }
    }
}