using World.Level.BlockStuff.Mesh;

namespace World.Level.BlockStuff
{
    public class Blocks
    {
        public readonly Block Air = new Block("air", new FullBlockMesh());
        public readonly Block Stone = new Block("stone", new FullBlockMesh());
    }
}