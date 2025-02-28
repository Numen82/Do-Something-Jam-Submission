using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    [SerializeField] private float moveSpeed;

    private bool isMoving;
    private bool isStopped;

    private bool mLeft;
    private bool mRight;
    private bool mUp;
    private bool mDown;

    void Start()
    {
        isStopped = true;
        mLeft = mRight = mUp = mDown = true;
        RestrictMove();
    }

    // Update is called once per frame
    void Update()
    {
        float dirctX = Input.GetAxisRaw("Horizontal");
        float dirctY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("d") && !isMoving && isStopped && mRight)
        {
            RestrictReset();
            isMoving = true;
            isStopped = false;
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        }
        else if (Input.GetKeyDown("a") && !isMoving && isStopped && mLeft)
        {
            RestrictReset();
            isMoving = true;
            isStopped = false;
            myRigidBody.velocity = new Vector2(moveSpeed * -1, myRigidBody.velocity.y);
        }
        else if (Input.GetKeyDown("w") && !isMoving && isStopped && mUp)
        {
            RestrictReset();
            isMoving = true;
            isStopped = false;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed);
        }
        else if (Input.GetKeyDown("s") && !isMoving && isStopped && mDown)
        {
            RestrictReset();
            isMoving = true;
            isStopped = false;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed * -1);
        }

        if (myRigidBody.velocity == Vector2.zero)
        {
            isMoving = false;
            isStopped = true;
            RestrictMove();
        }
    }

    public void RestrictMove()
    {
        float up = Physics2D.Raycast(transform.position, Vector2.up).distance;
        float right = Physics2D.Raycast(transform.position, Vector2.right).distance;
        float down = Physics2D.Raycast(transform.position, Vector2.down).distance;
        float left = Physics2D.Raycast(transform.position, Vector2.left).distance;

        RestrictReset();
        if (up < 1)
        {
            mUp = false;
        }
        if (right < 1)
        {
            mRight = false;
        }
        if (down < 1)
        {
            mDown = false;
        }
        if (left < 1)
        {
            mLeft = false;
        }

        Debug.Log($"{up} {right} {down} {left}");
    }

    public void RestrictReset()
    {
        mLeft = mRight = mUp = mDown = true;
    }
}
