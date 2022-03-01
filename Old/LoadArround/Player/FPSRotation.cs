using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSRotation : MonoBehaviour
    {
        private Camera _cam;
        private Vector2 _mouseSensitivity;
        private Vector2 _pitchMinMax;
        private float _smoothTime;
        private float _yaw;
        private float _smoothYaw;
        private float _smoothYawV;
        private float _pitch;
        private float _smoothPitch;
        private float _smoothPitchV;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _cam = GetComponentInChildren<Camera>();
            _mouseSensitivity = new Vector2(5f, 5f);
            _pitchMinMax = new Vector2(-90f, 90f);
            _smoothTime = 0.1f;
        }

        private void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            _yaw += mouseX * _mouseSensitivity.x;
            _pitch -= mouseY * _mouseSensitivity.y;

            _pitch = Mathf.Clamp(_pitch, _pitchMinMax.x, _pitchMinMax.y);

            // _smoothYaw = Mathf.SmoothDampAngle(_smoothYaw, _yaw, ref _smoothYawV, _smoothTime);
            // _smoothPitch = Mathf.SmoothDampAngle(_smoothPitch, _pitch, ref _smoothPitchV, _smoothTime);
            //
            // transform.eulerAngles = Vector3.up * _smoothYaw;
            // _cam.transform.localEulerAngles = Vector3.right * _smoothPitch;

            transform.eulerAngles = Vector3.up * _yaw;
            _cam.transform.localEulerAngles = Vector3.right * _pitch;
        }
    }
}