using UnityEngine;

namespace Player
{
    public class ActionHandler : MonoBehaviour
    {
        [SerializeField] private float reachDistance = 7.5f;
        [SerializeField] private float breakingCooldown = .01f;
        private GameObject _hitOld;

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(
                GetComponentInChildren<RotationX>().Position(),
                GetComponentInChildren<RotationX>().LookingAt(),
                out hit, reachDistance)
            )
            {
                if (hit.transform.CompareTag("Block"))
                {
                    hit.transform.GetComponent<BlockBehavior>().HighLight();

                    if (_hitOld != null && hit.transform.gameObject != _hitOld)
                        _hitOld.GetComponent<BlockBehavior>().UnHighLight();

                    if (Input.GetMouseButton(0) && breakingCooldown == 0)
                    {
                        hit.transform.GetComponent<BlockBehavior>().Break();
                        breakingCooldown = .03f;
                    }

                    _hitOld = hit.transform.gameObject;
                }
                else
                {
                    if (_hitOld != null)
                        _hitOld.GetComponent<BlockBehavior>().UnHighLight();
                }
            }
            else
            {
                if (_hitOld != null)
                    _hitOld.GetComponent<BlockBehavior>().UnHighLight();
            }

            breakingCooldown = breakingCooldown > 0 ? breakingCooldown - Time.deltaTime : 0;
        }
    }
}