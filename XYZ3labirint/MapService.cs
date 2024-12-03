using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTemplate
{
    public class MapService
    {
        private static MapService _instance;
        private static char[,] _map;

        private MapService() { }

        public static MapService GetInstance()
        {
            if (_instance == null)
                _instance = new MapService();

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
    }
}
