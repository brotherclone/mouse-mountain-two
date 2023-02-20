using System;
using System.Collections;
using System.Collections.Generic;
using MouseMountain.Things;
using UnityEngine;
using UnityEngine.UIElements;
using MouseMountain.Board;

namespace MouseMountain
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public Camera currentCamera;
        public BaseObject selectedObject;
        public BaseObject inspectedObject;
        public GameObject clickedObject;
        public InputManager inputManager;
        public HexGrid hexGrid;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void Start()
        {
            inputManager = GetComponentInChildren<InputManager>();
            hexGrid = GetComponentInChildren<HexGrid>();
        }

        public void HandleHexClick(int index)
        {
            hexGrid.TouchCell(index);
        }
    }
}