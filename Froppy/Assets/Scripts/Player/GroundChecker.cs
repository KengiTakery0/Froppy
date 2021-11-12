using UnityEngine;

public class GroundChecker : MonoBehaviour
{
   public bool isGrounded()
    {
        return Physics2D.OverlapPoint(transform.position) != null;
    }
}
