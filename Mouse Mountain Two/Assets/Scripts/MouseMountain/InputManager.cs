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
         MMObject,
         GMObject,
         HexCell,
         UIElement,
         None,
         Unknown
        }

        private GameObject clickedGameObject;
        private BaseObject clickedBaseObject;
        private int clickedHexIndex;
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var leftClick = HandleClick();
                switch (leftClick)
                {
                    case ClickType.MMObject:
                        GameManager.Instance.selectedObject = clickedBaseObject;
                        GameManager.Instance.cameraManager.currentCameraMode =
                            CameraManager.CameraMode.FollowingSelected;
                        break;
                    case ClickType.GMObject:
                        GameManager.Instance.clickedObject = clickedGameObject;
                        break;
                    case ClickType.HexCell:
                        GameManager.Instance.HandleHexClick(clickedHexIndex);
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
                    case ClickType.MMObject:
                        GameManager.Instance.inspectedObject = clickedBaseObject;
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
                    clickedBaseObject = mmObj;
                    return ClickType.MMObject;
                }
                if (gmObj != null && gmObj.name != "HexMesh")
                {
                    clickedGameObject = gmObj;
                    return ClickType.GMObject;
                }
                // ToDo : check type too
                point = transform.InverseTransformDirection(point);
                HexCoordinates coordinates = HexCoordinates.FromPosition(point);
                Debug.Log("coords"+coordinates);
                clickedHexIndex = coordinates.X + coordinates.Z * GameManager.Instance.hexGrid.width + coordinates.Z / 2;
                if (clickedHexIndex  >= 0)
                {
                    return ClickType.HexCell;
                }
            }
            return ClickType.Unknown;
        }
    }
}