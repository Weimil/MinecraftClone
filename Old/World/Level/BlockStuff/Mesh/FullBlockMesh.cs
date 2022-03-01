using System.Collections.Generic;
using UnityEngine;

namespace World.Level.BlockStuff.Mesh
{
    public class FullBlockMesh
    {
        /*
         * Order: X+- Y+- Z+-
         * X+: West  | X-: East
         * Y+: Top   | Y-: Bottom
         * Z+: South | Z-: North
         *
         * Documentation in "MineClone.drawio"
         */
        public Vector3[] BlockVertx = new Vector3[8]
        {
            new Vector3(0, 0, 0), // 0
            new Vector3(0, 0, 1), // 1
            new Vector3(1, 0, 0), // 2
            new Vector3(1, 0, 1), // 3
            new Vector3(0, 1, 0), // 4
            new Vector3(0, 1, 1), // 5
            new Vector3(1, 1, 0), // 6
            new Vector3(1, 1, 1)  // 7
        };
        
        public int[,] BlockTriangles = new int[6,4] 
        {                                                                                    
            /*                                                                               
             * Implementation will be:                                                       
             * - - - >                                                                       
             * {0,1,2,3}                                                                     
             *   < - - -                                                                     
             * loop 1                                                                        
             *    {0,1,2}                                                                    
             * loop 2                                                                        
             *    {3,2,1}                                                                    
             */                                                                              
            /* Just a curiosity                                                              
             *                                                                               
             * Difference between Noth and south is +1 in each vertex
             * {0,4,2,6}
             * +      1
             * ---------
             * {1,5,3,7}
             * Difference between East and West is +2 in each vertex
             * {0,4,1,5}
             * +      2
             * ---------
             * {2,6,3,7}
             * Difference between Top and Bottom is +4 in each vertex
             * {0,1,2,3}
             * +      4
             * ---------
             * {4,5,6,7}
             */
            // Side facing ...
            {0,4,1,5}, // ... East
            {2,6,3,7}, // ... West
            {0,1,2,3}, // ... Bottom
            {4,5,6,7}, // ... Top
            {0,4,2,6}, // ... North
            {1,5,3,7}  // ... South
        };
        
        public Vector2[] BlockUvs = new Vector2[4] 
        {
            /* 
             * Implementation will be:
             *    - - - - - - - - - - - - - - - - - > 
             *    {BlockUvs[0],BlockUvs[1],BlockUvs[2],BlockUvs[3]}
             *                  < - - - - - - - - - - - - - - - - -
             * Triangle 1 
             *    {BlockUvs[0],BlockUvs[1],BlockUvs[2]}
             * Triangle 2
             *    {BlockUvs[3],BlockUvs[2],BlockUvs[1],}  
             */
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1)
        };
        
        public Vector3[] FaceCheck = new Vector3[6]
        {
            // Side facing ...
            new Vector3(-1,0, 0 ), // ... East
            new Vector3(1, 0, 0 ), // ... West
            new Vector3(0, -1,0 ), // ... Bottom
            new Vector3(0, 1, 0 ), // ... Top
            new Vector3(0, 0, -1), // ... North
            new Vector3(0, 0, 1 )  // ... South
        };

        public List<Vector3> GetVertexListFromFace(int face)
        {
            List<Vector3> list = new List<Vector3>();

            for (int i = 0; i < BlockTriangles.GetLength(1); i++)
            {
                list.Add(BlockVertx[BlockTriangles[face,i]]);
            }

            return list;
        }
    }
}