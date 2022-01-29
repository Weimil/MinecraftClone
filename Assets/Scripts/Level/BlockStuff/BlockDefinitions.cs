using Level.BlockStuff.MaterialStuff;
using Level.BlockStuff.MeshStuff;

namespace Level.BlockStuff
{
    public class BlockDefinition
    {
        public Block Air = new Block("Air", null, null, 1); // 1
        public Block Bedrock = new Block("Bedrock", MeshDefinitions.FullBlock, MaterialDefinitions.Bedrock, 2); // 2
        public Block Dirt = new Block("Dirt", MeshDefinitions.FullBlock, MaterialDefinitions.Dirt, 4); // 4
        public Block Grass = new Block("Grass", MeshDefinitions.FullBlock, MaterialDefinitions.Dirt, 5); // 5
        public Block Stone = new Block("Stone", MeshDefinitions.FullBlock, MaterialDefinitions.Stone, 3); // 3
    }
}