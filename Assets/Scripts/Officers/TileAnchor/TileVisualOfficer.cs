using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVisualOfficer : MonoBehaviour
{
    [SerializeField] Color oddColor, evenColor;
    [SerializeField] SpriteRenderer spriteRendererOfTheTile;
    [SerializeField] Transform highlight;

    public void ColorTheTile(bool even)
    {
        spriteRendererOfTheTile.color = (even) ? evenColor : oddColor;
    }

    public void HighlightController(bool state) 
    {
        highlight.gameObject.SetActive(state);
    }
}
