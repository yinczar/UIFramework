using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{

    bool switchbool = true; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (switchbool)
            {
                UIManager.Instance.SwitchPanel<Panel_Green, Panel_Red>();
            }
            else
            {
                UIManager.Instance.SwitchPanel<Panel_Red, Panel_Green>();
            }
            switchbool = !switchbool;
        }
    }






}
