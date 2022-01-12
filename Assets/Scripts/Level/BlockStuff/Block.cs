using Level.BlockStuff.MaterialStuff;
using Level.BlockStuff.MeshStuff;

namespace Level.BlockStuff
{
    public class Block
    {
        private string _name;
        private MeshType _meshType;
        private Material _material;
        private int _textureMapIndex;
        
        public Block(string name, MeshType meshType, Material material, int textureMapIndex)
        {
            _name = name;
            _meshType = meshType;
            _material = material;
            _textureMapIndex = textureMapIndex;
        }
        
        public string Name
        {
            get { return _name; }
        }
        public MeshType MeshType
        {
            get { return _meshType; } 
        }
        public Material Material
        {
            get { return _material; } 
        }
        public int TextureMapIndex
        {
            get { return _textureMapIndex; }
        }
    }
}