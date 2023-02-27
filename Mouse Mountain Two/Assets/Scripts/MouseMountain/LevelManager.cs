using System;
using System.Collections.Generic;
using MouseMountain.Board;
using MouseMountain.Things;
using MouseMountain.Things.Characters;
using UnityEngine;
using MouseMountain.Utilities;

namespace MouseMountain
{
    [Serializable]
    public class LevelTileOccupant
    {
        public string objectKey;
    }
    [Serializable]
    public class LevelTile
    {
        public string color;
        public int id;
        public List<LevelTileOccupant> occupants;
    }
    
    [Serializable]
    public class LevelRow
    {
        public List<LevelTile> row;
    }
    [Serializable]
    public class Level
    {
        public string title;
        public string skybox;
        public string ambient;
        public List<LevelRow> tiles;
  
    }
    public class LevelManager : MonoBehaviour
    {
        private static string _jsonPath = "JSON/Levels/";
        private readonly Dictionary<int, string> _levelCatalog = new();
        public Level currentLevel;
        
        // Place the objects
        // Be able to delete the objects
        // Be able to delete the grid

        private void Awake()
        {
            _levelCatalog.Add(0, "level_proto_0");
        }

        private void Start()
        {
            currentLevel = LoadLevel(0);
            currentLevel = GameManager.Instance.hexGrid.CreatGridFromLevel(currentLevel);
            PlaceObjects(currentLevel);
        }

        private Level LoadLevel(int levelNum)
        {
            return JsonUtils.ImportJson<Level>(_jsonPath + _levelCatalog[levelNum]);
        }

        private void PlaceObjects(Level level)
        {
            //ToDo: This is just placing gameObjects not BaseObjects
            for (var outer = 0; outer < level.tiles.Count; outer++)
            {
                for (var inner = 0; inner < level.tiles[outer].row.Count; inner++)
                {
                    var tileIndex = level.tiles[outer].row[inner].id;
                    var tileTransform = GameManager.Instance.hexGrid.GetHexCellTransform(tileIndex);
                    foreach (var occupant in level.tiles[outer].row[inner].occupants)
                    {
                        try
                        {
                            var c = BaseCharacterCatalog.Instance.CharacterCatalog[occupant.objectKey];
                            Instantiate(c, tileTransform);
                            var b = c.GetComponent<BaseObject>();
                            var m = b.GetName();
                            Debug.Log(m);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                }
            }
        }
    }
}