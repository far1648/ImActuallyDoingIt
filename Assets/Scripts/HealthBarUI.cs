using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float Health, MaxHealth, Width, Height; //why is my naming so inconsistent? idk i saw tutorial at yt
    [SerializeField]
    private RectTransform healthBar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (Health/MaxHealth) * Width;
        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
