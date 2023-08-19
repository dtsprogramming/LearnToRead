using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float runSpeed = 20f;

    private Transform tf;
    private Rigidbody rb;
    private float hMove;
    private float vMove;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? runSpeed : moveSpeed;

        rb.velocity = new Vector3(hMove * speed * Time.fixedDeltaTime, 
            rb.velocity.y, vMove * speed * Time.fixedDeltaTime);
    }
}
