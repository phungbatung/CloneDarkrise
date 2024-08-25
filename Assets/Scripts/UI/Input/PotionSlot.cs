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

    private float cooldown;
    private float cooldownTimer;
    private bool isCoolDownCompleted;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textCoolDown;
    [SerializeField] private TextMeshProUGUI amount;
    private void Awake()
    {
        itemId = -1;
        isCoolDownCompleted = false;
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
            List<ItemSlot> potionSlots = Inventory.Instance.GetItemSlotById(itemId);
            if (potionSlots.Count > 0)
            Inventory.Instance.UsePotion(Inventory.Instance.GetItemSlotById(itemId)[0]);
            UpdateUI();
        }
    }

    public void AssignPotion(int _itemId)
    {
        itemId = _itemId;
    }

    public void UpdateUI()
    {
        if (itemId != -1)
        {
            ItemData itemData= Inventory.Instance.itemDict[itemId];
            image.sprite = itemData.icon;
            amount.text = Inventory.Instance.GetTotalAmount(itemId).ToString();
        }
        else
        {
            image.sprite = null;
            amount.text = "";
        }    
    }

}
