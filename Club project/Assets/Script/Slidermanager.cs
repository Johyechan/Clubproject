using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidermanager : MonoBehaviour
{
    public static Slidermanager instance;
    public Slider slider1;
    private void Awake()
    {
        instance = this;
    }
    public void OnDamage(float value)
    {
        StartCoroutine(BackSlider(value));
    }
    IEnumerator BackSlider(float value)
    {

        while (true)
        {
            if (slider1.value <= (float)(value / 5))
            {
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
            slider1.value -= 1 * Time.deltaTime;
        }
        yield return null;
    }
}
