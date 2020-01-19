using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleR : MonoBehaviour
{
    public GameObject paddle1r;
    public Rigidbody rbr;
    public Vector3 P_speedr;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbr.velocity = P_speedr;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rbr.velocity = -P_speedr;
        }
        else
        {
            rbr.velocity = new Vector3(0, 0, 0);
        }
    }
}
