using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Left : BasePanel
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.SetVisible(!IsVisible());
        }
    }
}
