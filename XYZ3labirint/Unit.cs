using System.Diagnostics;


namespace MazeTemplate
{
    public abstract class Unit
    {
        public Vector2 Position { get; private set; }
        private string _view;
        private IRenderer _renderer;

        public Unit(Vector2 startPosition, string view, IRenderer renderer)
        {
            Position = startPosition;
            _view = view;
            _renderer = renderer;

            try
            {
                _renderer.SetCell(Position.X, Position.Y, _view);
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
            if (LevelModel.GetInstance().GetMap()[newPosition.X, newPosition.Y] == '#')
                return false;

            if (_renderer == null)
                throw new NullRendererException();

            _renderer.SetCell(Position.X, Position.Y, " ");
            Position = newPosition;
            _renderer.SetCell(Position.X, Position.Y, _view);
            return true;
        }

        public abstract void Update();

    }
}
