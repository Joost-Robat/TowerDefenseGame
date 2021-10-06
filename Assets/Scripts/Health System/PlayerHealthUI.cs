using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Text text;
    private string health;
    private PlayerHealthComponent playerHealth;
    public void UpdateUI()
    {
        playerHealth = FindObjectOfType<PlayerHealthComponent>();
        float AmountOfLives = playerHealth.Currenthealth;
        text.text = "Player Lives: " + AmountOfLives;
    }
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthComponent>();
        if(playerHealth == null)
        {
            Debug.Log("Geen healthcomponent gedetecteerd.");
        }
        UpdateUI();

    }
}
