using System.Collections.Generic;
using UnityEngine;

namespace WorldStuff
{
    public class World : MonoBehaviour
    {
        public Chunk chunkPrefab;
        private Dictionary<Vector2, Chunk> _chunksDictionary;

        public void Init()
        {
            _chunksDictionary = new Dictionary<Vector2, Chunk>();
            List<Vector2> list = new List<Vector2>();
            list.Sort();
        }

        private void CreateChunk(Vector2 vector)
        {
            Debug.Log("Hi");
            Chunk chunk = Instantiate(
                chunkPrefab,
                new Vector3(vector.x, 0, vector.y) * 16f,
                Quaternion.identity,
                gameObject.transform
            );
            chunk.name = $"Chunk[{vector.x}|{vector.y}]";
            _chunksDictionary.Add(vector, chunk);
        }

        public void Load(Vector2 vector)
        {
            if (!_chunksDictionary.TryGetValue(vector, out Chunk chunk))
                CreateChunk(vector);
            else
                // chunk.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("Hi sir, I should not be talking, but I have to tell you that something is wrong");
        }

        public void Unload(Vector2 vector)
        {
            if (_chunksDictionary.TryGetValue(vector, out Chunk chunk))
            {
                Destroy(chunk.gameObject);
                _chunksDictionary.Remove(vector);
            }
        }
    }
}