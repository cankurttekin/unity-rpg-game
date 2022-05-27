using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour
{
    public Text bossName;
    Slider slider;
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }
    public void SetBossName(string name)
    {
        bossName.text = name;
    }

    public void SetHealthBarActive()
    {
        slider.gameObject.SetActive(true);
    }

    public void SetBossMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetBossCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
