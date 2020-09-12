using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camera_Control : MonoBehaviour
{
	public GameObject player;

	void Start()
	{

	}

	void Update()
	{
		if (player == null)
        {
			player = GameObject.Find("Canvas layer1").GetComponent<Localplayer>().THisislocalplayer;
		}

		transform.position = new Vector3(player.transform.position.x , player.transform.position.y , -29.804f);

	}
    private void LateUpdate()
    {

	}

}
