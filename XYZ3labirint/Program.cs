using System.Diagnostics;
using System.Numerics;
using XYZ3labirint;
using System.Linq;

namespace MazeTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char[,]> _levelMaps = new Dictionary<string, char[,]>();
            _levelMaps["Level 1"] = new[,] 
            {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ','#', },
                    { '#',' ',' ','#',' ','#',' ',' ','#',' ',' ',' ',' ','#', },
                    { '#',' ',' ','#',' ',' ',' ',' ','#','#',' ','#','#','#', },
                    { '#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#','#',' ',' ',' ','#',' ',' ','#',' ',' ','#',' ','#', },
                    { '#',' ',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ','#', },
                    { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#',' ','#',' ','#',' ',' ','#',' ',' ','#',' ',' ','#', },
                    { '#',' ',' ',' ','#',' ',' ','#',' ',' ','#',' ',' ','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
            };
            _levelMaps["Level 2"] = new[,]
            {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ',' ','#',' ','#','#','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#','#',' ',',',' ',' ',' ',' ','#',' ',' ','#',' ','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ',' ',' ','#',' ',' ','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#',' ',' ',',',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#',' ','#',',','#',' ',' ',' ',' ',' ','#',' ',' ','#', },
                    { '#',' ',' ',',','#',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
            };
            ConsoleRenderer renderer = new ConsoleRenderer();
            ConsoleInput input = new ConsoleInput();
            LevelsMenu levelsMenu = new LevelsMenu(_levelMaps, input, renderer);

            Player player = new Player(new Vector2(1, 1), renderer, input); //Null, input);
            VerticalObstacle obstacle1 = new VerticalObstacle(new Vector2(4, 5), '!', renderer);
            VerticalObstacle obstacle2 = new VerticalObstacle(new Vector2(8, 5), '!', renderer);
            VerticalObstacle obstacle3 = new VerticalObstacle(new Vector2(2, 11), '!', renderer);

            SmartEnemy enemy = new SmartEnemy(new Vector2(8, 12), '$', renderer, player);

            levelsMenu.SetMenu();

            Units units = new Units();
            units.Add(player);
            units.Add(obstacle1);
            units.Add(obstacle2);
            units.Add(obstacle3);
            units.Add(enemy);

            renderer.Render();

            while (true)
            {
                try 
                {
                    input.Update();
                }
                catch (NullRendererException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                input.Update();

                foreach (Unit unit in units)
                {
                    unit.Update();
                    
                }

                renderer.Render();

                Thread.Sleep(550);

                foreach (Unit unit in units)
                {
                    if (unit == player)
                        continue;

                    if (player.Position.Equals(unit.Position))
                        GameOver();
                }
            }
        }

        static void GameOver()
        {
            Environment.Exit(0);
        }
    }
}