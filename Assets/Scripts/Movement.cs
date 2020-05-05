using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidBody;
    private Collider2D collider;
    private string facing;
    public Flowchart flowchart;
    public float speed;
    public float jumpVelocity;
    public float sprintSpeed;
    public float xMin;
    public float xMax;
    public Animator animator;
    public bool facingRight;
    // Start is called before the first frame update
    void Start() {
        Debug.Log($"start");
        rigidBody = transform.GetComponent<Rigidbody2D>();
        collider = transform.GetComponent<Collider2D>();
        flowchart = GameObject.FindObjectOfType<Flowchart>();
        speed = 0;
        facing = "right";
    }

    void FixedUpdate() {
                float diff = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            diff -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            diff += speed * Time.deltaTime;
        }

        
        transform.Translate(new Vector3(diff, 0, 0));
        animator.SetFloat("Speed", Mathf.Abs(diff));
        if (diff > 0 && !facingRight) {
            Flip();
        } else if (diff < 0 && facingRight) {
            Flip();
        }

        if (diff == 0) {
            animator.SetBool("isStanding", true);
        } else {
            animator.SetBool("isStanding", false);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        speed = flowchart.GetFloatVariable("currentSpeed");
        jumpVelocity = flowchart.GetFloatVariable("jumpSpeed");
        sprintSpeed = flowchart.GetFloatVariable("sprintSpeed");

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rigidBody.velocity = Vector2.up * jumpVelocity;
        }

        // There has to be a prettier way to check for jumping but I don't know it
        if (IsGrounded() == true)
        {
            animator.SetBool("isJumping", false);
        }

        else
        {
            animator.SetBool("isJumping", true);
        }


        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.S)) {
            string activeScene = SceneManager.GetActiveScene().name;
            if (activeScene == "level1") {
                SceneManager.LoadScene("level3");
            }
            
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void LateUpdate() {
        if (transform.position.x < xMin) {
            transform.position = new Vector3(xMin, transform.position.y);
        }

        if (transform.position.x > xMax) {
            transform.position = new Vector3(xMax, transform.position.y);
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.01f, platformLayerMask);
        return (raycastHit.collider != null);
    }
}
