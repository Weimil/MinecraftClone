using UnityEngine;
public class BlockBehavior : MonoBehaviour
{
    public void goHighlight()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
    
    public void goBreak()
    {
        Destroy(gameObject);
    }
}
