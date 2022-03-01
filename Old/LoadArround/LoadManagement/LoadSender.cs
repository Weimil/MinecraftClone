using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace LoadManagement
{
    public class LoadSender : MonoBehaviour
    {
        private int ViewDistance { get; set; }
        private LoadReceiver _loadReceiver;
        private List<Vector2> ViewDistanceMask { get; set; }
        private Vector3 _position;

        public void Init(LoadReceiver loadReceiver)
        {
            ViewDistanceMask = new List<Vector2>();
            ViewDistance = 2;
            _loadReceiver = loadReceiver;
            CreateViewDistanceMask();
            SendRequest(Vector3.zero);
        }

        private void Update()
        {
            Vector3 currentPosition = MathW.Vector3IntDivision(transform.position, 16);
            if (_position != currentPosition) SendRequest(currentPosition);
        }

        private void SendRequest(Vector3 currentPosition)
        {
            _position = currentPosition;
            HashSet<Vector2> hashSet = new HashSet<Vector2>();
            for (int i = 0; i < ViewDistanceMask.Count; i++)
                hashSet.Add(new Vector2(
                        ViewDistanceMask[i].x + (int) _position.x,
                        ViewDistanceMask[i].y + (int) _position.z
                    )
                );
            _loadReceiver.ChunkRequest(hashSet);
        }

        private void CreateViewDistanceMask()
        {
            ViewDistanceMask.Clear();
            int max = ViewDistance * 2 + 1;

            for (int i = 0; i < max; i++)
            for (int j = 0; j < max; j++)
                ViewDistanceMask.Add(new Vector2(
                    i - ViewDistance,
                    j - ViewDistance
                ));
            //
            // string str = "List: \n";
            //
            // for (int i = 0; i < ViewDistanceMask.Count; i++)
            // {
            //     str += ViewDistanceMask[i] + "\t";
            //     if (i % max == max - 1)
            //         str += "\n\t\t";
            // }
            //
            // Debug.Log(str);
        }
    }
}