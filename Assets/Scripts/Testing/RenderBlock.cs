using System.Collections.Generic;
using Level.BlockStuff;
using Level.BlockStuff.MeshStuff;
using Level.ChunkStuff;
using Player;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.Mathematics.noise;

namespace Testing
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class RenderBlock : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private bool noiseToggle;
        [SerializeField] private float div;
        [SerializeField] private float scale;
        /*    (0_0)   */ private List<Vector3> _vertex;
        /*    (0_0)   */ private List<int> _triangles;
        /*    (0_0)   */ private List<Vector2> _uvs;
        /*    (0_0)   */ private Block[,,] _blocks;

        private void Start()
        {
            InitVariables();
            PopulateChunk();
            RenderChunk();
            CreateMesh();
        }

        private void InitVariables()
        {
            _blocks = new Block[ChunkStatics.ChunkWidth, ChunkStatics.ChunkWidth, ChunkStatics.ChunkWidth];
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
            _vertex = new List<Vector3>();
            _triangles = new List<int>();
            _uvs = new List<Vector2>();
        }
        private void PopulateChunk()
        {
            for (int x = 0; x < _blocks.GetLength(0); x++)
            {
                for (int y = 0; y < _blocks.GetLength(1); y++)
                {
                    for (int z = 0; z < _blocks.GetLength(2); z++)
                    {
                        if (noiseToggle)
                        {                                                                   
                            float newX = x / div;                                           
                            float newY = y / div;                                           
                            float newZ = z / div;                                           
                            if (snoise(new float3(newX, newY, newZ)) > scale)                                      
                                _blocks[x, y, z] = new BlockDefinition().Stone;                                                      
                            else                                                                                     
                                _blocks[x, y, z] = new BlockDefinition().Air;                                              
                        }                                                                                    
                        else                                                                                 
                        {                                                                                    
                            _blocks[x, y, z] = new BlockDefinition().Stone;                                                   
                        }  
                    }
                }
            }
        }
        private void RenderChunk()
        {
            for (int x = 0; x < _blocks.GetLength(0); x++)
            {
                for (int y = 0; y < _blocks.GetLength(1); y++)
                {
                    for (int z = 0; z < _blocks.GetLength(2); z++)
                    {
                        if (_blocks[x, y, z].Name == "Stone")
                        {
                            CosoDeRenderBlock(x, y, z);
                        }  
                    }
                }
            }

        }
        private void CosoDeRenderBlock(int x, int y, int z)
        {
            for (int i = 0; i < 6; i++)
            {
                if (IsPintable(x, y, z, i))
                {
                    _triangles.AddRange(_blocks[x, y, z].MeshType.GetTriangleListFromFace(i, _vertex.Count));
                    _vertex.AddRange(_blocks[x, y, z].MeshType.GetVertexListFromFace(i, new Vector3(x, y, z)));
                    _uvs.AddRange(_blocks[x, y, z].MeshType.GetUVsListFromFace(i, _blocks[x, y, z].TextureMapIndex));
                }
                /*
                int checkX = x + (int) MeshStatics.FaceCheck[i].x;
                int checkY = y + (int) MeshStatics.FaceCheck[i].y;
                int checkZ = z + (int) MeshStatics.FaceCheck[i].z;
                if (BlockUtils.IsValidPosition(checkX, checkY, checkZ))
                {
                    if (BlockUtils.ShouldRenderFace(_blocks[checkX, checkY, checkZ]))
                    {
                    
                    }
                }
                */
            }
        }

        private bool IsPintable(int x, int y, int z, int faceIndex)
        {
            int checkX = x + (int) MeshStatics.FaceCheck[faceIndex].x;
            int checkY = y + (int) MeshStatics.FaceCheck[faceIndex].y;
            int checkZ = z + (int) MeshStatics.FaceCheck[faceIndex].z;

            if (checkX >= 0 && checkX < ChunkStatics.ChunkWidth &&
                checkY >= 0 && checkY < ChunkStatics.ChunkWidth &&
                checkZ >= 0 && checkZ < ChunkStatics.ChunkWidth)
            {
                if (_blocks[checkX, checkY, checkZ].Name == "Air")
                {
                    return true;
                }
                return false;
            }

            return true;
        }
        
        private void CreateMesh()
        {
            Mesh mesh = new Mesh
            {
                indexFormat = IndexFormat.UInt32,
                vertices = _vertex.ToArray(),
                triangles = _triangles.ToArray(),
                uv = _uvs.ToArray()
            };

            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;
        }
    }
}