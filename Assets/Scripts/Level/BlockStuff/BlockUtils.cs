using Level.ChunkStuff;
using Testing;

namespace Level.BlockStuff
{
    public class BlockUtils
    {/*
        int checkX = x + (int) FullBlockMesh.FaceCheck[faceIndex].x;
        int checkY = y + (int) FullBlockMesh.FaceCheck[faceIndex].y;
        int checkZ = z + (int) FullBlockMesh.FaceCheck[faceIndex].z;
        
            if (_chunkData[checkX, checkY, checkZ].Name == "air")
        {
            return false;
        }*/
            
        /// <include file='../../../../docs.xml' path='Documentation/Scripts/Level/BlockStuff/BlockUtils/Script[@name="IsValidPosition"]'/>
        public static bool IsValidPosition(int x, int y, int z)
        {
            if (x >= 0 && x < ChunkStatics.ChunkWidth &&
                y >= 0 && y < ChunkStatics.ChunkWidth &&
                z >= 0 && z < ChunkStatics.ChunkWidth)
            {
                return true;
            }
            return false;
        }

        /// <include file='../../../../docs.xml' path='Documentation/Scripts/Level/BlockStuff/BlockUtils/Script[@name="ShouldRenderFace"]'/>
        public static bool ShouldRenderFace(Block block)
        {
            return block.Name != "Stone";
        }
    }
}