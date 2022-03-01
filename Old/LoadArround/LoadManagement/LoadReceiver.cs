using System.Collections.Generic;
using UnityEngine;
using WorldStuff;

namespace LoadManagement
{
    public class LoadReceiver : MonoBehaviour
    {
        private World _world;
        private HashSet<Vector2> _loadedChunks;
        private HashSet<Vector2> _toBeUnloaded;
        private HashSet<Vector2> _toBeLoaded;

        public void Init(World world)
        {
            _world = world;
            _loadedChunks = new HashSet<Vector2>();
            _toBeUnloaded = new HashSet<Vector2>();
            _toBeLoaded = new HashSet<Vector2>();
        }

        public void ChunkRequest(HashSet<Vector2> viewDistanceMask)
        {
            foreach (Vector2 vector2 in _loadedChunks) _toBeUnloaded.Add(vector2);
            _toBeUnloaded.ExceptWith(viewDistanceMask);
            foreach (Vector2 vector2 in _toBeUnloaded) _world.Unload(vector2);

            foreach (Vector2 vector2 in viewDistanceMask) _toBeLoaded.Add(vector2);
            _toBeLoaded.ExceptWith(_loadedChunks);
            foreach (Vector2 vector2 in _toBeLoaded) _world.Load(vector2);

            _loadedChunks.Clear();
            _toBeLoaded.Clear();
            _toBeUnloaded.Clear();

            foreach (Vector2 vector2 in viewDistanceMask) _loadedChunks.Add(vector2);
        }
    }
}