using UnityEngine;

public class WayPointEnemy : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 targetPos;
    [SerializeField][Range(0,100)] float moveSpeed;
    int wayPointIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     targetPos = wayPoints[0].position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            wayPointIndex++;
            if(wayPointIndex >= wayPoints.Length)
            {
                wayPointIndex = 0;
            }
        }

        targetPos = wayPoints[wayPointIndex].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().takeDamage(10.0f);
        }
    }
}
