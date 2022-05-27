using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetController : MonoBehaviour
{



    public CircleChart circleChart;
    public CircleChartMulti circleChartMulti;
    public SliderChart sliderChart0;
    public SliderChart sliderChart1;
    public SliderChart sliderChart2;
    public SliderChartAdv sliderChartAdv;
    public TextRoll textRoll_OneByOne;
    public TextRoll textRoll_Both;


    private void Start()
    {
        InvokeRepeating("ToValue", 0.5f, 3f);
        InvokeRepeating("ToValue_Text", 0.5f, 5f);
    }


    bool sliderChartAdvBool = true;
    private void ToValue()
    {
        circleChart.ToValue(0.7f);

        circleChartMulti.ToValue(
            new CircleChartMultiData[] {
            new CircleChartMultiData(0.2f, Color.red) ,
            new CircleChartMultiData(0.1f, Color.yellow),
            new CircleChartMultiData(0.2f, Color.green),
            new CircleChartMultiData(0.3f, Color.cyan),
              new CircleChartMultiData(0.2f, Color.black)});

        sliderChart0.ToValue(Random.Range( 0.3f ,0.9f));
        sliderChart1.ToValue(Random.Range(0.3f, 0.9f) ,0f, false);
        sliderChart2.ToValue(Random.Range(0.3f, 0.9f)  , 1000f * Random.Range(0.3f, 0.9f), true , "Count");

        if (sliderChartAdvBool)
            sliderChartAdv.ToValue(0.8f);
        else
            sliderChartAdv.ToValue(0.3f);
        sliderChartAdvBool = !sliderChartAdvBool;


    }

    private void ToValue_Text()
    {
        textRoll_OneByOne.ToValue(258951);
        textRoll_Both.ToValue(465257, TextRoll.RollType.Both);
    }

}
