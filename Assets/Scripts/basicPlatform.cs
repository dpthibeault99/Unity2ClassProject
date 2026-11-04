using UnityEngine;

public class basicPlatform : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    [Tooltip("Seconds for movment between end points")]
    [Min(0.01f)] public float lerpTime = 5.0f;
    [Min(0.00f)] public float pauseAtStart = 1.0f;
    [Min(0.00f)] public float pauseAtEnd = 1.0f;

    bool goingForward = true;
    float elasped;
    float pauseRemaning;
    void Start()
    {
        if (startPos == null || endPos == null) return;
        transform.position = startPos.position;
        pauseRemaning = Mathf.Max(0f,pauseAtStart);
        Physics.SyncTransforms();
    }

    void Update()
    {
        if (startPos == null || endPos == null) return;

        float remainingTime = Time.deltaTime;

        if(pauseRemaning > 0f)
        {
            float pauseTime = Mathf.Min(pauseRemaning, remainingTime);
            pauseRemaning-=pauseTime;
            remainingTime -= pauseTime;
        }
        if(remainingTime < 0f)return;

        elasped += remainingTime;

        float t = Mathf.Clamp01(elasped/Mathf.Max(0.01f,lerpTime));
        Vector3 from = goingForward? startPos.position:endPos.position;
        Vector3 to = goingForward? endPos.position:startPos.position;

        // lerp in liner interpration

        transform.position = Vector3.Lerp(from, to, t);
        Physics.SyncTransforms();

        if (t>=1)
        {
            pauseRemaning = Mathf.Max(0f,goingForward ? pauseAtEnd : pauseAtStart);
            goingForward = !goingForward;
            elasped = 0f;
        }

    }
}
