using UnityEngine;

namespace Level.BlockStuff.MeshStuff
{
    public static class MeshStatics
    {
        public static readonly Vector3[] FaceCheck = new Vector3[6]
        {
            // Side facing ...
            new Vector3(0, 1, 0), // ... Top
            new Vector3(0, -1, 0), // ... Bottom
            new Vector3(0, 0, 1), // ... North
            new Vector3(0, 0, -1), // ... South
            new Vector3(1, 0, 0), // ... East
            new Vector3(-1, 0, 0) // ... West
        };
    }
}