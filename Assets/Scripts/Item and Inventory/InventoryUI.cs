using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private ItemSlot[] itemSlots;
    public List<ItemInventory> inventoryItem => ItemManager.Instance.inventoryItems;
    private int currentPage;
    private int slotsPerPage =>itemSlots.Length;

    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    private bool isRightButtonActive;
    private bool isLeftButtonActive;
    private Animator rightAnim;
    private Animator leftAnim;
    [SerializeField] private TextMeshProUGUI pageCountTMP;


    [SerializeField] private Button sortButton;
    [SerializeField] private TMP_Dropdown sortDropdown;

    [SerializeField] private List<string> sortOptionList;
    private int sortOptionIndex;



    private void Awake()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
        rightButton.onClick.AddListener(RightButtonClick);
        leftButton.onClick.AddListener(LeftButtonClick);
        rightAnim = rightButton.GetComponent<Animator>();
        leftAnim = leftButton.GetComponent<Animator>();

        sortButton.onClick.AddListener(Sort);
        InitDropdown();
    }
    private void OnEnable()
    {
        currentPage = 1;
        if(inventoryItem!=null)
            UpdateInventoryUI();
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


    private void SetUpButton()
    {
        if (currentPage == 1)
        {
            isLeftButtonActive = false;
            isRightButtonActive = true;
        }
        else if (currentPage == getTotalPage())
        {
            isLeftButtonActive = true;
            isRightButtonActive = false;
        }
        else
        {
            isLeftButtonActive = true;
            isRightButtonActive = true;
        }
        if (getTotalPage() <= 1)
        {
            isLeftButtonActive = false;
            isRightButtonActive = false;
        }
        rightAnim.SetBool("active", isRightButtonActive);
        leftAnim.SetBool("active", isLeftButtonActive);
    }
    private void UpdateInventoryUI()
    {
        int slotCount = currentPage != getTotalPage()?slotsPerPage:(getInventorySize() - 24*(currentPage-1));

        for (int i = 0; i < slotsPerPage; i++)
        {
            if(i<slotCount)
                itemSlots[i].gameObject.SetActive(true);
            else
                itemSlots[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < slotCount; i++)
        {
            itemSlots[i].UpdateUI(inventoryItem[(currentPage-1)*24 + i]);
        }
        pageCountTMP.text = $"{currentPage}/{getTotalPage()}";
        SetUpButton();
    }
    private void RightButtonClick()
    {
        if (!isRightButtonActive)
            return;
        currentPage++;
        UpdateInventoryUI();
    }
    private void LeftButtonClick()
    {
        if (!isLeftButtonActive)
            return;
        currentPage--;
        UpdateInventoryUI();
    }
    private int getInventorySize() => ItemManager.Instance.inventorySize;
    private int getTotalPage() => Mathf.CeilToInt(ItemManager.Instance.inventorySize * 1.0f / 24);

    private void Sort()
    {
        if (sortOptionIndex == 0)
            SortByItemType();
        else if (sortOptionIndex == 1)
            SortByItemQuality();
        UpdateInventoryUI();
    }
    private void SortByItemType()
    {
        ItemManager.Instance.SortItemByItemType();
    }
    private void SortByItemQuality()
    {
        ItemManager.Instance.SortItemByItemQuality();
    }
    private void SelectSortOption()
    {
        sortOptionIndex = sortDropdown.value;
    }

}