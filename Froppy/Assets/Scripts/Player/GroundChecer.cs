using UnityEngine;

public class GroundChecer : MonoBehaviour
{
   public bool isGrounded()
    {
        return Physics2D.OverlapPointAll(transform.position) != null;
    }
}
