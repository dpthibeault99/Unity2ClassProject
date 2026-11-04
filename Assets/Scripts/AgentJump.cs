using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class AgentJump : MonoBehaviour
{
    public float jumpHeight = 2.0f;
    public float jumpDuration = 0.6f;
    public Animator anim;
    NavMeshAgent agent;
    bool jumping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
        // not attched to agent at the moment
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.isOnOffMeshLink && !jumping)
        {
            //StartCoroutine(Jump());
        }
    }

    //IEnumerator Jump()
    //{
    //    jumping = true;

    //    anim.SetTrigger("Jump");

    //    OffMeshLinkData link = agent.currentOffMeshLinkData;
    //    Vector3 start = transform.position;
    //    Vector3 end = link.endPos + Vector3.up * agent.baseOffset;

    //    float elapsedTime = 0.0f;

    //    while (elapsedTime < jumpDuration)
    //    {
    //        float time = Mathf.Clamp01(elapsedTime / jumpDuration);

    //        Vector3 position = Vector3.Lerp(start, end, time);
    //    }
    //}

}
