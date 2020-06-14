using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotModule : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    ShipMovement shipMovement;

    // Start is called before the first frame update
    void Start()
    {
        shipMovement = transform.parent.parent.GetComponent<ShipMovement>();
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

        shipMovement.Move(Vector3.Normalize(direction), speed);

    }
}
