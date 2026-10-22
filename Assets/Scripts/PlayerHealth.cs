using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
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
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth / playerHealth;
            if (currentHealth < 0)
            {
                Debug.Log("Player Is Dead");
                activateRagdoll();
            }
        }
    }

    public void activateRagdoll()
    {
        PlayerControls.enabled = false;
        playerModel.SetActive(false);
        ragdoll.SetActive(true);
    }
}
