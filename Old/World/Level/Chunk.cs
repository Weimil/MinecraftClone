using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using World.Level.BlockStuff;
using World.Level.BlockStuff.Mesh;
using static Unity.Mathematics.noise;

namespace World.Level
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class Chunk : MonoBehaviour
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
        /*    (0_0)   */ private Block[,,] _chunkData;
        
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
            _chunkData = new Block[worldWidth, worldHeight, worldWidth];
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
                            if (snoise(new float3(newX, newY, newZ)) > scale)                                      
                                _chunkData[x, y, z] = new Blocks().Stone;                                                       
                            else                                                                                     
                                _chunkData[x, y, z] = new Blocks().Air;                                                 
                        }                                                                                    
                        else                                                                                 
                        {                                                                                    
                            _chunkData[x, y, z] = new Blocks().Stone;                                                   
                        }                                                                                    
                    }                                                                                        
                }                                                                                            
            }                                                                                                
        }                                                                                                    
                                                                                                             
        private void RenderBlockow(int x, int y, int z)
        {
            if (_chunkData[x, y, z].Name == "stone")
            {
                for (int faceIndex = 0; faceIndex < 6; faceIndex++)
                {
                    if (!IsPintable(x, y, z, faceIndex))
                    {
                        // In the final version here will be called a method
                        // inside the type of block (fullBlock / slab / stair)

                        
                        for (int i = 0; i < 6; i++)
                        {
                            int triangleIndex = FullBlockMesh.BlockTriangles[faceIndex, i];
                            _vertices.Add(FullBlockMesh.BlockVertx[triangleIndex] + new Vector3(x,y,z));
                            _triangles.Add(_vertexIndex);
                    
                            _uvs.Add(FullBlockMesh.BlockUvs[i]);

                            _vertexIndex++;
                        }
                        
                        
                        _vertices.Add(_chunkData[x, y, z].BlockMesh.BlockVertx[]);
                        
                    }
                }
            }
        }

        private bool IsPintable(int x, int y, int z, int faceIndex)
        {
            int checkX = x + (int) FullBlockMesh.FaceCheck[faceIndex].x;
            int checkY = y + (int) FullBlockMesh.FaceCheck[faceIndex].y;
            int checkZ = z + (int) FullBlockMesh.FaceCheck[faceIndex].z;

            if (checkX >= 0 && checkX < worldWidth &&
                checkY >= 0 && checkY < worldHeight &&
                checkZ >= 0 && checkZ < worldWidth)
            {
                if (_chunkData[checkX, checkY, checkZ].Name == "air")
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