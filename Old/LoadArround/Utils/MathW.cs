using System;
using UnityEngine;
// ReSharper disable PossibleLossOfFraction
// ReSharper disable IntVariableOverflowInUncheckedContext

namespace Utils
{
    public static class MathW
    {
        // Unused Stuff, not sure what's in here
        //
        // public static Vector3 Vector3SpawnIdkBro(Vector2 vectorA, int num)
        // {
        //     return new Vector3(
        //         ((Math.Abs(vectorA.x) - 1) * num + num * 0.5f) * Math.Sign(vectorA.x),
        //         0,
        //         ((Math.Abs(vectorA.y) - 1) * num + num * 0.5f) * Math.Sign(vectorA.y)
        //     );
        // }
        //
        // public static Vector3 Vector3WrapOffset(int xA, int yA, int zA, int xB, int yB, int zB) 
        // {
        //     int nX = (int) (xA * 0.5f * xB + xB * 0.5f) * xA % 2 == 0 ? 1 : -1;
        //     nX = xA % 2 == 0 ? nX : nX * -1;
        //     
        //     int nY = (int) (yA * 0.5f * yB + yB * 0.5f) * yA % 2 == 0 ? 1 : -1;
        //     nY = yA % 2 == 0 ? nY : nY * -1;
        //     
        //     int nZ = (int) (zA * 0.5f * zB + zB * 0.5f) * zA % 2 == 0 ? 1 : -1;
        //     nZ = zA % 2 == 0 ? nZ : nZ * -1;
        //     
        //     return new Vector3(nX, nY, nZ);
        //     return new Vector3(
        //         (int) (xA * 0.5f * xB + xB * 0.5f) * xA % 2 == 0 ? 1 : -1,
        //         (int) (yA * 0.5f * yB + yB * 0.5f) * yA % 2 == 0 ? 1 : -1,
        //         (int) (zA * 0.5f * zB + zB * 0.5f) * zA % 2 == 0 ? 1 : -1
        //     );
        // }
        // 
        //
        // public static Vector2 MinimalVector(Vector2 vector)
        // {
        //     return new Vector2(
        //         vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0,
        //         vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0
        //     );
        // }
        // public static Vector2 MinimalVector(Vector2 vector)
        // {
        //     return new Vector2(
        //         vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0,
        //         vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0
        //     );
        // }
                //
        // public static Vector3 RegionSpawnCords(int x, int z, int size)
        // {
        //     int nX = (int) (x * 0.5f * size + size * 0.5f);
        //     nX = x % 2 == 0 ? nX : nX * -1;
        //
        //     int nZ = (int) (z * 0.5f * size + size * 0.5f);
        //     nZ = z % 2 == 0 ? nZ : nZ * -1;
        //
        //     return new Vector3(nX, 0, nZ);
        // }  
        // public static Vector3 ChunkSpawnCords(int x, int z, Vector2 regionId)
        // {
        //     Vector2 tmpVector = ChunkCoords(regionId, new Vector2(x, z) * ChunkStatics.ChunkWidth);
        //     
        //     return new Vector3(tmpVector.x, 0, tmpVector.y);
        // }
        // public static int RegionCoord(int num)
        // {
        //     return (int) (num % 2 == 0 ? num * 0.5f + 1 : (num * 0.5f + 1) * -1);
        // }
        // public static Vector2 ChunkCoords(Vector2 vectorA, Vector2 vectorB)
        // {
        //     return (AbsVector(vectorA) + vectorB) * MinimalVector(vectorA);
        // }
        // public static Vector2 MinimalVector(Vector2 vector)
        // {
        //     return new Vector2(
        //         vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0,
        //         vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0
        //     );
        // }
        // public static Vector2 AbsVector(Vector2 vector)
        // {
        //     return new Vector2(
        //         Math.Abs(vector.x),
        //         Math.Abs(vector.y)
        //     );
        // }
        // public static Vector3 MinimalVector(Vector3 vector)
        // {
        //     // float x = vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0;
        //     // float y = vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0; 
        //     // float z = vector.z != 0 ? vector.z > 0 ? 1 : -1 : 0; 
        //     return new Vector3(
        //         vector.x != 0 ? vector.x > 0 ? 1 : -1 : 0, 
        //         vector.y != 0 ? vector.y > 0 ? 1 : -1 : 0, 
        //         vector.z != 0 ? vector.z > 0 ? 1 : -1 : 0 
        //     );
        // }
        // public static Vector3 AbsVector(Vector3 vector)
        // {
        //     return new Vector3(
        //         Math.Abs(vector.x),
        //         Math.Abs(vector.y),
        //         Math.Abs(vector.z)
        //     );
        // }
        //

        public static Vector2 Vector2Mod(Vector2 vectorA, int mod) 
        {
            return Vector2Mod((int) vectorA.x, (int) vectorA.y, mod);
        }
        public static Vector2 Vector2Mod(int xA, int yA, int mod) 
        {
            return new Vector2(
                xA % mod,
                yA % mod
            );
        }
        
        public static Vector2 Vector2Abs(Vector2 vector) 
        {
            return Vector2Abs((int) vector.x, (int) vector.y);
        }
        public static Vector2 Vector2Abs(int xA, int yA) 
        {
            return new Vector2(
                Math.Abs(xA),
                Math.Abs(yA)
            );
        }

