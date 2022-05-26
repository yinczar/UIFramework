using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


/// <summary>///   Panel Base Class/// </summary>
public class BasePanel : MonoBehaviour
{
    #region Enum
    /// <summary>    ///   面板切换类型    /// </summary>
    public enum PanelSwitchType
    {
        CenterFade,
        Horizontal,
        Vertical,
    }

    #endregion

    #region Public Variable
    public bool showOnStart = false;
    public PanelSwitchType switchType = PanelSwitchType.CenterFade;
    public float fadeInTime = 0.5f;
    public float fadeOutTime = 0.5f;

    public float horizontalStartPointX = 0f;
    public float horizontalEndPointX = 0f;

    public float verticalStartPointY = 0f;
    public float verticalEndPointY = 0f;

    #endregion

    #region Private Variable
    private CanvasGroup canvasGroup;
    private bool isVisible;

    #endregion

    #region LifeCycle
    protected virtual void Start()
    {
        Init();
    }


    #endregion

    #region Public Functions
    /// <summary>    ///  设置面板显隐    /// </summary>
    public void SetVisible(bool _isVisible, PanelSwitchType _panelSwitchType = PanelSwitchType.CenterFade, UnityAction _callback_start = null, UnityAction _callback_completed = null)
    {
        if (!canvasGroup) { Debug.LogError("Component  CanvasGroup is null"); return; };

        if (_isVisible)
        {
            switch (switchType)
            {
                case PanelSwitchType.CenterFade:
                    CenterFadeIn(_callback_start, _callback_completed);
                    break;
                case PanelSwitchType.Horizontal:
                    HorizontalFadeIn(_callback_start, _callback_completed);
                    break;
                case PanelSwitchType.Vertical:
                    VerticalFadeIn(_callback_start, _callback_completed);
                    break;
            }
        }
        else
        {
            switch (switchType)
            {
                case PanelSwitchType.CenterFade:
                    CenterFadeOut(_callback_start, _callback_completed);
                    break;
                case PanelSwitchType.Horizontal:
                    HorizontalFadeOut(_callback_start, _callback_completed);
                    break;
                case PanelSwitchType.Vertical:
                    VerticalFadeOut(_callback_start, _callback_completed);
                    break;
            }
        }
    }

    /// <summary>    ///  返回面板显隐状态    /// </summary>
    /// <returns></returns>
    public bool IsVisible()
    {
        return isVisible;
    }

    #endregion

    #region Private Function


    private void Init()
    {
        //     You can custom CanvasGroup  By yourself
        if (!canvasGroup)
            canvasGroup = this.GetComponent<CanvasGroup>();
        if (!canvasGroup)
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();

   
        if (canvasGroup)
        {
            if (showOnStart)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                isVisible = true;
            }
            else
            {
                canvasGroup.alpha = 0f;
                canvasGroup.blocksRaycasts = false;
                isVisible = false;
            }
        }

        if (!canvasGroup) Debug.LogError("Component  CanvasGroup is null");
    }


    #endregion

    #region Dotween Animation
    private string tid_FadeIn = "PanelFadeIn";
    private void CenterFadeIn(UnityAction _callback_start, UnityAction _callback_completed)
    {
        canvasGroup.DOFade(1f, fadeInTime).SetEase(Ease.Linear).SetId(tid_FadeIn)
        .OnStart(() =>
        {
            canvasGroup.blocksRaycasts = false;
            isVisible = true;
            _callback_start?.Invoke();
        }).OnComplete(() =>
        {
            canvasGroup.blocksRaycasts = true;
            _callback_completed?.Invoke();
        });
    }

    private string tid_FadeOut = "PanelFadeOut";
    private void CenterFadeOut(UnityAction _callback_start, UnityAction _callback_completed)
    {
        canvasGroup.DOFade(0f, fadeOutTime).SetEase(Ease.Linear).SetId(tid_FadeOut)
        .OnStart(() =>
        {
            canvasGroup.blocksRaycasts = false;
            isVisible = false;
            _callback_start?.Invoke();
        }).OnComplete(() =>
        {
            _callback_completed?.Invoke();
        });
    }


    private string tid_HorizontalFadeIn = "HorizontalFadeIn";
    private void HorizontalFadeIn(UnityAction _callback_start, UnityAction _callback_completed)
    {
        canvasGroup.DOFade(1f, fadeInTime).SetEase(Ease.Linear).SetId(tid_HorizontalFadeIn)
       .OnStart(() =>
       {
           canvasGroup.blocksRaycasts = false;
           this.GetComponent<RectTransform>().DOAnchorPos3DX(horizontalEndPointX, fadeInTime).SetEase(Ease.Linear).SetId(tid_HorizontalFadeIn);
           isVisible = true;
           _callback_start?.Invoke();
       })
       .OnComplete(() =>
       {
           canvasGroup.blocksRaycasts = true;
           _callback_completed?.Invoke();
       });
    }



    private string tid_HorizontalFadeOut = "HorizontalFadeOut";
    private void HorizontalFadeOut(UnityAction _callback_start, UnityAction _callback_completed)
    {
        canvasGroup.DOFade(0f, fadeOutTime).SetEase(Ease.Linear).SetId(tid_HorizontalFadeOut)
        .OnStart(() =>
       {
           canvasGroup.blocksRaycasts = false;
           this.GetComponent<RectTransform>().DOAnchorPos3DX(horizontalStartPointX, fadeInTime).SetEase(Ease.Linear).SetId(tid_HorizontalFadeOut);
           isVisible = false;

           _callback_start?.Invoke();
       })
        .OnComplete(() =>
        {
            _callback_completed?.Invoke();
        });
    }


    private string tid_VerticalFadeIn = "VerticalFadeIn";
    private void VerticalFadeIn(UnityAction _callback_start, UnityAction _callback_completed)
    {
        canvasGroup.DOFade(1f, fadeInTime).SetEase(Ease.Linear).SetId(tid_VerticalFadeIn)
       .OnStart(() =>
       {
           canvasGroup.blocksRaycasts = false;
           this.GetComponent<RectTransform>().DOAnchorPos3DY(verticalEndPointY, fadeInTime).SetEase(Ease.Linear).SetId(tid_VerticalFadeIn);
           isVisible = true;
           _callback_start?.Invoke();
       })
       .OnComplete(() =>
       {
           canvasGroup.blocksRaycasts = true;
           _callback_completed?.Invoke();
       });
    }


    private string tid_VerticalFadeOut = "VerticalFadeOut";
    private void VerticalFadeOut(UnityAction _callback_start, UnityAction _callback_completed)
    {
        canvasGroup.DOFade(0f, fadeOutTime).SetEase(Ease.Linear).SetId(tid_VerticalFadeOut)
        .OnStart(() =>
        {
            canvasGroup.blocksRaycasts = false;
            this.GetComponent<RectTransform>().DOAnchorPos3DY(verticalStartPointY, fadeInTime).SetEase(Ease.Linear).SetId(tid_VerticalFadeOut);
            isVisible = false;
            _callback_start?.Invoke();
        })
        .OnComplete(() =>
        {
            _callback_completed?.Invoke();
        });
    }

    #endregion

}
