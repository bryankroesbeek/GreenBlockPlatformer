using GreenBlockPlatformer.Objects;
using GreenBlockPlatformer.Objects.Character;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GreenBlockPlatformer {
    public class Game1 : Game {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private Texture2D _texture;
        private Vector2 _texpos;

        private Box box;

        public Game1() {
            this._graphics = new GraphicsDeviceManager(this) {
                PreferredBackBufferWidth = Globals.ScreenWidth,
                PreferredBackBufferHeight = Globals.ScreenHeight
            };
            this.Content.RootDirectory = "Content";
        }
        
        protected override void Initialize() {
            this._texture = new Texture2D(this.GraphicsDevice, 45, 75);
            this._texpos = new Vector2(0, 0);

            base.Initialize();
        }
        
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            this._spriteBatch = new SpriteBatch(this.GraphicsDevice);

            Color[] colors = new Color[this._texture.Width * this._texture.Height];
            for (int i = 0; i < colors.Length; i++) {
                colors[i] = new Color(16, 137, 62);
            }

            
            this._texture.SetData(colors);
            this._texture.SetData(colors);

            this.box = new Box(this._texture, this._texpos);
            
        }
        
        protected override void UnloadContent() {

        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            this.box.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            this.GraphicsDevice.Clear(new Color(225, 225, 225));
            this._spriteBatch.Begin();

            this.box.Draw(this._spriteBatch, gameTime);

            this._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
