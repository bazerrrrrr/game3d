using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthView : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI healthText;

    public void Show(float current, float max)
    {
        healthBar.fillAmount = current / max;
        if (healthText != null)
        {
            healthText.text = current + " / " + max;
        }
    }
}
