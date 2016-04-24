using UnityEngine;
using System.Collections;
using System;

public class CharacterController : MonoBehaviour
{
    private Vector3 targetPosition;

    public Vector3 TargetPosition
    {
        get { return targetPosition; }
        set { targetPosition = value; }
    }

    Ray ray;
    RaycastHit2D hit;
    Rigidbody2D myRigidBody;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        moveWithClick();
        moveWithWASD();
    }
    void moveWithWASD()
    {
        myRigidBody.MovePosition((Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
    void moveWithClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform != null)
            {
                targetPosition = hit.point;
                //myRigidBody.MovePosition(new Vector2(targetPosition.x, targetPosition.y));
                transform.Translate(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, 0);
            }
        }
    }

}
