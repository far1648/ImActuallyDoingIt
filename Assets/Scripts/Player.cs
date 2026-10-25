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
    public bool lari = false;

    [SerializeField]int health =  100;
    [SerializeField]float stamina = 100;
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

        if (stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime * 10;
        }
    }

    void Move()
    {
        if (stamina >= 0 && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
            anim.SetBool("isRunning", true);
            lari = true;
            stamina -= Time.deltaTime * 10;
        } else
        {
            moveSpeed = 5f;
            anim.SetBool("isRunning", false);
            lari = false;
        }
        
        Rb.MovePosition(Rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        
        if (movementInput.x != 0 || movementInput.y !=0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
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
