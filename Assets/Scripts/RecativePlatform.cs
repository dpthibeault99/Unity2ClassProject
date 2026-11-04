using System;
using Unity.Mathematics;
using UnityEngine;

public class RecativePlatform : MonoBehaviour
{
    public GameObject obj;
    public Transform startPos;
    public Transform endPos;
    [Min(0.01f)] public float lerpTime = 5.0f;
    [Min(0.00f)] public float pauseTime = 1.0f;
    [Min(0.00f)] public float returnDelay = 3.0f;
    public bool isActive;

    public Transform movingTransform => obj != null ? obj.transform : null;
    bool goingForward = true;
    float currentLerpTime;
    float pauseRemaning;
    bool hasRider;
    float emptyTime;
    bool waitingForRider;
    bool returnHome;
    Vector3 returnFrom;
    float returnElapsed;
    float returnDuration;
    void Start()
    {
        if(startPos != null)
        {
            movingTransform.position = startPos.position;
            Physics.SyncTransforms();
        }
    }
    void Update()
    {
        if (startPos == null || endPos == null) return;
        if (waitingForRider && !hasRider)
        {
            emptyTime += Time.deltaTime;
            if(emptyTime >= returnDelay)
            {
                BeginReturnHome();
            }
        }

        if(returnHome) 
        {
            returnElapsed += Time.deltaTime;
            float returnT = Mathf.Clamp01(returnElapsed / returnDuration);
            movingTransform.position = Vector3.Lerp(returnFrom,startPos.position, returnT);
            Physics.SyncTransforms();

            if(returnT >+ 1f)
            {
                returnHome = false;
                isActive = false;
                goingForward = true;
                currentLerpTime = 0f;
                pauseRemaning = 0f;
            }
            return;

        }

        float remainingTime = Time.deltaTime;
        if (pauseRemaning > 0f)
        {
            float pauseTime = Mathf.Min(pauseRemaning,remainingTime);
            pauseRemaning -= pauseTime;
            remainingTime -= pauseTime;
        }

        if(remainingTime < 0f)
        {
            return;
        }

        // move platform

        currentLerpTime += remainingTime;


        float t = Mathf.Clamp01(currentLerpTime / Mathf.Max(0.01f, lerpTime));
        Vector3 from = goingForward ? startPos.position : endPos.position;
        Vector3 to = goingForward ? endPos.position : startPos.position;
        movingTransform.position = Vector3.Lerp(from, to, t);
        Physics.SyncTransforms();

        if(t>=1)
        {
            goingForward = !goingForward;
            currentLerpTime = 0f;
            pauseRemaning = Mathf.Max(0f,pauseTime);
        }
    }

    public void activatePlatform()
    {
        isActive = true;
    }
    public void deActivatePlatform()
    {
        isActive = false;
    }

    public void PlayerBoarded()
    {
        hasRider = true;
        waitingForRider = false;
        emptyTime = 0f;
        if(returnHome)
        {
            float fullDistance = Vector3.Distance(startPos.position, endPos.position);
            float progress = fullDistance > 0.0f ? Vector3.Distance(startPos.position, movingTransform.position) / fullDistance : 0f;
            goingForward = true;
            currentLerpTime = Mathf.Clamp01(progress * Mathf.Max(0.0f,lerpTime));
            pauseRemaning = 0f;
            returnHome = false;
        }
        activatePlatform();
    }

    public void playerLeft()
    {
        hasRider =false;
        waitingForRider = true;
        emptyTime = 0f;
    }

    // end of day
    private void BeginReturnHome()
    {
        waitingForRider = false;
        returnHome = true;
        returnFrom = movingTransform.position;
        returnElapsed = 0.0f;

        float fullDistance = Vector3.Distance(startPos.position, endPos.position);
        float fraction = fullDistance > 0.0f ? Vector3.Distance(returnFrom,startPos.position)/fullDistance : 0.0f;
        returnDuration = Mathf.Max(0.0f,lerpTime * fraction);

    }
}
