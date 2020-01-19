using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_l : MonoBehaviour
{
    public Vector3 speed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -speed;
        }
        else
            rb.velocity = new Vector3(0, 0, 0);
    }
}
