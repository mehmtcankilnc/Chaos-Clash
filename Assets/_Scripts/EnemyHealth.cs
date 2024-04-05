using Pathfinding;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private CoinBar coinBar;
    private ProgressBar progressBar;
    private EnemyData enemyData;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isDead = false;
    public floatingHealthBar healthBar;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyData = GetComponent<EnemyData>();
        enemyData.currentHealth = enemyData.maxHealth;
        progressBar = GameObject.FindAnyObjectByType<ProgressBar>();
        coinBar = GameObject.FindAnyObjectByType<CoinBar>();
    }
    private void Update()
    {
        healthBar.UpdateHealthBar(enemyData.currentHealth, enemyData.maxHealth);
    }
    public void TakeDamage(int damage)
    {
        enemyData.currentHealth -= damage;
        if (enemyData.currentHealth <= 0 && !isDead)
        {
            healthBar.UpdateHealthBar(enemyData.currentHealth, enemyData.maxHealth);
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        gameObject.GetComponent<EnemyHealth>().enabled = false;
        gameObject.GetComponent<AIPath>().enabled = false;
        gameObject.GetComponent<Seeker>().enabled = false;

        if (rb.gameObject.name == "Enemy1(Clone)")
        {
            int coinToAdd = 10;
            if (GameManager.Instance.coin < GameManager.Instance.maxCoin)
            {
                if (GameManager.Instance.coin + coinToAdd > GameManager.Instance.maxCoin)
                {
                    coinToAdd = GameManager.Instance.maxCoin - GameManager.Instance.coin;
                }
                GameManager.Instance.coin += coinToAdd;
                coinBar.GainCoin(coinToAdd);
            }
            progressBar.IncreaseProgress(12);
        }
        else if (rb.gameObject.name == "Enemy2(Clone)")
        {
            int coinToAdd = 20;
            if (GameManager.Instance.coin < GameManager.Instance.maxCoin)
            {
                if (GameManager.Instance.coin + coinToAdd > GameManager.Instance.maxCoin)
                {
                    coinToAdd = GameManager.Instance.maxCoin - GameManager.Instance.coin;
                }
                GameManager.Instance.coin += coinToAdd;
                coinBar.GainCoin(coinToAdd);
            }
            progressBar.IncreaseProgress(20);
        }
        animator.SetTrigger("Death");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
