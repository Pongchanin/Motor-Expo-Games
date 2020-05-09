using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
	public Player1_Controller player1;

	private Vector3 lastPLayerPosition;
	private float distanceToMove;

	void Start()
	{
		player1 = FindObjectOfType<Player1_Controller>();
		lastPLayerPosition = player1.transform.position;
	}

	void Update()
	{
		distanceToMove = player1.transform.position.x - lastPLayerPosition.x;

		transform.position = new Vector2(transform.position.x + distanceToMove, player1.transform.position.y);

		lastPLayerPosition = player1.transform.position;
	}
}
