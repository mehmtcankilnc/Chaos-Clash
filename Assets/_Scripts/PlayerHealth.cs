using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public HealthBar healthBar;
    public ProgressBar progressBar;
    public CoinBar coinBar;
    public GameObject minimap;
    public GameObject gameoverScene; 
    private Animator animator;
    private bool isDead = false;
    private bool isGameStarted = false;
    public AudioSource gameoverAudioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("isSaved") == 1)
        {
            healthBar.SetMaxHealth(GameManager.Instance.maxHealth);
            healthBar.SetHealth(GameManager.Instance.currentHealth);
            isGameStarted = true;
        }
        else
        {
            healthBar.SetMaxHealth(GameManager.Instance.maxHealth);
            healthBar.SetHealth(GameManager.Instance.maxHealth);
            GameManager.Instance.currentHealth = GameManager.Instance.maxHealth;
        }
    }
    void Update()
    {
        if (isGameStarted && GameManager.Instance.currentHealth <= 0 && !isDead)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        gameObject.GetComponent<PlayerMovement>().isDead = true;
        waveSpawner.gameObject.SetActive(false);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        animator.SetTrigger("Death");
        isDead = true;
        PlayerPrefs.DeleteAll();
        yield return new WaitForSeconds(1.01f);
        healthBar.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);
        coinBar.gameObject.SetActive(false);
        minimap.SetActive(false);
        gameoverScene.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        PlayerPrefs.DeleteAll();
    }
    public void TakeDamage(int damage)
    {
        GameManager.Instance.currentHealth -= damage;
        healthBar.SetHealth(GameManager.Instance.currentHealth);
    }
    public void DeathSound()
    {
        gameoverAudioSource.Play();
    }
}
