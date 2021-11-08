using UnityEngine;

namespace Scenes.Scripts.Player
{
    public class PlayerActionHandler : MonoBehaviour
    {
        [SerializeField] private float fReach = 7.5f;

        private CharacterController characterController;
        
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            RaycastHit hit;
            //TODO: Origin from eyes.
            //Origin should be from the position of the eyes.
            Ray ray = new Ray(characterController.transform.position,Vector3.forward);
            if (Physics.Raycast(ray, out hit, fReach))
            {
                if (hit.transform.CompareTag("Block"))
                {
                    /*
                     * block.highlight
                     */
                }

                if (hit.transform.CompareTag("Mob"))
                {
                    /*
                     * Mob.hit(intemInHand)
                     */
                }
            }
        }

    }
}