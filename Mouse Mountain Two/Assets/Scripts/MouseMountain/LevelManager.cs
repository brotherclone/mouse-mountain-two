using System.Collections.Generic;
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
        public Level testLevel;
        // Need some dictionary of keys to levels
        // Need some dictionary of keys to objects
        // Find that level
        // Load the grid
        // Place the objects
        // Be able to delete the objects
        // Be able to delete the grid

        private void Start()
        {
            var test = JsonUtils.ImportJson<Level>("JSON/Levels/level_proto_0");
            Debug.Log(test.skybox);
            Debug.Log(test.tiles[0].row[0].color);
            Debug.Log(test.tiles[0].row[0].occupants[0].objectKey);
        }
    }
}