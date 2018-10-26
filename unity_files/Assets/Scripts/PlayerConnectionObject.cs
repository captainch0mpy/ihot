using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour {

    public GameObject ShipPrefab;

    // Use this for initialization
	void Start () {
        // Is this my local player object
        if(isLocalPlayer == false) {
            //This object belongs to another player
            return;
        }

        // Give the player, which is invisible, something to control
        // Command the server to spawn our unit
        CmdSpawnShip();
	}
	
	// Update is called once per frame
	void Update () {
        // Remember: this runs on everyone's computer regardless of whether or not they own this particular playerobject
	}

    // Commands are special functions that only get executed on the server.
    [Command]
    void CmdSpawnShip () {
        // Create on the server
        GameObject go = Instantiate(ShipPrefab);

        // Propogate to all clients and wire up network identity
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
