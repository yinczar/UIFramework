using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class SliderChartAdv : BaseChart
{
    public Slider mSlider_Front;
    public Slider mSlider_Back;
    public Image mBackFillImage;

    void Awake()
    {
        if (!mSlider_Back)
            mSlider_Back = this.GetComponent<Slider>();
        mSlider_Back.value = 0f;

        if (!mSlider_Front)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (!mSlider_Front && this.transform.GetChild(i).GetComponent<Slider>())
                    mSlider_Front = this.transform.GetChild(i).GetComponent<Slider>();
            }

            if (!mBackFillImage)
                mBackFillImage = mSlider_Back.fillRect.GetComponent<Image>();
            mBackFillImage.gameObject.SetActive(false);
        }
    }


    public void ToValue(float targetValue, Ease ease = Ease.OutQuart,  float frontDuration = 1f , float backDuration = 1.5f, UnityAction completeCallback = null)
    {
        if (targetValue > mSlider_Front.value)
        {
            //  increase
            DOTween.Kill(this);
            mSlider_Back.value = mSlider_Front.value;
            mBackFillImage.gameObject.SetActive(true);
            DOTween.To(() => mSlider_Back.value, x => mSlider_Back.value = x, targetValue, backDuration).SetEase(ease);
            DOTween.To(() => mSlider_Front.value, x => mSlider_Front.value = x, targetValue, frontDuration).SetDelay( backDuration/4f).SetEase(ease).OnComplete(() =>
            {
                mBackFillImage.gameObject.SetActive(false);
                completeCallback?.Invoke();
            });

        }
        else if (targetValue < mSlider_Front.value)
        {
            //  reduce
            DOTween.Kill(this);
            mSlider_Back.value = mSlider_Front.value;
            mBackFillImage.gameObject.SetActive(true);
            DOTween.To(() => mSlider_Front.value, x => mSlider_Front.value = x, targetValue, frontDuration).SetEase(ease).OnComplete(() =>
            {
                completeCallback?.Invoke();
            });
            DOTween.To(() => mSlider_Back.value, x => mSlider_Back.value = x, targetValue, backDuration).SetDelay(frontDuration/4f).SetEase(ease).OnComplete(() =>
            {
                mBackFillImage.gameObject.SetActive(false);
            });
        }
    }








}
