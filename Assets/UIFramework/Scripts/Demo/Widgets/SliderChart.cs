using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderChart : BaseChart
{
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
        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(ease).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }

    public void ToValue(float startValue, float targetValue, Ease ease = Ease.OutQuart, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        mSlider.value = startValue;
        targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);
        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(ease).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }


    public void ToValue(float targetValue, AnimationCurve animationCurve, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        mSlider.value = 0f;
        targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);
        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(animationCurve).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }
    public void ToValue(float startValue, float targetValue, AnimationCurve animationCurve, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        mSlider.value = startValue;
        targetValue = Mathf.Clamp(targetValue, mSlider.minValue, mSlider.maxValue);
        DOTween.To(() => mSlider.value, x => mSlider.value = x, targetValue, duration).SetEase(animationCurve).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }
}
