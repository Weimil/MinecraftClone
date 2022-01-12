using Level.ChunkStuff;
using UnityEngine;

namespace Level.RegionStuff
{
    public static class RegionStatics
    {
        public static readonly int RegionSizeInChunks = 32;
        public static readonly int RegionSizeInBlocks = RegionSizeInChunks * ChunkStatics.ChunkWidth;
    }
}