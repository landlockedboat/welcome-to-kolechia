using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientNetworking : NetworkBehaviour {


    public void Start()
    {
     /*   if (isServer)
            return;
        GameObject[] spawnedVillagers = GameObject.FindGameObjectsWithTag("Villager");
        foreach (GameObject villager in spawnedVillagers)
        {
            NetworkMovementSync nms = villager.GetComponent<NetworkMovementSync>();
            nms.CmdGetLastServerDestination();
            Vector2 villagerServerPosition = nms.LastServerDestination;
            villager.transform.position = villagerServerPosition;
            EntityMovement em = villager.GetComponent<EntityMovement>();
            Debug.Log(villagerServerPosition);
            em.Destination = villagerServerPosition;
        }*/
    }


    // Update is called once per frame
    void Update () {
	
	}
}
