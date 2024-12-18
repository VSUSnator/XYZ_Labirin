﻿namespace MazeTemplate
{
    public class SmartEnemy : Unit
    {
        private Unit _target;
        private int[] dx = { -1, 0, 1, 0 };
        private int[] dy = { 0, 1, 0, -1 };

        public SmartEnemy(Vector2 startPosition, string view, IRenderer renderer) :
            base(startPosition, view, renderer)
        {
            _target = LevelModel.Player;
        }

        public override void Update()
        {
            if(_target != null)
            {
                _target = LevelModel.Player;
                return;
            }

            List<Node> path = FindPath();

            if (path == null) 
                return;

            if(path.Count <= 1)
                return;
            Node nextPosition = path[1];
            TryChangePosition(nextPosition.Position);

        }

        public List<Node> FindPath()
        {
            Node startNode = new Node(Position);
            Node targetNode = new Node(_target.Position);

            // сюда добавляются все вершины, в которые можно пойти.
            List<Node> openList = new List<Node> { startNode };
         
            // сюда добавляются все вершины, по которым уже прошли, они в вычислениях не участвуют
            List<Node> closedList = new List<Node>();

            while (openList.Count > 0)
            {
                Node currentNode = openList[0];

                foreach (var node in openList)
                {
                    if (node.Value < currentNode.Value)
                        currentNode = node;
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode.Position.Equals (targetNode.Position))
                {
                    List<Node> path = new List<Node>();

                    while (currentNode != null)
                    {
                        path.Add(currentNode);
                        currentNode = currentNode.Parent;
                    }

                    path.Reverse();
                    return path;
                }

                for (int i = 0; i < dx.Length; i++)
                {
                    int newX = currentNode.Position.X + dx[i];
                    int newY = currentNode.Position.Y + dy[i];

                    if (IsValid(newX, newY))
                    {
                        Node neighbor = new Node(new Vector2(newX, newY));

                        if (closedList.Contains(neighbor))
                            continue;

                        neighbor.Parent = currentNode;
                        neighbor.CalculateEstimate(targetNode.Position);
                        neighbor.CalculateValue();

                        openList.Add(neighbor);
                    }
                }
            }

            return null;
        }

        private bool IsValid(int x, int y)
        {
            char[,] map = LevelModel.GetInstance().GetMap();
            bool containsX = x >= 0 && x < map.GetLength(0);
            bool containsY = y >= 0 && y < map.GetLength(1);
            bool isNotWall = map[x, y] != '#';
            return containsX && containsY && isNotWall;
        }
    }
}
