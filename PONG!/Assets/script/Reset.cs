using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    Vector3 ballStartPosition;
    public Vector3 pos;
    public Quaternion rot;
    public GameObject ball;
   
    // Start is called before the first frame update
    void Start()
    {

     
       
    }

  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(ball, pos,rot); 
        }
    }


}
