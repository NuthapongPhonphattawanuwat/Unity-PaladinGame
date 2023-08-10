using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;

    private void Start()
    {
        SetHealth(PlayerController.PlayerHealth,PlayerController.PlayerMaxHealth);
    }

    public void SetHealth(float playerHealth, float playerMaxHealth)
    {
        slider.value = playerHealth;
        slider.maxValue = playerMaxHealth;
        
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
