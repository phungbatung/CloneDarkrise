using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private List<MenuOption> options;
    [SerializeField] private MenuOption defaulOption;
    private void Awake()
    {
        GetComponentsInFirstDepthChildren();
    }
    private void Start()
    {
        SwitchTo(defaulOption);
    }
    private void GetComponentsInFirstDepthChildren()
    {
        options = new List<MenuOption>();
        for (int i=0; i < transform.childCount; i++)
        {
            MenuOption option = transform.GetChild(i).GetComponent<MenuOption>();
            if (option != null)
                options.Add(option);
        }

    }
    public void SwitchTo(MenuOption option)
    {
        foreach (var _option in options)
        {
            _option.gameObject.SetActive(false);
        }
        option.gameObject.SetActive(true);
    }
}
