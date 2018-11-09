using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid
{
    public GameObject gameObject;
    public Vector3 trajectory;
    public Asteroid(GameObject gameObject, Vector3 trajectory)
    {
        this.gameObject = gameObject;
        this.trajectory = trajectory;
    }
}