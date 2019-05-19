using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public CharacterController character;
    public GameObject model;
    public GameObject[] modelParts;
    public Animator animator;
    public new Camera camera;

    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpHeight = 15f;
    public float gravityScale = 5f;
    public float rotateSpeed = 5f;
    public float bounceHeight = 5f;

    public bool isKnockedBack = false;
    public float knockbackPower = 3f;
    public float knockbackDuration = 0.5f;
    private float knockbackTimer;

    private bool grounded;
    private Vector3 motion;

    private void Awake()
    {
        instance = this;
        enabled = false;

        grounded = character.isGrounded;
    }

    private void Update()
    {
        if (grounded)
            motion.y = 0;

        if (isKnockedBack)
            CalculateMotionKnockback();
        else
            CalculateMotion();

        motion.y += gravityScale * Physics.gravity.y * Time.deltaTime;

        character.Move(motion * Time.deltaTime);

        grounded = character.isGrounded;

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(motion.x) + Mathf.Abs(motion.z));
    }

    private void CalculateMotion()
    {
        float currentHeight = motion.y;
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        motion = transform.forward * verticalInput + transform.right * horizontalInput;
        motion.Normalize();
        motion *= Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        motion.y = currentHeight;

        if (grounded && Input.GetButtonDown("Jump"))
        {
            AudioManager.instance.PlayEffect(AudioManager.SFX.Jump);
            motion.y = jumpHeight;
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation = Quaternion.Euler(0f, camera.transform.rotation.eulerAngles.y, 0f);

            model.transform.rotation = Quaternion.Slerp(
                model.transform.rotation,
                Quaternion.LookRotation(new Vector3(motion.x, 0f, motion.z)), 
                rotateSpeed * Time.deltaTime
            );
        }
    }

    private void CalculateMotionKnockback()
    {
        knockbackTimer -= Time.deltaTime;
        isKnockedBack = knockbackTimer > 0;

        motion = character.transform.forward * -knockbackPower;
    }

    public void Knockback()
    {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
    }

    public void Bounce()
    {
        motion.y = bounceHeight;
    }

    public void Debounce(float height)
    {
        motion.y = height;
    }
}
