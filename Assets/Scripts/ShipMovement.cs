using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.position += Vector3.Normalize(direction) * (Time.deltaTime * speed);
    }
}
