using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInterator : MonoBehaviour
{
    public float interactDistance = 3.0f;
    public LayerMask interatctMask = ~0;
    public Vector3 playerInteractHeight = new Vector3(0,1f,0);

    public void OnInteract(InputValue value)
    {
        Debug.Log("interact");
        if(value.isPressed)
        {
            Ray ray = new Ray(transform.position + playerInteractHeight, transform.forward);

            if(Physics.Raycast(ray, out RaycastHit hit,interactDistance,interatctMask))
            {
                Debug.Log("interacted with " + hit.collider.name);
                if (hit.collider.name == "Door")
                {
                    DoorOpen door = hit.collider.gameObject.GetComponent<DoorOpen>();

                    if (door != null)
                    {
                        door.doorOpen = true;
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + playerInteractHeight, transform.position + playerInteractHeight + transform.forward * interactDistance);
    }
}
