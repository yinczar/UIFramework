using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetController : MonoBehaviour
{



    public CircleChart circleChart;
    public SliderChart sliderChart;
    public SliderChartAdv sliderChartAdv;
    


    private void Start()
    {
        InvokeRepeating("ToValue", 0.5f , 3.5f );

    }


    bool sliderChartAdvBool = true;
    private void ToValue()
    {
        circleChart.ToValue(0.7f);
        sliderChart.ToValue(0.7f);

        if (sliderChartAdvBool)
            sliderChartAdv.ToValue(0.8f);
        else
            sliderChartAdv.ToValue(0.3f);
        sliderChartAdvBool = !sliderChartAdvBool;

    }

}
