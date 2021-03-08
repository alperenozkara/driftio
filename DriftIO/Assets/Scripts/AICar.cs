using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public float speed;
    public float steerSpeed;
    public float ball_swing_speed;
    public float ride_radius;
    [SerializeField]
    private GameObject target;
    public List<GameObject> p_list;
    public float target_distance;
    public bool is_Boosted;
    public bool is_Grounded;
    public GameObject ball;
    public bool is_Fail;
    public GameObject trails;
    private bool attack;
  
    void Start()
    {
       
        targetChange();
        
    }

  
    void Update()
    {
        if(is_Fail == true)
        {
            trails.SetActive(false);
            ball.SetActive(false);
        }
        if (is_Fail == false)
        {
           
            if (target.gameObject.transform.position.y < 0)
            {
                targetChange();
            }
            if (transform.position.y < -2f)
            {
                is_Fail = true;
            }

            Rope();
            if (transform.position.y > 2f)
            {
                is_Grounded = false;
                flip();
                gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
            }
            if (transform.position.y < 2f && transform.position.y > 0.8f)
            {
                is_Grounded = true;
                gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
            }
            if (is_Grounded)
            {

                trails.SetActive(true);
                if (target != null)
                {
                    target_distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
                    if (target_distance < 10 && target_distance > 8)
                    {
                        transform.RotateAround(gameObject.transform.position, Vector3.up, 300f * Time.deltaTime);
                    }
                    else
                    {
                        Move();
                    }
                }

            }
            else
            {
                trails.SetActive(false);
            }
        }

    }
    void Move()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * rb.mass);
        if (target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
            //transform.LookAt(target.transform.position);
        }
       
    }
    void fast()
    {
        
    }
    void flip()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y, 0), Time.deltaTime * 2f);
    }
    void Rope()
    {
        LineRenderer lr = ball.GetComponent<LineRenderer>();
        lr.SetPosition(0, ball.transform.position);
        lr.SetPosition(1, gameObject.transform.position);
    }
    

    void OnTriggerEnter(Collider coll) {

    }
    void OnTriggerExit(Collider coll) {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Car")
        {
           //target = null;
        }
    }


    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Ball") {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 explosionPoint = new Vector3(coll.contacts[0].point.x, coll.contacts[0].point.y-1.5f, coll.contacts[0].point.z);
            rb.AddExplosionForce(rb.mass * 350f, explosionPoint, 200f);
            Debug.Log("Hit from ball");
        }
        if (coll.gameObject.tag == "Car")
        {  
            Debug.Log("Car Hit");
            targetChange();
        }

    }
    void targetChange() {
        p_list = GameObject.FindGameObjectWithTag("Players").GetComponent<Players>().player_list;
        int x = Random.Range(0, p_list.Count);
        if(p_list[x] != gameObject)
        {
            target = p_list[x];  
        }
        if(p_list[x] == gameObject)
        {
            targetChange();
        }
    }
   
}
