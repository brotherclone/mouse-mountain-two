using System;
using UnityEngine;
using System.Collections.Generic;
using MouseMountain.Interfaces;

namespace MouseMountain.Board
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class HexMesh : MonoBehaviour
    {
        private Mesh _hexMesh;
        private List<Vector3> _vertices;
        private List<int> _triangles;
        private MeshCollider _meshCollider;
        private List<Color> _colors;

        void Awake()
        {
            GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
            _meshCollider = gameObject.AddComponent<MeshCollider>();
            _hexMesh.name = "HexMesh";
            _vertices = new List<Vector3>();
            _triangles = new List<int>();
            _colors = new List<Color>();
        }

        public void Triangulate(HexCell[] cells)
        {
            _hexMesh.Clear();
            _vertices.Clear();
            _triangles.Clear();
            _colors.Clear();
            foreach (var cell in cells)
            {
                Triangulate(cell);
            }

            _hexMesh.vertices = _vertices.ToArray();
            _hexMesh.triangles = _triangles.ToArray();
            _hexMesh.colors = _colors.ToArray();
            _hexMesh.RecalculateNormals();
            _meshCollider.sharedMesh = _hexMesh;
        }

        void Triangulate(HexCell cell)
        {
            Vector3 center = cell.transform.localPosition;
            for (var i = 0; i < 6; i++)
            {
                AddTriangle(
                    center,
                    center + HexMetrics.corners[i],
                    center + HexMetrics.corners[i + 1]
                );
                AddTriangleColor(cell.color);
            }
        }

        void AddTriangleColor(Color color)
        {
            _colors.Add(color);
            _colors.Add(color);
            _colors.Add(color);
        }

        void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            int vertexIndex = _vertices.Count;
            _vertices.Add(v1);
            _vertices.Add(v2);
            _vertices.Add(v3);
            _triangles.Add(vertexIndex);
            _triangles.Add(vertexIndex + 1);
            _triangles.Add(vertexIndex + 2);
        }
    }
}