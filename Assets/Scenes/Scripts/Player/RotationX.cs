using UnityEngine;

namespace Scenes.Scripts.Player
{
    public class RotationX : MonoBehaviour
    {
        [SerializeField] private float fRotationX = 750f;

        private Vector3 v3Rotation;
        void Start()
        {
            v3Rotation = transform.localPosition;
        }

        void Update()
        {
            float fMouseX = -Input.GetAxis("Mouse Y");
            
            v3Rotation.x += fMouseX * Time.deltaTime * fRotationX;
            v3Rotation.x = Mathf.Clamp(v3Rotation.x,-90f,90f);
            
            transform.localRotation = Quaternion.Euler(v3Rotation);
        }
    }
}
