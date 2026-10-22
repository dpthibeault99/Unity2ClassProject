using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float currentHealth;
    [Header("Ragdoll Stuff")]
    public GameObject ragdoll;
    public GameObject playerModel;
    public PlayerController PlayerControls;
    void Start()
    {
        currentHealth = playerHealth;
    } 

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            Debug.Log("Player Is Dead");
            activateRagdoll();
        }
    }

    public void activateRagdoll()
    {
        PlayerControls.enabled = false;
        playerModel.SetActive(false);
        ragdoll.SetActive(true);
    }
}
