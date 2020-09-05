using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveShift : MonoBehaviour
{
    public Material backgroundMat;
    public Material playerMat;

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
                playerMat.SetColor("_Color", Color.white);
                backgroundMat.SetColor("_Color", Color.black);

                lightObjs.SetActive(false);
                darkObjs.SetActive(true);
            } else {
                playerMat.SetColor("_Color", Color.black);
                backgroundMat.SetColor("_Color", Color.white);

                lightObjs.SetActive(true);
                darkObjs.SetActive(false);
            }
        }
    }
}
