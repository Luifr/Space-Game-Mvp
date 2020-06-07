using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunnerBarrel : MonoBehaviour {
    const float forwardOffset = 0.07f;

    void Update() {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        var diff = mousePosition - transform.parent.position;
        var direction = Quaternion.LookRotation(Vector3.forward, diff);

        transform.rotation = direction;
        transform.localPosition = Vector3.Normalize(diff) * forwardOffset;
    }
}
