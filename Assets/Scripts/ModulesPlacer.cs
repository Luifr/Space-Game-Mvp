using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesPlacer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform modules = transform.Find("Modules");
        foreach(Transform child in modules) {
            string name = child.gameObject.name;
            if (name.StartsWith("Pilot")) {
                child.position += new Vector3(0.5f, 0.5f, 0);
            }
            else if (name.StartsWith("Gunner")) {
                child.position += new Vector3(-0.5f, -0.5f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
