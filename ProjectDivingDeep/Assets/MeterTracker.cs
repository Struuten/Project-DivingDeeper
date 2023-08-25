using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeterTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meterText;
    [SerializeField] TextMeshProUGUI dieMeterText;
    [SerializeField] TextMeshProUGUI endMeterText;

    // Update is called once per frame
    void Update()
    {
        meterText.text = Mathf.Floor(transform.position.y) + "m";
        dieMeterText.text = Mathf.Floor(transform.position.y) + "m";
        endMeterText.text = Mathf.Floor(transform.position.y) + "m";
    }
}
