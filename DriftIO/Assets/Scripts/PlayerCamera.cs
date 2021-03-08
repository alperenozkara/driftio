using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform player_car;
    public float height,gap;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(player_car.position.x - gap, height, player_car.position.z);
    }
}
