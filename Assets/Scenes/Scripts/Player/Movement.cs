using UnityEngine;

namespace Scenes.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float fMovementSpeed = 7.5f;
        [SerializeField] private float fRunMultiplier = 1.75f;
        [SerializeField] private float fJumpPower = 4f;
        [SerializeField] private float fFallModifier = 10f;

        private float fFallSpeed;
        private CharacterController characterController;
    
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            // TODO: Normalize movement.
            // Rn the usage of Vector3.Normalize(move) when instancing it is slow af,
            // but normalizing it after multiplying if by fMovementSpeed doesn't work as intended.
            
            float fHorizontalMovement = Input.GetAxis("Horizontal");
            float fVerticalMovement = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(fHorizontalMovement, 0, fVerticalMovement) * Time.deltaTime * fMovementSpeed;

            if (Input.GetKey(KeyCode.LeftControl))
                move *= fRunMultiplier;

            // TODO: Custom isGrounded
            // characterController.isGrounded is not working properly, and gives out false positives.
            
            if (!characterController.isGrounded)
            {
                fFallSpeed += fFallModifier * Time.deltaTime;
                characterController.stepOffset = 0f;
            }
            else if (characterController.isGrounded && Input.GetKey(KeyCode.Space))
            {
                fFallSpeed = -fJumpPower;
            }
            else
            {
                characterController.stepOffset = 0.5f;
                fFallSpeed = 0;
            }

            move.y = -fFallSpeed * Time.deltaTime;
            
            characterController.Move(transform.TransformVector(move));

            if (characterController.transform.position.y < 0)
                characterController.transform.position = new Vector3(0, 5, 0);
        }
    }
}