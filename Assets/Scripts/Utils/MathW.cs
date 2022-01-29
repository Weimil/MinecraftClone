using System;
using UnityEngine;

namespace Utils
{
    public static class MathW
    {
        /*
         Useless but idk
        public static Vector2 CosoCoords(Vector2 coords)
        {
            return new Vector2(
                (int) coords.x % 2 == 1 ? coords.x / 2 + 1 : (coords.x / 2 + 1) * -1,
                (int) coords.y % 2 == 1 ? coords.y / 2 + 1 : (coords.y / 2 + 1) * -1
            );
        }
        public static int CosoCoordsSuma(int coord)
        {
            return coord % 2 == 1 ? coord / 2 + 1 : (coord / 2 + 1) * -1;
        }
        public static int CFormat(int coord)
        {
            return coord % 2 == 1 ? coord / 2 + 1 : (coord / 2 + 1) * -1;
        }
        public static Vector3 RegionCoordCalc(int x, int z)
        {
            return new Vector3(
                x % 2 == 1
                    ? x / 2 * RegionStatics.RegionSizeInBlocks + RegionStatics.RegionSizeInBlocks / 2
                    : (x / 2 * RegionStatics.RegionSizeInBlocks + RegionStatics.RegionSizeInBlocks / 2) * -1,
                0,
                z % 2 == 1
                    ? z / 2 * RegionStatics.RegionSizeInBlocks + RegionStatics.RegionSizeInBlocks / 2
                    : (z / 2 * RegionStatics.RegionSizeInBlocks + RegionStatics.RegionSizeInBlocks / 2) * -1
            );
        }
        public static Vector3 ChunkCoordCalc(int x, int z, Vector3 position)
        {
            new Vector3(
                CFormat(x) - 1 * ChunkStatics.ChunkWidth,
                0,
                0
            );
            return new Vector3(
                x % 2 == 1 ? x / 2 + 1 : (x / 2 + 1) * -1,
                0,
                z % 2 == 1
                    ? z / 2 * ChunkStatics.ChunkWidth + position.z
                    : (z / 2 * ChunkStatics.ChunkWidth + position.z) * -1
            );
        }
        */
        public static Vector3 RegionSpawnCords(int x, int z, int size)
        {
            int nX = x / 2 * size + size / 2;
            nX = x % 2 == 0 ? nX : nX * -1;

            int nZ = z / 2 * size + size / 2;
            nZ = z % 2 == 0 ? nZ : nZ * -1;

            return new Vector3(nX, 0, nZ);
        }
        
        public static Vector3 ChunkSpawnCords(int x, int z, Vector3 offSet, int size)
        {
            int nX = x / 2 * size + size / 2;
            nX = x % 2 == 0 ? nX : nX * -1;
            nX = nX + (int) offSet.x;

            int nZ = z / 2 * size + size / 2;
            nZ = z % 2 == 0 ? nZ : nZ * -1;
            nZ = nZ + (int) offSet.z;

            return new Vector3(nX, 0, nZ);
        }
        
        public static int RegionCoord(int num)
        {
            return num % 2 == 0 ? num / 2 + 1 : (num / 2 + 1) * -1;
        }

        public static Vector2 ChunkCoords(Vector2 vectorA, Vector2 vectorB)
        {
            return (AbsVector(vectorA) + vectorB) * MinimalVector(vectorA);
        }
        
        public static Vector2 MinimalVector(Vector2 vector)
        {
            // float x = vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0;
            // float y = vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0; 
            return new Vector2(
                vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0, 
                vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0
            );
        }

        public static Vector2 AbsVector(Vector2 vector)
        {
            return new Vector2(
                Math.Abs(vector.x),
                Math.Abs(vector.y)
            );
        }
        
        public static Vector3 MinimalVector(Vector3 vector)
        {
            // float x = vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0;
            // float y = vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0; 
            // float z = vector.z != 0 ? vector.z > 0 ? 1 : -1 : 0; 
            return new Vector3(
                vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0, 
                vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0, 
                vector.z != 0 ? vector.z > 0 ? 1 : -1 : 0 
            );
        }
        
        public static Vector3 AbsVector(Vector3 vector)
        {
            return new Vector3(
                Math.Abs(vector.x),
                Math.Abs(vector.y),
                Math.Abs(vector.z)
            );
        }
    }
}