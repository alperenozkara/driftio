using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject[] s1, s2, s3, s4, s5, s6;
    public int currentfloor;
    void Start()
    {
        currentfloor = 6;
        Invoke("deleteFloors",20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void deleteFloors() {

        
        switch (currentfloor)
        {
            case 6:
                for (int i = 0; i < s1.Length; i++)
                {
                    s1[i].GetComponent<Rigidbody>().isKinematic = false;
                    s1[i].GetComponent<Rigidbody>().useGravity = true;
                    
                }
                currentfloor--;
                Invoke("deleteFloors", 20f);
                return;
            case 5:
                for (int i = 0; i < s2.Length; i++)
                {
                    s2[i].GetComponent<Rigidbody>().isKinematic = false;
                    s2[i].GetComponent<Rigidbody>().useGravity = true;
                   
                }
                currentfloor--;
                Invoke("deleteFloors", 20f);
                return;
            case 4:
                for (int i = 0; i < s3.Length; i++)
                {
                    s3[i].GetComponent<Rigidbody>().isKinematic = false;
                    s3[i].GetComponent<Rigidbody>().useGravity = true;
                   
                }
                currentfloor--;
                Invoke("deleteFloors", 20f);
                return;
            case 3:
                for (int i = 0; i < s4.Length; i++)
                {
                    s4[i].GetComponent<Rigidbody>().isKinematic = false;
                    s4[i].GetComponent<Rigidbody>().useGravity = true;
                    
                }
                currentfloor--;
                Invoke("deleteFloors", 20f);
                return;
            case 2:
                for (int i = 0; i < s5.Length; i++)
                {
                    s5[i].GetComponent<Rigidbody>().isKinematic = false;
                    s5[i].GetComponent<Rigidbody>().useGravity = true;
                   
                }
                currentfloor--;
                Invoke("deleteFloors", 20f);
                return;
            case 1:
                
                return;
        }
        
    }
}
