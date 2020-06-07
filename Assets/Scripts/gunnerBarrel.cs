using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerBarrel : MonoBehaviour {
    const float forwardOffset = 0.07f;

    public void lookAt (Vector3 target) {
        var diff = target - transform.parent.position;
        var direction = Quaternion.LookRotation(Vector3.forward, diff);

        transform.rotation = direction;
        transform.localPosition = Vector3.Normalize(diff) * forwardOffset;
    }
}
