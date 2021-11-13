using UnityEngine;

namespace Scenes.Scripts.Player
{
    public class RotationY : MonoBehaviour
    {
        [SerializeField] private float fRotationY = 500.0f;

        private CharacterController characterController;
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float fMouseY = Input.GetAxis("Mouse X");
            
            characterController.transform.Rotate(new Vector3(0f,fMouseY,0f) * Time.deltaTime * fRotationY);
        }
    }
}