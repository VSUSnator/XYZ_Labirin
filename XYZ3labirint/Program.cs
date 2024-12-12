using System.Diagnostics;
using System.Numerics;
using System.Linq;

namespace MazeTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = new GameData();
            IRenderer renderer = new ConsoleRenderer();
            ConsoleInput input = new ConsoleInput();
            UnitFactory unitFactory = new UnitFactory(renderer, input);
            LevelsMenu levelsMenu = new LevelsMenu(data, input, renderer, unitFactory);
         
            levelsMenu.SetMenu();



            Units units = new Units();

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

                if(LevelModel.Units != null)
                    foreach (Unit unit in LevelModel.Units)
                    {
                        unit.Update();
                    
                    }

                renderer.Render();

                Thread.Sleep(550);
            }
        }

        static void GameOver()
        {
            Environment.Exit(0);
        }
    }
}