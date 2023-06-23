using UnityEngine;

public class mousemovement : MonoBehaviour
{
    [Header("Player Health Things")]
    private float playerHealth = 5f;
    public float presentHealth;

    [Header("player movement")]
    public float speed = 1.9f;
    public float playerSprint = 3f;
    [Header("player script cameras")]
    public Transform playerCamera;
    public GameObject EndGameMenuUI;

    [Header("player animator and gravitiy")]
    public CharacterController CharacterController;
    public float gravity = -9.81f;
    public Animator animator;
    [Header("player jumping and velocity")]
    public float turnCalculeteTime = 0.1f;
    float turnCalculateVelocity;
    public float jumpRange = 1f;
    Vector3 velocity;
    public Transform surfaceCheck;
    bool onSurface;
    public float surfaceDistence = 0.4f;
    public LayerMask surfaceLayerMask;

    void playerMove()
    {
        float horizontalaxis = Input.GetAxisRaw("Horizontal");
        float verticalaxis = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalaxis, 0f, verticalaxis).normalized;
        //Vector3 d = new Vector3(horizontalaxis, 0f, verticalaxis).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Sprint", false);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float ta = Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, ta, ref turnCalculateVelocity, turnCalculeteTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            CharacterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Sprint", false);
        }

    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        presentHealth = playerHealth;
    }

    //Update is called once per frame
    void Update()
    {

        onSurface = Physics.CheckSphere(surfaceCheck.position, surfaceDistence, surfaceLayerMask);
        if (onSurface && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime);
        playerMove();
        jump();
        sprint();
    }

    public void playerHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage;
        if (presentHealth <= 0)
        {
            animator.SetBool("die",true);
            PlayerDie();
        }
    }
    private void PlayerDie()
    {
        
        Cursor.lockState = CursorLockMode.None;
        //Object.Destroy(gameObject, 1.0f);
        EndGameMenuUI.SetActive(true);

    }
    void jump()
    {
        if (Input.GetButtonDown("Jump") && onSurface)
        {
            animator.SetBool("Idle", false);
            animator.SetTrigger("Jump");

            velocity.y = Mathf.Sqrt(jumpRange * -2 * gravity);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.ResetTrigger("Jump");

        }
    }
    void sprint()
    {
        if (Input.GetButton("Sprint") && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && onSurface)
        {
            float horizontalaxis = Input.GetAxisRaw("Horizontal");
            float verticalaxis = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontalaxis, 0f, verticalaxis).normalized;
            //Vector3 d = new Vector3(horizontalaxis, 0f, verticalaxis).normalized;

            if (direction.magnitude >= 0.1f)
            {

                animator.SetBool("Walk", false);
                animator.SetBool("Sprint", true);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float ta = Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, ta, ref turnCalculateVelocity, turnCalculeteTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                CharacterController.Move(moveDir.normalized * playerSprint * Time.deltaTime);
            }
            else
            {

                animator.SetBool("Walk", true);
                animator.SetBool("Sprint", false);
            }
        }

    }
   

}