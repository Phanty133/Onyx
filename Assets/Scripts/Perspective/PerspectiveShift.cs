using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveShift : MonoBehaviour
{
    public Material lightMat;
    public Material darkMat;

    public GameObject player;
    public GameObject bgPlate;

    public GameObject lightObjs;
    public GameObject darkObjs;

    private bool toggled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")) {
            toggled = !toggled;
            if(toggled) {
                player.GetComponent<Renderer>().material = lightMat;
                bgPlate.GetComponent<Renderer>().material = darkMat;

                lightObjs.SetActive(false);
                darkObjs.SetActive(true);
            } else {
                player.GetComponent<Renderer>().material = darkMat;
                bgPlate.GetComponent<Renderer>().material = lightMat;

                lightObjs.SetActive(true);
                darkObjs.SetActive(false);
            }
        }
    }
}
