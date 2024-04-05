using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public float moveSpeed;
    public int attackDamage;
    public int maxHealth;
    public int currentHealth;
    public int coin;
    public int maxCoin;
    public float damageLevel;
    public float speedLevel;
    public float maxHealthLevel;
    public float maxCoinLevel;
    public int damageCostLevel;
    public int speedCostLevel;
    public int maxHealthCostLevel;
    public int maxCoinCostLevel;
    public float masterVolume;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        PlayerPrefs.SetInt("attackDamage", attackDamage);
        PlayerPrefs.SetInt("maxHealth", maxHealth);
        PlayerPrefs.SetInt("currentHealth", currentHealth);
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("maxCoin", maxCoin);
        PlayerPrefs.SetFloat("damageLevel", damageLevel);
        PlayerPrefs.SetFloat("speedLevel", speedLevel);
        PlayerPrefs.SetFloat("maxHealthLevel", maxHealthLevel);
        PlayerPrefs.SetFloat("maxCoinLevel", maxCoinLevel);
        PlayerPrefs.SetInt("damageCostLevel", damageCostLevel);
        PlayerPrefs.SetInt("speedCostLevel", speedCostLevel);
        PlayerPrefs.SetInt("maxHealthCostLevel", maxHealthCostLevel);
        PlayerPrefs.SetInt("maxCoinCostLevel", maxCoinCostLevel);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetInt("isSaved", 1);
        PlayerPrefs.Save();
    }
    public void LoadData()
    {
        moveSpeed = PlayerPrefs.GetFloat("moveSpeed", 3f);
        attackDamage = PlayerPrefs.GetInt("attackDamage", 5);
        maxHealth = PlayerPrefs.GetInt("maxHealth", 10);
        currentHealth = PlayerPrefs.GetInt("currentHealth", 10);
        coin = PlayerPrefs.GetInt("coin", 0);
        maxCoin = PlayerPrefs.GetInt("maxCoin", 50);
        damageLevel = PlayerPrefs.GetFloat("damageLevel", 0);
        speedLevel = PlayerPrefs.GetFloat("speedLevel", 0);
        maxHealthLevel = PlayerPrefs.GetFloat("maxHealthLevel", 0);
        maxCoinLevel = PlayerPrefs.GetFloat("maxCoinLevel", 0);
        damageCostLevel = PlayerPrefs.GetInt("damageCostLevel", 0);
        speedCostLevel = PlayerPrefs.GetInt("speedCostLevel", 0);
        maxHealthCostLevel = PlayerPrefs.GetInt("maxHealthCostLevel", 0);
        maxCoinCostLevel = PlayerPrefs.GetInt("maxCoinCostLevel", 0);
        masterVolume = PlayerPrefs.GetFloat("masterVolume", 0.5f);
    }
}