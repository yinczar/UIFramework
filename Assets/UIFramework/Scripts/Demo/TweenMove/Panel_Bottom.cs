using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Bottom : BasePanel
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.SetVisible(!IsVisible());
        }
    }


}
