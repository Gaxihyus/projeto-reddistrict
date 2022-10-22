using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    [Header("Ground Check")]
    [SerializeField] private float bodyHeight;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private bool isMoving;

    private Rigidbody rb;
    private Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isMoving) rb.MovePosition(rb.position + moveDir * movementSpeed * Time.fixedDeltaTime);
        if (isGrounded) Jump();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        isMoving = context.performed;
        moveDir.x = context.ReadValue<Vector2>().x;
        moveDir.z = context.ReadValue<Vector2>().y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        isGrounded = context.action.triggered;
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, this.transform.localScale.y * 0.5f + 0.1f);
    }
}
