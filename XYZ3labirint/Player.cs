namespace MazeTemplate;

public class Player : Unit
{


    public Player(Vector2 startPosition, ConsoleRenderer renderer, IMoveInput input) : base(startPosition, '@', renderer)
    {
        input.MoveUp += () => TryMoveUp();
        input.MoveDown += () => TryMoveDown();
        input.MoveRight += () => TryMoveRight();
        input.MoveLeft += () => TryMoveLeft();
    }
    public override void Update()
    {
    }
}    

