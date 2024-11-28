using MazeTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ3labirint
{
    internal class LevelsMenu
    {
        private Dictionary<string, char[,]> _levelMaps;
        private ConsoleInput _input;
        private ConsoleRenderer _renderer;

        public LevelsMenu(Dictionary<string, char[,]> levelMaps, ConsoleInput input, ConsoleRenderer renderer)
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
            SetMapPixels(_levelMaps[level], _renderer);
        }

        public void SetMapPixels(char[,] map, ConsoleRenderer renderer)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    renderer.SetPixel(i, j, map[i, j]);
                }
            }
        }
    }
}
