using Level.ChunkStuff;
using UnityEngine;

namespace Level.RegionStuff
{
    public class Region : MonoBehaviour
    {
        private Vector2 _id;
        private Vector3 _position;
        private Chunk[,] _chunks;

        public Region(Vector2 id, Vector3 position)
        {
            _chunks = new Chunk[2, 2];

            _chunks[0, 0] = new Chunk(new Vector3(16,0,16));
            _chunks[1, 0] = new Chunk(new Vector3(-16,0,16));
            _chunks[0, 1] = new Chunk(new Vector3(16,0,-16));
            _chunks[1, 1] = new Chunk(new Vector3(-16,0,-16));

            
            _id = id;
            _position = position;
            
            /*
            _id = new Vector2(
                (int) id.x % 2 == 1 ? id.x / 2 : id.x / 2 * -1,
                (int) id.y % 2 == 1 ? id.y / 2 : id.y / 2 * -1
            );
            
            _position = new Vector3(
                _id.x * RegionStatics.RegionSizeInBlocks, 
                0, 
                _id.y
            );
            */

        }

        private void InitVariables(Vector2 id)
        {
            _id.x = (int) id.x % 2 == 1 ? id.x / 2 : id.x / 2 * -1;
            _id.y = (int) id.y % 2 == 1 ? id.y / 2 : id.y / 2 * -1;
            // Instantiate Region in coords pos


        }
    }
}