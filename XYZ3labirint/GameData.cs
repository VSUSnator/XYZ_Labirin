using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTemplate
{
    public class GameData
    {
        private Dictionary<string, char[,]> _levelMaps = new Dictionary<string, char[,]>
        {
            { "Level 1", new[,]
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
                }
            },
            {"Level 2", new[,]
                {
                        { '#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                        { '#',' ',' ',' ',' ',' ','#','#','#','#','#',' ','#','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                        { '#','#',' ',' ',' ',' ',' ',' ','#',' ',' ','#',' ','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                        { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                        { '#',' ','#',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#', },
                        { '#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                        { '#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                }
            }
        };

        private Dictionary<string, List<UnitConfig>> _levelEnemies = new Dictionary<string, List<UnitConfig>>
        {
            { "Level 1", new List<UnitConfig> 
                {
                    new UnitConfig(new Vector2(1, 1), "@", UnitType.Player),
                    new UnitConfig(new Vector2(4, 5), "!", UnitType.VerticalObcstacle),
                    new UnitConfig(new Vector2(8, 5), "!", UnitType.VerticalObcstacle),
                    new UnitConfig(new Vector2(2, 11), "!", UnitType.VerticalObcstacle),
                    new UnitConfig(new Vector2(8, 12), "$", UnitType.SmartEnemy),
                 }
            },
            { "Level 2", new List<UnitConfig>
                {
                    new UnitConfig(new Vector2(1, 1), "@", UnitType.Player),
                    new UnitConfig(new Vector2(4, 5), "!", UnitType.VerticalObcstacle),
                    new UnitConfig(new Vector2(8, 12), "!", UnitType.VerticalObcstacle),
                    new UnitConfig(new Vector2(8, 5), "!", UnitType.VerticalObcstacle),
                    //new UnitConfig(new Vector2(8, 11), "$", UnitType.SmartEnemy),
                 }
            },
        };

        public Dictionary<string, char[,]> LevelMaps => _levelMaps;

        public Dictionary<string, List<UnitConfig>> LevelUnits => LevelUnits;

        public Dictionary<string, List<UnitConfig>> LevelEnemies => _levelEnemies;

    }

    public enum UnitType
    {
        Player, VerticalObcstacle, SmartEnemy
    }
}
