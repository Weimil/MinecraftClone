using UnityEngine;

namespace Player
{
    public class RotationY : MonoBehaviour
    {
        [SerializeField] private float rotationY = 500.0f;
        private CharacterController _characterController;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float mouseY = Input.GetAxis("Mouse X");

            _characterController.transform.Rotate(new Vector3(0f, mouseY, 0f) * Time.deltaTime * rotationY);
        }
    }
}