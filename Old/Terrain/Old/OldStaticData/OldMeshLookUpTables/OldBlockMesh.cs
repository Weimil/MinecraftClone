using UnityEngine;

namespace Terrain.StaticData.BlockMesh
{
    public static class BlockMesh
    {
        public static readonly Vector3[] BlockVerts = new Vector3[8]
        {
            new Vector3(0, 0, 0), // 0
            new Vector3(1, 0, 0), // 1
            new Vector3(1, 1, 0), // 2
            new Vector3(0, 1, 0), // 3
            new Vector3(0, 0, 1), // 4
            new Vector3(1, 0, 1), // 5
            new Vector3(1, 1, 1), // 6
            new Vector3(0, 1, 1)  // 7
        };
        
        public static readonly int[,] BlockTriangles = new int[6,6] 
        {
            {0, 3, 1, 1, 3, 2}, 
            {5, 6, 4, 4, 6, 7}, 
            {3, 7, 2, 2, 7, 6}, 
            {1, 5, 0, 0, 5, 4}, 
            {4, 7, 0, 0, 7, 3}, 
            {1, 2, 5, 5, 2, 6}
        };
        
        public static readonly Vector2[] BlockUvs = new Vector2[6] 
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        
        public static readonly Vector3[] FaceCheck = new Vector3[6]
        {
            new Vector3(0, 0, -1),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0)
        };
    }
}