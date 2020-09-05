using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3();
        if(Input.GetKey("w"))
            move += transform.forward;
        if(Input.GetKey("s"))
            move += -transform.forward;
        if(Input.GetKey("a"))
            move += -transform.right;
        if(Input.GetKey("d"))
            move += transform.right;
        transform.Translate(move/(100-speed));
    }
}
