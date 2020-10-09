using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class QTEPressed : NetworkBehaviour
{
    // Start is called before the first frame update
    public bool isClicked;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setIsClicked()
    {
        if (isLocalPlayer)
        {
            isClicked = true;
        }
        
    }


}
