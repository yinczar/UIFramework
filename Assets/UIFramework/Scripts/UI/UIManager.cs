using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoSingleton<UIManager>
{


    #region Public  Variable



    #endregion

    #region Private  Variable
    List<BasePanel> basePanelList = new List<BasePanel>();

    #endregion


    #region LifeCycle   
    public override void Awake()
    {
        base.Awake();
        Init();
    }

    #endregion

    #region Private Function
    private void Init()
    {
        BasePanel[] basePanels = FindObjectsOfType<BasePanel>();
        foreach (var panel in basePanels)
        {
            basePanelList.Add(panel);
        }
    }

    #endregion



    #region Public Function

    /// <summary>    /// Get panel class    /// </summary>
    /// <typeparam name="T">  BasePanel child class  </typeparam>
    /// <returns> panel class </returns>
    public T GetPanel<T>() where T : BasePanel
    {
        foreach (var basePanel in basePanelList)
        {
            T component = basePanel.gameObject.GetComponent<T>();
            if (component != null)
                return component;
        }
        return default;
    }

    /// <summary>    /// Set panel visible    /// </summary>
    /// <typeparam name="T"> BasePanel child class  </typeparam>
    /// <param name="visible"></param>
    /// <param name="_callback_start"></param>
    /// <param name="_callback_completed"></param>
    public void SetPanelVisible<T>( bool visible, UnityAction _callback_start = null, UnityAction _callback_completed = null)  where T : BasePanel
    {
        GetPanel<T>().SetVisible(visible , _callback_start, _callback_completed);
    }

    /// <summary>    /// Switch panel    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="currentPanel"></param>
    /// <param name="targetPanel"></param>
    /// <param name="fadeOnTweenStart"></param>
    /// <param name="_callback_start"></param>
    /// <param name="_callback_completed"></param>
    public void SwitchPanel<T0, T1>( bool fadeOnTweenStart = true, UnityAction _callback_start = null, UnityAction _callback_completed = null) 
        where T0 : BasePanel 
        where T1 : BasePanel
    {
        GetPanel<T0>().SwitchToPanel(GetPanel<T1>(), fadeOnTweenStart, _callback_start, _callback_completed);
    }


    //public void ShowTips(   string contents , Canvas canvas = null)
    //{
    //    if (!canvas)
    //    {
    //        canvas = FindObjectOfType<Canvas>();
    //    }
    //  GameObject  tipsGO =     GameObjectPool.Instance.CreateObject("Tips", Resources.Load<GameObject>("UIFramework/Tips"), canvas.transform);
    //    tipsGO.GetComponentInChildren<Text>().text = contents;
    //}

    #endregion







}
