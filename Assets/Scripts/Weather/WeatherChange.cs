using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherChange : MonoBehaviour
{
    [SerializeField] GameObject rainMaker;

    private void Start()
    {
        rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 1;
    }
}
