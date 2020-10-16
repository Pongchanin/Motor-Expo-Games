using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class arrow : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float value;
    private bool left_right = true;
    private float actualvalue;
    private float actactualvalue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualvalue = (value / 100) * 412;
        actactualvalue = actualvalue - 206;
        this.GetComponent<RectTransform>().localPosition = new Vector3(actactualvalue, -285, 0);



        if (value >= 100 || value <= 0)
        {
            left_right = !left_right;
        }

        if (left_right)
        {
            value += 3;
        }
        else
        {
            value -= 3;
        }
    }
}
