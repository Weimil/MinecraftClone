using System;
using System.Collections.Generic;
using Level.ChunkStuff;
using Level.RegionStuff;
using UnityEngine;
using Utils;
using Random = System.Random;

namespace Level.WorldStuff
{
    public class World : MonoBehaviour
    {
        public static int Seed;
        public static Random Random;
        public Chunk _chunkPrefab;
        public Region _regionPrefab;
        [SerializeField] private int manualSeed;
        private Dictionary<Vector2, Region> RegionDictionary { get; set; }
        private Region[,] Regions { get; set; }

        private void Start()
        {
            Init();
            StartGen();
            StartRendering();
        }

        private void Init()
        {
            Seed = manualSeed;
            Random = new Random(Seed);
            Regions = new Region[2,2];
        }

        private void StartGen()
        {
            for (int x = 0; x < Regions.GetLength(0); x++)
            for (int z = 0; z < Regions.GetLength(1); z++)
            {
                Region region = Instantiate(
                    _regionPrefab,
                    MathW.RegionSpawnCords(x, z, RegionStatics.RegionSizeInBlocks),
                    Quaternion.identity,
                    gameObject.transform
                );
                int nX = MathW.RegionCoord(x);
                int nZ = MathW.RegionCoord(z);
                region.name = $"Region[{nX}|{nZ}]";
                region.GetComponent<Region>().Init(new Vector2(x, z), _chunkPrefab);
                //Debug.Log("R|" + x + "|" + z + "|");
                Regions[x, z] = region;
            }
        }

        private void StartRendering()
        {
            foreach (Region region in Regions)
            foreach (Chunk chunk in region.Chunks)
                chunk.Render();
        }
        
        public Chunk GetChunk(int x, int y)
        {
            Debug.LogError("X: " + x + " Y: " + y);
            int size = RegionStatics.RegionSizeInChunks;
            int numRegions = size * Regions.GetLength(0);

            int checkX = Math.Abs(x);
            int checkY = Math.Abs(x);
            
            if (checkX < numRegions &&
                checkY < numRegions)
                return Regions[checkX / size, checkY / size].Chunks[checkX % size, checkY % size];
            return null;
        }
    }
}