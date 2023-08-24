using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OxygenCountdown : MonoBehaviour
{
    [SerializeField] float oxygenTime;
    [SerializeField] TextMeshProUGUI oxygenText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OxygenDecrease();
    }

    private void OxygenDecrease()
    {
        oxygenTime -= Time.deltaTime;
        oxygenText.text = MathF.Ceiling(oxygenTime).ToString();
    }
}
