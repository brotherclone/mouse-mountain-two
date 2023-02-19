using MouseMountain.Board;
using UnityEngine;

namespace MouseMountain.Interfaces
{
    public interface IMouseable
    {
        void Hover(GameObject gameObject)
        {
            Debug.Log("Mouse Over "+gameObject);
        }

        void Hover(HexCell hexCell)
        {
            Debug.Log("Mouse Over "+ hexCell._HexCoordinates);
        }

        void Click(GameObject gameObject)
        {
            Debug.Log("Mouse Click "+gameObject);
        }
        
    }
}