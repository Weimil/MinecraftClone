using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float fMovementSpeed = 5f;
        [SerializeField] private float fRunMultiplier = 1.75f;
        [SerializeField] private float fJumpPower = 3.5f;
        [SerializeField] private float fFallModifier = 13f;
        /*    (0_0)   */ private CharacterController characterController;
        /*    (0_0)   */ private float fFallSpeed;
        /*    (0_0)   */ private bool bIsRunning;
        /*    (0_0)   */ private Vector3 v3Move;
        
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void Update()
        {
            v3Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            if (!characterController.isGrounded)
            {
                fFallSpeed += fFallModifier * Time.deltaTime;
                characterController.stepOffset = 0f;
                v3Move /= 1.6f;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                fFallSpeed = -fJumpPower;
            }
            else
            {
                bIsRunning = Input.GetKey(KeyCode.LeftControl);
                characterController.stepOffset = 0.5f;
                fFallSpeed = 0;
            }
            
            if (bIsRunning && v3Move.z > .1f)
                v3Move *= Time.deltaTime * fMovementSpeed * fRunMultiplier;
            else
                v3Move *= Time.deltaTime * fMovementSpeed;

            v3Move.y = -fFallSpeed * Time.deltaTime;
            
            characterController.Move(transform.TransformVector(v3Move));
        }
    }
}