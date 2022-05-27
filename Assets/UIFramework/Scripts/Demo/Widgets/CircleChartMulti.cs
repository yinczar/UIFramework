using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class CircleChartMultiData
{
    public float percent;
    public Color color;

    public CircleChartMultiData(float _percent, Color _color)
    {
        if (_percent < 0f)
            _percent = 0f;
        if (_percent > 1)
            _percent = 1f;
        percent = _percent;
        color = _color;
    }
}

public class CircleChartMulti : BaseChart
{

    public Image image_B;
    public Sprite fillSprite;

    List<Image> fillImageList = new List<Image>();
    float angle = 0f;

    public void ToValue(CircleChartMultiData[] circleChartMultiDatas, Ease ease = Ease.InOutQuad, float duration = 0.5f, UnityAction completeCallback = null)
    {
        DOTween.Kill(this);
        Reset();
        Sequence tweenSequence = DOTween.Sequence();
        for (int i = 0; i < circleChartMultiDatas.Length; i++)
        {
          int index = i; 
            Image image = CreateFill(circleChartMultiDatas[index].color);
            if (index == 0)
            {
                angle = 0f;
            }
            else
            {
                 angle -= 360f * circleChartMultiDatas[index-1].percent;
                image.transform.Rotate(Vector3.forward, angle);
            }
            tweenSequence.Append(DOTween.To(() => image.fillAmount, x => image.fillAmount = x, circleChartMultiDatas[index].percent, duration).SetEase(ease).OnComplete(() =>
            {
                completeCallback?.Invoke();
            })).SetEase(Ease.Linear);
        }
    }




    private Image CreateFill(Color color , string colorStr = "")
    {
        GameObject fillGO = new GameObject("Image_Fill_" + colorStr);
        RectTransform fillRectT = fillGO.AddComponent<RectTransform>();
        Image fillImage = fillGO.AddComponent<Image>();
        fillImageList.Add(fillImage);
        fillGO.transform.parent = this.transform;
        fillRectT.anchoredPosition = Vector2.zero;
        fillRectT.sizeDelta = new Vector2(image_B.GetComponent<RectTransform>().sizeDelta.x, image_B.GetComponent<RectTransform>().sizeDelta.y);

        fillImage.color = color;
        fillImage.sprite = fillSprite;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Radial360;
        fillImage.fillOrigin = 2;
        fillImage.fillAmount = 0f;
        fillImage.fillClockwise = true;
        return fillImage;
    }


    private void Reset()
    {
        DOTween.Kill(this);
        foreach (var fill in fillImageList)
        {
            DestroyImmediate(fill.gameObject);
        }
        fillImageList.Clear();
    }



}


