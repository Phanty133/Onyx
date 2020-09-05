using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 60;

    public GameObject cameraObj;
    public GameObject playerModel;

    private Queue<Vector3> cameraMoveQueue = new Queue<Vector3>();
    private int delayCounter = 0;
    private int moveDelayCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {
            moveDelayCounter = moveDelayCounter < 10 ? moveDelayCounter+1 : 10;
            Debug.Log(moveDelayCounter);
        } else {
            moveDelayCounter = 0;
        }
        Vector3 move = new Vector3();
        if(Input.GetKey("w"))
            move += transform.forward;
        if(Input.GetKey("s"))
            move += -transform.forward;
        if(Input.GetKey("a"))
            move += -transform.right;
        if(Input.GetKey("d"))
            move += transform.right;
        //playerModel.transform.Translate(move/(100-speed));
        Rigidbody playerBody = playerModel.GetComponent<Rigidbody>();
        playerBody.velocity = move*speed/7/(11-moveDelayCounter);
        move = playerBody.velocity == Vector3.zero ? Vector3.zero : move;
        Vector3 cameraMove = -new Vector3(cameraObj.transform.position.x-playerModel.transform.position.x, cameraObj.transform.position.z-playerModel.transform.position.z, 0)/2;
        if(delayCounter < 60) {
            cameraMoveQueue.Enqueue(cameraMove);
            delayCounter++;
        } else {
            cameraObj.transform.Translate(cameraMoveQueue.Dequeue()/(100-speed));
            cameraMoveQueue.Enqueue(cameraMove);
        }
    }
}
