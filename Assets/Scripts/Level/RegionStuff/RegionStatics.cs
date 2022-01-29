using Level.ChunkStuff;

namespace Level.RegionStuff
{
    public static class RegionStatics
    {
        public static readonly int RegionSizeInChunks = 4;
        public static readonly int RegionSizeInBlocks = RegionSizeInChunks * ChunkStatics.ChunkWidth;
    }
}