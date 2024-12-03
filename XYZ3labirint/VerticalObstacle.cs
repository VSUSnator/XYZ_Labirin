namespace MazeTemplate
{
    public class VerticalObstacle : Unit
    {
        private bool _obstacleDownDir = true;

        public VerticalObstacle(Vector2 startPosition, string view,IRenderer renderer) :
            base(startPosition, view, renderer)
        {
        }

        public override void Update()
        {
            if (_obstacleDownDir)
            {
                if (!TryMoveDown())
                    _obstacleDownDir = false;
            }
            else
            {
                if (!TryMoveUp())
                    _obstacleDownDir = true;
            }
        }
    }
}
