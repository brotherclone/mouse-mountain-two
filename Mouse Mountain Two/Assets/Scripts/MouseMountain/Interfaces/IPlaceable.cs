using MouseMountain.Board;
using UnityEngine;

namespace MouseMountain.Interfaces
{
    public interface IPlaceable
    {
        void Place(HexCell hexCell)
        {
            Debug.Log("Place on hex cell");
        }

        void Place(int hexId)
        {
            Debug.Log("placed on hex with id");
        }

        void Place(Vector3 vector3)
        {
            Debug.Log("placed with vector 3");
        }
        
    }
}