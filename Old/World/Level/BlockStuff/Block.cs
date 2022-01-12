using World.Level.BlockStuff.Mesh;

namespace World.Level.BlockStuff
{
    public class Block
    {
        private string _name;
        private FullBlockMesh _fullBlockMesh;

        public Block(string name, FullBlockMesh fullBlockMesh)
        {
            _name = name;
            _fullBlockMesh = fullBlockMesh;
        }


        public string Name
        {
            get { return _name; } 
            set { _name = value; }
        }
        
        public FullBlockMesh BlockMesh
        {
            get { return _fullBlockMesh; } 
        }
    }
}