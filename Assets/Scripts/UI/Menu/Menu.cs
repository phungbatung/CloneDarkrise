using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private MenuOption optionParent;
    private List<MenuOption> optionsChild;
    [SerializeField] private MenuOption defaulOption;
    private void Awake()
    {
        optionParent = GetComponent<MenuOption>();
        GetComponentsInFirstDepthChildren();
    }
    private void Start()
    {
        SwitchTo(defaulOption);
    }
    private void GetComponentsInFirstDepthChildren()
    {
        optionsChild = new List<MenuOption>();
        for (int i=0; i < transform.childCount; i++)
        {
            MenuOption option = transform.GetChild(i).GetComponent<MenuOption>();
            if (option != null)
            {
                optionsChild.Add(option);
                option.SetMenu(this);
            }
        }

    }
    public void SwitchTo(MenuOption option)
    {
        if (optionParent!=null)
            optionParent.SwitchToThisOption();
        foreach (var _option in optionsChild)
        {
            _option.gameObject.SetActive(false);
        }
        option.gameObject.SetActive(true);
    }
}
