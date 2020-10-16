using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Camera_Multi : NetworkBehaviour
{
	public Player1_Controller_Solo player1Solo;
	public Player1_Controller player1;

	private Vector3 lastPLayerPosition;
	private float distanceToMove;

	public Vector3 offset;

	[Client]
	void Start()
	{
		player1Solo = GetComponentInParent<Player1_Controller_Solo>();
		lastPLayerPosition = player1Solo.transform.position;
	}

	void Update()
	{
		this.gameObject.SetActive(true);
		if (player1 != null)
		{
			distanceToMove = player1.transform.position.x - lastPLayerPosition.x;
			transform.position = new Vector3(transform.position.x, player1.transform.position.y, 0) + offset;
			lastPLayerPosition = player1.transform.position;
		}
		else
		{

			distanceToMove = player1Solo.transform.position.x - lastPLayerPosition.x;
			transform.position = new Vector3(transform.position.x, player1Solo.transform.position.y, 0) + offset;
			lastPLayerPosition = player1Solo.transform.position;
		}

	}
    private void LateUpdate()
    {
		
		
	}
}
