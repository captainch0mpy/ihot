using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShipMovement : NetworkBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletEmitter;
    public float speed;
    public float shootModifier;
    public float bulletModifier;
    int shootTime = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (hasAuthority == false) {
            return;
        }
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
                Fire(shootTime);
            }
            shootTime = 0;
        }
    }

    void Fire(int shootTime)
    {
        // Create the Bullet from the Prefab
        GameObject bulletClone;
        bulletClone = Instantiate(bulletPrefab, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = bulletClone.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(transform.up * shootTime * bulletModifier, ForceMode.Impulse);

        // Destroy the bullet after 2 seconds
        Destroy(bulletClone, 5.0f);
    }

}
