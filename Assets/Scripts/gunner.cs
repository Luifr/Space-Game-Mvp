using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gunner : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab = null;

    [SerializeField]
    float shootCooldown = 200; // Shooting priod. Measured in milisseconds / shots

    System.DateTime lastShotTimestamp = new System.DateTime(0);

    private bool canShoot () {
        var milissecondsSinceLastShot = System.DateTime.Now.Subtract(lastShotTimestamp).TotalMilliseconds;
        return milissecondsSinceLastShot >= shootCooldown;
    }

    private void shoot () {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        var diff = mousePosition - transform.position;
        var bulletDirection = Quaternion.LookRotation(Vector3.forward, diff);

        var bullet = Instantiate(BulletPrefab, transform.position, bulletDirection);
        lastShotTimestamp = System.DateTime.Now;
    }

    private void shootIfPossible () {
        if (canShoot()) shoot();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) shootIfPossible();
    }
}
