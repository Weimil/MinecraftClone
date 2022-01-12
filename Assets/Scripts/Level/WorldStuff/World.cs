using System;
using Level.RegionStuff;
using UnityEngine;
using Random = System.Random;

namespace Level.WorldStuff
{
    public class World : MonoBehaviour
    {
        private Region[,] _regions;
        public static readonly int seed = 0;
        public static Random Random = new Random(seed);
        
        private void Start()
        {
            /*
            _regions = new Region[2, 2];

            for (int x = 0; x < _regions.GetLength(0); x++)
            {
                for (int z = 0; z < _regions.GetLength(1); z++)
                {
                    Region region = Instantiate(new GameObject(), new Vector3(16, 0, 16), Quaternion.identity);
                    GameObject tmp1 = new GameObject();
                    tmp1.AddComponent<Region>();
                    _regions[x, z] = tmp1;
                    GameObject gameObject = new GameObject("region", typeof(Region));
                }
            }

            _regions[x, z];
            _regions[0, 0] = new Region(new Vector2(1,1), new Vector3(16,0,16));
            _regions[1, 0] = new Region(new Vector2(-1,1), new Vector3(-16,0,16));
            _regions[0, 1] = new Region(new Vector2(1,-1), new Vector3(16,0,-16));
            _regions[1, 1] = new Region(new Vector2(-1,-1), new Vector3(-16,0,-16));
            */
        }
    }
}