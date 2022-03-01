using Level.ChunkStuff;
using Level.RegionStuff;
using UnityEngine;

namespace Level.WorldStuff
{
    // public class WorldUtils : MonoBehaviour
    // {
    //     private World _world;
    //     private void Start()
    //     {
    //         _world = GetComponent<World>();
    //     }
    //     
    //     public Chunk GetChunk(Vector2 vector)
    //     {
    //         int size = RegionStatics.RegionSizeInChunks;
    //         return _world.Regions[(int) vector.x / size, (int) vector.y / size].Chunks[(int) vector.x % size, (int) vector.y % size];
    //     }
    //     
    //     public Chunk GetChunk(int x, int y)
    //     {
    //         int size = RegionStatics.RegionSizeInChunks;
    //         return _world.Regions[x / size, y / size].Chunks[x % size, y % size];
    //     }
    // }
}