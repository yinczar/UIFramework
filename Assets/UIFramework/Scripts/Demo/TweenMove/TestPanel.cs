using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel : MonoBehaviour
{
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.GetPanel<Panel_Center>().SetVisible(!UIManager.Instance.GetPanel<Panel_Center>().IsVisible());
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UIManager.Instance.GetPanel<Panel_Top>().SetVisible(!UIManager.Instance.GetPanel<Panel_Top>().IsVisible());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UIManager.Instance.GetPanel<Panel_Bottom>().SetVisible(!UIManager.Instance.GetPanel<Panel_Bottom>().IsVisible());
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UIManager.Instance.GetPanel<Panel_Left>().SetVisible(!UIManager.Instance.GetPanel<Panel_Left>().IsVisible());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UIManager.Instance.GetPanel<Panel_Right>().SetVisible(!UIManager.Instance.GetPanel<Panel_Right>().IsVisible());
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
          //  UIManager.Instance.ShowTips(" Hello World ");
        }
    }
#endif


}
