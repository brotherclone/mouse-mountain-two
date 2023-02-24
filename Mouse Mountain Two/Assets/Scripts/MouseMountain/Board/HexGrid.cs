using System;
using System.Collections;
using System.Collections.Generic;
using MouseMountain.Interfaces;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.Serialization;

namespace MouseMountain.Board {
    public class HexGrid : MonoBehaviour
    {
        public int width;
        public int height;
        public HexCell cellPrefab;
        private HexCell[] _hexCells;
        [FormerlySerializedAs("_hexCellLabel")] public TMP_Text hexCellLabel;
        Canvas _hexGridCanvas;
        HexMesh _hexMesh;
        public Color defaultColor = Color.white;
        public Color touchedColor = Color.magenta;

        private void Awake()
        {
            _hexGridCanvas = GetComponentInChildren<Canvas>();
            _hexMesh = GetComponentInChildren<HexMesh>();
        }

        public void CreateGrid(int rows, int columns)
        {
            width = rows;
            height = columns;
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
        public void TouchCell(int index)
        {
            HexCell cell = _hexCells[index];
            cell.color = touchedColor;
            _hexMesh.Triangulate(_hexCells);
        }
        void CreateHexCell(int x, int z, int i)
        {
            TMP_Text hexCellLabel = Instantiate<TMP_Text>(this.hexCellLabel, _hexGridCanvas.transform, false);
            Vector3 position;
            position.x =  (x + z * 0.5f - z / 2) * (HexMetrics.InnerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexMetrics.OuterRadius * 1.5f);
            hexCellLabel.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
            var hexCell = _hexCells[i] = Instantiate<HexCell>(cellPrefab);
            Transform hexCellTransform;
            (hexCellTransform = hexCell.transform).SetParent(transform,false);
            hexCellTransform.localPosition = position;
            hexCell.hexCoordinates = HexCoordinates.FromOffsetCoordinates(x, z);
            hexCellLabel.text = hexCell.hexCoordinates.ToStringOnSeparateLines();
            cellPrefab.color = defaultColor;
        }
    }
}