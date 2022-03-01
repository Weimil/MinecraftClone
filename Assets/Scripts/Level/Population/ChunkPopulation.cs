using Level.BlockStuff;
using Level.WorldStuff;

namespace Level.Population
{
    public static class ChunkPopulation
    {
        public static Block[,,] FillWithAir(Block[,,] blocks)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            for (int y = 0; y < blocks.GetLength(1); y++)
                blocks[x, y, z] ??= new BlockDefinition().Air;
            return blocks;
        }

        public static Block[,,] BedrockLayer(Block[,,] blocks)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int y = 0; y < 5; y++)
            for (int z = 0; z < blocks.GetLength(2); z++)
                if (World.Random.NextDouble() > (float) y / 5)
                    blocks[x, y, z] = new BlockDefinition().Bedrock;
                else
                    blocks[x, y, z] = new BlockDefinition().Stone;

            return blocks;
        }

        public static Block[,,] StoneLayer(Block[,,] blocks, int[,] heightMap)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            for (int y = 0; y < heightMap[x, z]; y++)
                blocks[x, y, z] ??= new BlockDefinition().Stone;
            return blocks;
        }

        public static Block[,,] DirtGrassLayer(Block[,,] blocks, int[,] heightMap)
        {
            // TMP, just for testing
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            {
                blocks[x, heightMap[x, z], z] = new BlockDefinition().Grass;
                blocks[x, heightMap[x, z] - 1, z] = new BlockDefinition().Dirt;
                blocks[x, heightMap[x, z] - 2, z] = new BlockDefinition().Dirt;
                blocks[x, heightMap[x, z] - 3, z] = new BlockDefinition().Dirt;
            }

            return blocks;
        }
    }
}