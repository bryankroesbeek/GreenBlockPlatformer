using System.Collections.Generic;
using GreenBlockPlatformer.Global;
using GreenBlockPlatformer.Objects;
using GreenBlockPlatformer.Objects.Camera;
using GreenBlockPlatformer.Objects.Character;
using GreenBlockPlatformer.Objects.Platforms;
using GreenBlockPlatformer.Objects.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GreenBlockPlatformer {
    public class Game1 : Game {
        GraphicsDeviceManager _graphics;
        SpriteBatch SpriteBatch { get; set; }

        private IBox Box { get; set; }

        private ICamera Camera { get; set; }

        private IWorld World { get; set; }

        private List<IPlatform> PlatformList { get; set; }

        public Game1() {
            this._graphics = new GraphicsDeviceManager(this) {
                PreferredBackBufferWidth = Globals.ScreenWidth,
                PreferredBackBufferHeight = Globals.ScreenHeight,
                IsFullScreen = Globals.FullScreen
            };
            this.Content.RootDirectory = "Content";
        }
        
        protected override void Initialize() {

            base.Initialize();
        }
        
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.Box = new Box(this.GraphicsDevice.CreateMonoTexture(45, 75, new Color(16, 137, 62)), new Vector2(0, 0));

            this.Camera = new BoxCamera(this.Box, this.GraphicsDevice.Viewport);

            this.World = new GeneralWorld(Box, this.GraphicsDevice, this.Camera);
        }
        
        protected override void UnloadContent() {

        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            this.World.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            this.GraphicsDevice.Clear(new Color(225, 225, 225));
            this.SpriteBatch.Begin(transformMatrix: this.Camera.ViewMatrix);

            this.World.Draw(this.SpriteBatch, gameTime);

            this.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
