using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchOptionButton : MonoBehaviour
{
    [SerializeField] private MenuOption option;
    private Button switchButton;
    private void Awake()
    {
        switchButton = GetComponent<Button>();
        switchButton.onClick.AddListener(SwitchOption);
    }
    private void SwitchOption()
    {
        option.SwitchToThisOption();
    }
}
