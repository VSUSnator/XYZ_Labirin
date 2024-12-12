using System.Numerics;

namespace MazeTemplate;

public class Player : Unit
{

    private readonly Units _units;
    private IMoveInput _input;

    public event Action Death;

    public Player(Vector2 startPosition, IRenderer renderer, IMoveInput input) :
        base(startPosition, "@", renderer)
    {
        _input = input;
        _input.MoveUp += Up;
        _input.MoveDown += Down;
        _input.MoveRight += Right;
        _input.MoveLeft += Left;
    }

    private void Up()
    {
        TryMoveUp();
    }
    private void Down()
    {
        TryMoveDown();
    }
    private void Right()
    {
        TryMoveRight();
    }
    private void Left()
    {
        TryMoveLeft();
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

    public void Dispose()
    {
        _input.MoveUp -= Up;
        _input.MoveDown -= Down;
        _input.MoveRight -= Right;
        _input.MoveLeft -= Left;
    }
}    

