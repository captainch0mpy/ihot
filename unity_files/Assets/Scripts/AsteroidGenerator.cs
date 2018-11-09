using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {

	public class Asteroid
	{
		private GameObject gameObject;
		private Vector3 trajectory;
    private float speed;
    private Vector3 rotation;
    public Asteroid(GameObject gameObject, Vector3 trajectory, float speed)
		{
				this.gameObject = gameObject;
				this.trajectory = trajectory;
				this.speed = speed;
        // this.rotation = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

		public Vector3 getTrajectory() {
      return this.trajectory;
    }
	  public void setTrajectory(Vector3 newTrajectory) {
      this.trajectory = newTrajectory;
    }

		public GameObject getGameObject() {
      return this.gameObject;
    }
	  public void setGameObject(GameObject newGameObject) {
      this.gameObject = newGameObject;
    }

		public float getSpeed() {
      return this.speed;
    }
	  public void setSpeed(float newSpeed) {
      this.speed = newSpeed;
    }

		public Vector3 getRotation() {
      return this.rotation;
    }
	  public void setRotation(Vector3 newRotation) {
      this.rotation = newRotation;
    }

		public void rotate() {
			this.gameObject.transform.Rotate(this.rotation);
		}
	}

  #region
  public GameObject[] asteroidPrefabs;
  public Asteroid[] asteroids;
  public Transform cage;
  private float cageRadius;
  #endregion

  void Fire(Asteroid asteroid) {
    asteroid.getGameObject().GetComponent<Rigidbody>().AddForce(asteroid.getTrajectory() * asteroid.getSpeed(), ForceMode.Impulse);
  }

  Asteroid CreateAsteroid(int prefabIndex) {
    return new Asteroid(
        Instantiate(
          asteroidPrefabs[prefabIndex], // prefab
          new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f)), // position
          new Quaternion(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) // rotation
        ) as GameObject,
        new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), // trajectory
        Random.Range(10.0f, 20.0f) // speed/force
      );
  } 
	void Start () {
    asteroids = new Asteroid[asteroidPrefabs.Length]; //makes sure they match length
    cageRadius = (cage.localScale.x / 2) * 100;
    // Instantiate all the asteroids
		for (int i = 0; i < asteroids.Length; i++) {
      asteroids[i] = CreateAsteroid(i);
      Fire(asteroids[i]); // Fire the asteroids :)
    }
	}
	
	// Update is called once per frame
	void Update () {
    for (int i = 0; i < asteroids.Length; i++) {
      // If the asteroid leaves the cage destroy and respawn it
      Debug.LogWarning(cageRadius);
      if (Vector3.Distance(asteroids[i].getGameObject().transform.position, cage.position) > cageRadius) {
        Destroy(asteroids[i].getGameObject());
        asteroids[i] = CreateAsteroid(i);
        Fire(asteroids[i]);
      }
    }
	}
}
