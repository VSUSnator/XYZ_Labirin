﻿using MazeTemplate;
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

        public LevelsMenu(GameData gameData, ConsoleInput input, IRenderer renderer)
        {
            _gameData = gameData;
            _input = input;
            _renderer = renderer;

            _input.Esc += SetMenu;
        }

        public void SetMenu()
        {
            Console.Clear();
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
            MapService.SetMap(_gameData.LevelMaps[level]);
            SetMapPixels(_gameData.LevelMaps[level]);
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
