using Level.ChunkStuff;
using UnityEngine;
using Utils;

namespace Level.RegionStuff
{
    public class Region : MonoBehaviour
    {
        private Chunk _chunkPrefab;
        public Chunk[,] Chunks { get; set; }
        private Vector3 _position;
        private Vector2 _id;

        public void Init(Vector2 id, Chunk chunkPrefab)
        {
            _id = id;
            _position = transform.position;
            _chunkPrefab = chunkPrefab;
            
            // 15 - 5M
            // 14 - 4M
            // 13 - 3M
            // 12 - 1M
            // 11 - 500K
            
            Chunks = new Chunk[RegionStatics.RegionSizeInChunks, RegionStatics.RegionSizeInChunks];

            for (int x = 0; x < Chunks.GetLength(0); x++)
            for (int z = 0; z < Chunks.GetLength(1); z++)
            {
                Chunk chunk = Instantiate(
                    _chunkPrefab,
                    MathW.ChunkSpawnCords(x, z, _position - Vector3.one * ChunkStatics.ChunkWidth/2, ChunkStatics.ChunkWidth),
                    Quaternion.identity,
                    gameObject.transform
                );
                Vector2 chunkCoords = MathW.ChunkCoords(_id, new Vector2(x,z));
                chunk.name = $"Chunk[{(int) chunkCoords.x}|{(int) chunkCoords.y}]";
                
                chunk.GetComponent<Chunk>().Init(100.5f, chunkCoords);
                //Debug.Log("C|" + x + "|" + z + "|");
                Chunks[x, z] = chunk;
            }
        }
    }
}