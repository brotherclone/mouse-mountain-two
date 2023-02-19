using System;
using System.Collections;
using System.Collections.Generic;
using MouseMountain.Interfaces;
using UnityEngine;
using Unity.UI;
using TMPro;

namespace MouseMountain.Board {
    public class HexGrid : MonoBehaviour, IMouseable
    {
        public int width = 6;
        public int height = 6;
        public HexCell cellPrefab;
        private HexCell[] _hexCells;
        public TMP_Text _hexCellLabel;
        Canvas _hexGridCanvas;
        HexMesh _hexMesh;
        public Color defaultColor = Color.white;
        public Color touchedColor = Color.magenta;
        
        private void Awake()
        {
            _hexGridCanvas = GetComponentInChildren<Canvas>();
            _hexMesh = GetComponentInChildren<HexMesh>();
            _hexCells = new HexCell[height * width];
            for (int z=0, i=0; z<height; z++)
            {
                for (var x = 0; x < width; x++)
                {
                    CreateHexCell(x,z, i++);
                }
            }
        }
        
        private void Start()
        {
            _hexMesh.Triangulate(_hexCells);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                HandleInput();
            }
        }

        void HandleInput()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit))
            {
                TouchCell(hit.point);
            }
        }

        void TouchCell(Vector3 position)
        {
            position = transform.InverseTransformDirection(position);
            HexCoordinates coordinates = HexCoordinates.FromPosition(position);
            //Debug.Log("tocuhed"+position + coordinates.ToString());
            int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
            HexCell cell = _hexCells[index];
            Click(cell);
            cell.color = touchedColor;
            _hexMesh.Triangulate(_hexCells);
        }

        private void Click(HexCell hexCell)
        {
            //Debug.Log("impl" + hexCell._HexCoordinates);
        }
        
        void CreateHexCell(int x, int z, int i)
        {
            TMP_Text hexCellLabel = Instantiate<TMP_Text>(_hexCellLabel);
            hexCellLabel.rectTransform.SetParent(_hexGridCanvas.transform, false);
            Vector3 position;
            position.x =  (x + z * 0.5f - z / 2) * (HexMetrics.InnerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexMetrics.OuterRadius * 1.5f);
            hexCellLabel.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
            var hexCell = _hexCells[i] = Instantiate<HexCell>(cellPrefab);
            hexCell.transform.SetParent(transform,false);
            hexCell.transform.localPosition = position;
            hexCell._HexCoordinates = HexCoordinates.FromOffsetCoordinates(x, z);
            hexCellLabel.text = hexCell._HexCoordinates.ToStringOnSeparateLines();
            cellPrefab.color = defaultColor;
        }
    }
}