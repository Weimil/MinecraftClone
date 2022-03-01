using System;
using System.Collections.Generic;
using Terrain.StaticData.BlockMesh;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.Mathematics.noise;

namespace Terrain
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class RenderBlock : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private float div;
        [SerializeField] private float scale;
        [SerializeField] private int worldWidth;
        [SerializeField] private int worldHeight;
        [SerializeField] private bool noiseToggle;
        /*    (0_0)   */ private int _vertexIndex;
        /*    (0_0)   */ private List<Vector3> _vertices;
        /*    (0_0)   */ private List<int> _triangles;
        /*    (0_0)   */ private List<Vector2> _uvs;
        /*    (0_0)   */ private string[,,] _chunkData;
        
        private void Start()
        {
            Initialize();
            PopulateChunk();
            AddChunkData();
            CreateMesh();
        }

        private void Initialize()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
            _vertices = new List<Vector3>();
            _triangles = new List<int>();
            _uvs = new List<Vector2>();
            _chunkData = new string[worldWidth, worldHeight, worldWidth];
        }

        private void PopulateChunk()
        {
            for (int x = 0; x < _chunkData.GetLength(0); x++)
            {
                for (int y = 0; y < _chunkData.GetLength(1); y++)
                {
                    for (int z = 0; z < _chunkData.GetLength(2); z++)
                    {
                        if (noiseToggle)
                        {                                                                   
                            float newX = x / div;                                           
                            float newY = y / div;                                           
                            float newZ = z / div;                                           
                            if (snoise(new float3(newX, newY, newZ)) >   scale)                                      
                                _chunkData[x, y, z] = "stone";                                                       
                            else                                                                                     
                                _chunkData[x, y, z] = "air";                                                 
                        }                                                                                    
                        else                                                                                 
                        {                                                                                    
                            _chunkData[x, y, z] = "stone";                                                   
                        }                                                                                    
                    }                                                                                        
                }                                                                                            
            }                                                                                                
        }                                                                                                    
                                                                                                             
        private void RenderBlockow(int x, int y, int z)
        {
            if (_chunkData[x, y, z] == "stone")
            {
                for (int faceIndex = 0; faceIndex < 6; faceIndex++)
                {
                    if (!IsPintable(x, y, z, faceIndex))
                    {
                        // In the final version here will be called a method
                        // inside the type of block (fullBlock / slab / stair)

                        for (int vertexIndex = 0; vertexIndex < 6; vertexIndex++)
                        {
                            int triangleIndex = BlockMesh.BlockTriangles[faceIndex, vertexIndex];
                            _vertices.Add(BlockMesh.BlockVerts[triangleIndex] + new Vector3(x,y,z));
                            _triangles.Add(_vertexIndex);
                    
                            _uvs.Add(BlockMesh.BlockUvs[vertexIndex]);

                            _vertexIndex++;
                        }
                    }
                }
            }
        }

        private bool IsPintable(int x, int y, int z, int faceIndex)
        {
            int checkX = x + (int) BlockMesh.FaceCheck[faceIndex].x;
            int checkY = y + (int) BlockMesh.FaceCheck[faceIndex].y;
            int checkZ = z + (int) BlockMesh.FaceCheck[faceIndex].z;

            if (checkX >= 0 && checkX < worldWidth &&
                checkY >= 0 && checkY < worldHeight &&
                checkZ >= 0 && checkZ < worldWidth)
            {
                if (_chunkData[checkX, checkY, checkZ] == "air")
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        private void AddChunkData()
        {
            for (int y = 0; y < worldHeight; y++)
            {
                for (int z = 0; z < worldWidth; z++)
                {
                    for (int x = 0; x < worldWidth; x++)
                    {
                        RenderBlockow(x,y,z);
                    }
                }
            }
        }
        
        private void CreateMesh()
        {
            Mesh mesh = new Mesh();
            mesh.indexFormat = IndexFormat.UInt32;
            
            mesh.vertices = _vertices.ToArray();
            mesh.triangles = _triangles.ToArray();
            mesh.uv = _uvs.ToArray();
            
            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;
        }
    }
}