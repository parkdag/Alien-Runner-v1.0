using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject gameOverPanel;

    private int health = 3;

    public void TakeDamage()
    {
        
        if (health <= 0)
            
            return;
            
        health--;

        hearts[health].enabled = false;

        if (health > 0)
        {
            animator.Play("Stumble", 0, 0);
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        animator.Play("Death");

        gameOverPanel.SetActive(true);

        GetComponent<PlayerMovement>().enabled = false;
    }
}
