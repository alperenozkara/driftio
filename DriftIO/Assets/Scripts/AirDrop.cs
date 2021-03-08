using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrop : MonoBehaviour
{
    public GameObject dropPrefab;
    void Start()
    {
        Invoke("sendDrop", 5f);
    }

    
    void Update()
    {
        
    }

    void sendDrop() {
        GameObject drop = Instantiate(dropPrefab, new Vector3(Random.Range(-15f, 15f), 12.5f, Random.Range(-15f, 15f)), Quaternion.identity) as GameObject;
        
    }
}
