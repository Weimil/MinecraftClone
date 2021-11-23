using UnityEngine;

namespace Terrain.StaticData.BlockMesh
{
    public static class BlockMesh
    {
        public static readonly Vector3[] BlockVerts = new Vector3[8]
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(1.0f, 0.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(0.0f, 1.0f, 1.0f)
        };
        
        public static readonly Vector3[] FaceChecks = new Vector3[6] 
        {
             new Vector3(00.0f, 00.0f, -1.0f),
            new Vector3(00.0f, 00.0f, 01.0f),
            new Vector3(00.0f, 01.0f, 00.0f),
            new Vector3(00.0f, -1.0f, 00.0f),
            new Vector3(-1.0f, 00.0f, 00.0f),
            new Vector3(01.0f, 00.0f, 00.0f)
        };
        
        public static readonly int[,] BlockTriangles = new int[6,4] 
        {
            {0, 3, 1, 2}, 
            {5, 6, 4, 7}, 
            {3, 7, 2, 6}, 
            {1, 5, 0, 4}, 
            {4, 7, 0, 3}, 
            {1, 2, 5, 6}
        };

        public static readonly Vector2[] BlockUvs = new Vector2[4] 
        {
            new Vector2 (0.0f, 0.0f),
            new Vector2 (0.0f, 1.0f),
            new Vector2 (1.0f, 0.0f),
            new Vector2 (1.0f, 1.0f)
        };
    }
}