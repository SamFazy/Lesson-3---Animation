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
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;

        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;

        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth);
            randomYValue = generator.Next(0, _graphics.PreferredBackBufferHeight);
            tribbleGreyRect = new Rectangle(randomXValue, randomYValue, 100, 100);
            tribbleGreySpeed = new Vector2(8, 1);

            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth);
            tribbleCreamRect = new Rectangle(randomXValue, 90, 100, 100);
            tribbleCreamSpeed = new Vector2(2, 1);

            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth);
            randomYValue = generator.Next(0, _graphics.PreferredBackBufferHeight);
            tribbleBrownRect = new Rectangle(randomXValue, randomYValue, 100, 100);
            tribbleBrownSpeed = new Vector2(2, 10);

            randomXValue = generator.Next(0, _graphics.PreferredBackBufferWidth);
            randomYValue = generator.Next(0, _graphics.PreferredBackBufferHeight);
            tribbleOrangeRect = new Rectangle(randomXValue, randomYValue, 100, 100);
            tribbleOrangeSpeed = new Vector2(12, 7);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");

            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");

            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");

            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.Left < 0)
                tribbleGreySpeed.X *= -1;

            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Top < 0 || tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight)
                tribbleGreySpeed.Y *= -1;


            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            if (tribbleCreamRect.Right > 900)
            {
                tribbleCreamSpeed.X = tribbleCreamSpeed.X + 1;
                if (tribbleCreamSpeed.X == 900)
                {
                    tribbleCreamSpeed.X = tribbleCreamSpeed.X = 1;
                }
                tribbleCreamRect = new Rectangle(-100 , 90, 100, 100);
            }
                

            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Bottom > 900)
            {
                randomXValue = generator.Next(0, 700);
                randomSize = generator.Next(5, 300);
                tribbleBrownRect = new Rectangle(randomXValue, -300, randomSize, randomSize);
            }

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
                tribbleOrangeSpeed.X *= -1;

            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRect.Bottom > 900)
            {
                randomSpeed = generator.Next(2, 100);
                tribbleOrangeSpeed.Y = tribbleOrangeSpeed.Y = randomSpeed;
                randomXValue = generator.Next(0, 700);
                tribbleOrangeRect = new Rectangle(randomXValue, -100, 100, 100);
            }
             

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
