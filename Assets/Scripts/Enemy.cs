using UnityEngine;
using System.Collections;
using Fungus;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove;
    public float EnemySpeed;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    public bool _moveRight = true;
    public Animator animator;
    public Flowchart flowchart;


    // Use this for initialization
    public void Awake()
    {
         enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
    }


    // Update is called once per frame
    public void Update()
    {
        EnemySpeed = flowchart.GetFloatVariable("enemySpeed");
        if (_moveRight)
        {
            enemyRigidBody2D.velocity = Vector2.right * EnemySpeed;
            if (!_isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.velocity = Vector2.left * EnemySpeed;
            if (_isFacingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;


    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }
}