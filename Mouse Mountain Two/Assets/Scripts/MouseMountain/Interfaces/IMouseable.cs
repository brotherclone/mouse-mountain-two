using MouseMountain.Board;
using MouseMountain.Things;
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
            Debug.Log("Mouse Over "+ hexCell.hexCoordinates);
        }
        void Click(GameObject gameObject)
        {
            Debug.Log("Mouse Click "+gameObject);
        }
        void Click(BaseObject baseObject)
        {
            Debug.Log("Mouse Click's base object "+baseObject);
        }
        void Click(Vector3 position){
            Debug.Log("Mouse Click's position for tile " + position);
        }
    }
}