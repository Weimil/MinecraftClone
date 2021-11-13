using UnityEngine;

namespace Scenes.Scripts.Player
{
    public class PlayerActionHandler : MonoBehaviour
    {
        [SerializeField] private float fMaxReachDistance = 7.5f;
                         private float fBlockBreakingCooldown = .01f;
        
        private void Update()
        {
            DebugRaycast();
            HighlightBlock();
            if (Input.GetMouseButton(0))
            {
                if (fBlockBreakingCooldown == 0)
                {
                    BreakBlock();

                }
            }

            fBlockBreakingCooldown = fBlockBreakingCooldown > 0 ? fBlockBreakingCooldown - Time.deltaTime : 0; 
            Debug.Log(fBlockBreakingCooldown);
        }

        private void BreakBlock()
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(transform.position,transform.forward);
            if (Physics.Raycast(ray, out hitInfo, fMaxReachDistance))
            {
                if (hitInfo.transform.CompareTag("Block"))
                {
                    hitInfo.transform.gameObject.SendMessage("goBreak");
                    fBlockBreakingCooldown = .01f;
                }
            }
        }
        private void DebugRaycast()
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(transform.position,transform.forward);
            if (Physics.Raycast(ray, out hitInfo, fMaxReachDistance))
            {
                Debug.DrawLine(ray.origin,hitInfo.point,Color.red);
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * fMaxReachDistance,Color.green);
            }
        }
        private void HighlightBlock()
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(transform.position,transform.forward);
            if (Physics.Raycast(ray, out hitInfo, fMaxReachDistance))
            {
                if (hitInfo.transform.CompareTag("Block"))
                {
                    hitInfo.transform.gameObject.SendMessage("goHighlight");
                }
            }
        }

    }
}