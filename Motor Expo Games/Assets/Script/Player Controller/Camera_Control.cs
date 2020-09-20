using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camera_Control : MonoBehaviour
{
	public Player1_Controller_Solo player1Solo;
	public Player1_Controller player1;

	private Vector3 lastPLayerPosition;
	private float distanceToMove;

	public Vector3 offset;

	void Start()
	{
		if(FindObjectOfType<Player1_Controller>() != null)
        {
			player1 = FindObjectOfType<Player1_Controller>();
			lastPLayerPosition = player1.transform.position;
		}
        else
        {
			player1 = null;
			player1Solo = FindObjectOfType<Player1_Controller_Solo>();
			lastPLayerPosition = player1Solo.transform.position;
		}
		
	}

	void Update()
	{
		if(player1 != null)
        {
			distanceToMove = player1.transform.position.x - lastPLayerPosition.x;
			transform.position = new Vector3(transform.position.x + distanceToMove, player1.transform.position.y, transform.position.z) + offset;
			lastPLayerPosition = player1.transform.position;
		}
        else
        {
			distanceToMove = player1Solo.transform.position.x - lastPLayerPosition.x;
			transform.position = new Vector3(transform.position.x + distanceToMove, player1Solo.transform.position.y, transform.position.z) + offset;
			lastPLayerPosition = player1Solo.transform.position;
		}
		
	}
    private void LateUpdate()
    {
		
		
	}
}
