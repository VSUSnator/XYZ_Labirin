namespace MazeTemplate
{
    public class UnitFactory
    {
        private IRenderer _renderer;
        private IMoveInput _moveInput;

        public UnitFactory(IRenderer renderer, IMoveInput moveInput)
        {
            _renderer = renderer;
            _moveInput = moveInput;
        }
    

        public void CreateUnit(UnitConfig config)
        {
            switch (config.Type)
            {
                case UnitType.Player:
                    Player player = new Player(config.Position, _renderer, _moveInput);
                    LevelModel.AddUnit(player);
                    LevelModel.SetPlayer(player);
                    break;
                case UnitType.VerticalObcstacle:
                    LevelModel.AddUnit(new VerticalObstacle(config.Position, config.View, _renderer));
                    break;
                case UnitType.SmartEnemy:
                    LevelModel.AddUnit(new SmartEnemy(config.Position, config.View, _renderer));
                    break;
            }
        }
    }       
}
