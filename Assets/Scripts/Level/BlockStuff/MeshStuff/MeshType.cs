using System.Collections.Generic;
using Graphics;
using UnityEngine;

namespace Level.BlockStuff.MeshStuff
{
    public class MeshType
    {
        private readonly List<int>[] _blockTriangle;
        private readonly Vector3[] _blockVertex;

        public MeshType(Vector3[] blockVertex, List<int>[] blockTriangle)
        {
            _blockVertex = blockVertex;
            _blockTriangle = blockTriangle;
        }

        public List<Vector3> GetVertexListFromFace(int face, Vector3 pos)
        {
            List<Vector3> list = new List<Vector3>();

            for (int i = 0; i < _blockTriangle[face].Count; i++) list.Add(_blockVertex[_blockTriangle[face][i]] + pos);

            return list;
        }

        public List<int> GetTriangleListFromFace(int face, int vertexIndex)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < _blockTriangle[face].Count; i++)
            {
                list.Add(vertexIndex);
                vertexIndex++;
            }

            return list;
        }

        public List<Vector2> GetUVsListFromFace(int face, int textureIndex)
        {
            List<Vector2> list = new List<Vector2>();

            for (int i = 0; i < _blockTriangle[face].Count; i++)
                switch (face)
                {
                    case 0:
                    case 1:
                        list.Add(new Vector2(
                                _blockVertex[_blockTriangle[face][i]].x / TextureMap.TextureMapWidth +
                                (float) 1 / TextureMap.TextureMapWidth * face,
                                _blockVertex[_blockTriangle[face][i]].z / TextureMap.TextureMapHeight +
                                (float) 1 / TextureMap.TextureMapHeight * textureIndex
                            )
                        );
                        break;

                    case 2:
                    case 3:
                        list.Add(new Vector2(
                                _blockVertex[_blockTriangle[face][i]].x / TextureMap.TextureMapWidth +
                                (float) 1 / TextureMap.TextureMapWidth * face,
                                _blockVertex[_blockTriangle[face][i]].y / TextureMap.TextureMapHeight +
                                (float) 1 / TextureMap.TextureMapHeight * textureIndex
                            )
                        );
                        break;

                    case 4:
                    case 5:
                        list.Add(new Vector2(
                                _blockVertex[_blockTriangle[face][i]].z / TextureMap.TextureMapWidth +
                                (float) 1 / TextureMap.TextureMapWidth * face,
                                _blockVertex[_blockTriangle[face][i]].y / TextureMap.TextureMapHeight +
                                (float) 1 / TextureMap.TextureMapHeight * textureIndex
                            )
                        );
                        break;
                }

            /*
             * X: vector[i].x / TextureMap.TextureMapWidth + (( (float) 1 / TextureMap.TextureMapWidth ) * face)
             * Y: vector[i].y / TextureMap.TextureMapHeight + (( (float) 1 / TextureMap.TextureMapHeight ) * textureIndex)
             */

            // int textureID = 
            return list;
        }
    }
}