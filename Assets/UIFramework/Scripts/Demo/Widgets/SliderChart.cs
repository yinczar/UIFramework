using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderChart : BaseChart
{
    public Text mText_Title;
    public Text mText_Value;
    private Slider mSlider;

    void Awake()
    {
        mSlider = this.GetComponent<Slider>();
    }

    public void ToValue(float targetValue, Ease ease = Ease.OutQuart, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        mSlider.value = 0f;
        targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);
        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(ease).OnComplete(() =>
        {
            completeCallback?.Invoke();
        });
    }


    public void ToValue(float targetValue, AnimationCurve animationCurve, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        mSlider.value = 0f;
        targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);
        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(animationCurve).OnComplete(() =>
        {
            completeCallback?.Invoke();
        });
    }


    public void ToValue(float targetValue, float count, bool showValue, string title = "", Ease ease = Ease.OutQuart, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        mSlider.value = 0f;
        mText_Title.text = title;                     //    you can customize Text's size by prefab 

        targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);

        if (showValue)
        DOTween.To(value => { mText_Value.text = Mathf.Floor(value).ToString(); }, 0f, count, duration).SetEase(Ease.Linear);
        else
            mText_Value.text = "";

        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(ease)
            .OnComplete(() =>
            {
                completeCallback?.Invoke();
            });
    }


}
