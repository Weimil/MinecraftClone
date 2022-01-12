namespace Level.BlockStuff.MaterialStuff
{
    public class Material
    {
        private string _name;
        private string _tool; // private Tool _tool
        private int _resistance;

        public Material(string name, string tool, int resistance)
        {
            _name = name;
            _tool = tool;
            _resistance = resistance;
        }
    }
}