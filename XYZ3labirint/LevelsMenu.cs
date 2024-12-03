using MazeTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTemplate
{
    internal class LevelsMenu
    {
        private Dictionary<string, char[,]> _levelMaps;
        private ConsoleInput _input;
        private IRenderer _renderer;

        public LevelsMenu(Dictionary<string, char[,]> levelMaps, ConsoleInput input, IRenderer renderer)
        {
            _levelMaps = levelMaps;
            _input = input;
            _renderer = renderer;

            _input.Esc += SetMenu;
        }

        public void SetMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберете уровень:");
            foreach (var levelMap in _levelMaps)
            {
                Console.WriteLine(levelMap);
            }
            string input = Console.ReadLine();

            if (_levelMaps.ContainsKey(input))
                SetLevel(input);
            else
                SetMenu();
        }

        public void SetLevel(string level)
        {
            Console.Clear();
            GameData.SetMap(_levelMaps[level]);
            SetMapPixels(_levelMaps[level]);
        }

        public void SetMapPixels(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    _renderer.SetCell(i, j, map[i, j].ToString());
                }
            }
        }
    }
}
