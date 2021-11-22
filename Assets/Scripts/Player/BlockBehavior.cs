using UnityEngine;

namespace Player
{
    public class BlockBehavior : MonoBehaviour
    {
        private void goHighLight()
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
        private void goUnHighLight()
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        private void goBreak()
        {
            Destroy(gameObject);
        }
    }
}
