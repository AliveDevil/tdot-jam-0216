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
    void Update()
    {
        moveWithClick();
        moveWithWASD();
    }
    void moveWithWASD()
    {
        transform.Translate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }
    void moveWithClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform != null)
            {
                targetPosition = hit.point;
                transform.Translate(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, 0);
            }
        }

    }
}
