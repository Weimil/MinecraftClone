using System;
using System.Collections.Generic;
using Level.BlockStuff;
using Level.BlockStuff.MeshStuff;
using Level.Population;
using Level.RegionStuff;
using Level.WorldStuff;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.Mathematics.noise;

namespace Level.ChunkStuff
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(MeshFilter))]
    public class Chunk : MonoBehaviour
    {
        private Block[,,] Blocks { get; set; }
        private int[,] _heightMap;
        private MeshCollider _meshCollider;
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private Vector3 _position;
        private float _scale;
        private List<int> _triangles;
        private List<Vector2> _uvs;
        private List<Vector3> _vertex;
        private Vector2 _coord;

        public void Init(float scale, Vector2 chunkCoord)
        {
            Blocks = new Block[ChunkStatics.ChunkWidth, ChunkStatics.ChunkHeight, ChunkStatics.ChunkWidth];
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshFilter = GetComponent<MeshFilter>();
            _meshCollider = GetComponent<MeshCollider>();
            _vertex = new List<Vector3>();
            _triangles = new List<int>();
            _uvs = new List<Vector2>();
            
            _position = transform.position;
            _scale = scale;
            _coord = chunkCoord;

            Populate();
        }

        private void Populate()
        {
            CreateHeightMap();
            PopulateChunk();
        }

        public void Render()
        {
            RenderChunk();
            CreateMesh();
        }
        
        private void CreateHeightMap()
        {
            _heightMap = new int[ChunkStatics.ChunkWidth, ChunkStatics.ChunkWidth];

            for (int x = 0; x < _heightMap.GetLength(0); x++)
            for (int z = 0; z < _heightMap.GetLength(1); z++)
            {
                float totalDivisions = 0;
                float noiseValue = 0;
                float multiplier = 1;
                float divider = 1;

                float newX = (x + _position.x + 0.0001f) / _scale;
                float newZ = (z + _position.z + 0.0001f) / _scale;

                for (int i = 0; i < 4; i++)
                {
                    noiseValue += divider * snoise(new float3(newX * multiplier, World.Seed, newZ * multiplier));
                    totalDivisions += divider;
                    multiplier *= 2;
                    divider /= 2;
                }

                noiseValue = (float) Math.Pow(noiseValue, 2);
                
                _heightMap[x, z] = (int) (noiseValue / totalDivisions * 32 + 40);
            }
        }

        private void PopulateChunk()
        {
            //_blocks = ChunkPopulation.FillWithAir(_blocks);
            Blocks = ChunkPopulation.BedrockLayer(Blocks);
            Blocks = ChunkPopulation.StoneLayer(Blocks, _heightMap);
            Blocks = ChunkPopulation.DirtGrassLayer(Blocks, _heightMap);
            /*
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
            */
        }

        private void RenderChunk()
        {
            for (int x = 0; x < Blocks.GetLength(0); x++)
            for (int y = 0; y < Blocks.GetLength(1); y++)
            for (int z = 0; z < Blocks.GetLength(2); z++)
                if (Blocks[x, y, z] != null)
                    RenderBlock(x, y, z);
        }

        private void RenderBlock(int x, int y, int z)
        {
            for (int i = 0; i < 6; i++)
                if (IsVisible(x, y, z, i))
                {
                    _triangles.AddRange(Blocks[x, y, z].MeshType.GetTriangleListFromFace(i, _vertex.Count));
                    _vertex.AddRange(Blocks[x, y, z].MeshType.GetVertexListFromFace(i, new Vector3(x, y, z)));
                    _uvs.AddRange(Blocks[x, y, z].MeshType.GetUVsListFromFace(i, Blocks[x, y, z].TextureMapIndex));
                }
        }

        // private bool IsVisible3(int x, int y, int z, int faceIndex)
        // {
        //     int checkX = x + (int) MeshStatics.FaceCheck[faceIndex].x;
        //     int checkY = y + (int) MeshStatics.FaceCheck[faceIndex].y;
        //     int checkZ = z + (int) MeshStatics.FaceCheck[faceIndex].z;
        //
        //     if (checkX >= 0 && checkX < ChunkStatics.ChunkWidth &&
        //         checkY >= 0 && checkY < ChunkStatics.ChunkHeight &&
        //         checkZ >= 0 && checkZ < ChunkStatics.ChunkWidth)
        //         return Blocks[checkX, checkY, checkZ] == null;
        //     return false;
        // }

        private bool IsVisible(int x, int y, int z, int faceIndex)
        {
            int checkX = x + (int) MeshStatics.FaceCheck[faceIndex].x;
            int checkY = y + (int) MeshStatics.FaceCheck[faceIndex].y;
            int checkZ = z + (int) MeshStatics.FaceCheck[faceIndex].z;

            if (checkX >= 0 && checkX < ChunkStatics.ChunkWidth  &&
                checkY >= 0 && checkY < ChunkStatics.ChunkHeight &&
                checkZ >= 0 && checkZ < ChunkStatics.ChunkWidth
            )
                return Blocks[checkX, checkY, checkZ] == null;
            return true;
            World world = GetComponentInParent<Region>().GetComponentInParent<World>(); 
            
            if (checkX < 0)
                return world.GetChunk((int) _coord.x - 1, (int) _coord.y).Blocks[15, y, z] == null;
            if (checkX > ChunkStatics.ChunkWidth)
                return world.GetChunk((int) _coord.x + 1, (int) _coord.y).Blocks[15, y, z] == null;
            if (checkY < 0)
                return world.GetChunk((int) _coord.x, (int) _coord.y - 1).Blocks[15, y, z] == null;
            if (checkY > ChunkStatics.ChunkWidth)
                return world.GetChunk((int) _coord.x, (int) _coord.y + 1).Blocks[15, y, z] == null;

            return false;
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

            mesh.Optimize();
            mesh.RecalculateNormals();

            _meshFilter.mesh = mesh;
            _meshCollider.sharedMesh = mesh;
        }
    }
}