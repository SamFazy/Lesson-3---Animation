using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lesson_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Random generator = new Random();

        int randomYValue;
        int randomXValue;
        int randomSize;
        int randomSpeed;



        Texture2D tribbleGreyTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleBrownTexture;
        Texture2D tribbleOrangeTexture;
        Tribble greyTribble, orangeTribble, creamTribble, brownTribble;

        Texture2D appleTexture;
        Rectangle appleRect;
        Vector2 appleSpeed;

        Texture2D appleDoubleTexture;
        Rectangle appleDoubleRect;
        Vector2 appleDoubleSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            

            

            

            

            appleRect = new Rectangle(500, 350, 100, 100);
            appleSpeed = new Vector2(2, 7);

            appleDoubleRect = new Rectangle(-100, -100, 100, 100);
            appleDoubleSpeed = new Vector2(2, 7);

            base.Initialize();
            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth - 100);
            randomYValue = generator.Next(0, _graphics.PreferredBackBufferHeight - 100);
            greyTribble = new Tribble(tribbleGreyTexture, new Rectangle(randomXValue, randomYValue, 100, 100), new Vector2(8, 1));

            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth);
            creamTribble = new Tribble(tribbleCreamTexture, new Rectangle(randomXValue, 90, 100, 100), new Vector2(2, 1));

            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth);
            randomYValue = generator.Next(0, _graphics.PreferredBackBufferHeight);
            brownTribble = new Tribble(tribbleBrownTexture, new Rectangle(randomXValue, randomYValue, 100, 100), new Vector2(2, 10));

            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth - 100);
            randomYValue = generator.Next(0, _graphics.PreferredBackBufferHeight);
            orangeTribble = new Tribble(tribbleOrangeTexture, new Rectangle(randomXValue, randomYValue, 100, 100), new Vector2(12, 7));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");

            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");

            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");

            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            appleTexture = Content.Load<Texture2D>("apple");

            appleDoubleTexture = Content.Load<Texture2D>("apple");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            greyTribble.Move();
            if (greyTribble.Bounds.Top < 0 || greyTribble.Bounds.Bottom > _graphics.PreferredBackBufferHeight)
            {
                greyTribble.BounceTopBottom();
            }
            if (greyTribble.Bounds.Left < 0 || greyTribble.Bounds.Right > _graphics.PreferredBackBufferWidth)
            {
                greyTribble.BounceLeftRight();
            }

            creamTribble.Move();
            if (creamTribble.Bounds.Top < 0 || creamTribble.Bounds.Bottom > _graphics.PreferredBackBufferHeight)
            {
                creamTribble.BounceTopBottom();
            }
            if (creamTribble.Bounds.Left < 0 || creamTribble.Bounds.Right > _graphics.PreferredBackBufferWidth)
            {
                creamTribble.BounceLeftRight();
            }

            brownTribble.Move();
            if (brownTribble.Bounds.Top < 0 || brownTribble.Bounds.Bottom > _graphics.PreferredBackBufferHeight)
            {
                brownTribble.BounceTopBottom();
            }
            if (brownTribble.Bounds.Left < 0 || brownTribble.Bounds.Right > _graphics.PreferredBackBufferWidth)
            {
                brownTribble.BounceLeftRight();
            }

            orangeTribble.Move();
            if (orangeTribble.Bounds.Top < 0 || orangeTribble.Bounds.Bottom > _graphics.PreferredBackBufferHeight)
            {
                orangeTribble.BounceTopBottom();
            }
            if (orangeTribble.Bounds.Left < 0 || orangeTribble.Bounds.Right > _graphics.PreferredBackBufferWidth)
            {
                orangeTribble.BounceLeftRight();
            }

            appleRect.X += (int)appleSpeed.X;
            appleDoubleRect.X += (int)appleDoubleSpeed.X;
            if (appleRect.Right == 800)
            {
                appleDoubleRect = new Rectangle(-100, 350, 100, 100);

            }

            if (appleDoubleRect.Right == 800)
            {
                appleRect = new Rectangle(-100, 350, 100, 100);

            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(greyTribble.Texture, greyTribble.Bounds, Color.White);
            _spriteBatch.Draw(creamTribble.Texture, creamTribble.Bounds, Color.White);
            _spriteBatch.Draw(brownTribble.Texture, brownTribble.Bounds, Color.White);
            _spriteBatch.Draw(orangeTribble.Texture, orangeTribble.Bounds, Color.White);
            _spriteBatch.Draw(appleTexture, appleRect, Color.White);
            _spriteBatch.Draw(appleDoubleTexture, appleDoubleRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
