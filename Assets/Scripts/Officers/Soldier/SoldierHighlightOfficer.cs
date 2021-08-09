using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHighlightOfficer : MonoBehaviour
{
    [SerializeField] Transform highlight;

    public void Highlight(bool state) 
    {
        highlight.gameObject.SetActive(state);
    }
}
