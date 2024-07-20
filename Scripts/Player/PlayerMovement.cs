using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public Rigidbody rb;
    public Animator anim;
    private GameManager manager;

    public CheckpointSystem checkpoint;

    [SerializeField] private GameObject deathParticles;

    [Header("Animator Parameters")]
    [SerializeField] private string speedAnimParam = "Speed";
    [SerializeField] private string jumpAnimParam = "Jump";
    [SerializeField] private string groundedAnimParam = "Grounded";
    [SerializeField] private string freeFallAnimParam = "FreeFall";

    public AudioSource footsteps;
    public AudioSource jump;

    private Vector3 inputMove = Vector3.zero;
    private Vector3 smoothInputMove = Vector3.zero;
    private bool inputJump = false;
    private bool inputRun = false;
    
    private P1Input controls;

    [Header("Movement and Orbit")]
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float inAirSpeedFactor = .5f;
    [SerializeField] private float turnAngularSpeed = 6f;
    [SerializeField] private float jumpImpulse = 5f;
    [SerializeField] private float movementLerpSpeed = 17.5f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = .175f;

    private bool jumpedThisFrame;
    public bool isGrounded;
    private bool isFreeFalling;
    private float speed;
    private float turnSmoothVelocity;

    void Start() {
        cam = GameObject.Find("MC"+this.gameObject.name).GetComponent<Transform>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = checkpoint.spawnPoint;
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("DeathBox")) {
            print("DEAD");
            Die();
        }
    }

    void Update() {
        isGrounded = CheckGround();
        isFreeFalling = CheckFreeFalling();
        UpdateAnimatorParameters();
    }

    public void Die() {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        manager.dead = true;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        inputMove = Vector3.zero;
        Vector2 move = ctx.ReadValue<Vector2>();
        inputMove.x = move.x;
        inputMove.z = move.y;
        if(inputMove.magnitude >= 0.01f) 
            smoothInputMove = Vector3.Lerp(smoothInputMove, inputMove, runSpeed);
        else
            smoothInputMove = Vector3.zero;
    }

    public void OnJump(InputAction.CallbackContext ctx) {
        if(ctx.performed && isGrounded)
            jumpedThisFrame = true;
    }

    public void OnHold(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            Collider[] colliders = Physics.OverlapSphere(transform.position+0.5f*Vector3.up, 1.5f);
            foreach (var collider in colliders) {
                if(collider.gameObject.name == "Block"+this.gameObject.name) {
                    collider.gameObject.GetComponent<Holdable>().Hold();
                    break;
                }
            }
        }
    }

    private void UpdateAnimatorParameters() {
        anim.SetFloat(speedAnimParam, speed/runSpeed);
        anim.SetBool(groundedAnimParam, isGrounded);
        anim.SetBool(freeFallAnimParam, isFreeFalling);
    }

    private bool CheckGround() {
        return Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);
    }

    private bool CheckFreeFalling() {
        return Mathf.Abs(rb.velocity.y) > runSpeed;
    }

    private void FixedUpdate() {
        Jump();
        Move(Time.fixedDeltaTime);
    }

    public void DoJump(float factor) {
        this.gameObject.transform.parent = null;
        jumpedThisFrame = false;
        rb.AddForce(Vector3.up * factor * jumpImpulse, ForceMode.Impulse);
        jump.Play();
        anim.SetTrigger(jumpAnimParam);
    }

    private void Jump() {
        if(jumpedThisFrame && isGrounded) {
            DoJump(1f);
        }
    }

    private void Move(float delta) {
        float targetSpeed = smoothInputMove.magnitude * (inputRun ? runSpeed : walkSpeed);
        speed = Mathf.Lerp(speed, targetSpeed, delta * movementLerpSpeed);

        if(jumpedThisFrame) {
            Vector3 velocity = rb.transform.forward * speed * inAirSpeedFactor;
            rb.velocity += velocity;
            jumpedThisFrame = false;
            return;
        }

        if(inputMove == Vector3.zero) {
            if(footsteps.isPlaying && isGrounded || !isGrounded)
                footsteps.Stop();
            return;
        } else {
            if(!footsteps.isPlaying || !isGrounded)
                footsteps.Play();
        }

        if(!isGrounded) {
            delta *= inAirSpeedFactor;
        }


        Vector3 direction = cam.transform.TransformVector(smoothInputMove);
        direction.y = 0;
        direction.Normalize();
        
        rb.transform.forward = Vector3.Slerp(rb.transform.forward, direction, turnAngularSpeed * delta);

        Vector3 position = rb.position + rb.transform.forward * speed * delta;
        rb.MovePosition(position);
        
    }
}
