﻿using System.Diagnostics;
using XYZ3labirint;

namespace MazeTemplate
{
    public abstract class Unit
    {
        public Vector2 Position { get; private set; }
        private char _symbol;
        private ConsoleRenderer _renderer;

        public Unit(Vector2 startPosition, char symbol, ConsoleRenderer renderer)
        {
            Position = startPosition;
            _symbol = symbol;
            _renderer = renderer;

            try
            {
                _renderer.SetPixel(Position.X, Position.Y, _symbol);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
        }

        public virtual bool TryMoveLeft()
        {
            return TryChangePosition(new Vector2(Position.X - 1, Position.Y));
        }

        public virtual bool TryMoveRight()
        {
            return TryChangePosition(new Vector2(Position.X + 1, Position.Y));
        }

        public virtual bool TryMoveUp()
        {
            return TryChangePosition(new Vector2(Position.X, Position.Y - 1));
        }

        public virtual bool TryMoveDown()
        {
            return TryChangePosition(new Vector2(Position.X, Position.Y + 1));
        }

        protected virtual bool TryChangePosition(Vector2 newPosition)
        {
            if (GameData.GetInstance().GetMap()[newPosition.X, newPosition.Y] == '#')
                return false;

            if (_renderer == null)
                throw new NullRendererException();

            _renderer.SetPixel(Position.X, Position.Y, ' ');
            Position = newPosition;
            _renderer.SetPixel(Position.X, Position.Y, _symbol);
            return true;
        }

        public abstract void Update();

    }
}