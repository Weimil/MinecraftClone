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