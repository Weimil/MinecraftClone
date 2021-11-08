using UnityEngine;

namespace Scenes.Scripts.Player
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private float fVerticalRotation = 750f;
        [SerializeField] private float fHorizontalRotation = 500.0f;

        private CharacterController characterController;
        private Vector3 v3Rotation;
        void Start()
        {
            characterController = GetComponentInParent<CharacterController>();
            v3Rotation = transform.localPosition;
        }

        void Update()
        {
            float fMouseY = -Input.GetAxis("Mouse Y");
            float fMouseX = Input.GetAxis("Mouse X");
            
            characterController.transform.Rotate(new Vector3(0f,fMouseX,0f) * Time.deltaTime * fHorizontalRotation);
            
            v3Rotation.x += fMouseY * Time.deltaTime * fVerticalRotation;
            v3Rotation.x = Mathf.Clamp(v3Rotation.x,-90f,90f);
            
            transform.localRotation = Quaternion.Euler(v3Rotation);
        }
    }
}