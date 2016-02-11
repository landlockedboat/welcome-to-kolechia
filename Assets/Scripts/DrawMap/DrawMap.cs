using UnityEngine;
using System.Collections;
using FreeWorld;

public class DrawMap : MonoBehaviour {
    DataMap dataMap;
    void Start () {
        dataMap = new DataMap(Constants.mapWidth, Constants.mapHeight);
        float horizontalOffset = (Constants.mapWidth / 2) * Constants.tileSize;
        float verticatOffset = (Constants.mapHeight / 2) * Constants.tileSize;
        for (int i = 0; i < Constants.mapWidth; i++)
        {
            for (int j = 0; j < Constants.mapHeight; j++)
            {
                Vector3 position = new Vector3(
                    i * Constants.tileSize - horizontalOffset,
                    j * Constants.tileSize - verticatOffset,
                    0);
                GameObject newTile = Instantiate(Resources.Load("Prefabs/tile_prefab"), position, Quaternion.identity) as GameObject;
                newTile.transform.parent = this.transform;
                newTile.name = "tile (" + i.ToString() + ", " + j.ToString() + ")";
                DrawTile drawComponent = newTile.GetComponent<DrawTile>();
                drawComponent.Initilalize(dataMap.GetTileAt(i, j));
            }
        }
    }
}
