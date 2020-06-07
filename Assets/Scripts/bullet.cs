using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 0.04f;

    float secondsTillDeath = 1f;

    public Vector3 velocity = Vector3.zero;

    void die () {
        Object.Destroy(gameObject);
    }

    void Update() {
        transform.position += transform.up * speed;

        secondsTillDeath -= Time.deltaTime;
        if (secondsTillDeath <= 0) die();
    }
}
