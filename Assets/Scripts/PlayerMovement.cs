using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            direction.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            direction.x -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            direction.x += 1;
        }
        transform.position += Vector3.Normalize(direction) * (Time.deltaTime * speed);
    }
}
