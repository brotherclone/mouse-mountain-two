using UnityEngine;
using UnityEngine.Serialization;

namespace MouseMountain.Board
{
    public class HexCell : MonoBehaviour
    {
        public HexCoordinates hexCoordinates;
        public Color color;
        public int x;
        public int z;
        public int id;
    }
}