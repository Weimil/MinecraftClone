using UnityEngine;

namespace Player
{
    public class ActionHandler : MonoBehaviour
    {
        [SerializeField] private float fMaxReachDistance = 7.5f;
        [SerializeField] private float fBlockBreakingCooldown = .01f;
        /*    (0_0)   */ private GameObject hitOld;

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(
                GetComponentInChildren<RotationX>().Position(), 
                GetComponentInChildren<RotationX>().LookingAt(), 
                out hit, fMaxReachDistance)
            )
            {
                if (hit.transform.CompareTag("Block"))
                {
                    hit.transform.GetComponent<BlockBehavior>().HighLight();

                    if (hitOld != null && hit.transform.gameObject != hitOld)
                        hitOld.GetComponent<BlockBehavior>().UnHighLight();
                        
                    if (Input.GetMouseButton(0) && fBlockBreakingCooldown == 0)
                    {
                        hit.transform.GetComponent<BlockBehavior>().Break();
                        fBlockBreakingCooldown = .03f;
                    }
                        
                    hitOld = hit.transform.gameObject;
                }
                else
                {
                    if (hitOld != null)
                        hitOld.GetComponent<BlockBehavior>().UnHighLight();
                }
            }
            else
            {
                if (hitOld != null)
                    hitOld.GetComponent<BlockBehavior>().UnHighLight();
            }
            
            fBlockBreakingCooldown = fBlockBreakingCooldown > 0 ? fBlockBreakingCooldown - Time.deltaTime : 0; 
        }
    }
}