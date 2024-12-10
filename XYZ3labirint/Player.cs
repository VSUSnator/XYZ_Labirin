using System.Numerics;

namespace MazeTemplate;

public class Player : Unit
{

    private readonly Units _units;

    public event Action Death;

    public Player(Vector2 startPosition, IRenderer renderer, IMoveInput input) :
        base(startPosition, "@", renderer)
    {
        input.MoveUp += () => TryMoveUp();
        input.MoveDown += () => TryMoveDown();
        input.MoveRight += () => TryMoveRight();
        input.MoveLeft += () => TryMoveLeft();
    }
    public override void Update()
    {
        foreach (Unit unit in LevelModel.Units)
        {
            if (unit == this)
                continue;

            if (Position.Equals(unit.Position))
                Death?.Invoke();
        }
    }
}    

