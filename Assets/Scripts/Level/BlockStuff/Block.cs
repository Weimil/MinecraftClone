using Level.BlockStuff.MaterialStuff;
using Level.BlockStuff.MeshStuff;

namespace Level.BlockStuff
{
    public class Block
    {
        public Block(string name, MeshType meshType, Material material, int textureMapIndex)
        {
            Name = name;
            MeshType = meshType;
            Material = material;
            TextureMapIndex = textureMapIndex;
        }

        private string Name 
        {
            get;
        }

        public MeshType MeshType 
        {
            get;
        }

        public Material Material 
        {
            get;
        }

        public int TextureMapIndex 
        {
            get;
        }
    }
}