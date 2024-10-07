using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatBuff : MonoBehaviour
{
    public int itemId { get; set; }
    private int buffType;
    [SerializeField] private Image buffIcon;
    [SerializeField] private TextMeshProUGUI buffTimerText;
    private float buffTimer;

    private void Update()
    {
        buffTimer -= Time.deltaTime;
        if (buffTimer < 0)
            EndBuff();
        else if (buffTimer < 60)
            buffTimerText.text = $"{buffTimer}sec";
        else
            buffTimerText.text = $"{Mathf.FloorToInt(buffTimer / 60)} min";
    }

    public void StartBuff(int _itemId, int _buffType)
    {
        itemId = _itemId;
        buffType = _buffType;
        PlayerManager.Instance.player.stats.AddModifier(ItemManager.Instance.itemDict[itemId].properties);
        buffTimer = float.Parse(ItemManager.Instance.itemDict[itemId].properties[ItemUtilities.COOLDOWN]);
        buffIcon.sprite = ItemManager.Instance.itemDict[itemId].icon;
    }

    public void EndBuff()
    {
        PlayerManager.Instance.player.stats.RemoveModifier(ItemManager.Instance.itemDict[itemId].properties);
        PlayerManager.Instance.player.stats.buffDict[buffType] = null;

        Destroy(gameObject);
    }
}
