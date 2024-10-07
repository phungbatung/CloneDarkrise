using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionSlot : MonoBehaviour, IPointerDownHandler
{
    public int itemId { get; private set; }

    private float cooldown { get; set; }
    private float cooldownTimer;
    public bool isCoolDownCompleted { get; set; }

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textCoolDown;
    [SerializeField] private TextMeshProUGUI amount;
    private void Awake()
    {
        itemId = -1;
        isCoolDownCompleted = true;
        cooldownTimer = 0;
    }

    private void OnEnable()
    {
        UpdateUI();
    }
    private void Update()
    {
        if (!isCoolDownCompleted)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                isCoolDownCompleted = true;
                image.fillAmount = 1;
                textCoolDown.text = "";
                return;
            }
            image.fillAmount = (cooldown - cooldownTimer) / cooldown;
            textCoolDown.text = ((int)cooldownTimer).ToString();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isCoolDownCompleted && itemId != -1)
        {
            List<ItemInventory> potionSlots = ItemManager.Instance.GetListItemInventoroyById(itemId);
            if (potionSlots.Count > 0)
            {
                ItemManager.Instance.UsePotion(potionSlots[0]);
                UpdateUI();
            }
        }
    }

    public void AssignPotion(int _itemId)
    {
        itemId = _itemId;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (itemId != -1)
        {
            ItemData itemData= ItemManager.Instance.itemDict[itemId];
            image.sprite = itemData.icon;
            amount.text = ItemManager.Instance.GetTotalAmount(itemId).ToString();
            textCoolDown.text = cooldown<=0?"":cooldown.ToString();
        }
        else
        {
            image.sprite = null;
            amount.text = "";
        }    
    }

    public void ApplyCoolDown(float _cooldown)
    {
        cooldown = _cooldown;
        cooldownTimer = _cooldown;
        isCoolDownCompleted = false;
    }    

}
