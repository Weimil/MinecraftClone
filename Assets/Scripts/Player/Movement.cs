using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float runMultiplier = 1.75f;
        [SerializeField] private float jumpPower = 3.5f;
        [SerializeField] private float fallModifier = 13f;
        private bool _bIsRunning;
        private CharacterController _characterController;
        private float _fFallSpeed;
        private Vector3 _v3Move;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            // TODO : Coyote Time
            // https://www.youtube.com/watch?v=qf9vq-ru2Ks
            // TODO : Inertia
            // Player have Inertia in the air and if the player have jumped will continue moving although v3Move may be  (0, 0, 0) 
            // TODO : Custom isGrounded
            // Create an isGrounded method using a raycast
            // TODO : FIX Diagonal movement
            // It can be fixed by using the method Normalize from Vector3 but it do not work as intended

            _v3Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (!_characterController.isGrounded)
            {
                _fFallSpeed += fallModifier * Time.deltaTime;
                _characterController.stepOffset = 0f;
                _v3Move /= 1.6f;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                _fFallSpeed = -jumpPower;
            }
            else
            {
                _bIsRunning = Input.GetKey(KeyCode.LeftControl);
                _characterController.stepOffset = 0.5f;
                _fFallSpeed = 0;
            }

            if (_bIsRunning && _v3Move.z > .1f)
                _v3Move *= Time.deltaTime * movementSpeed * runMultiplier;
            else
                _v3Move *= Time.deltaTime * movementSpeed;

            _v3Move.y = -_fFallSpeed * Time.deltaTime;

            _characterController.Move(transform.TransformVector(_v3Move));

            _characterController.transform.position =
                _characterController.transform.position.y < 0
                    ? new Vector3(0, 150, 0)
                    : _characterController.transform.position;
        }
    }
}