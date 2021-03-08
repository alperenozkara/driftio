using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public Vector2 mousePos;
    public GameObject endPanel;
    public float speed;
    public float steerSpeed;
    public float ball_swing_speed;
    public bool is_Grounded;
    public bool is_Boosted;
    public bool is_Fail;
    public GameObject trails;
    public GameObject ball;

    void Start()
    {
       
    }

    
    void Update()
    {
        if (is_Fail == true)
        {
            endPanel.SetActive(true);
            trails.SetActive(false);
            ball.SetActive(false);
            
        }
        if (is_Fail == false)
        {
           
            if (transform.position.y < -2f)
            {
                is_Fail = true;
            }
            if (transform.position.y > 1.1f)
            {
                is_Grounded = false;
            }
            if (transform.position.y < 1.1f && transform.position.y > 0.8f)
            {
                is_Grounded = true;
            }
            Rope();
            fast();
            if (is_Grounded)
            {
                trails.SetActive(true);
                Move();
                Turn();
            }
            else
            {
                trails.SetActive(false);
                Turn();
                flip();
            }
        }
        //GET MOUSE POSITION CENTER AS ZERO FOR EDITOR TESTS
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePos.x -= 0.5f;
        mousePos.y -= 0.5f;
        //GET TOUCH POSITION FOR BUILD

    }

    void flip() {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y, 0), Time.deltaTime * 50f);
    }
    void Move() {   
         Rigidbody rb = gameObject.GetComponent<Rigidbody>();
         rb.AddForce(transform.forward*speed*rb.mass);
    }
    void Turn() {
        
        if (mousePos.x > 0)
        {   
            transform.Rotate(Vector3.up * steerSpeed * 0.1f * mousePos.x);
            ball.GetComponent<Rigidbody>().AddForce(-ball.transform.up * ball_swing_speed * mousePos.x);
           
        }
        if (mousePos.x < 0)
        {
            transform.Rotate(Vector3.up * steerSpeed * 0.1f * mousePos.x);
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.up * ball_swing_speed * -mousePos.x);

        }
        
    }
    void fast() {
        if (is_Boosted) {
            ball.transform.RotateAround(transform.position, Vector3.up, 300f * Time.deltaTime);
        }  
        

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            if (coll.gameObject.tag == "Ball")
            {
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                Vector3 explosionPoint = new Vector3(coll.contacts[0].point.x, coll.contacts[0].point.y - 1.5f, coll.contacts[0].point.z);
                rb.AddExplosionForce(rb.mass * 350f, explosionPoint, 200f);
                Debug.Log("Hit from ball");
            }
        }
        
    }
    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Jumper")
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * rb.mass * 500f);
        }
    }
    
    void Rope() {
        LineRenderer lr = ball.GetComponent<LineRenderer>();
        lr.SetPosition(0, ball.transform.position);
        lr.SetPosition(1, gameObject.transform.position);
    }
    public void PlayAgain() {
        
        SceneManager.LoadScene(0);
        
    }

}
