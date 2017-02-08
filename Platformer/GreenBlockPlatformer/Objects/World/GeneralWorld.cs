using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBlockPlatformer.Global;
using GreenBlockPlatformer.Objects.Camera;
using GreenBlockPlatformer.Objects.Character;
using GreenBlockPlatformer.Objects.Platforms;
using GreenBlockPlatformer.Objects.World.Backgrounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenBlockPlatformer.Objects.World {
    class GeneralWorld : IWorld {
        public ICharacter Character { get; set; }
        public List<Platform> Platforms { get; set; }

        private List<Platform> OutOfRangePlatforms { get; set; }

        private ICamera Camera { get; set; }

        private IBackground Background { get; set; }
        private IBackground Foreground { get; set; }

        public GeneralWorld(ICharacter character, GraphicsDevice gd, ICamera camera, Texture2D background, Texture2D foreground) {
            this.Character = character;
            this.Camera = camera;

            int platformLength = 200;
            int platformHeight = 50;

            this.Background = new Background(this, background);
            this.Foreground = new Foreground(this, foreground);

            this.Platforms = new List<Platform> {
                new Platform(gd.CreateMonoTexture(200, 50, new Color(199, 199, 199)), new Vector2(-10, 100)),
                new Platform(gd.CreateMonoTexture(200, 50, new Color(199, 199, 199)), new Vector2(300, 300)),
                new Platform(gd.CreateMonoTexture(200, 50, new Color(199, 199, 199)), new Vector2(600, 500)),
                new Platform(gd.CreateMonoTexture(1400, 50, new Color(199, 199, 199)), new Vector2(-20, 700))
            };

            Random rand = new Random();

            for (int i = 0; i < 15000; i++) {
                this.Platforms.Add(new Platform(gd.CreateMonoTexture(platformLength, platformHeight, new Color(199, 199, 199)), new Vector2(rand.Next(-20000, 20000), rand.Next(-10000, 10000))));
            }

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            this.Background.Draw(spriteBatch, gameTime);

            this.Character.Draw(spriteBatch, gameTime);

            foreach (Platform p in this.Platforms) {
                if (p.Position.IsBetween(this.Character.Position, 1920, 1080)) {
                    p.Draw(spriteBatch, gameTime);
                }
            }

            
            this.Foreground.Draw(spriteBatch, gameTime);
        }

        public void Update(GameTime gameTime) {
            this.Background.Update(gameTime);
            this.Foreground.Update(gameTime);
            this.Character.Platforms = this.Platforms;
            this.Character.Update(gameTime);

            this.Camera.Update(gameTime);

            foreach (Platform p in this.Platforms) {
                p.Update(gameTime);
            }

        }
    }
}