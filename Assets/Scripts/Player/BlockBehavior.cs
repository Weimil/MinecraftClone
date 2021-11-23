using UnityEngine;

namespace Player
{
    public class BlockBehavior : MonoBehaviour
    {
        public void HighLight()
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
        public void UnHighLight()
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        public void Break()
        {
            Destroy(gameObject);
        }
    }
}
