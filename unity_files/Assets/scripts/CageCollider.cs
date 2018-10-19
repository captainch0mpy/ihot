﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CageCollider : MonoBehaviour {

  #region
  public Rigidbody ship;
  private Rigidbody cage;
  private bool collision = false;
  private int impulseForce = 6000;
  private Vector3 lastPosition = new Vector3(0, 0, 0);
  #endregion
  // Use this for initialization
  void Start () {
    cage = GetComponent<Rigidbody>();
    lastPosition = ship.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    Debug.Log("collision: " + collision + ", last position: " + lastPosition);
    if (collision) {
      ship.AddForce(-ship.velocity.normalized * impulseForce * Time.deltaTime, ForceMode.Impulse);
    } else {
      lastPosition = ship.transform.position;
    }
	}

	private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      Go();
    }
	}

	private void OnTriggerExit(Collider other) {
    if (other.tag == "Player") {
      Stop();
    }
  }

	private void Stop() {
    collision = true;
  }

	private void Go() {
    collision = false;
  }
}
