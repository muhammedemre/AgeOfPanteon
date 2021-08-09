using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOfficer : MonoBehaviour
{
    [SerializeField] Color min, max;
    [SerializeField] Slider sliderOfHpBar;
    [SerializeField] Transform hpBar;
    public GameObject currentHpBar;
    [SerializeField] Vector3 offsetForTheBar;

    public void UpdateSliderWithCurrentHealth(float health, bool firstUpdate)
    {
        if (firstUpdate)
        {
            Transform tempHpBar = Instantiate(hpBar, UIManager.Instance.sliderContainer);
            currentHpBar = tempHpBar.gameObject;
            sliderOfHpBar = tempHpBar.GetComponent<Slider>();
            sliderOfHpBar.maxValue = health;
        }
        sliderOfHpBar.value = health;
        sliderOfHpBar.fillRect.GetComponent<Image>().color = Color.Lerp(min, max, sliderOfHpBar.normalizedValue);
    }

    private void Update()
    {
        if (currentHpBar != null)
        {
            sliderOfHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offsetForTheBar);
        }
        
    }
}
