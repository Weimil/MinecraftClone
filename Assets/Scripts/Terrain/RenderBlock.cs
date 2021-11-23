using System;
using System.Collections.Generic;
using Terrain.StaticData.BlockMesh;
using UnityEngine;

namespace Terrain
{
    public class RenderBlock : MonoBehaviour
    {
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;
        private void Start()
        {
            int verticesIndex = 0;
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int triangleIndex = BlockMesh.BlockTriangles[i,j];
                    vertices.Add(BlockMesh.BlockVerts[triangleIndex]);
                    triangles.Add(verticesIndex);

                    verticesIndex++;
                }
            }

            Mesh mesh = new Mesh();
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            
            mesh.RecalculateNormals();
            
        }
    }
}