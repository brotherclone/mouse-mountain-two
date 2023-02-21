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
        public LevelManager levelManager;
        public BaseObject selectedObject;
        public BaseObject inspectedObject;
        public GameObject clickedObject;
        public InputManager inputManager;
        public HexGrid hexGrid;
        public CameraManager cameraManager;
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

        void Start()
        {
            levelManager = GetComponentInChildren<LevelManager>();
            inputManager = GetComponentInChildren<InputManager>();
            hexGrid = GetComponentInChildren<HexGrid>();
            cameraManager = GetComponentInChildren<CameraManager>();
        }
        
        public void HandleHexClick(int index)
        {
            hexGrid.TouchCell(index);
        }
    }
}