using UnityEngine;
using System.Collections;

public class DataTile
{
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
    }
    private Sprite sprite;
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
    public DataTile(string _name, Sprite _tileSprite)
    {
        name = _name;
        sprite = _tileSprite;
    }
}
