using System;
using UnityEngine;

namespace Scenes.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float fMovementSpeed = 7.5f;
        [SerializeField] private float fRunMultiplier = 1.75f;
        [SerializeField] private float fJumpPower = 4f;
        [SerializeField] private float fFallModifier = 15f;
        
        private CharacterController characterController;
        private float fFallSpeed;
    
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            // TODO: Normalize movement.
            // Rn the usage of Vector3.Normalize(v3Move) is slow af.
            // 2021-11-10 Vector3.Normalize(v3Move) in unusable.
            
            Vector3 v3Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
            
            //v3Move = Vector3.Normalize(v3Move);

            if (Input.GetKey(KeyCode.LeftControl))
                v3Move *= Time.deltaTime * fMovementSpeed * fRunMultiplier;
            else
                v3Move *= Time.deltaTime * fMovementSpeed;
            
            // TODO: Custom isGrounded
            // characterController.isGrounded is not working properly, and gives out false positives.
            
            if (!characterController.isGrounded)
            {
                fFallSpeed += fFallModifier * Time.deltaTime;
                characterController.stepOffset = 0f;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                fFallSpeed = -fJumpPower;
            }
            else
            {
                characterController.stepOffset = 0.5f;
                fFallSpeed = 0;
            }
            v3Move.y = -fFallSpeed * Time.deltaTime;
            
            characterController.Move(transform.TransformVector(v3Move));
            
            CheckDeath();
        }

        private void CheckDeath()
        {
            if (characterController.transform.position.y < 0)
                characterController.transform.position = new Vector3(0, 5, 0);
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position,-transform.up,1);
        }
    }
}