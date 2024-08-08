using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SortItem : MonoBehaviour
{
    private Button sortButton;
    private TMP_Dropdown sortDropdown;

    [SerializeField] private List<string> sortOptionList ;
    private int sortOptionIndex;

    private void Awake()
    {
        sortButton = GetComponentInChildren<Button>();
        sortDropdown = GetComponentInChildren<TMP_Dropdown>();

        sortButton.onClick.AddListener(Sort);
        InitDropdown();
    }

    private void InitDropdown()
    {
        foreach (var sortOption in sortOptionList)
        {
            var option = new TMP_Dropdown.OptionData(sortOption);
            sortDropdown.options.Add(option);
        }
        sortDropdown.onValueChanged.AddListener(delegate { SelectSortOption(); });
    }
    private void Sort()
    {
        if (sortOptionIndex == 0)
            SortByItemType();
        else if (sortOptionIndex == 1)
            SortByItemQuality();
    }

    private void SortByItemType()
    {
        Inventory.Instance.SortItemByItemType(Inventory.Instance.inventorySlots);
    }
    private void SortByItemQuality()
    {
        Inventory.Instance.SortItemByItemQuality(Inventory.Instance.inventorySlots);
    }

    private void SelectSortOption()
    {
        sortOptionIndex = sortDropdown.value;
    }

}
