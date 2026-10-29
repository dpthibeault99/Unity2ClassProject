using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackTransform;
    public float attackRadius;
    public float attackDamage = 1;

    public void attackPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackTransform.position, attackRadius);    

        foreach(var player in hitColliders)
        {
            if(player.CompareTag("Player"))
            {
                Debug.Log("Hit PLayer");
                player.GetComponent<PlayerHealth>().takeDamage(attackDamage);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackTransform.position, attackRadius);  
    }
}
