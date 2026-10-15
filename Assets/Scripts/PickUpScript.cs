using Unity.Mathematics;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Visual")]
    public float rotateSpeed = 90f;
    public float bobHeight= 0.3f;
    public float bobSpeed= 2.0f;

    Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate item
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

        // make it float
        float newY = _startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // if this game manager exist, call this function
            GameManager.instance?.onPickUpCollected();
            Destroy(this.gameObject);
        }
    }
}
