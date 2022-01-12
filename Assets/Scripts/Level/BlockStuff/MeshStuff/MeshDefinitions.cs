using System.Collections.Generic;
using UnityEngine;

namespace Level.BlockStuff.MeshStuff
{
    public static class MeshDefinitions
    {
        public static readonly MeshType FullBlock = new MeshType(
            /*
             * Order: X+- Y+- Z+-
             * X+: East  \ X-: West
             * Y+: Top   \ Y-: Bottom
             * Z+: North \ Z-: South
             *
             * Documentation in "MineClone.drawio"
             */
            new Vector3[8]
            {
                new Vector3(0, 0, 0), // 0
                new Vector3(0, 0, 1), // 1
                new Vector3(1, 0, 0), // 2
                new Vector3(1, 0, 1), // 3
                new Vector3(0, 1, 0), // 4
                new Vector3(0, 1, 1), // 5
                new Vector3(1, 1, 0), // 6
                new Vector3(1, 1, 1), // 7
            },
            new List<int>[6] 
            {
                // Side facing ...
                new List<int> {4,5,6,6,5,7}, // ... Top
                new List<int> {0,2,1,1,2,3}, // ... Bottom
                new List<int> {1,3,5,5,3,7}, // ... North
                new List<int> {0,4,2,2,4,6}, // ... South
                new List<int> {2,6,3,3,6,7}, // ... East
                new List<int> {0,1,4,4,1,5}, // ... West
            }
        );
    }
}