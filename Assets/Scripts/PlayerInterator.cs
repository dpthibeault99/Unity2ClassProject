using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInterator : MonoBehaviour
{
    public float interactDistance = 3.0f;
    public LayerMask interatctMask = ~0;
    public Vector3 playerInteractHeight = new Vector3(0,1f,0);

    public void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            Ray ray = new Ray(transform.position + playerInteractHeight, transform.forward);

            //if(Physics)
            //{

            //}
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + playerInteractHeight, transform.position + playerInteractHeight + transform.forward * interactDistance);
    }
}
