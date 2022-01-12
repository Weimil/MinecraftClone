# About

## 

# RoadMap

Some features I want to add 

[ ]  Hola



Classes
	- GlobalVariables // Clase en la que es definiran valors per a moltes clases amb el 
						unic objectiu de que siga mes facil de editar eixes propietats
	- Block // Class que defineix a un block
		- Nom
		- VertexArray
		- Texture
		- 
	- BlockList // Class per a guardar la informacio de tots els diferents tipos de blocks en el joc
	- Chunk // Class que defineix a un Chunk
		- Array de blocks
		- Posicio en el mon
		- Tamany
	- ChunkRenderer // Class encarregada de renderitzar el chunk
		+ Get Chunk and render mesh of it
		
Chunk generation proces

maximum number of chunks to generate

Client sends its position to the server, 
Server takes the position and based on the "RENDER_DISTNCE", starts to proces of loading chunks 
	by sending the area is needed to be loaded (2DArrayOf chunk coords),
The proces the first "NUM_OF_CHUNKS_TO_GENERATE" and checks wether the chunk exists or not,
if the chunk exixsts 

 those chunks and checks what chunks are already generated , server takes  and 

## UnUsed Code
    Mesh generation:
    '''c#
    /*
        private void AddBlockDataOld(Vector3Int position)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++) 
                {
                    int triangleIndex = BlockMesh.BlockTriangles[i, j];
                    _vertices.Add(BlockMesh.BlockVerts[triangleIndex] + position);
                    _triangles.Add(_vertexIndex);
                    
                    _uvs.Add(BlockMesh.BlockUvs[j]);

                    _vertexIndex++;
                }
            }
        }
        private void AddNoisedBlockData(Vector3Int position)
        {
            float newX = position.x / div;
            float newY = position.y / div;
            float newZ = position.z / div;
            if (snoise(new float3(newX, newY, newZ)) > scale)
                AddBlockDataOld(position);
        }
    */
    
            private bool IsValidPosition(int x, int y, int z, int faceIndex)
        {
            int checkX = x + (int) BlockMesh.FaceCheck[faceIndex].x;
            int checkY = y + (int) BlockMesh.FaceCheck[faceIndex].y;
            int checkZ = z + (int) BlockMesh.FaceCheck[faceIndex].z;

            return !(checkX >= 0 && checkX < chunkSize &&
                     checkY >= 0 && checkY < chunkSize &&
                     checkZ >= 0 && checkZ < chunkSize);
        }

        private void RenderBlocko(Vector3 position)
        {
            if (_chunkData[(int) position.x, (int) position.y, (int) position.z] == "stone")
            {
                for (int i = 0; i < 6; i++)
                {
                    Vector3 checkBlock = position + BlockMesh.FaceCheck[i];

                    if (BlockExists(checkBlock))
                    {
                        if (_chunkData[(int) checkBlock.x, (int) checkBlock.y, (int) checkBlock.z] == "stone")
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                int triangleIndex = BlockMesh.BlockTriangles[i, j];
                                _vertices.Add(BlockMesh.BlockVerts[triangleIndex] + position);
                                _triangles.Add(_vertexIndex);
                                _uvs.Add(BlockMesh.BlockUvs[j]);
                                _vertexIndex++;
                            }
                        } 
                    }
                }
            }
        }

        private bool BlockExists(Vector3 block)
        {
            Debug.Log("Hey");
            return block.x >= 0 && block.x <= chunkSize-1 && block.y >= 0 && block.y <= chunkSize-1 && block.z >= 0 && block.z <= chunkSize-1;
        }




si el block del costat es o aire o esta fora del chunk pintau