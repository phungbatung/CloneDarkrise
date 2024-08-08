using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPage : MonoBehaviour
{
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    private bool isRightButtonActive;
    private bool isLeftButtonActive;
    private Animator rightAnim;
    private Animator leftAnim;


    [SerializeField] private TextMeshProUGUI pageInfo;
    [SerializeField] private Transform pagesParent;
    private List<Page> pages;
    private int currentPage;


    private void Awake()
    {
        rightButton.onClick.AddListener(RightButtonClick);
        leftButton.onClick.AddListener(LeftButtonClick);
        rightAnim=rightButton.GetComponent<Animator>();
        leftAnim=leftButton.GetComponent<Animator>();
    }
    private void Start()
    {
        InitialPages();
        SetUpButton();
        UpdatePageInfo();
    }
    private void RightButtonClick()
    {
        if (!isRightButtonActive)
            return;
        pages[currentPage].gameObject.SetActive(false);
        currentPage++;
        pages[currentPage].gameObject.SetActive(true);
        SetUpButton();
        UpdatePageInfo();
    }   
    private void LeftButtonClick() 
    {
        if (!isLeftButtonActive) 
            return;
        pages[currentPage].gameObject.SetActive(false);
        currentPage--;
        pages[currentPage].gameObject.SetActive(true);
        SetUpButton();
        UpdatePageInfo();
    }
    private void SetUpButton()
    {
        if (currentPage == 0)
        {
            isLeftButtonActive = false;
            isRightButtonActive = true;
        }
        else if (currentPage == pages.Count - 1)
        {
            isLeftButtonActive=true;
            isRightButtonActive=false;
        }
        else
        {
            isLeftButtonActive = true;
            isRightButtonActive = true;
        }
        if (pages.Count <=1)
        {
            isLeftButtonActive = false;
            isRightButtonActive = false;
        }
        rightAnim.SetBool("active", isRightButtonActive);
        leftAnim.SetBool("active", isLeftButtonActive);
    }
    private void UpdatePageInfo()
    {
        pageInfo.text = $"{currentPage+1}/{pages.Count}";
    }
    private void InitialPages()
    {
        pages = pagesParent.GetComponentsInChildren<Page>().ToList();
        foreach (Page page in pages)
        {
            page.gameObject.SetActive(false);
        }
        pages[0].gameObject.SetActive(true);
        currentPage = 0;
        UpdatePageInfo();
    }
}
