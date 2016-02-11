using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using FreeWorld;

public class VillagerSpawning : NetworkBehaviour {
    public override void OnStartServer()
    {
        int horizontalOffset = (Constants.mapWidth / 2) * Constants.tileSize;
        int verticatOffset = (Constants.mapHeight / 2) * Constants.tileSize;
        for (int i = 0; i < 10; i++)
        {
            int posX = Random.Range(0, Constants.mapWidth / 2) - horizontalOffset / 2;
            int posY = Random.Range(0, Constants.mapHeight /2 ) - verticatOffset / 2;
            Vector3 spawnPos = new Vector3(posX, posY, 0);
            Debug.Log(spawnPos);
            NetworkServer.Spawn((GameObject)Instantiate(Resources.Load("Prefabs/villager_prefab"), spawnPos, Quaternion.identity));
        }
    }
}
