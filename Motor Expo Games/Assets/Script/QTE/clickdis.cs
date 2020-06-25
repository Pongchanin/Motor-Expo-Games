using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class clickdis : MonoBehaviour
{
    [Range(0.0f, 50f)]
    public float size;
    private float aztualsize;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        aztualsize = (size / 50) * (19.9f);
        this.GetComponent<RectTransform>().localScale = new Vector3(aztualsize, transform.localScale.y, transform.localScale.z);
    }
}

    //0
    //203


