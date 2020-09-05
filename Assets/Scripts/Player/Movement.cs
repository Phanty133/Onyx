using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 60;

    public GameObject camera;
    public GameObject playerModel;

    private Queue<Vector3> cameraMoveQueue = new Queue<Vector3>();
    private int delayCounter = 0;
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
        playerModel.transform.Translate(move/(100-speed));
        if(delayCounter < 60) {
            cameraMoveQueue.Enqueue(new Vector3(move.x, move.z, move.y));
            delayCounter++;
        } else {
            camera.transform.Translate(cameraMoveQueue.Dequeue()/(100-speed));
            cameraMoveQueue.Enqueue(new Vector3(move.x, move.z, move.y));
        }
    }
}
