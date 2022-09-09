using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    Health health ;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void Start()
    {
        
        healthText.text = "HP: " + health.health.ToString("0");
    }

    private void OnEnable()
    {
        health.onHealthChangeFloat += updateHealthText;
    }
    private void OnDisable()
    {
        health.onHealthChangeFloat -= updateHealthText;
    }

    public void updateHealthText(float _health)
    {
        healthText.text = "HP: " + _health.ToString("0");
    }
   
}
