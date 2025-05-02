using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;

    // Variabe que da accesso a todas las acciones en InputAction
    public InputActionAsset InputActions;

    // Variables relacionadas a las acciones
    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction jumpAction;
    private InputAction shieldAction;

    //private Animator animator;
    private Rigidbody2D rigidbody2D;

    // Variables para saltar y moverse
    public float MoveSpeed = 45f;
    public float JumpForce = 8000f;

    public Vector2 movementInput;

    // Habilitar el action map
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    // Deshabilitar el action map
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        // Mapear las acciones del action map a sus variables respectivas
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        shieldAction = InputSystem.actions.FindAction("Shield");
        attackAction = InputSystem.actions.FindAction("Attack");

        // Agarrar los componentes animator y rigidbody
        //animator = GetComponent<Animator>();
    }

    // Funciones para el movimiento
    public void Jump()
    {
        canJump = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
    }
    public void Move()
    {
        gameObject.transform.Translate(movementInput.x * MoveSpeed * Time.deltaTime, 0, 0);
    }

    // sdkbjglhbgds

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            Jump();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    // Colision en el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "floor")
        {
            canJump = true;   
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
}
