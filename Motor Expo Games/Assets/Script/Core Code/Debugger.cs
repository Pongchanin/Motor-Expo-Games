using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject textincanvas;
    public GameObject object1;
    charcustomizablecon test;
    // Update is called once per frame


    private void Awake()
    {
        test = object1.GetComponent<charcustomizablecon>();
    }
    void Update()
    {
        textincanvas.GetComponent<UnityEngine.UI.Text>().text = "power : " + test.array1[test.selected1].power + test.array2[test.selected2].power + test.array3[test.selected3].power + "\n" + 
                                                                "weight : " + test.array1[test.selected1].weight + test.array2[test.selected2].weight + test.array3[test.selected3].weight + "\n" +
                                                                "movement : " + test.array1[test.selected1].movementspeed + test.array2[test.selected2].movementspeed + test.array3[test.selected3].movementspeed + "\n" +
                                                                "strength : " + test.array1[test.selected1].strength + test.array2[test.selected2].strength + test.array3[test.selected3].strength
                                                                ;

        /*/
        boatstatus.Player1.weight = array1[selected1].weight + array2[selected2].weight + array3[selected3].weight;
        boatstatus.Player1.movementspeed = array1[selected1].movementspeed + array2[selected2].movementspeed + array3[selected3].movementspeed;
        boatstatus.Player1.strength = array1[selected1].strength + array2[selected2].strength + array3[selected3].strength;
        /*/
    }
}
