using UnityEngine;

namespace Player
{
    public class RotationX : MonoBehaviour
    {
        [SerializeField] private float rotationX = 750f;
        private Vector3 _rotation;

        private void Update()
        {
            float mouseX = -Input.GetAxis("Mouse Y");

            _rotation.x += mouseX * Time.deltaTime * rotationX;
            _rotation.x = Mathf.Clamp(_rotation.x, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_rotation);
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