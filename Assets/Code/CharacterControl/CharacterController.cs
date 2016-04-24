using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 targetPosition;

    public Vector3 TargetPosition
    {
        get { return targetPosition; }
        set { targetPosition = value; }
    }

    private Ray ray;
    private RaycastHit2D hit;
    private Rigidbody2D myRigidBody;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveWithWASD();
        moveWithClick();
    }

    private void moveWithWASD()
    {
        myRigidBody.MovePosition((Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime);
    }

    private void moveWithClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null)
            {
                targetPosition = hit.point;
                myRigidBody.MovePosition(new Vector2(targetPosition.x, targetPosition.y));
            }
        }
    }
}