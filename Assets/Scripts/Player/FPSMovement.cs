using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _velocity;
    private Vector3 _smoothVelocityV;
    private float _verticalVelocity;
    private float _lastGroundedTime;
    private float _smoothTime;
    private float _jumpForce;
    private float _walkSpeed;
    private float _runSpeed;
    private float _gravity;
    private bool _isJumping;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _characterController = GetComponent<CharacterController>();
        _smoothTime = 0.1f;
        _jumpForce = 8f;
        _walkSpeed = 6f;
        _runSpeed = 12f;
        _gravity = 18f;
    }

    private void Update()
    {
        Vector3 inputDirection = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        Vector3 worldInputDir = transform.TransformDirection(inputDirection);
        
        if (inputDirection.z > 0 && Input.GetKey(KeyCode.LeftControl))
            worldInputDir *= _runSpeed;
        else
            worldInputDir *= _walkSpeed;

        _velocity = Vector3.SmoothDamp(_velocity, worldInputDir, ref _smoothVelocityV, _smoothTime);

        _gravity = _characterController.transform.position.y > 0 ? 18f : 36f;
        
        _verticalVelocity -= _gravity * Time.deltaTime;
        _velocity.y = _verticalVelocity;

        CollisionFlags flags = _characterController.Move(_velocity * Time.deltaTime);
        if (flags == CollisionFlags.Below)
        {
            _isJumping = false;
            _lastGroundedTime = Time.deltaTime;
            _verticalVelocity = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float timeSinceLastGroundedTime = Time.deltaTime - _lastGroundedTime;
            if (_characterController.isGrounded || !_isJumping && timeSinceLastGroundedTime < 0.15f)
            {
                _isJumping = true;
                _verticalVelocity = _jumpForce;
            }
        }
    }
}
