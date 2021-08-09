using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBoxActor : MonoBehaviour
{
    [SerializeField] float closeBoxDelayDuration;

    public IEnumerator boxCoseDelayer() 
    {
        yield return new WaitForSeconds(closeBoxDelayDuration);
        CloseTheBox();
    }
    public void CloseTheBox()
    {
        gameObject.SetActive(false);
    }
}
