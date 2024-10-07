using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    private Menu menu;
    public void SetMenu(Menu _menu)
    {
        menu = _menu;
    }
    public void SwitchToThisOption()
    {
        menu.SwitchTo(this);
    }    
}
