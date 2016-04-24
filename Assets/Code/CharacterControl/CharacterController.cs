using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	private PathFindingAgent agent;
	private RaycastHit2D hit;
	private Rigidbody2D myRigidBody;
	private Ray ray;
	private Vector3 targetPosition;

	public Vector3 TargetPosition
	{
		get
		{
			return targetPosition;
		}
		set
		{
			targetPosition = value;
		}
	}

	private void Awake()
	{
		agent = GetComponent<PathFindingAgent>();
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		moveWithWASD();
	}

	private void moveWithClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.transform != null)
			{
				agent.Move(hit.point.ToPoint());
			}
		}
	}

	private void moveWithWASD()
	{
		var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (input.magnitude > 0)
		{
			agent.MovePosition(myRigidBody.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime);
		}
	}

	private void Update()
	{
		moveWithClick();
	}
}
