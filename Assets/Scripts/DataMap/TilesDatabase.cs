using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TilesDatabase
{
    private Dictionary<string, DataTile> tileDictionary;

    public TilesDatabase()
    {
        tileDictionary = new Dictionary<string, DataTile>();
        LoadDatabase();
    }

    public DataTile GetDataTile(string dataTileName)
    {
        if (tileDictionary.ContainsKey(dataTileName))
        {
            return tileDictionary[dataTileName];
        }
        else
        {
            Debug.LogError("Tile " + dataTileName + " does not exist in the database.");
            return null;
        }
    } 

    void LoadDatabase()
    {
        string[] tilesFile = System.IO.File.ReadAllLines("Assets/DB_IO/DB_Tiles.txt");
        Sprite[] tileSprites = Resources.LoadAll<Sprite>("Sprites/tileTextures");
        for (int i = 0; i < tilesFile.Length;)
        {
            string tileName = tilesFile[i++];
            int tileSpriteIndex = int.Parse(tilesFile[i++]);
            Sprite tileSprite;
            if (tileSpriteIndex >= 0 && tileSpriteIndex < tileSprites.Length)
            {
                tileSprite = tileSprites[tileSpriteIndex];
            }
            else
            {
                Debug.LogError("The tile sprite with index " + tileSpriteIndex.ToString() + " could not be loaded: out of bounds.");
                tileSprite = null;
            }
            tileDictionary[tileName] = new DataTile(
                tileName,
                tileSprite
                );
        }
    }

}
