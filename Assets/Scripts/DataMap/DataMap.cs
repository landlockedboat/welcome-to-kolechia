using UnityEngine;
using System.Collections;

public class DataMap {
    int width, height;
    DataTile[,] tilesMatrix;
    private TilesDatabase database;
    public DataMap(int _width, int _height)
    {
        tilesMatrix = new DataTile[_width, _height];
        database = new TilesDatabase();
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                tilesMatrix[i, j] = database.GetDataTile("grass");
            }
        }
    }
    public DataTile GetTileAt(int x, int y)
    {
        if(x < 0 || x >= tilesMatrix.GetLength(0) ||
            y < 0 || y >= tilesMatrix.GetLength(1))
        {
            Debug.LogError("GetTileAt: tile at (x: " + x.ToString() + ", y: " + y.ToString() + ") does not exist.");
            return null;
        }
        return tilesMatrix[x, y];
    }
}
