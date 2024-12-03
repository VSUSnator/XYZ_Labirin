using System.Numerics;

namespace MazeTemplate;

public class Player : Unit
{

    private readonly Units _units;

    public event Action Death;

    public Player(Vector2 startPosition, IRenderer renderer, IMoveInput input, Units units) :
        base(startPosition, "@", renderer)
    {
        input.MoveUp += () => TryMoveUp();
        input.MoveDown += () => TryMoveDown();
        input.MoveRight += () => TryMoveRight();
        input.MoveLeft += () => TryMoveLeft();
        _units = units;
    }
    public override void Update()
    {
        foreach (Unit unit in _units)
        {
            if (unit == this)
                continue;

            if (Position.Equals(unit.Position))
                Death?.Invoke();
        }
    }
}    

