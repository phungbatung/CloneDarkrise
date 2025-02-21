using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillNodeUnlockWindow : MonoBehaviour
{
    [SerializeField] private UI_SkillTree skillTreeUI;
    private SkillNode skillNode;
    [SerializeField] private Image frame;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI SkillNodeName;
    [SerializeField] private TextMeshProUGUI SkillNodeProperties;
    [SerializeField] private TextMeshProUGUI SkillNodeDescription;
    [SerializeField] private Button UnlockButton;
    [SerializeField] private Button CloseWindow;
    private void Awake()
    {
        UnlockButton.onClick.AddListener(UnlockCurrentNode);
        CloseWindow.onClick.AddListener(SwitchOffWindow);
    }
    public void SetupWindow(SkillNode node, SkillTreeBaseData data)
    {
        skillNode = node;
        SkillNodeName.text = skillNode.name;
        SkillNodeProperties.text = GetDescription();

        frame.sprite = data.frameBorder[skillNode.powerLevel];
        icon.sprite = data.data[skillNode.name].icon;
        if (skillNode.powerLevel == 0)
        {
            frame.transform.localScale = Vector3.one;
        }
        else if (skillNode.powerLevel == 1)
        {
            frame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (skillNode.powerLevel == 2)
        {
            frame.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        UnlockButton.gameObject.SetActive(!skillNode.unlocked);
        gameObject.SetActive(true);
        RefreshContentSize();
    }
    private string GetDescription()
    {
        string res = "";
        if (skillNode != null)
        {
            foreach(var kvp in skillNode.properties)
            {
                res += $"{kvp.Key} +{kvp.Value}\n";
            }
        }
        return res;
    }
    public void UnlockCurrentNode()
    {
        skillTreeUI.UnlockNode(skillNode);
        SwitchOffWindow();
    }
    private void RefreshContentSize()
    {
        IEnumerator Routine()
        {
            var csf1 = SkillNodeProperties.GetComponent<ContentSizeFitter>();
            var csf2 = SkillNodeDescription.GetComponent<ContentSizeFitter>();
            csf1.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            csf2.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            yield return null;
            csf1.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            csf2.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        StartCoroutine(Routine());
    }
    private void SwitchOffWindow()
    {
        gameObject.SetActive(false);
    }
}
