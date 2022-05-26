using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;

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

    public T GetPanel<T>()
    {
        foreach (var basePanel in basePanelList)
        {
            T component = basePanel.gameObject.GetComponent<T>();
            if (component != null)
                return component;
        }
        return default;
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
