using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerPlayerControls : MonoBehaviour {
    Gunner GunnerScript;
    GunnerBarrel GunnerBarrelScript;

    void Start() {
        GunnerScript = GetComponent<Gunner>();
        GunnerBarrelScript = transform.Find("Gunner-barrel").GetComponent<GunnerBarrel>();
    }

    void Update() {
        GunnerScript.PlayerFrame();
        GunnerBarrelScript.PlayerFrame();
    }
}
