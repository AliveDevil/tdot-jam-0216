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
        if (Input.GetMouseButtonDown(0))
        {
           hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform != null)
            {
                targetPosition = hit.point;
                move();
            }
        }
    }
    void move()
    {
        transform.position = targetPosition;
    }
}
