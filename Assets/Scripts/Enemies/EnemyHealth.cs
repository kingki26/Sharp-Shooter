using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;
    GameManager gameManager;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamge(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            gameManager.AdjustEnemiesLeft(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }


}
