using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private bool _isGrounded;
    private bool _isJumping;
    private bool _isGameStarted;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (!_isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                _isGameStarted = true;
                
            }
            
            return; 
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = 1.0f;
        moveSpeed += 0.05f * Time.deltaTime;
        Vector3 movement = (transform.right * horizontal) + (transform.forward * vertical);
        transform.position += (movement * (moveSpeed * Time.deltaTime));
        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -5f, 5f);
        transform.position = pos;
        
        animator.SetFloat("Right", horizontal);
        animator.SetBool("IsJumping", _isJumping);
        animator.SetFloat("Forward", vertical);
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        
        _isJumping = Input.GetKeyDown(KeyCode.Space);
        _isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
