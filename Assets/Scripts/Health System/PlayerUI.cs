using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text text, text1, text2;
    private string health;
    private PlayerHealthComponent playerHealth;
    private int scrap;
    public void UpdateUI()
    {
        playerHealth = FindObjectOfType<PlayerHealthComponent>();
        float AmountOfLives = playerHealth.Currenthealth;
        text.text = "Player Lives: " + AmountOfLives;
        text1.text = "Scrap: " + scrap;
        text2.text = "Wave " + FindObjectOfType<WaveSystem>().wave;
    }
    public void adjustScrap(int amount)
    {
        scrap += amount;
    }
    public int scrapAmount()
    {
        return scrap;
    }
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthComponent>();
        if (playerHealth == null)
        {
            Debug.Log("Geen healthcomponent gedetecteerd.");
        }
        UpdateUI();

    }
}
