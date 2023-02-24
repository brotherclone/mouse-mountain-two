using System;
using System.Collections;
using System.Collections.Generic;
using MouseMountain.Things;
using MouseMountain.Board;
using UnityEngine;

namespace MouseMountain
{
    public class InputManager: MonoBehaviour
    {
        enum ClickType
        {
         MmObject,
         GmObject,
         HexCell,
         UIElement,
         None,
         Unknown
        }

        private GameObject _clickedGameObject;
        private BaseObject _clickedBaseObject;
        private int _clickedHexIndex;
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var leftClick = HandleClick();
                switch (leftClick)
                {
                    case ClickType.MmObject:
                        GameManager.Instance.selectedObject = _clickedBaseObject;
                        GameManager.Instance.cameraManager.currentCameraMode =
                            CameraManager.CameraMode.FollowingSelected;
                        break;
                    case ClickType.GmObject:
                        GameManager.Instance.clickedObject = _clickedGameObject;
                        break;
                    case ClickType.HexCell:
                        GameManager.Instance.HandleHexClick(_clickedHexIndex);
                        break;
                    default:
                        Debug.Log("unknown left click");
                        break;
                }
            }
            if (Input.GetMouseButton(1))
            {
                var rightClick = HandleClick();
                switch (rightClick)
                {
                    case ClickType.MmObject:
                        GameManager.Instance.inspectedObject = _clickedBaseObject;
                        break;
                    default:
                        Debug.Log("unknown right click");
                        break;
                }
            } 
        }
        private ClickType HandleClick()
        {
            var ray = GameManager.Instance.cameraManager.currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var point = hit.point;
                var gmObj = hit.collider.gameObject;
                var mmObj = hit.collider.GetComponent<BaseObject>();
                if (mmObj != null)
                {
                    _clickedBaseObject = mmObj;
                    return ClickType.MmObject;
                }
                if (gmObj != null && gmObj.name != "HexMesh")
                {
                    _clickedGameObject = gmObj;
                    return ClickType.GmObject;
                }
                // ToDo : check type too
                point = transform.InverseTransformDirection(point);
                HexCoordinates coordinates = HexCoordinates.FromPosition(point);
                Debug.Log("coords"+coordinates);
                _clickedHexIndex = coordinates.X + coordinates.Z * GameManager.Instance.hexGrid.width + coordinates.Z / 2;
                if (_clickedHexIndex  >= 0)
                {
                    return ClickType.HexCell;
                }
            }
            return ClickType.Unknown;
        }
    }
}