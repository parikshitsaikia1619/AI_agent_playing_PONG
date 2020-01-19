using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class moveball3d : MonoBehaviour
{

    Vector3 ballStartPosition;
    Rigidbody rb;
    public float speed = 8;
    public GameObject paddle_L, paddle_r;
    public Material Red, Blue,def;
    public Renderer Rend;
    public Text score_l, score_r;
    int sl = 0, sr = 0;
    public AudioSource blip, blop;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        ballStartPosition = this.transform.position;
        ResetBall();
        Rend.sharedMaterial = def;

    }

    void OnCollisionEnter(Collision col)
    {
      
        if(col.gameObject.name =="paddle_l")
        {

            blip.Play();
            Rend.sharedMaterial = Red;
        }
        if (col.gameObject.name == "paddle_r")
        {

            blop.Play();
            Rend.sharedMaterial = Blue;

        }

        if (col.gameObject.name == "bwall_l")
        {
            sr++;
            score_r.text = sr.ToString();
            ResetBall();
           // Destroy(gameObject);

        }

        if (col.gameObject.name == "bwall_r")
        {
            sl++;
            score_l.text = sl.ToString();
            ResetBall();
            // Destroy(gameObject);

        }

        if (col.gameObject.tag == "tops")
        {
            rb.AddForce(0, -rb.velocity.normalized.y * speed*10, 0);
           // Debug.Log("tops");
        }


    }
    public void ResetBall()
    {
        this.transform.position = ballStartPosition;
        Rend.sharedMaterial = def;
        rb.velocity = Vector3.zero;
        Vector3 dir = new Vector3(Random.Range(-100, 100), Random.Range(-50, 50), 0).normalized;
        rb.velocity = (dir * speed);
    }



        // Update is called once per frame
        void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            sl = 0;
            sr = 0;
            score_l.text = sl.ToString();
            score_r.text = sr.ToString();
            ResetBall();
        }
        rb.velocity = rb.velocity.normalized * speed;

        //Debug.Log(rb.velocity.magnitude);
    }
   

}
