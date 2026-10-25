using UnityEngine;

public class StaminaBarUI : MonoBehaviour
{
    public float Stamina, MaxStamina, Width, Height; //why is my naming so inconsistent? idk i saw tutorial at yt
    [SerializeField]
    private RectTransform staminaBar;

    public void SetMaxStamina(float maxStamina)
    {
        MaxStamina = maxStamina;
    }

    public void SetStamina(float stamina)
    {
        Stamina = stamina;
        float newWidth = (Stamina/MaxStamina) * Width;
        staminaBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
