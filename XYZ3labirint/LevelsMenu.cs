using MazeTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTemplate
{
    public class LevelsMenu
    {
        private GameData _gameData;
        private ConsoleInput _input;
        private IRenderer _renderer;
        private UnitFactory _unitFactory;

        public LevelsMenu(GameData gameData, ConsoleInput input, IRenderer renderer, UnitFactory unitFactory)
        {
            _gameData = gameData;
            _input = input;
            _renderer = renderer;
            _unitFactory = unitFactory;

            _input.Esc += SetMenu;
        }

        public void SetMenu()
        {
            _renderer.Clear();
            Console.WriteLine("Выберете уровень:");
            foreach (var levelMap in _gameData.LevelMaps)
            {
                Console.WriteLine(levelMap);
            }
            string input = Console.ReadLine();

            if (_gameData.LevelMaps.ContainsKey(input))
                SetLevel(input);
            else
                SetMenu();
        }

        public void SetLevel(string level)
        {
            Console.Clear();
            LevelModel.SetMap(_gameData.LevelMaps[level]);
            LevelModel.SetUnits(new Units());
            SetMapPixels(_gameData.LevelMaps[level]);
            SetUnits(_gameData.LevelEnemies[level]);
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

        public void SetUnits(List<UnitConfig> units)
        {
            foreach (var unitConfig in units)
            {
                _unitFactory.CreateUnit(unitConfig);
            }
        }
    }
}
