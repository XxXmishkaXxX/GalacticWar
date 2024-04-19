using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GalacticWar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StartScreenMenu startScreenMenu;
        private KeyboardState prevKeyboardState;
        private  Texture2D backgroundStartScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Загрузка фонового изображения для начального экрана
            var backgroundStartScreen = Content.Load<Texture2D>("backgrounds/BackgroundStartPage");

            // Загрузка текстур для кнопок
            var playButtonTexture = Content.Load<Texture2D>("buttons/PlayBtn");
            var playButtonClickTexture = Content.Load<Texture2D>("buttons/PlayClick");
            var optButtonTexture = Content.Load<Texture2D>("buttons/OptBtn");
            var optButtonClickTexture = Content.Load<Texture2D>("buttons/OptClick");
            var exitButtonTexture = Content.Load<Texture2D>("buttons/ExitBtn");
            var exitButtonClickTexture = Content.Load<Texture2D>("buttons/ExitClick");

            // Создание экземпляра StartScreenMenu с передачей только текстур кнопок
            startScreenMenu = new StartScreenMenu(backgroundStartScreen,
                new Texture2D[] { playButtonTexture, optButtonTexture, exitButtonTexture },
                new Texture2D[] { playButtonClickTexture, optButtonClickTexture, exitButtonClickTexture },
                new Vector2[] { new (100, 100), new (100, 200), new (100, 300) });
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.GetState();

            startScreenMenu.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            startScreenMenu.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
