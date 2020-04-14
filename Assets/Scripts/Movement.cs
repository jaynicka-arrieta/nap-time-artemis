using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidBody;
    private Collider2D collider;
    public float speed = 1;
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
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.01f, platformLayerMask);
        return (raycastHit.collider != null);
    }
}
