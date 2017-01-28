using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBlockPlatformer.Global;
using GreenBlockPlatformer.Objects.Camera;
using GreenBlockPlatformer.Objects.Character;
using GreenBlockPlatformer.Objects.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.World {
    class GeneralWorld : IWorld {
        public IBox Character { get; set; }
        public List<Platform> Platforms { get; set; }

        private List<Platform> OutOfRangePlatforms { get; set; }

        private ICamera Camera { get; set; }

        public GeneralWorld(IBox character, GraphicsDevice gd, ICamera camera) {
            this.Character = character;
            this.Camera = camera;

            int platformLength = 200;
            int platformHeight = 50;

            this.Platforms = new List<Platform> {
                new Platform(gd.CreateMonoTexture(200, 50, new Color(56, 56, 56)), new Vector2(-10, 100)),
                new Platform(gd.CreateMonoTexture(200, 50, new Color(56, 56, 56)), new Vector2(300, 300)),
                new Platform(gd.CreateMonoTexture(200, 50, new Color(56, 56, 56)), new Vector2(600, 500)),
                new Platform(gd.CreateMonoTexture(1400, 50, new Color(56, 56, 56)), new Vector2(-20, 700))
            };

            Random rand = new Random();

            for (int i = 0; i < 15000; i++) {
                this.Platforms.Add(new Platform(gd.CreateMonoTexture(platformLength, platformHeight, new Color(56, 56, 56)), new Vector2(rand.Next(-20000, 20000), rand.Next(-10000, 10000))));
            }

        }

        public GeneralWorld(Box character, List<Platform> platforms) {
            this.Character = character;
            this.Platforms = platforms;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            this.Character.Draw(spriteBatch, gameTime);

            foreach (Platform p in this.Platforms) {
                if (p.Position.IsBetween(this.Character.Position, 1920, 1080)) {
                    p.Draw(spriteBatch, gameTime);
                }
            }
        }

        public void Update(GameTime gameTime) {
            this.Character.Platforms = this.Platforms;
            this.Character.Update(gameTime);

            this.Camera.Update(gameTime);

            foreach (Platform p in this.Platforms) {
                p.Update(gameTime);
            }

        }
    }
}