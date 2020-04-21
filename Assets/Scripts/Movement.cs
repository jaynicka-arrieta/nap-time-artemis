using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidBody;
    private Collider2D collider;
    public float speed = 1;
    public float xMin;
    public float xMax;
    // Start is called before the first frame update
    void Start() {
        Debug.Log($"start");
        rigidBody = transform.GetComponent<Rigidbody2D>();
        collider = transform.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update() {
        float diff = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            diff -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            diff += speed * Time.deltaTime;
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            float jumpVelocity = 10f;
            rigidBody.velocity = Vector2.up * jumpVelocity;
        }

        transform.Translate(new Vector3(diff, 0, 0));

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
