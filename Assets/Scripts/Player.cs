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

    [SerializeField] float health =  100, maxHealth = 100;
    [SerializeField] private HealthBarUI healthBar;
    float invisFrame = 1f;
    [SerializeField] float stamina = 30, maxStamina = 30;
    [SerializeField] private StaminaBarUI staminaBar;
    void Awake()
    {
        Rb = GetComponentInParent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        anim = GetComponentInChildren<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
    }

    void Update()
    {
        UpdatePointer();

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        if (invisFrame >= 0)
        {
            invisFrame -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Move();

        if (stamina < maxStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            SetStamina(Time.deltaTime * 7.5f);
        }
    }

    public void SetHealth(float healthChange)
    {
        health += healthChange;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.SetHealth(health);
    }
    public void SetStamina(float staminaChange)
    {
        stamina += staminaChange;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        staminaBar.SetStamina(stamina);
    }

    void Move()
    {
        if (stamina >= 0 && Input.GetKey(KeyCode.LeftShift) && (movementInput.x != 0 || movementInput.y !=0))
        {
            moveSpeed = 10f;
            lari = true;
            SetStamina(-Time.deltaTime * 10);
        } else
        {
            moveSpeed = 5f;
            lari = false;
        }
        
        Rb.MovePosition(Rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        
        if (movementInput.x != 0 || movementInput.y !=0)
        {
            if (moveSpeed == 5)
            {
                anim.SetBool("isWalking", true);
            }
            if (moveSpeed == 10)
            {
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Angrity" && invisFrame <= 0)
        {
            SetHealth(-10);
            invisFrame = 1;
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
