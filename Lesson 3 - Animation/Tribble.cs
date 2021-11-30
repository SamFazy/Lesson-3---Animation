using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_3___Animation
{
    class Tribble
{
        private Vector2 _speed;
        private Rectangle _rectangle;
        private Texture2D _texture;

        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
        {
            _speed = speed;
            _rectangle = rectangle;
            _texture = texture;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public void Move()
        {
            _rectangle.Offset(_speed);
        }

        public void BounceLeftRight()
        {
            _speed.X *= -1;
        }

        public void BounceTopBottom()
        {
            _speed.Y *= -1;
        }

    }
}
