using UnityEngine;
using System.Collections;

public class DrawTile : MonoBehaviour {
    SpriteRenderer spriterenderer;
    public void Initilalize(DataTile dTile)
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.sprite = dTile.Sprite;
    }
}
