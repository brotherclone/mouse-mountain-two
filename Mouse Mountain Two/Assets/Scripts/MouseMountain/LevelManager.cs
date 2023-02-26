using System;
using System.Collections.Generic;
using MouseMountain.Board;
using MouseMountain.Things.Characters;
using UnityEngine;
using MouseMountain.Utilities;

namespace MouseMountain
{
    [System.Serializable]
    public class LevelTileOccupant
    {
        public string objectKey;
    }
    [System.Serializable]
    public class LevelTile
    {
        public string color;
        public int id;
        public List<LevelTileOccupant> occupants;
    }
    
    [System.Serializable]
    public class LevelRow
    {
        public List<LevelTile> row;
    }
    [System.Serializable]
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
        private Dictionary<int, string> _mountainLevelsBase = new Dictionary<int, string>();
        private Dictionary<string, GameObject> _mouseMountainCharacters = new Dictionary<string, GameObject>();
        public GameObject owlArch;
        public GameObject testMouse;
        public Level currentLevel;
        
        // Find that level

        // Place the objects
        // Be able to delete the objects
        // Be able to delete the grid

        private void Awake()
        {
            _mountainLevelsBase.Add(0, "level_proto_0");
            _mouseMountainCharacters.Add("OWLARCH", owlArch);
            _mouseMountainCharacters.Add("TESTMOUSE", testMouse);
        }
        
        private void Start()
        {
            currentLevel = LoadLevel(0);
            currentLevel = GameManager.Instance.hexGrid.CreatGridFromLevel(currentLevel);
            PlaceObjects(currentLevel);
        }

        private Level LoadLevel(int levelNum)
        {
            return JsonUtils.ImportJson<Level>(_jsonPath + _mountainLevelsBase[levelNum]);
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
                            var gameObject = _mouseMountainCharacters[occupant.objectKey];
                            Instantiate(gameObject, tileTransform);
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