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
        OneByOne,
        Both
    }

    public Text[] mTexts = new Text[] { };

    private void Awake()
    {
        mTexts = this.GetComponentsInChildren<Text>();
    }


    public void ToValue(int targetValue, RollType _rollType = RollType.OneByOne, Ease ease = Ease.InOutQuad, float duration = 0.4f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        for (int i = 0; i < mTexts.Length; i++)
        {
            mTexts[i].text = "0";
        }
        string tempValue = targetValue.ToString();
        int valueStrLength = tempValue.Length;
        if (valueStrLength != mTexts.Length)
        {
            Debug.LogError("Text's length is not enough");
            return;
        }

        switch (_rollType)
        {
            case RollType.OneByOne:

                Sequence tweenSequence = DOTween.Sequence();
                for (int i = valueStrLength - 1; i >= 0; i--)
                {
                    int index = i;
                    tweenSequence.Append(
                        DOTween.To(value => { mTexts[index].text = Mathf.Floor(value).ToString(); }, Random.Range(0f, 3f), Random.Range(7f, 10f), 0.08f).SetEase(Ease.InOutQuad).SetLoops(4, LoopType.Yoyo)
                        .OnComplete(() =>
                        {
                            DOTween.To(value => { mTexts[index].text = Mathf.Floor(value).ToString(); }, 0f, float.Parse(tempValue[index].ToString()), duration: duration).SetEase(ease);
                        }));
                }
                break;

            case RollType.Both:
                // random numbers
                for (int i = 0; i < valueStrLength; i++)
                {
                    int index = i;
                    if (index == valueStrLength - 1)
                    {
                        DOTween.To(value => { mTexts[index].text = Mathf.Floor(value).ToString(); }, Random.Range(0f, 3f), Random.Range(7f, 10f), 0.125f).SetEase(Ease.InOutQuad).SetLoops(10, LoopType.Yoyo).OnComplete(() =>
                        {
                            for (int j = 0; j < valueStrLength; j++)
                            {
                                int idx = j;
                                DOTween.To(value => { mTexts[idx].text = Mathf.Floor(value).ToString(); }, 0f, float.Parse(tempValue[idx].ToString()), duration: duration).SetEase(ease);
                            }
                        });
                    }
                    else
                    {
                        DOTween.To(value => { mTexts[index].text = Mathf.Floor(value).ToString(); }, Random.Range(0f, 3f), Random.Range(7f, 10f), 0.125f).SetEase(Ease.InOutQuad).SetLoops(10, LoopType.Yoyo);
                    }
                }
                break;
        }

    }

}
