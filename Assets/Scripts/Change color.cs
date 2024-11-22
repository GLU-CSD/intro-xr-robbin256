using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Changecolor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Renderer renderer = other.GetComponent<Renderer>();
        Material mat = renderer.material;
        mat.color = Color.green;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Enter");
        Renderer renderer = other.GetComponent<Renderer>();
        Material mat = renderer.material;
        mat.color = Color.blue;
    }

}
