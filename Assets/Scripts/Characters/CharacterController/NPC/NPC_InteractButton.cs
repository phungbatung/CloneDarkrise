using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC_InteractButton : MonoBehaviour, IPointerClickHandler
{
    private NPC npc;
    public void OnPointerClick(PointerEventData eventData)
    {
        npc.InteractAction(); 
    }
    public void SetNPC(NPC _npc)
    {
        npc = _npc;
    }
}
