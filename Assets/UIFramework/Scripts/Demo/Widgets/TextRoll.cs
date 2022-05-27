using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class TextRoll : BaseChart
{
    public enum RollType
    {
        OneByOne , 
        Both
    }

    public Text[] mTexts = new Text[] { };

    private void Awake()
    {
        mTexts = this.GetComponentsInChildren<Text>();
    }


    public void ToValue(int targetValue, RollType _rollType = RollType.OneByOne , Ease ease = Ease.OutQuart, float duration = 2f, UnityAction completeCallback = null)
    {

        //mText_UsedCount[3].text = (usedCount % 10000 / 1000).ToString(); ;
        //mText_UsedCount[2].text = (usedCount % 1000 / 100).ToString(); ;
        //mText_UsedCount[1].text = (usedCount % 100 / 10).ToString(); ;
        //mText_UsedCount[0].text = (usedCount % 10).ToString(); ;


        DOTween.Kill(this);
        //mSlider.value = 0f;
        //targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);
        //DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(ease).OnComplete(() => {
        //    completeCallback?.Invoke();
        //});
        switch (_rollType)
        {
            case RollType.OneByOne:

                Sequence tweenSequence = DOTween.Sequence();
                //tweenSequence.Append(DOTween.To(value => { mText_Total[0].text = Mathf.Floor(value).ToString(); }, startValue: 0f, endValue: totalHouse % 10, duration: 0.3f).SetEase(Ease.Linear));
                //tweenSequence.Append(DOTween.To(value => { mText_Total[1].text = Mathf.Floor(value).ToString(); }, startValue: 0f, endValue: totalHouse % 100 / 10, duration: 0.3f).SetEase(Ease.Linear));
                //tweenSequence.Append(DOTween.To(value => { mText_Total[2].text = Mathf.Floor(value).ToString(); }, startValue: 0f, endValue: totalHouse % 1000 / 100, duration: 0.3f).SetEase(Ease.Linear));
                //tweenSequence.Append(DOTween.To(value => { mText_Total[3].text = Mathf.Floor(value).ToString(); }, startValue: 0f, endValue: totalHouse % 10000 / 1000, duration: 0.3f).SetEase(Ease.Linear));
                //tweenSequence.Append(DOTween.To(value => { mText_Total[4].text = Mathf.Floor(value).ToString(); }, startValue: 0f, endValue: totalHouse / 10000, duration: 0.3f).SetEase(Ease.Linear));
                break;
            case RollType.Both:
                ////  房屋属性类型设置
                //for (int i = 0; i < mImage_Bars.Length; i++)
                //{
                //    int index = i;
                //    mImage_Bars[index].GetComponentInChildren<Text>().text = houseTypeCount[index].ToString() + "（" + ((float)houseTypeCount[index] / (float)totalHouse * 100f).ToString("f") + "%）";
                //    DOTween.To(value => { mImage_Bars[index].fillAmount = value; }, startValue: 0f, endValue: (float)houseTypeCount[index] / (float)totalHouse, duration: 1.2f);
                //}
                break;
        }

    }

}
