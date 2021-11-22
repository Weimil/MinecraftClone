using UnityEngine;

namespace Player
{
    public class RotationX : MonoBehaviour
    {
        [SerializeField] private float fRotationX = 750f;
        /*    (0_0)   */ private Vector3 v3Rotation;
        private void Update()
        {
            float fMouseX = -Input.GetAxis("Mouse Y");
            
            v3Rotation.x += fMouseX * Time.deltaTime * fRotationX;
            v3Rotation.x = Mathf.Clamp(v3Rotation.x,-90f,90f);
            
            transform.localRotation = Quaternion.Euler(v3Rotation);
        }

        public Vector3 LookingAt()
        {
            return transform.forward;
        }
        
        public Vector3 Position()
        {
            return transform.position;
        }
    }
}
