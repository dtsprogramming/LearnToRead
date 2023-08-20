using UnityEngine;

[RequireComponent (typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float rotationSpeed = 600f;

    private Transform tf;
    private Rigidbody rb;
    private Animator anim;

    private float hRotation;
    private float vMove;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        AnimatePlayer();
    }

    private void GetInput()
    {
        vMove = Input.GetAxis("Vertical");
        hRotation = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? runSpeed : moveSpeed;

        Vector3 moveDirection = new Vector3(rb.velocity.x, rb.velocity.y, vMove).normalized;
        Vector3 moveAmount = moveDirection * speed * Time.fixedDeltaTime;
        tf.Translate(moveAmount, Space.Self);
    }

    private void RotatePlayer()
    {
        tf.Rotate(Vector3.up * hRotation * rotationSpeed * Time.deltaTime);
    }

    private void AnimatePlayer()
    {
        anim.SetFloat("zMove", vMove);
        anim.SetBool("isJumping", Input.GetKeyDown(KeyCode.Space));
    }
}
