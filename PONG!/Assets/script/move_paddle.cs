using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_paddle : MonoBehaviour
{
    public GameObject paddle;
    public GameObject ball;
    public float yvel1=0, paddleMaxSpeed= 15;
    float paddleMinY = -2.2f, paddleMaxY = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
       
        if(Input.GetKey(KeyCode.UpArrow))
        {
            yvel1 = 0.3f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yvel1 = -0.3f;
        }

        float posy = Mathf.Clamp(paddle.transform.position.y + (yvel1 * Time.deltaTime * paddleMaxSpeed),
                                 paddleMinY, paddleMaxY);
        paddle.transform.position = new Vector3(paddle.transform.position.x, posy, paddle.transform.position.z);
    }
}