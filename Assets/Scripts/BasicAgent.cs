using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BasicAgent : MonoBehaviour
{
    public Transform playerTarget;
    public NavMeshAgent agent;
    public Animator animator;
    public float attackDuration;
    private bool isAttacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // are we in attack range?
        if (!isAttacking && Vector3.Distance(transform.position, playerTarget.position) > 3)
        {
            agent.SetDestination(playerTarget.position);

        }
        if (!isAttacking && Vector3.Distance(transform.position, playerTarget.position) < 3)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
        animator.SetFloat("running", agent.velocity.magnitude);
        
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
    }
}
