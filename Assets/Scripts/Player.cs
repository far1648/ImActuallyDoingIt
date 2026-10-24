using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputActionReference pointerPosition;
    public float moveSpeed = 5f;
    private Vector2 pointerInput, movementInput;

    public WeaponParent weaponParent;
    Animator anim;
    Rigidbody2D Rb;
    void Awake()
    {
        Rb = GetComponentInParent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        UpdatePointer();

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Rb.MovePosition(Rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        
        if (movementInput.x != 0 || movementInput.y !=0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void UpdatePointer()
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