        public static Vector2 Vector2Sign(Vector2 vector) 
        {
            return Vector2Sign((int) vector.x, (int) vector.y);
        }
        public static Vector2 Vector2Sign(int xA, int yA) 
        {
            return new Vector2(
                xA >= 0 ? 1 : -1,
                yA >= 0 ? 1 : -1
            );
        }

        public static Vector2 Vector2Wrap(Vector2 vectorA) 
        {
            return Vector2Wrap((int) vectorA.x, (int) vectorA.y);
        }
        public static Vector2 Vector2Wrap(int xA, int yA) 
        {
            return new Vector2(
                xA % 2 == 0 ? xA * 0.5f + 1 : (xA * 0.5f + 1) * -1,
                yA % 2 == 0 ? yA * 0.5f + 1 : (yA * 0.5f + 1) * -1
            );
        }

        public static Vector2 Vector2WrapOffset(Vector2 vectorA, Vector2 vectorB) 
        {
            return Vector2WrapOffset((int) vectorA.x, (int) vectorA.y, (int) vectorB.x, (int) vectorB.y);
        }
        public static Vector2 Vector2WrapOffset(Vector2 vectorA, int xA, int yA) 
        {
            return Vector2WrapOffset((int) vectorA.x, (int) vectorA.y, xA, (int) yA);
        }
        public static Vector2 Vector2WrapOffset(int xA, int yA, Vector2 vectorA) 
        {
            return Vector2WrapOffset(xA, yA, (int) vectorA.x, (int) vectorA.y);
        }
        public static Vector2 Vector2WrapOffset(int xA, int yA, int xB, int yB) 
        {
            int nX = (int) (xA * 0.5f * xB + xB * 0.5f);
            nX = xA % 2 == 0 ? nX : nX * -1;

            int nY = (int) (yA * 0.5f * yB + yB * 0.5f);
            nY = yA % 2 == 0 ? nY : nY * -1;

            return new Vector2(nX, nY);
        }
        
        
        public static Vector3 Vector3Mod(Vector3 vectorA, int mod) 
        {
            return Vector3Mod((int) vectorA.x, (int) vectorA.y, (int) vectorA.z, mod);
        }
        public static Vector3 Vector3Mod(int xA, int yA, int zA, int mod) 
        {
            return new Vector3(
                xA % mod,
                yA % mod,
                zA % mod
            );
        }
        
        public static Vector3 Vector3Abs(Vector3 vectorA) 
        {
            return Vector3Abs((int) vectorA.x, (int) vectorA.y, (int) vectorA.z);
        }
        public static Vector3 Vector3Abs(int xA, int yA, int zA) 
        {
            return new Vector3(
                Math.Abs(xA),
                Math.Abs(yA),
                Math.Abs(zA)
            );
        }

        public static Vector3 Vector3Sign(Vector3 vectorA) 
        {
            return Vector3Sign((int) vectorA.x, (int) vectorA.y, (int) vectorA.z);
        }
        public static Vector3 Vector3Sign(int xA, int yA, int zA) 
        {
            return new Vector3(
                xA >= 0 ? 1 : -1,
                yA >= 0 ? 1 : -1,
                zA >= 0 ? 1 : -1
            );
        }

        public static Vector3 Vector3Wrap(Vector3 vector) 
        {
            return Vector3Wrap((int) vector.x, (int) vector.y, (int) vector.z);
        }
        public static Vector3 Vector3Wrap(int xA, int yA, int zA) 
        {
            return new Vector3(
                xA * 0.5f + 1 * xA % 2 == 0 ? 1 : -1,
                yA * 0.5f + 1 * yA % 2 == 0 ? 1 : -1,
                zA * 0.5f + 1 * zA % 2 == 0 ? 1 : -1
            );
        }
        
        public static Vector3 Vector3WrapOffset(int xA, int yA, int zA, int offset) 
        {
            return Vector3WrapOffset(xA, yA, zA, offset, offset, offset);
        }
        public static Vector3 Vector3WrapOffset(int xA, int yA, int zA, Vector3 vector) 
        {
            return Vector3WrapOffset(xA, yA, zA, (int) vector.x, (int) vector.y, (int) vector.z);
        }
        public static Vector3 Vector3WrapOffset(int xA, int yA, int zA, int xB, int yB, int zB) 
        {
            return new Vector3(
                (int) (xA * 0.5f * xB + xB * 0.5f) * xA % 2 == 0 ? 1 : -1,
                (int) (yA * 0.5f * yB + yB * 0.5f) * yA % 2 == 0 ? 1 : -1,
                (int) (zA * 0.5f * zB + zB * 0.5f) * zA % 2 == 0 ? 1 : -1
            );
        }
        
        public static Vector3 Vector3IntDivision(Vector3 vectorA, int div) 
        {
            return Vector3IntDivision((int) vectorA.x, (int) vectorA.y, (int) vectorA.z, div);
        }
        public static Vector3 Vector3IntDivision(int xA, int yA, int zA, int div) 
        {
            return new Vector3(
                xA / div,
                yA / div,
                zA / div
            );
        }
    }
}