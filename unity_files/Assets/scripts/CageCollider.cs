using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageCollider : MonoBehaviour {

  #region 
  private bool collision = false;
  public Transform target;
  private Vector3 lastPosition = new Vector3(0, 0, 0);
  #endregion
  // Use this for initialization
  void Start () {
		lastPosition = target.position;
	}
	
	// Update is called once per frame
	void Update () {
    Debug.Log("collision: " + collision + ", last position: " + lastPosition);
    if (collision) {
			target.position = lastPosition;
		} else {
      lastPosition = target.position;
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
