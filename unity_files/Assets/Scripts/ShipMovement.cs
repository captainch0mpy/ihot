using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public int speed;
    public int shootModifier;
    int shootTime = 0;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0)) {
            shootTime += 1;
        } else {
            if (shootTime > 0){
                rb.AddRelativeForce(Vector3.down * shootTime * shootModifier);
            }
            shootTime = 0;
        }
    }

}
