using UnityEngine;

namespace Player
{
    public class ActionHandler : MonoBehaviour
    {
        [SerializeField] private float fMaxReachDistance = 7.5f;
        [SerializeField] private float fBlockBreakingCooldown = .01f;
        /*    (0_0)   */ private GameObject hitOld;
        /*    (0_0)   */ private Vector3 v3Origin;
        /*    (0_0)   */ private Vector3 v3Look;
        
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
                    hit.transform.gameObject.SendMessage("goHighLight");

                    if (hitOld != null && hit.transform.gameObject != hitOld)
                        hitOld.SendMessage("goUnHighLight");
                        
                    if (Input.GetMouseButton(0) && fBlockBreakingCooldown == 0)
                    {
                        hit.transform.gameObject.SendMessage("goBreak");
                        fBlockBreakingCooldown = .03f;
                    }
                        
                    hitOld = hit.transform.gameObject;
                }
                else
                {
                    if (hitOld != null)
                        hitOld.SendMessage("goUnHighLight");
                }
            }
            else
            {
                if (hitOld != null)
                    hitOld.SendMessage("goUnHighLight");
            }
            
            fBlockBreakingCooldown = fBlockBreakingCooldown > 0 ? fBlockBreakingCooldown - Time.deltaTime : 0; 
        }
    }
}