using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brain3: MonoBehaviour
{

    public GameObject paddle;
    public GameObject ball;
    public LayerMask layerMask;
    Rigidbody brb;
    float yvel;
    public float paddleMinY = -2.2f;
    public float paddleMaxY = 2.2f;
    public float paddleMaxSpeed = 20;
    public float numSaved = 0;
    public float numMissed = 0;
    

    ANN ann;

    // Use this for initialization
    void Start()
    {

        ann = new ANN(6, 1, 1, 4, 0.11);
        brb = ball.GetComponent<Rigidbody>();
    }

    List<double> Run(double bx, double by, double bvx, double bvy, double px, double py, double pv, bool train)
    {
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();
        inputs.Add(bx);
        inputs.Add(by);
        inputs.Add(bvx);
        inputs.Add(bvy);
        inputs.Add(px);
        inputs.Add(py);
        outputs.Add(pv);
        if (train)
            return (ann.Train(inputs, outputs));
        else
            return (ann.CalcOutput(inputs, outputs));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(paddle.GetComponent<Rigidbody>().position);
        //Debug.Log(ball.GetComponent<Rigidbody>().position);

        float posy = Mathf.Clamp(paddle.transform.position.y + (yvel * Time.deltaTime * paddleMaxSpeed),
                                 paddleMinY, paddleMaxY);
        paddle.transform.position = new Vector3(paddle.transform.position.x, posy, paddle.transform.position.z);

        List<double> output = new List<double>();

        // RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, brb.velocity, 1000, layerMask);
        RaycastHit hit;
       // Debug.DrawRay(ball.transform.position, brb.velocity.normalized * 1000, Color.white);

        if (Physics.Raycast(ball.transform.position,brb.velocity, out hit, 1000, layerMask))
        {
            Debug.DrawRay(ball.transform.position, brb.velocity.normalized * 1000, Color.red);
            //Debug.Log(hit.collider.name);


            //tops reflection calculation
            if (hit.collider.gameObject.tag == "tops") //reflect off top
            {
                //RaycastHit reflectHit;
                Vector3 reflection = Vector3.Reflect(brb.velocity, hit.normal);
                Vector3 offset = new Vector3(0, 0, -0.21f);
                //hit = Physics2D.Raycast(hit.point, reflection, 1000, layerMask);
                if (Physics.Raycast(hit.point, reflection, out hit, 1000, layerMask))
                {
                   // Debug.Log("HIT TOPS");
                    Debug.DrawRay(hit.point+offset, (reflection+offset).normalized * 1000, Color.blue);
                   
                }
            }

            // backwall ball position calculation
            if (hit.collider != null && hit.collider.gameObject.tag == "backwall")
            {
                float dy = (hit.point.y - paddle.transform.position.y);

                output = Run(ball.transform.position.x,
                                    ball.transform.position.y,
                                    brb.velocity.x, brb.velocity.y,
                                    paddle.transform.position.x,
                                    paddle.transform.position.y,
                                    dy, true);
                yvel = (float)output[0];

               // Debug.Log("HIT WALLL");

            }
        }
        else
            yvel = 0;





    }

}
