using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FreeWorld;

[RequireComponent(typeof(NetworkMovementSync))]

public class VillagerPathfinding : EntityMovement {
    Queue<Direction> path;
    NetworkMovementSync networkMove;

    void Start () {
        path = new Queue<Direction>();
        networkMove = GetComponent<NetworkMovementSync>();
        if (!networkMove.IsServer)
            return;
        StartCoroutine("Roam");
	}
	
	void Update () {
        if (!networkMove.IsServer)
            return;
	    if(path.Count > 0 && !isMoving)
        {
            Direction currentDirection = path.Dequeue();
            networkMove.NextDirection = currentDirection;
            MoveTo(currentDirection);
        }
	}
    IEnumerator Roam()
    {
        while (true)
        {
            path.Enqueue((Direction)Random.Range(0, 4));
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
