using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Quaternion targetRotation;
    public float turningRate;
    public Camera camera;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            targetRotation *= Quaternion.Euler(0, -45, 0);
        }

        if (Input.GetKeyDown("e"))
        {
            targetRotation *= Quaternion.Euler(0, 45, 0);
        }

        if (transform.rotation != targetRotation)
        {
            // Turn towards our target rotation.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5*Time.deltaTime);
        }

        var ray = camera.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray, out var hit,100.0f)) {
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
    }

    private void FixedUpdate()
    {
        var vec = new Vector3();

        if (Input.GetKey("w"))
        {
            vec.x += 1;
        }

        if (Input.GetKey("s"))
        {
            vec.x -= 1;
        }

        if (Input.GetKey("a"))
        {
            vec.z += 1;
        }

        if (Input.GetKey("d"))
        {
            vec.z -= 1;
        }

        camera.orthographicSize = Math.Max(Math.Min(16, camera.orthographicSize + Input.GetAxis("Mouse ScrollWheel")), 2);

        GetComponent<Rigidbody>().AddForce(targetRotation * vec * 20);
    }
}