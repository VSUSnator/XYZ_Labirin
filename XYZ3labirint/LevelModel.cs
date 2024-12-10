using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTemplate
{
    public class LevelModel
    {
        private static LevelModel _instance;
        private static char[,] _map;
        private static Player _player;
        private static Units _units;

        public static Player Player => _player;

        public static Units Units => _units;

        private LevelModel() { }

        public static LevelModel GetInstance()
        {
            if (_instance == null)
                _instance = new LevelModel();

            return _instance;

        }

        public static void SetMap(char[,] map)
        {
            _map = map;
        }

        public char[,] GetMap()
        {
            if (_map == null)
            {
                Console.WriteLine("Карта не установлена");
                return null;
            }
            return _map;
        }

        public static void SetPlayer(Player player)
        {
            _player = player;
        }

        public static void SetUnits(Units units)
        {
            _units = units;
        }

        public static void AddUnit(Unit unit)
        {
            if (_units != null)
                _units.Add(unit);
        }
    }
}
