using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class CircleChart : BaseChart
{

    public Image image_B;
    public Image image_F;



    public void ToValue( float targetValue ,  Ease ease  = Ease.OutQuart,  float duration = 2f , UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        image_F.fillAmount = 0f;
       targetValue = Mathf.Clamp(targetValue, 0f, 1f);
        DOTween.To(() => image_F.fillAmount, x => image_F.fillAmount = x, targetValue, duration).SetEase(ease).OnComplete(()=> {
            completeCallback?.Invoke();
        });
    }


    public void ToValue(float startValue  , float targetValue, Ease ease = Ease.OutQuart, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        image_F.fillAmount =  startValue;
        targetValue = Mathf.Clamp(targetValue, 0f, 1f);
        DOTween.To(() => image_F.fillAmount, x => image_F.fillAmount = x, targetValue, duration).SetEase(ease).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }



    public void ToValue(float targetValue, AnimationCurve animationCurve, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        image_F.fillAmount = 0f;
        targetValue = Mathf.Clamp(targetValue, 0f, 1f);
        DOTween.To(() => image_F.fillAmount, x => image_F.fillAmount = x, targetValue, duration).SetEase(animationCurve).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }


    public void ToValue(float startValue ,float targetValue, AnimationCurve animationCurve, float duration = 2f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        image_F.fillAmount =  startValue;
        targetValue = Mathf.Clamp(targetValue, 0f, 1f);
        DOTween.To(() => image_F.fillAmount, x => image_F.fillAmount = x, targetValue, duration).SetEase(animationCurve).OnComplete(() => {
            completeCallback?.Invoke();
        });
    }

}
