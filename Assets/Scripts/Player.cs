using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputActionReference pointerPosition;
    private Vector2 pointerInput, movementInput;

    public WeaponParent weaponParent;
    void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    // Update is called once per frame
    void Update()
    {
        pointerInput = GetPointerInput();
        
        weaponParent.PointerPosition = pointerInput;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
