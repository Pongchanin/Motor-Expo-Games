using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject textincanvas;
    public GameObject object1;
    // Update is called once per frame
    void Update()
    {
        textincanvas.GetComponent<UnityEngine.UI.Text>().text = "value1 : " + object1.GetComponent<Player1_Controller>().noquicktime + "\n" + 
                                                                "value2 : " + object1.GetComponent<Player1_Controller>().moveSpeed;

    }
}
