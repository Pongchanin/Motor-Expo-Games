using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camera_Control : MonoBehaviour
{
	public Player1_Controller player1;

	private Vector3 lastPLayerPosition;
	private float distanceToMove;

	public Vector3 offset;

	void Start()
	{
		player1 = FindObjectOfType<Player1_Controller>();
		lastPLayerPosition = player1.transform.position;
	}

	void Update()
	{
		distanceToMove = player1.transform.position.x - lastPLayerPosition.x;
		transform.position = new Vector3(transform.position.x + distanceToMove, player1.transform.position.y) + offset;
		lastPLayerPosition = player1.transform.position;
	}
    private void LateUpdate()
    {
		
		
	}
}
